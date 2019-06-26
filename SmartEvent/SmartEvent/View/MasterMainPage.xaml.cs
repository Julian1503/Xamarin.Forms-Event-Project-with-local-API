using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEvent.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterMainPage : MasterDetailPage
    {
        public MasterMainPage()
        {
            InitializeComponent();
        }

        public MainPageViewModel ViewModel { get; private set; }

        protected async override void OnAppearing()
        {
            ViewModel = new MainPageViewModel(Navigation);
            await ViewModel.LoadData();
            this.BindingContext = ViewModel;
            base.OnAppearing();
        }
    }
}