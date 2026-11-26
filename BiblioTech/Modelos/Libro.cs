namespace BiblioTech.Modelos
{
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
