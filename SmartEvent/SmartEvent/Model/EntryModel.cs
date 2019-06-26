namespace SmartEvent.Model
{
    public class EntryModel : ModelBase
    {
        public long EventoId { get; set; }
        public string Nombre { get; set; }
        public int CantidadDisponible { get; set; }
        public decimal Precio { get; set; }
        
        public TipoEntrada TipoEntrada { get; set; }
    }
    public enum TipoEntrada
    {
        Gratuita = 1,
        Paga = 2
    }
}
