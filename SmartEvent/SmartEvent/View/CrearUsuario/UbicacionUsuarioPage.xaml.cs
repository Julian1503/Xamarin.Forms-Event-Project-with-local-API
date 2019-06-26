using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEvent.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View.CrearUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UbicacionUsuarioPage : ContentPage
    {
        private UsuarioViewModel viewModel;

        public UbicacionUsuarioPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            BindingContext = this.viewModel;
            await viewModel.LoadData();
            base.OnAppearing();
        }

        public UbicacionUsuarioPage(UsuarioViewModel viewModel):this()
        {
            this.viewModel = viewModel;
            txtDireccion.Completed += (sender, e) => { txtCiudad.Focus(); };
            txtCiudad.Completed += (sender, e) => { txtProvincia.Focus(); };
            txtProvincia.Completed += (sender, e) => { txtCodigoPostal.Focus(); };
            txtCodigoPostal.Completed += (sender, e) => { pickerPais.Focus(); };
            MessagingCenter.Subscribe<UsuarioViewModel>(this, "Creado", async (a) =>
            {
                    await DisplayAlert("Post", "El usuario fue creado", "Ok");
                    await Navigation.PopToRootAsync();
                });
        }
    }
}