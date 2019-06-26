using System.Collections.Generic;
using System.Linq;
using SmartEvent.Helpers;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace SmartEvent.ModelView
{
    using Constantes;
    using SmartEvent.Model;
    using SmartEvent.View;
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class MainPageViewModel : BaseViewModel
    {
        #region Propiedades
        private ObservableCollection<EventModel> _data;
        private string _searchBarText;

        public bool LogIn
        {
            get
            {
                OnPropertyChanged();
                return !Cook.Logged;
            }
        }
        public bool LogOut
        {
            get
            {
                OnPropertyChanged();
                return Cook.Logged;
            }
        }
        //public bool LogOut
        //{
        //    get => !ButtonVisible;
        //}

        //public bool ButtonVisible
        //{
        //    get
        //    {

        //    }
        //}
        public string SearchBarText
        {
            get { return _searchBarText; }
            set
            {
                _searchBarText = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<EventModel> Data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged();
            }
        }

        private ICommand _searchCommand;
        private ICommand _inscriptionCommand;
        private ICommand _logOutCommand;
        private ICommand _logInCommand;
        private ICommand _createEventCommand;

        public ICommand SearchCommand
        {
            get { return _searchCommand = _searchCommand ?? new DelegateCommand(BuscandoEventos); }
        }


        public ICommand CreateEventCommand
        {
            get { return _createEventCommand = _createEventCommand ?? new DelegateCommand(CrearEventoClick); }
        }

        private async void CrearEventoClick()
        {
            if (Cook.Logged)
            {
                await Navigation.PushAsync(new NombreEventoPage());
            }
            else
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }

        public ICommand LogInCommand
        {
            get
            {
                return _logInCommand = _logInCommand ?? new DelegateCommand(LogInClick);
            }
        }

        private async void LogInClick()
        {
            await Navigation.PushAsync(new LoginPage());
        }

        public INavigation Navigation { get; set; }

        public ICommand InscriptionCommand
        {
            get => _inscriptionCommand = _inscriptionCommand ?? new Command<long>(InscripcionClick);
        }

        private async void InscripcionClick(long eventId)
        {
            if (Cook.Logged)
            {
                await Navigation.PushAsync(new InscriptionPage((long)eventId), true);
            }
            else
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }

        public ICommand LogOutCommand
        {
            get => _logOutCommand = _logOutCommand ?? new DelegateCommand(LogOutClick);

        }

        private async void LogOutClick()
        {
            Cook.Logged = false;
            await LoadData();
        }
        #endregion

        #region Constructor
        public MainPageViewModel(INavigation navegacion) : base()
        {
            Navigation = navegacion;
        }

        private async void BuscandoEventos()
        {
            if (!SearchBarText.Equals("Busca un evento"))
            {
                IsBusy = true;
                var arrayEventoBusqueda =
                    await restClient.GetData<EventModel[]>(Constantes.URL_SERVICIOSAPI +
                                                           $"/Evento/obtenerpordescripcion?cadenaBuscar={SearchBarText}");
                Data = new ObservableCollection<EventModel>(arrayEventoBusqueda);
                IsBusy = false;
            }
            else
            {
                await LoadData();
            }
        }

        #endregion

        public override async Task LoadData()
        {
                IsBusy = true;
                var arrayData =
                    await restClient.GetData<EventModel[]>(Constantes.URL_SERVICIOSAPI + "/Evento/obtenertodos");
                Data = new ObservableCollection<EventModel>(arrayData.Where(x => (x.EsPaginaPublica || Cook.Logged)));
                IsBusy = false;
            
        }
        private string _result;
        public string Result
        {
            get => _result;
            set
            {
                _result = value;
                OnPropertyChanged();
            }
        }

        private ICommand _acreditacionCommand;

        public ICommand AcreditacionCommand
        {
            get
            {
                return _acreditacionCommand = _acreditacionCommand ?? new DelegateCommand(OnButtomCommand);
            }
        }


        private void OnButtomCommand()
        {
            Navigation.PushAsync(new AcreditacionPage());
            //var options = new MobileBarcodeScanningOptions();
            //options.PossibleFormats = new List<BarcodeFormat>
            //{
            //    BarcodeFormat.QR_CODE
            //};
            //var page = new ZXingScannerPage(options) { Title = "Scanner" };
            //var closeItem = new ToolbarItem { Text = "Close" };
            //closeItem.Clicked += (object sender, EventArgs e) =>
            //{
            //    page.IsScanning = false;
            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        Application.Current.MainPage.Navigation.PopModalAsync();
            //    });
            //};
            //page.ToolbarItems.Add(closeItem);
            //page.OnScanResult += (result) =>
            //{
            //    page.IsScanning = false;

            //    Device.BeginInvokeOnMainThread(() =>
            //    {
            //        Application.Current.MainPage.Navigation.PopModalAsync();
            //        if (string.IsNullOrEmpty(result.Text))
            //        {
            //            Result = "No valid code has been scanned";
            //        }
            //        else
            //        {
            //            Result = $"Result: {result.Text}";
            //        }
            //    });
            //};
            //Application.Current.MainPage.Navigation.PushModalAsync(new NavigationPage(page) { BarTextColor = Color.White, BarBackgroundColor = Color.CadetBlue }, true);
        }
    }
}
