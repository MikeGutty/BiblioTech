namespace BiblioTech.Modelos
{
    /// <summary>
    /// Representa al Autor de uno o varios libros del catálogo.
    /// </summary>
    public class Autor
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = string.Empty;
        public string Nacionalidad { get; set; } = string.Empty;

        public Autor()
        {
        }

        public Autor(int id, string nombreCompleto, string nacionalidad)
        {
            Id = id;
            NombreCompleto = nombreCompleto;
            Nacionalidad = nacionalidad;
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
