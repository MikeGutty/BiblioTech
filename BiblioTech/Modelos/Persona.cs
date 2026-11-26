namespace BiblioTech.Modelos
{
    // Clase base abstracta para UsuarioSistema y Lector
    public abstract class Persona
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Documento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        protected Persona()
        {
        }

        protected Persona(int id, string nombreCompleto, string documento, string email)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Documento = documento;
            Email = email;
        }

        // Método virtual para sobrescribir en las clases hijas
        public virtual string ObtenerResumen()
        {
            return $"{NombreCompleto} (Doc: {Documento})";
        }
    }
}
