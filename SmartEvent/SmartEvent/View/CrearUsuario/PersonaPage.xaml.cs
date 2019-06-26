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
    public partial class PersonaPage : ContentPage
    {
        public PersonaPage()
        {
            InitializeComponent();

        }

        public PersonaPage(UsuarioViewModel viewModel) : this()
        {
            BindingContext = viewModel;

            txtNombre.Completed += (sender, e) => { txtApellido.Focus(); };
            txtApellido.Completed += (sender, e) => { txtApellidoCasada.Focus(); };
            txtApellidoCasada.Completed += (sender, e) => { txtEmail.Focus(); };
            txtEmail.Completed += (sender, e) => { txtDni.Focus(); };
            txtDni.Completed += (sender, e) => { txtTelefono.Focus(); };
            txtTelefono.Completed += (sender, e) => { txtCelular.Focus(); };
            MessagingCenter.Subscribe<UsuarioViewModel>(this,"GoToUbicacion", async (a) =>
                {
                    await Navigation.PushAsync(new UbicacionUsuarioPage(viewModel));
                });
        }

    }
}