using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEvent.Model;
using SmartEvent.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicacionEventoPage : ContentPage
    {
        private CreacionEventoViewModel viewModel;

        public UbicacionEventoPage()
        {
            InitializeComponent();
            MessagingCenter.Subscribe<CreacionEventoViewModel>(this,"GoToFinal", async (a) =>
                {
                    await Navigation.PushAsync(new FinEventoPage(viewModel));
                }
                );
        }
        protected async override void OnAppearing()
        {
            await viewModel.LoadData();
            base.OnAppearing();
        }
        public UbicacionEventoPage(CreacionEventoViewModel viewModel) :this()
        {
            BindingContext = viewModel;
            this.viewModel = viewModel;
            txtDireccion.Completed += ( sender,  e) => { txtCiudad.Focus(); };
            txtCiudad.Completed += ( sender,  e) => { txtProvincia.Focus(); };
            txtProvincia.Completed += ( sender,  e) => { txtCodigoPostal.Focus(); };
            txtCodigoPostal.Completed += ( sender,  e) => { pickerPais.Focus(); };
        }

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrWhiteSpace(txtCiudad.Text) && !string.IsNullOrWhiteSpace(txtProvincia.Text) && !string.IsNullOrWhiteSpace(txtDireccion.Text) && !string.IsNullOrWhiteSpace(txtCodigoPostal.Text) && pickerPais.SelectedItem!=null)
        //    {
        //        //viewModel.Data.Ubicacion.Direccion = txtDireccion.Text;
        //        //viewModel.Data.Ubicacion.Ciudad = txtCiudad.Text;
        //        //viewModel.Data.Ubicacion.CodigoPostal = txtCodigoPostal.Text;
        //        //viewModel.Data.Ubicacion.Provincia = txtProvincia.Text;
        //        //viewModel.Data.Ubicacion.PaisId = ((CountryModel)pickerPais.SelectedItem).Id;
        //        await Navigation.PushAsync(new FinEventoPage(viewModel));
        //    }
        //    else
        //    {
        //        await DisplayAlert("Alerta", "Faltan llenar campos", "Ok");
        //    }
        //}


    }
}