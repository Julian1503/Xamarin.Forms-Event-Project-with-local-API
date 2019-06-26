using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartEvent.ModelView;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartEvent.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DescripcionEventoPage : ContentPage
    {
        public DescripcionEventoPage()
        {
            InitializeComponent();
        }

        public DescripcionEventoPage(CreacionEventoViewModel viewModel) : this()
        {
            BindingContext = viewModel;
            MessagingCenter.Subscribe<CreacionEventoViewModel>(this, "GoToFecha", async (a) =>
            {
                await Navigation.PushAsync(new FechaEventoPage(viewModel));
            });
        }
    }
}