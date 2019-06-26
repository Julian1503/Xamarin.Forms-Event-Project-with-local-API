using System;
using System.Collections.Generic;
using System.Net;
using Plugin.Media;
using SmartEvent.ModelView;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinEventoPage : ContentPage
    {
        public FinEventoPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<CreacionEventoViewModel>(this, "Exito", async (a) =>
            {
                await DisplayAlert("Alert", "Exito en carga de datos", "Ok");
                await Navigation.PopToRootAsync();
            });
        }
        protected override void OnAppearing()
        {
            pickerTipoEntrada.ItemsSource = new List<string> { "Gratuita", "Paga" };
            base.OnAppearing();
        }
        public FinEventoPage(CreacionEventoViewModel viewModel) :this()
        {
            BindingContext = viewModel;
            pickerTemaEvento.SelectedIndexChanged += (sender,e) => { txtNombre.Focus();};
            txtNombre.Completed += (sender,e) => { pickerTipoEntrada.Focus(); };
            txtCantidad.Completed += (sender,e) => { txtPrecio.Focus(); };
        }

        //No va esto...

        //private async void Button_Clicked(object sender, EventArgs e)
        //{
        //    if(pickerTemaEvento.SelectedItem!=null && pickerTipoEntrada.SelectedItem != null && pickerTipoEvento.SelectedItem != null)
        //    {
        //        viewModel.Data.EsPaginaPublica = switchEventoPublico.IsToggled;
        //        viewModel.Data.EstaBorrado = false;
        //        viewModel.Data.Entrada.Nombre = txtNombre.Text;
        //        viewModel.Data.Entrada.Precio = int.Parse(txtPrecio.Text);
        //        viewModel.Data.Entrada.CantidadDisponible = int.Parse(txtCantidad.Text);
        //        viewModel.Data.MostrarLasEntradasRestantes = switchEntradas.IsToggled;
        //        viewModel.Data.Entrada.TipoEntrada = pickerTipoEntrada.SelectedIndex == 0 ? TipoEntrada.Gratuita : TipoEntrada.Paga;
        //        viewModel.Data.TipoEventoId = ((TypeEventModel)pickerTipoEvento.SelectedItem).Id;
        //        viewModel.Data.TemaEventoId = ((EventThemeModel)pickerTemaEvento.SelectedItem).Id;
        //        viewModel.Data.Id = 0;
        //        viewModel.Data.Organizador = "El Brayan";
        //        viewModel.Data.Path = "Playa.jpg";
        //        viewModel.Data.FileName = "Playa.jpg";
        //        await viewModel.PostData();
        //        await DisplayAlert("Exito", "Se creo el evento exitosamente", "Ok");
        //        await Navigation.PopToRootAsync();
        //    }
        //    else
        //    {
        //        await DisplayAlert("Alerta", "Faltan llenar campos", "Ok");
        //    }
        //}

        private void PickerTipoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pickerTipoEntrada.SelectedIndex == 0)
            {
                txtPrecio.Text = "0";
                txtPrecio.IsEnabled = false;
            }
            else
            {
                txtPrecio.IsEnabled = true;
            }
        }
        private async void Take_Photo(object sender, EventArgs e)
        {
            await CrossMedia.Current.Initialize();
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Fallo", "Eleccion de foto no soportada", "Ok");
                return;
            }

            var _mediaFile = await CrossMedia.Current.PickPhotoAsync();
            if (_mediaFile == null)
                return;
            txtImagen.Text = _mediaFile.Path;
            ImageSource.FromStream((() => { return _mediaFile.GetStream(); })); // 
        }
        private void Button_OnClicked(object sender, EventArgs e)
        {
           Take_Photo(sender,e);
        }
    }
}