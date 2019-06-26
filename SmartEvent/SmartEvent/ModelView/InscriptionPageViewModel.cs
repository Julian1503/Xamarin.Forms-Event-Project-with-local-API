using SmartEvent.Model;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using SmartEvent.Constantes;
using System;
using SmartEvent.Helpers;

namespace SmartEvent.ModelView
{
    public class InscriptionPageViewModel : BaseViewModel
    {
        #region Propiedades
        public EventModel Data { get; set; }
        public TypeEventModel TipoEvento { get; set; }
        public EventThemeModel TemaEvento { get; set; }
        private long _eventoId { get; set; }

        #endregion

        #region Comandos

        private ICommand _inscripcionCommand { get; set; }
        public ICommand InscripcionCommand
        {
            get { return _inscripcionCommand = _inscripcionCommand ?? new DelegateCommand(InscripcionClick); }
        }

     
        #endregion

        #region Constructores

        public InscriptionPageViewModel(INavigation navigation, long eventoId) : base()
        {
            _eventoId = eventoId;
        }
        #endregion

        #region Metodos
        private async void InscripcionClick()
        {
            if (Cook.Logged)
            {
                await restClient.SaveTodoItemAsync(new InscriptionModel
                    {
                        Fecha = DateTime.Now,
                        EntradaId = Data.Entrada.Id,
                        EstaBorrado = false,
                        EstadoInscripcion = EstadoInscripcion.Aprobada,
                        PersonaId = 1,
                        Id = 0
                    }, Constantes.Constantes.URL_SERVICIOSAPI + "/Inscripcion/crear", true);
                MessagingCenter.Send(this, "Exito");
            }
            else
            {
                MessagingCenter.Send(this, "Logueate");
            }
        }
        public override async Task LoadData()
        {
            var arrayData = await restClient.GetData<EventModel>(Constantes.Constantes.URL_SERVICIOSAPI + $"/Evento/{_eventoId}");
            Data = arrayData;
            TipoEvento = await restClient.GetData<TypeEventModel>(Constantes.Constantes.URL_SERVICIOSAPI + $"/TipoEvento/{Data.TipoEventoId}");
            TemaEvento = await restClient.GetData<EventThemeModel>(Constantes.Constantes.URL_SERVICIOSAPI + $"/TemaEvento/{Data.TemaEventoId}");

        }
        #endregion

    }
}
