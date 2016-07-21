namespace TelerikCharts.Pages
{
    using ViewModel;
    using Xamarin.Forms;

    public partial class ReactiveLiveChartPage : ContentPage
    {
        public ReactiveLiveChartPage()
        {
            InitializeComponent();

            this.BindingContext = new ReactiveLiveChartViewModel();
        }
    }
}
