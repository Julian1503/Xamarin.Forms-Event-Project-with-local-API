using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEvent.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FechaEventoPage : ContentPage 
    {
        public FechaEventoPage()
        {
            InitializeComponent();
        }

        private void tpHoraHasta_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Time"))
            {
                lblError.IsVisible = tpHoraHasta.Time <= tpHoraDesde.Time;
            }
        }

        public FechaEventoPage(CreacionEventoViewModel viewModel):this()
        {
            BindingContext = viewModel;
            MessagingCenter.Subscribe<CreacionEventoViewModel>(this, "GoToUbicacion", async (a) =>
            {
                await Navigation.PushAsync(new UbicacionEventoPage(viewModel));
            });
        }

    }
}