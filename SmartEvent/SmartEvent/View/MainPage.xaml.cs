using System;
using System.Collections.Generic;
using System.Windows.Input;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace SmartEvent
{
    using System.ComponentModel;
    using System.Threading.Tasks;
    using SmartEvent.Converter;
    using SmartEvent.ModelView;
    using SmartEvent.View;
    using Xamarin.Forms;
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }
        public MainPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            ViewModel = new MainPageViewModel(Navigation);
            await ViewModel.LoadData();
            this.BindingContext = ViewModel;
            base.OnAppearing();
        }

        private async void ViewCell_Appearing(object sender, System.EventArgs e)
        {
            var cell = sender as ViewCell;
            var view = cell.View;
            view.Opacity = 0.5;
            await Task.WhenAny<bool>(
                view.FadeTo(1, 500, Easing.CubicInOut)
            );
        }


     
    }
}
