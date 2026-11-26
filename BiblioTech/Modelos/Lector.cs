namespace BiblioTech.Modelos
{
    // Representa a los estudiantes o docentes registrados como lectores
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

        // Un docente puede llevar hasta 5 libros simultáneos, un estudiante hasta 3
        public int ObtenerLimiteLibros()
        {
            if (TipoLector.Equals("Docente", StringComparison.OrdinalIgnoreCase))
            {
                return 5;
            }
            return 3;
        }

        public override string ObtenerResumen()
        {
            return $"{NombreCompleto} - {TipoLector} (Doc: {Documento})";
        }

        public override string ToString()
        {
            return ObtenerResumen();
        }
    }
}
