using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TelerikCharts
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();

            this.BindingContext = this.GetSource(5, 4);
        }

        private List<List<Data>> GetSource(int seriesCount, int dataPointsCount)
        {
            return new List<List<Data>>(Enumerable.Range(0, seriesCount).Select(s => this.GetData(dataPointsCount)));
        }

        private List<Data> GetData(int dataPointsCount)
        {
            return new List<Data>(Enumerable.Range(0, dataPointsCount).Select(p => new Data { Value = p, Category = "a" + p }));
        }
    }

    public class CustomListView : ListView
    {
        protected override void SetupContent(Cell content, int index)
        {
            base.SetupContent(content, index);

            var currentViewCell = content as ViewCell;
            if (currentViewCell != null)
            {
                currentViewCell.View.BackgroundColor = index % 2 == 0 ? Color.FromHex("e1e1e1") : Color.White;
            }
        }
    }

    public class Data
    {
        public int Value { get; set; }
        public string Category { get; set; }
    }
}
