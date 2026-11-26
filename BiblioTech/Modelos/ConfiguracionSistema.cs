namespace BiblioTech.Modelos
{
    /// <summary>
    /// Guarda los parámetros configurables por el Administrador en el Módulo 5.
    /// </summary>
    public class ConfiguracionSistema
    {
        public string NombreBiblioteca { get; set; } = "BiblioTech Universitaria";
        public int DiasMaximoPrestamo { get; set; } = 7;
        public decimal MultaPorDiaRetraso { get; set; } = 5.00m;
    }

    /// <summary>
    /// Clase estática para mantener en memoria al usuario que inició sesión actualmente
    /// y la configuración global de la biblioteca.
    /// </summary>
    public static class SesionActual
    {
        public static UsuarioSistema? Usuario { get; set; }
        public static ConfiguracionSistema Configuracion { get; set; } = new ConfiguracionSistema();
    }
}
