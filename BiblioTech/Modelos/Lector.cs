namespace BiblioTech.Modelos
{
    /// <summary>
    /// CLASE HIJA: Lector
    /// HERENCIA: También hereda de Persona. Representa a los Estudiantes o Docentes
    /// que solicitan libros prestados en la biblioteca.
    /// </summary>
    public class Lector : Persona
    {
        public string TipoLector { get; set; } = "Estudiante"; // "Estudiante" o "Docente"
        public string Telefono { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        public Lector() : base()
        {
        }

        public Lector(int id, string nombreCompleto, string documento, string email,
                      string tipoLector, string telefono, bool activo)
            : base(id, nombreCompleto, documento, email)
        {
            TipoLector = tipoLector;
            Telefono = telefono;
            Activo = activo;
        }

        /// <summary>
        /// Regla de negocio orientada a objetos:
        /// Un Docente puede llevar hasta 5 libros simultáneos, un Estudiante hasta 3.
        /// </summary>
        public int ObtenerLimiteLibros()
        {
            if (TipoLector.Equals("Docente", StringComparison.OrdinalIgnoreCase))
            {
                return 5;
            }
            return 3;
        }

        // POLIMORFISMO: Sobrescribimos el método de Persona
        public override string ObtenerResumen()
        {
            return $"{NombreCompleto} - {TipoLector} (Doc: {Documento})";
        }

        // Sobrescribimos ToString() para que al cargarlo en un ComboBox se vea legible
        public override string ToString()
        {
            return ObtenerResumen();
        }
    }
}
