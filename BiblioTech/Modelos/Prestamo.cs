namespace BiblioTech.Modelos
{
    /// <summary>
    /// Representa la operación central de la biblioteca: el Préstamo de un Libro a un Lector.
    /// Encapsula la lógica para saber si está vencido y calcular la multa por retraso.
    /// </summary>
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

        // Estado base en BD: "Activo" o "Devuelto"
        public string Estado { get; set; } = "Activo";
        public decimal MultaPagada { get; set; } = 0m;
        public string Observaciones { get; set; } = string.Empty;

        /// <summary>
        /// Determina si un préstamo activo ya superó su fecha límite de devolución.
        /// </summary>
        public bool EstaVencido()
        {
            if (Estado == "Devuelto")
            {
                return false;
            }
            return DateTime.Today > FechaDevolucionEsperada.Date;
        }

        /// <summary>
        /// Propiedad calculada que muestra "Vencido" automáticamente cuando un préstamo activo se pasó de fecha.
        /// </summary>
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

        /// <summary>
        /// Calcula cuántos días de retraso tiene el préstamo respecto a hoy (o respecto a su fecha de devolución real).
        /// </summary>
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

        /// <summary>
        /// Calcula el monto de la multa multiplicando los días de retraso por la tarifa diaria configurada.
        /// </summary>
        public decimal CalcularMulta(decimal montoPorDia)
        {
            int diasRetraso = ObtenerDiasRetraso();
            return diasRetraso * montoPorDia;
        }
    }
}
