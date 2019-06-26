namespace SmartEvent.Model
{
    public class UserModel : ModelBase
    {
        public PersonaModel Persona { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }

    }
}
