using SmartEvent.ModelView;
using System;
using System.Net;
using SmartEvent.Helpers;
using SmartEvent.View.CrearUsuario;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel ViewModel;
        public LoginPage()
        {
            InitializeComponent();
            ViewModel = new LoginViewModel();
            BindingContext = ViewModel;
            MessagingCenter.Subscribe<LoginViewModel>(this, "Perfecto", async (a) =>
            {
                await DisplayAlert("POST", "Todo salio bien", "Ok");
                await Navigation.PopToRootAsync();
            });
            MessagingCenter.Subscribe<LoginViewModel>(this, "GoToRegistrarse", async (a) =>
            {
                await Navigation.PushAsync(new NombreUsuarioView());
            });
            txtNombre.Completed += (object sender, EventArgs e) =>
            {
                txtContrasenia.Focus();
            };
        }

        
    }

}
