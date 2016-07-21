namespace TelerikCharts.Pages
{
    using ViewModel;
    using Xamarin.Forms;

    public partial class LiveChartExamplePage : ContentPage
    {
        public LiveChartExamplePage()
        {
            InitializeComponent();
            this.BindingContext = new LiveChartExampleViewModel();
        }
    }
}
