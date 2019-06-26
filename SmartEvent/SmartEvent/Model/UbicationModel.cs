namespace SmartEvent.Model
{
    public class UbicationModel : ModelBase
    {
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string CodigoPostal { get; set; }
        public long PaisId { get; set; }
    }
}
