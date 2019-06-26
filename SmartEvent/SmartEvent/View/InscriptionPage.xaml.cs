using SmartEvent.ModelView;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InscriptionPage : ContentPage
    {
        public InscriptionPageViewModel ViewModel;
        private long _eventoId;
        public InscriptionPage(long eventoId)
        {
            InitializeComponent();
            _eventoId = eventoId;
            MessagingCenter.Subscribe<InscriptionPageViewModel>(this, "Exito", async (a) => 
            {
                await DisplayAlert("Alert", "Exito en carga de datos", "Ok");
                await Navigation.PopAsync();
            });
            MessagingCenter.Subscribe<InscriptionPageViewModel>(this, "Logueate", async (a) =>
            {
                await Navigation.PushAsync(new LoginPage());
            });
        }
        protected async override void OnAppearing()
        {
            ViewModel = new InscriptionPageViewModel(Navigation,_eventoId);
             await ViewModel.LoadData();
            BindingContext = ViewModel;
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}