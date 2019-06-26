using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentacion.Helpers;
using SmartEvent.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AcreditacionPage
    {
        private AcreditacionViewModel view;

        public AcreditacionPage()
        {
            InitializeComponent();
            view = new AcreditacionViewModel();
        }

        private void AcreditacionPage_OnOnScanResult(Result result)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await DisplayAlert("Scanned result", result.Text, "OK");
            });
            this.IsAnalyzing = false;
            view.Acreditar(result.Text);
        }
    }
}