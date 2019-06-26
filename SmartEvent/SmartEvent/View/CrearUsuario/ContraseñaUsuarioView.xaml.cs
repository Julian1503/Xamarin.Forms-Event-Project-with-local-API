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
    public partial class ContraseñaUsuarioView : ContentPage
    {
        public ContraseñaUsuarioView()
        {
            InitializeComponent();
           
        }

        public ContraseñaUsuarioView(UsuarioViewModel viewModel):this()
        {
            BindingContext = viewModel;
            MessagingCenter.Subscribe<UsuarioViewModel>(this, "Perfecto", async (a) =>
            {
                await Navigation.PushAsync(new PersonaPage(viewModel));
            });
            txtContrasenia.Completed += (sender, e) => { txtReContrasenia.Focus();};
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContrasenia.Text))
            {
                await DisplayAlert("Alerta", "No debe enviar campos vacios", "Ok");
                return;
            }

            if (!txtContrasenia.Text.Equals(txtReContrasenia.Text))
            
            {
                await DisplayAlert("Alerta", "Las claves deben coincidir", "Ok");
            }
        }
    }
}