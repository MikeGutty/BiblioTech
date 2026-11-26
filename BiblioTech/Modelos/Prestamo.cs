namespace BiblioTech.Modelos
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int IdLibro { get; set; }
        public string TituloLibro { get; set; } = string.Empty;
        public string IsbnLibro { get; set; } = string.Empty;

        public int IdLector { get; set; }
        public string NombreLector { get; set; } = string.Empty;
        public string DocumentoLector { get; set; } = string.Empty;

        public int IdUsuarioRegistro { get; set; }
        public string NombreUsuarioRegistro { get; set; } = string.Empty;

        public DateTime FechaPrestamo { get; set; } = DateTime.Now;
        public DateTime FechaDevolucionEsperada { get; set; }
        public DateTime? FechaDevolucionReal { get; set; }

        // "Activo" o "Devuelto"
        public string Estado { get; set; } = "Activo";
        public decimal MultaPagada { get; set; } = 0m;
        public string Observaciones { get; set; } = string.Empty;

        // Verifica si el préstamo sigue activo y ya pasó la fecha límite
        public bool EstaVencido()
        {
            if (Estado == "Devuelto")
            {
                return false;
            }
            return DateTime.Today > FechaDevolucionEsperada.Date;
        }

        public string EstadoVisual
        {
            get
            {
                if (Estado == "Activo" && EstaVencido())
                {
                    return "Vencido";
                }
                return Estado;
            }
        }

        // Calcula los días de retraso a la fecha actual o a la fecha en que se devolvió
        public int ObtenerDiasRetraso()
        {
            DateTime fechaReferencia = FechaDevolucionReal.HasValue
                ? FechaDevolucionReal.Value.Date
                : DateTime.Today;

            if (fechaReferencia > FechaDevolucionEsperada.Date)
            {
                TimeSpan diferencia = fechaReferencia - FechaDevolucionEsperada.Date;
                return diferencia.Days;
            }

            return 0;
        }

        public decimal CalcularMulta(decimal montoPorDia)
        {
            int diasRetraso = ObtenerDiasRetraso();
            return diasRetraso * montoPorDia;
        }
    }
}
