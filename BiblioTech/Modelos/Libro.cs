namespace BiblioTech.Modelos
{
    /// <summary>
    /// Representa un Libro dentro del catálogo de la biblioteca.
    /// Se relaciona con un Autor (IdAutor) y una Categoría (IdCategoria).
    /// </summary>
    public class Libro
    {
        public int Id { get; set; }
        public string ISBN { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public int IdAutor { get; set; }
        public string NombreAutor { get; set; } = string.Empty;
        public int IdCategoria { get; set; }
        public string NombreCategoria { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; } = DateTime.Now.Year;
        public int StockTotal { get; set; }
        public int StockDisponible { get; set; }

        public Libro()
        {
        }

        /// <summary>
        /// Método encapsulado que indica si hay al menos un ejemplar disponible para prestar.
        /// </summary>
        public bool TieneEjemplaresDisponibles()
        {
            return StockDisponible > 0;
        }

        public override string ToString()
        {
            return $"{Titulo} - {NombreAutor} (Disp: {StockDisponible}/{StockTotal})";
        }
    }
}
