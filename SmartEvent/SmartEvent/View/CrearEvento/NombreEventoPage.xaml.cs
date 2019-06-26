using SmartEvent.ModelView;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NombreEventoPage : ContentPage
    {
        protected CreacionEventoViewModel ViewModel;
        public NombreEventoPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<CreacionEventoViewModel>(this,"GoToDescripcion", async (a) =>
                {
                    await Navigation.PushAsync(new DescripcionEventoPage(ViewModel));
                });

            ViewModel = new CreacionEventoViewModel();
            this.BindingContext = ViewModel;
        }

        //private void Button_OnClicked(object sender, EventArgs e)
        //{
        //    lblError.IsVisible = string.IsNullOrWhiteSpace(txtNombre.Text);
        //}
    }
}