﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikCharts.ViewModel
{
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ReactiveLiveChartViewModel
    {
        public ReactiveLiveChartViewModel()
        {
            this.Random = new Random();
            this.DData = this.GetDateTimeData(200);

            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                this.UpdateData();
                return true;
            });
        }

        private int i = 201;
        private void UpdateData()
        {
            DData.RemoveAt(0);
            DData.Add(new DateTimeData()
            {
                Category = DateTime.Now.AddDays(i),
                Value = this.Random.Next(10, 90)
            });
            i++;
        }

        private ObservableCollection<DateTimeData> GetDateTimeData(int v)
        {
            var result = new ObservableCollection<DateTimeData>();

            for (int i = 0; i < v; i++)
            {
                result.Add(new DateTimeData() { Category = DateTime.Now.AddDays(i), Value = this.Random.Next(0, 100) });
            }

            return result;
        }

        private Random Random { get; set; }

        public ObservableCollection<DateTimeData> DData { get; set; }
    }
}
