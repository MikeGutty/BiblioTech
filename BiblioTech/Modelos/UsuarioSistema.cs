namespace BiblioTech.Modelos
{
    // Hereda de Persona los datos básicos y agrega credenciales de acceso
    public class UsuarioSistema : Persona
    {
        public string NombreUsuario { get; set; } = string.Empty;
        public string Contrasena { get; set; } = string.Empty;
        public string Rol { get; set; } = "Bibliotecario"; // "Administrador" o "Bibliotecario"
        public bool Activo { get; set; } = true;

        public UsuarioSistema() : base()
        {
        }

        public UsuarioSistema(int id, string nombreCompleto, string documento, string email,
                              string nombreUsuario, string contrasena, string rol, bool activo)
            : base(id, nombreCompleto, documento, email)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Rol = rol;
            Activo = activo;
        }

        public bool EsAdministrador()
        {
            return Rol.Equals("Administrador", StringComparison.OrdinalIgnoreCase);
        }

        public override string ObtenerResumen()
        {
            return $"[Usuario: {NombreUsuario} | Rol: {Rol}] {NombreCompleto}";
        }
    }
}
