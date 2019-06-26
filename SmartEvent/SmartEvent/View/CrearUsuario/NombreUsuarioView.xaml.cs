using SmartEvent.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View.CrearUsuario
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NombreUsuarioView : ContentPage
    {
        public UsuarioViewModel viewModel { get; set; }
        public NombreUsuarioView()
        {
            InitializeComponent();
            viewModel = new UsuarioViewModel();
            BindingContext = viewModel;
            MessagingCenter.Subscribe<UsuarioViewModel>(this,"GoToContraseña", async (a) =>
                {
                    await Navigation.PushAsync(new ContraseñaUsuarioView(viewModel));
                });
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                await DisplayAlert("Alerta", "No debe ingresar campos vacios", "Ok");
            }
        }
    }
}