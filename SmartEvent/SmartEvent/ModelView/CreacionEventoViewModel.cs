using SmartEvent.Model;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Media;
using Xamarin.Forms;

namespace SmartEvent.ModelView
{
    public class CreacionEventoViewModel : BaseViewModel
    {
        public EventModel Event { get; set; }


        #region PantallaNombre

        #region Propiedades
        private string _nombre;
        private bool _nombreEventoError;

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
        public bool NombreEventoError
        {
            get
            {
                return _nombreEventoError;
            }
            set
            {
                _nombreEventoError = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Comandos

        private ICommand _nombreCommand;

        public ICommand NombreCommand
        {
            get => _nombreCommand = _nombreCommand ?? new DelegateCommand(btnNombreClick);
        }

        #endregion

        #region Metodos
        private void btnNombreClick()
        {
            if (!string.IsNullOrWhiteSpace(Nombre))
            {
                Event.Nombre = Nombre;
                NombreEventoError = false;
                MessagingCenter.Send(this, "GoToDescripcion");
            }
            else
            {
                NombreEventoError = true;
            }
        }



        #endregion

        #endregion

        #region PantallaDescripcion

        #region Propiedades

        private string _descripcion;

        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
                OnPropertyChanged();
            }
        }


        #endregion

        #region Comandos

        private ICommand _descripcionCommand;

        public ICommand DescripcionCommand
        {
            get => _descripcionCommand = _descripcionCommand ?? new DelegateCommand(btnDescripcionClick);

        }

        #endregion

        #region Metodos

        private void btnDescripcionClick()
        {
            Event.Descripcion = string.IsNullOrEmpty(Descripcion) ? "" : Descripcion;
            MessagingCenter.Send(this, "GoToFecha");
        }

        #endregion

        #endregion

        #region PantallaFecha

        #region Propiedades
        private DateTime _fechaDesde;
        private DateTime _fechaHasta;
        private TimeSpan _horaDesde;
        private TimeSpan _horaHasta = new TimeSpan(12, 01, 00);
        public DateTime FechaDesde
        {
            get => _fechaDesde;
            set => _fechaDesde = value;
        }

        public DateTime FechaHasta
        {
            get { return _fechaHasta; }
            set
            {
                _fechaHasta = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan HoraDesde
        {
            get
            {
                return _horaDesde;
            }
            set
            {
                _horaDesde = value;
                OnPropertyChanged();
            }
        }

        public TimeSpan HoraHasta
        {
            get
            {
                return _horaHasta;
            }
            set
            {
                _horaHasta = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Comandos

        private ICommand _fechaCommand;
        public ICommand FechaCommand
        {
            get => _fechaCommand = _fechaCommand ?? new DelegateCommand(btnFechaClick);
        }


        #endregion

        #region Metodos

        private void btnFechaClick()
        {
            if (HoraDesde < HoraHasta)
            {
                Event.Programacion = new ProgramationModel
                {
                    HoraSalida = String.Format("{0}:{1}", HoraHasta.Hours.ToString("00"), HoraHasta.Minutes.ToString("00")),
                    HoraEntrada = String.Format("{0}:{1}", HoraDesde.Hours.ToString("00"), HoraDesde.Minutes.ToString("00")),
                    FechaHasta = FechaHasta,
                    FechaDesde = FechaDesde,
                    EstaBorrado = false,
                    EventoId = Event.Id
                };
                MessagingCenter.Send(this, "GoToUbicacion");
            }
        }



        #endregion

        #endregion

        #region PantallaUbicacion

        #region Propiedades

        public ObservableCollection<CountryModel> Paises
        {
            get
            {
                return _paises;
            }
            private set
            {
                _paises = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<CountryModel> _paises;
        private string _ciudad;
        private string _provincia;
        private CountryModel _paisSeleccionado;
        private string _codigoPostal;
        private string _direccion;
        private bool _direccionError;
        private bool _provinciaError;
        private bool _ciudadError;
        private bool _codigoPostalError;
        private bool _paisError;


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
        public string Ciudad
        {
            get
            {
                return _ciudad;
            }
            set
            {
                _ciudad = value;
                OnPropertyChanged();
            }
        }
        public string Provincia
        {
            get
            {
                return _provincia;
            }
            set
            {
                _provincia = value;
                OnPropertyChanged();
            }
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
        public string CodigoPostal
        {
            get
            {
                return _codigoPostal;
            }
            set
            {
                _codigoPostal = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Comandos
        private ICommand _ubicacionCommand;

        public ICommand UbicacionCommand
        {
            get => _ubicacionCommand = _ubicacionCommand ?? new DelegateCommand(UbicacionClick);

        }

        #endregion

        #region Metodos
        private void UbicacionClick()
        {
            DireccionError = string.IsNullOrWhiteSpace(Direccion);
            CiudadError = string.IsNullOrWhiteSpace(Ciudad);
            ProvinciaError = string.IsNullOrWhiteSpace(Provincia);
            CodigoPostalError = string.IsNullOrWhiteSpace(CodigoPostal);
            PaisError = PaisSeleccionado == null;
            if (DireccionError || CiudadError || ProvinciaError || CodigoPostalError || PaisError)
                return;

            Event.Ubicacion = new UbicationModel
            {
                Direccion = Direccion,
                Ciudad = Ciudad,
                CodigoPostal = CodigoPostal,
                PaisId = PaisSeleccionado.Id,
                Provincia = Provincia,
                EstaBorrado = false
            };
            MessagingCenter.Send(this, "GoToFinal");
        }
        #endregion

        #endregion

        #region PantallaFinal

        #region Propiedades
        private string _nombreEntrada;
        private int _numeroEntradas;
        private decimal _precioEntradas;
        private bool _pickerTemaError;
        private bool _pickerTipoError;
        private bool _pickerTipoEntradaError;
        private bool _textNombreEntradaError;
        private bool _organizadorError;
        private TypeEventModel _tipoEventoSeleccionado;
        private EventThemeModel _temaEventoSeleccionado;
        private int? _tipoEntradaSeleccionado;
        private bool _mostrarEntradasRestantes = true;
        private bool _esPaginaPublica = true;
        private ObservableCollection<EventThemeModel> _temaEvento;
        private ObservableCollection<TypeEventModel> _tipoEvento;
        private string _path;
        private string _fileName;
        private string _organizador;

        public bool OrganizadorError
        {
            get
            {
                return _organizadorError;
            }
            set
            {
                _organizadorError = value;
                OnPropertyChanged();
            }
        }
        public string Organizador
        {
            get
            {
                return _organizador;
            }
            set
            {
                _organizador = value;
                OnPropertyChanged();
            }
        }
        public string Path
        {
            get
            {
                return _path;

            }
            set
            {
                _path = value;
                OnPropertyChanged();
            }
        }
        public string FileName
        {
            get
            {
                return _fileName ;

            }
            set
            {
                _fileName = System.IO.Path.GetFileName(Path);
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TypeEventModel> TipoEvento
        {
            get
            {
                return _tipoEvento;
            }
            private set
            {
                _tipoEvento = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<EventThemeModel> TemaEvento
        {
            get
            {
                return _temaEvento;
            }
            private set
            {
                _temaEvento = value;
                OnPropertyChanged();
            }
        }
        public TypeEventModel TipoEventoSeleccionado
        {
            get
            {
                return _tipoEventoSeleccionado;
            }
            set
            {
                _tipoEventoSeleccionado = value;
                OnPropertyChanged();
            }
        }
        public EventThemeModel TemaEventoSeleccionado
        {
            get
            {
                return _temaEventoSeleccionado;
            }
            set
            {
                _temaEventoSeleccionado = value;
                OnPropertyChanged();
            }
        }
        public int? TipoEntradaSeleccionado
        {
            get
            {
                return _tipoEntradaSeleccionado;
            }
            set
            {
                _tipoEntradaSeleccionado = value;
                OnPropertyChanged();
            }
        }
        public string NombreEntrada
        {
            get
            {
                return _nombreEntrada;
            }
            set
            {
                _nombreEntrada = value;
                OnPropertyChanged();
            }
        }
        public int NumeroEntradas
        {
            get
            {
                return _numeroEntradas;
            }
            set
            {
                _numeroEntradas = value;
                OnPropertyChanged();
            }
        }
        public decimal PrecioEntradas
        {
            get
            {
                return _precioEntradas;
            }
            set
            {
                _precioEntradas = value;
                OnPropertyChanged();
            }
        }
        public bool MostrarEntradasRestantes
        {
            get
            {
                return _mostrarEntradasRestantes;
            }
            set
            {
                _mostrarEntradasRestantes = value;
                OnPropertyChanged();
            }
        }
        public bool EsPaginaPublica
        {
            get
            {
                return _esPaginaPublica;
            }
            set
            {
                _esPaginaPublica = value;
                OnPropertyChanged();
            }
        }
        public bool PickerTemaError
        {
            get
            {
                return _pickerTemaError;
            }
            set
            {
                _pickerTemaError = value;
                OnPropertyChanged();
            }
        }
        public bool PickerTipoError
        {
            get
            {
                return _pickerTipoError;
            }
            set
            {
                _pickerTipoError = value;
                OnPropertyChanged();
            }
        }
        public bool PickerTipoEntradaError
        {
            get
            {
                return _pickerTipoEntradaError;
            }
            set
            {
                _pickerTipoEntradaError = value;
                OnPropertyChanged();
            }
        }
        public bool TextNombreEntradaError
        {
            get
            {
                return _textNombreEntradaError;
            }
            set
            {
                _textNombreEntradaError = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Comandos

        private ICommand _finalCommand;
      
        public ICommand FinalCommand
        {
            get
            {
                return _finalCommand = _finalCommand ?? new DelegateCommand(btnFinalClick);
            }
        }


        #endregion

        #region Metodos
        private async void btnFinalClick()
        {
            //Mostrar label de error

            TextNombreEntradaError = string.IsNullOrWhiteSpace(NombreEntrada);

            PickerTemaError = TemaEventoSeleccionado == null;

            PickerTipoError = TipoEventoSeleccionado == null;

            PickerTipoEntradaError = TipoEntradaSeleccionado == null;

            OrganizadorError = string.IsNullOrWhiteSpace(Organizador);

            //Verificamos que no haya errores.
            if (TextNombreEntradaError || PickerTemaError || OrganizadorError || PickerTipoEntradaError || PickerTipoEntradaError)
                return;

            //Todo OK entonces.. Asignamos

            Event.TipoEventoId = TipoEventoSeleccionado.Id;
            Event.TemaEventoId = TemaEventoSeleccionado.Id;
            Event.Organizador = Organizador;
            Event.Path = Path;
            Event.FileName = FileName;
            Event.EsPaginaPublica = EsPaginaPublica;
            Event.MostrarLasEntradasRestantes = MostrarEntradasRestantes;
            Event.Entrada = new EntryModel
            {
                EventoId = Event.Id,
                TipoEntrada = TipoEntradaSeleccionado == 0 ? TipoEntrada.Gratuita : TipoEntrada.Paga,
                EstaBorrado = false,
                Nombre = NombreEntrada,
                CantidadDisponible = NumeroEntradas,
                Precio = PrecioEntradas

            };
            await PostData();
            MessagingCenter.Send(this, "Exito");
        }

        #endregion

        #endregion


        public CreacionEventoViewModel()
        {
            Event = new EventModel();
        }

        public async override Task PostData()
        {
            await restClient.SaveTodoItemAsync(Event, Constantes.Constantes.URL_SERVICIOSAPI + "/Evento/crear", true);
        }
        public async override Task LoadData()
        {
            Paises = new ObservableCollection<CountryModel>(await restClient.GetData<CountryModel[]>(Constantes.Constantes.URL_SERVICIOSAPI + "/Pais/obtener"));
            TipoEvento = new ObservableCollection<TypeEventModel>(await restClient.GetData<TypeEventModel[]>(Constantes.Constantes.URL_SERVICIOSAPI + "/TipoEvento/obtener"));
            TemaEvento = new ObservableCollection<EventThemeModel>(await restClient.GetData<EventThemeModel[]>(Constantes.Constantes.URL_SERVICIOSAPI + "/TemaEvento/obtener"));
        }
    }
}
