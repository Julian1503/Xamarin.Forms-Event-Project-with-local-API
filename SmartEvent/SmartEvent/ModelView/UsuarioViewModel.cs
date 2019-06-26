using SmartEvent.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartEvent.ModelView
{
    public class UsuarioViewModel : BaseViewModel
    {
        public UserModel Data { get; set; }


        #region NombrePage

        #region Propiedades

        private string _nombre;

        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Comandos
        private ICommand _nombreCommand;


        public ICommand NombreCommand
        {
            get => _nombreCommand = _nombreCommand ?? new DelegateCommand(NombreClick);
        }


        #endregion

        #region Metodos
        private void NombreClick()
        {
            //localhost:3000/api/Usuario/getpersona-nombreusuario-o-dni?nombreUsuario Falta revisar si existe otro usuario igual.
            if (string.IsNullOrWhiteSpace(Nombre))
            {
                Data.Nombre = Nombre;
                MessagingCenter.Send(this, "GoToContraseña");
            }
        }



        #endregion

        #endregion

        #region ContraPage

        #region Propiedades
        private string _rePassword;
        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        public string RePassword
        {
            get
            {
                return _rePassword;
            }
            set
            {
                _rePassword = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Comandos
        private ICommand _crearUsuarioCommand;


        public ICommand CrearUsuarioCommand
        {
            get
            {
                return _crearUsuarioCommand = _crearUsuarioCommand ?? new DelegateCommand(PasswordClick);
            }
        }



        #endregion

        #region Metodos

        private void PasswordClick()
        {
            if (Password == RePassword)
                MessagingCenter.Send(this, "Perfecto");

        }



        #endregion


        #endregion

        #region PersonaPage

        #region Propiedades

        private string _personaNombre;
        private string _personaApellido;
        private bool _personaAltaPorMostrador;
        private string _personaApellidoCasada;
        private string _personaCelular;
        private string _personaDni;
        private string _personaEmail;
        private string _personaTelefono;
        private bool _personaNombreError;
        private bool _personaCelularError;
        private bool _personaTelefonoError;
        private bool _personaDniError;
        private bool _personaEmailError;
        private bool _personaApellidoError;
        private ICommand _personaCommand;

        public bool PersonaNombreError
        {
            get
            {
                return _personaNombreError;
            }
            set
            {
                _personaNombreError = value;
                OnPropertyChanged();
            }
        }

        public bool PersonaCelularError
        {
            get
            {
                return _personaCelularError;
            }
            set
            {
                _personaCelularError = value;
                OnPropertyChanged();
            }
        }

        public bool PersonaTelefonoError
        {
            get
            {
                return _personaTelefonoError;
            }
            set
            {
                _personaTelefonoError = value;
                OnPropertyChanged();
            }
        }

        public bool PersonaDniError
        {
            get
            {
                return _personaDniError;
            }
            set
            {
                _personaDniError = value;
                OnPropertyChanged();
            }
        }

        public bool PersonaEmailError
        {
            get
            {
                return _personaEmailError;
            }
            set
            {
                _personaEmailError = value;
                OnPropertyChanged();
            }
        }

        public bool PersonaApellidoError
        {
            get
            {
                return _personaApellidoError;
            }
            set
            {
                _personaApellidoError = value;
                OnPropertyChanged();
            }
        }


        public string PersonaTelefono
        {
            get
            {
                return _personaTelefono;
            }
            set
            {
                _personaTelefono = value;
                OnPropertyChanged();
            }
        }

        public string PersonaEmail
        {
            get
            {
                return _personaEmail;
            }
            set
            {
                _personaEmail = value;
                OnPropertyChanged();
            }
        }

        public string PersonaDni
        {
            get
            {
                return _personaDni;
            }
            set
            {
                _personaDni = value;
                OnPropertyChanged();
            }
        }

        public string PersonaCelular
        {
            get
            {
                return _personaCelular;
            }
            set
            {
                _personaCelular = value;
                OnPropertyChanged();
            }
        }

        public string PersonaApellidoCasada
        {
            get
            {
                return _personaApellidoCasada;
            }
            set
            {
                _personaApellidoCasada = value;
                OnPropertyChanged();
            }
        }

        public bool PersonaAltaPorMostrador
        {
            get
            {
                return _personaAltaPorMostrador;
            }
            set
            {
                _personaAltaPorMostrador = value;
                OnPropertyChanged();
            }
        }

        public string PersonaApellido
        {
            get
            {
                return _personaApellido;
            }
            set
            {
                _personaApellido = value;
                OnPropertyChanged();
            }
        }

        public string PersonaNombre
        {
            get
            {
                return _personaNombre;
            }
            set
            {
                _personaNombre = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Comando

        public ICommand PersonaCommand
        {
            get
            {
                return _personaCommand = _personaCommand ?? new DelegateCommand(NextPageClick);
            }
        }


        #endregion

        #region Metodos

        private void NextPageClick()
        {
            PersonaNombreError = string.IsNullOrWhiteSpace(PersonaNombre);
            PersonaApellidoError = string.IsNullOrWhiteSpace(PersonaApellido);
            PersonaDniError = string.IsNullOrWhiteSpace(PersonaDni);
            PersonaCelularError = string.IsNullOrWhiteSpace(PersonaCelular);
            PersonaTelefonoError = string.IsNullOrWhiteSpace(PersonaTelefono);
            PersonaEmailError = string.IsNullOrWhiteSpace(PersonaEmail);
            if (!PersonaEmailError || !PersonaTelefonoError || !PersonaCelularError || !PersonaDniError || !PersonaApellidoError || PersonaNombreError)
            {
                MessagingCenter.Send(this, "GoToUbicacion");
            }
        }


        #endregion

        #endregion

        #region UbicacionPage

        #region Propiedades
        private string _direccion;
        private string _direccionCiudad;
        private string _direccionCodigoPostal;
        private string _direccionProvincia;
        private bool _direccionError;
        private bool _ciudadError;
        private bool _provinciaError;
        private bool _paisError;
        private bool _codigoPostalError;
        private CountryModel _paisSeleccionado;
        private ObservableCollection<CountryModel> _paises;


        public ObservableCollection<CountryModel> Paises
        {
            get
            {
                return _paises;
            }
            private set { _paises = value; OnPropertyChanged(); }
        }
        public CountryModel PaisSeleccionado
        {
            get
            {
                return _paisSeleccionado;
            }
            set
            {
                _paisSeleccionado = value;
                OnPropertyChanged();
            }
        }

        public string DireccionProvincia
        {
            get
            {
                return _direccionProvincia;
            }
            set
            {
                _direccionProvincia = value;
                OnPropertyChanged();
            }
        }

        public string DireccionCodigoPostal
        {
            get
            {
                return _direccionCodigoPostal;
            }
            set
            {
                _direccionCodigoPostal = value;
                OnPropertyChanged();
            }
        }

        public string DireccionCiudad
        {
            get
            {
                return _direccionCiudad;
            }
            set
            {
                _direccionCiudad = value;
                OnPropertyChanged();
            }
        }

        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
                OnPropertyChanged();
            }
        }

        public bool DireccionError
        {
            get
            {
                return _direccionError;
            }
            set
            {
                _direccionError = value;
                OnPropertyChanged();
            }
        }

        public bool CiudadError
        {
            get
            {
                return _ciudadError;
            }
            set
            {
                _ciudadError = value;
                OnPropertyChanged();
            }
        }

        public bool ProvinciaError
        {
            get
            {
                return _provinciaError;
            }
            set
            {
                _provinciaError = value;
                OnPropertyChanged();
            }
        }

        public bool PaisError
        {
            get
            {
                return _paisError;
            }
            set
            {
                _paisError = value;
                OnPropertyChanged();
            }
        }

        public bool CodigoPostalError
        {
            get
            {
                return _codigoPostalError;
            }
            set
            {
                _codigoPostalError = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Metodos

        private async void CrearClick()
        {
            DireccionError = string.IsNullOrWhiteSpace(Direccion);
            CiudadError= string.IsNullOrWhiteSpace(DireccionCiudad);
            CodigoPostalError = string.IsNullOrWhiteSpace(DireccionCodigoPostal);
            ProvinciaError = string.IsNullOrWhiteSpace(DireccionProvincia);
            PaisError = PaisSeleccionado==null;
            if (PaisError || DireccionError || CiudadError || CodigoPostalError || ProvinciaError)
                return;
            Data.Nombre = Nombre;
            Data.Password = Password;
            Data.EstaBorrado = false;
            Data.Persona = new PersonaModel
            {
                Id = 0,
                Nombre = PersonaNombre,
                Apellido = PersonaApellido,
                AltaPorMostrador = PersonaAltaPorMostrador,
                ApellidoCasada = PersonaApellidoCasada,
                Celular = PersonaCelular,
                Dni = PersonaDni,
                Email = PersonaEmail,
                EstaBorrado = false,
                Telefono = PersonaTelefono,
                Direccion = new UbicationModel
                {
                    Direccion = Direccion,
                    Ciudad = DireccionCiudad,
                    CodigoPostal = DireccionCodigoPostal,
                    Provincia = DireccionProvincia,
                    EstaBorrado = false,
                    PaisId = PaisSeleccionado.Id,
                    Id = 0
                }

            };
            var exito = await restClient.SaveTodoItemAsync(Data, Constantes.Constantes.URL_SERVICIOSAPI + "/Usuario/crear");
            if (exito)
            {
                MessagingCenter.Send(this, "Creado");
            }

        }


        #endregion

        #region Comandos

        private ICommand _finCommand;
       

        public ICommand FinCommand
        {
            get => _finCommand = _finCommand ?? new DelegateCommand(CrearClick);
        }

        #endregion
        #endregion

        public UsuarioViewModel()
        {
            Data = new UserModel();
            Paises = new ObservableCollection<CountryModel>();
        }

        public override async Task LoadData()
        {
            Paises = new ObservableCollection<CountryModel>(await restClient.GetData<CountryModel[]>(Constantes.Constantes.URL_SERVICIOSAPI + "/Pais/obtener"));
        }

        public async override Task PostData()
        {
            await restClient.SaveTodoItemAsync(Data, Constantes.Constantes.URL_SERVICIOSAPI + "/Usuario/crear", true);

        }
    }
}
