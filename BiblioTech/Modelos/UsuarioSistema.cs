namespace BiblioTech.Modelos
{
    /// <summary>
    /// CLASE HIJA: UsuarioSistema
    /// HERENCIA: Hereda de la clase Persona (con ": Persona") todos sus atributos
    /// (Id, NombreCompleto, Documento, Email) y agrega atributos propios del login.
    /// </summary>
    public class UsuarioSistema : Persona
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = "Bibliotecario"; // "Administrador" o "Bibliotecario"
        public bool Activo { get; set; } = true;

        public UsuarioSistema() : base()
        {
        }

        // Llamada al constructor de la clase padre usando ": base(...)"
        public UsuarioSistema(int id, string nombreCompleto, string documento, string email,
                              string nombreUsuario, string contrasena, string rol, bool activo)
            : base(id, nombreCompleto, documento, email)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Rol = rol;
            Activo = activo;
        }

        // Método propio de negocio
        public bool EsAdministrador()
        {
            return Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }

        // POLIMORFISMO: Sobrescribimos (override) el método de la clase padre Persona
        public override string ObtenerResumen()
        {
            return $"[Usuario: {NombreUsuario} | Rol: {Rol}] {NombreCompleto}";
        }
    }
}
