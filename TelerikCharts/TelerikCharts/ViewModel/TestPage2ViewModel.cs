using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikCharts.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Reactive.Linq;
    using ReactiveUI;

    public class TestPage2ViewModel : ReactiveObject
    {
        private bool _genData;
        public bool GenData
        {
            get { return _genData; }
            set { this.RaiseAndSetIfChanged(ref _genData, value); }
        }

        public IReactiveCommand LoadPageCommand { get; set; }

        private Random _random { get; set; }

        private ObservableCollection<DataPoint> _dataPoints;
        public ObservableCollection<DataPoint> DataPoints
        {
            get { return _dataPoints; }
            set { this.RaiseAndSetIfChanged(ref _dataPoints, value); }
        }

        public void TestPage2()
        {
            _random = new Random();
            DataPoints = new ObservableCollection<DataPoint>();
            GenData = false;
            LoadPageCommand = ReactiveCommand.CreateAsyncTask(LoadPageCommandHandler, RxApp.TaskpoolScheduler);

            this.WhenAnyValue(x => x.GenData)
                .Where(x => x)
                .InvokeCommand(LoadPageCommand);
        }

        private async Task LoadPageCommandHandler(object arg)
        {
            await GenerateData();

            await Task.Run(() =>
            {
                SetupPolling();
            });
        }

        private async Task GenerateData()
        {
            var now = DateTime.Now;
            for (int i = 0; i < 200; i++)
            {
                DataPoints.Add(new DataPoint()
                {
                    Timestamp = now.AddSeconds(i * -10),
                    Value = _random.Next(1, 101)
                });
            }
        }

        private void SetupPolling()
        {
            var ticker = Observable.Timer(TimeSpan.FromSeconds(10));
            var sub = ticker.Subscribe(
            async (x) => await GetUpdate(),
            (error) =>
            {
            },
            () =>
            {
            });
        }

        private async Task GetUpdate()
        {

            DataPoints.RemoveAt(0);
            DataPoints.Add(new DataPoint()
            {
                Timestamp = DateTime.Now,
                Value = _random.Next(1, 101)
            });

            SetupPolling();
        }
    }

    public class DataPoint : ReactiveObject
    {
        private double _value;
        public double Value
        {
            get { return _value; }
            set { this.RaiseAndSetIfChanged(ref _value, value); }
        }

        private DateTime _timestamp;
        public DateTime Timestamp
        {
            get { return _timestamp; }
            set { this.RaiseAndSetIfChanged(ref _timestamp, value); }
        }
    }
}
