using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Presentacion.Helpers;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace SmartEvent.ModelView
{
   public class AcreditacionViewModel : BaseViewModel
   {
       private string _cadenaDesencriptada;
        public void Acreditar(string cadena)
        {
            _cadenaDesencriptada = Encriptar.Base64Decode(cadena);
            
        }

        //private ICommand _buttonCommand;

        //public ICommand ButtonCommand
        //{
        //    get
        //    {
        //        //return _buttonCommand = _buttonCommand ?? new DelegateCommand(OnButtomCommand);
        //    }
        //}


        //private void OnButtomCommand()
        //{
        //    var options = new MobileBarcodeScanningOptions();
        //    options.PossibleFormats = new List<BarcodeFormat>
        //    {
        //        BarcodeFormat.QR_CODE
        //    };
        //    var page = new ZXingScannerPage(options) { Title = "Scanner" };
        //    var closeItem = new ToolbarItem { Text = "Close" };
        //    closeItem.Clicked += (object sender, EventArgs e) =>
        //    {
        //        page.IsScanning = false;
        //        Device.BeginInvokeOnMainThread(() =>
        //        {
        //            Application.Current.MainPage.Navigation.PopModalAsync();
        //        });
        //    };
        //    page.ToolbarItems.Add(closeItem);
        //    page.OnScanResult += (result) =>
        //    {
        //        page.IsScanning = false;

        //        Device.BeginInvokeOnMainThread(() => {
        //            Application.Current.MainPage.Navigation.PopModalAsync();
        //            if (string.IsNullOrEmpty(result.Text))
        //            {
        //                Resultado = "No valid code has been scanned";
        //            }
        //            else
        //            {
        //                Resultado = $"Result: {result.Text}";
        //            }
        //        });
        //    };
        //    Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(page) { BarTextColor = Color.White, BarBackgroundColor = Color.CadetBlue }, true);
        //}
    }
}

