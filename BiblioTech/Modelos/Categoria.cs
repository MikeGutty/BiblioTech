namespace BiblioTech.Modelos
{
    /// <summary>
    /// Representa una Categoría o Género literario/académico (Ej: Programación, Matemáticas, Novela).
    /// </summary>
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        public Categoria()
        {
        }

        public Categoria(int id, string nombre, string descripcion)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
