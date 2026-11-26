namespace BiblioTech.Modelos
{
    // Parámetros generales de la biblioteca
    public class ConfiguracionSistema
    {
        public string NombreBiblioteca { get; set; } = "BiblioTech Universitaria";
        public int DiasMaximoPrestamo { get; set; } = 7;
        public decimal MultaPorDiaRetraso { get; set; } = 5.00m;
    }

    // Mantiene en memoria los datos de la sesión activa
    public static class SesionActual
    {
        public static UsuarioSistema? Usuario { get; set; }
        public static ConfiguracionSistema Configuracion { get; set; } = new ConfiguracionSistema();
    }
}
