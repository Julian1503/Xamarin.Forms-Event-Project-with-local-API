namespace Comunidad.Conexion
{
    public static class CadenaConexion
    {
        private const string Servidor = @"DESKTOP-HAL8M4B\SQLEXPRESS";
        private const string BaseDatos = "MeetUpDB";
        private const string Usuario = "";
        private const string Password = "";

        public static string ObtenerCadenaConexionSql => $"Data Source={Servidor}; " +
                                                      $"Initial Catalog={BaseDatos}; " +
                                                      $"User Id={Usuario}; " +
                                                      $"Password={Password};";
        public static string ObtenerCadenaConexionWin => $"Data Source={Servidor}; " +
                                                      $"Initial Catalog={BaseDatos}; " +
                                                      $"Integrated Security = true";
    }
}
