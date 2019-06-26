using SmartEvent.Model;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SmartEvent.Helpers;
using Xamarin.Forms;

namespace SmartEvent.ModelView
{
    public class LoginViewModel : BaseViewModel
    {

        #region Propiedades
        public UserModel Data { get; set; }
        private string _usuarioContraseña;
        private string _usuarioNombre;
        public string UsuarioNombre
        {
            get { return _usuarioNombre; }

            set
            {

                _usuarioNombre = value;
                OnPropertyChanged();

            }
        }
        public string UsuarioContraseña
        {
            get { return _usuarioContraseña; }
            set
            {
                _usuarioContraseña = value;

                OnPropertyChanged();
            }
        }
        #endregion

        #region Comandos
        private ICommand _registrarseCommand;
        private ICommand _logInCommand;
        public ICommand LogInCommand
        {
            get
            {
                return _logInCommand = _logInCommand ?? new DelegateCommand(VerificarLogIn);
            }

        }
        public ICommand RegistrarseCommand
        {
            get
            {
                return _registrarseCommand = _registrarseCommand ?? new DelegateCommand(RegistrarseClick);
            }
        }
        #endregion

        #region Metodos

        private async void VerificarLogIn()
        {
            if (!string.IsNullOrWhiteSpace(UsuarioNombre) && !string.IsNullOrWhiteSpace(UsuarioContraseña))
            {
                Data.Nombre = UsuarioNombre;
                Data.Password = UsuarioContraseña;

                //Esto es un diccionario pero solo sirve dentro de este objeto lamentablemente.
                Application.Current.Properties["LogVar"] = await restClient.SaveTodoItemAsync(Data,
                    Constantes.Constantes.URL_SERVICIOSAPI +
                    $"/Usuario/login?nombreUsuario={Data.Nombre}&Contraseña={Data.Password}");
                if ((bool)Application.Current.Properties["LogVar"])
                {
                    Cook.Logged = true;
                    MessagingCenter.Send(this, "Perfecto");
                }
            }
        }



        private void RegistrarseClick()
        {
            MessagingCenter.Send(this, "GoToRegistrarse");
        }


        #endregion

        public LoginViewModel()
        {
            Data = new UserModel();
        }

        public async override Task PostData()
        {
           await restClient.SaveTodoItemAsync(Data, Constantes.Constantes.URL_SERVICIOSAPI + $"/Usuario/login?nombreUsuario={Data.Nombre}&Contraseña={Data.Password}", true);
        }
    }
}
