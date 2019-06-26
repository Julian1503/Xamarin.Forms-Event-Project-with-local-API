namespace SmartEvent.Model
{
    public class EventModel: ModelBase
    {
        public long TipoEventoId { get; set; }
        public long TemaEventoId { get; set; }
        public string Nombre { get; set; }
        public UbicationModel Ubicacion { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public string Descripcion { get; set; }
        public string Organizador { get; set; }
        public bool MostrarLasEntradasRestantes { get; set; }
        public bool EsPaginaPublica { get; set; }
        public ProgramationModel Programacion { get; set; }
        public EntryModel Entrada { get; set; }
    }
}
