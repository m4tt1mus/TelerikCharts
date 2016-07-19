using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TelerikCharts.Pages
{
    using ViewModel;

    public partial class TestPage2 : ContentPage
    {
        public TestPage2ViewModel _viewModel { get; set; }

        public TestPage2()
        {
            InitializeComponent();

            _viewModel = new TestPage2ViewModel();
            this.BindingContext = _viewModel;
        }
    }
}
