using BiblioTech.Modelos;
using MySqlConnector;

namespace BiblioTech.Datos
{
    /// <summary>
    /// Acceso a datos para el Módulo 3 (Préstamos y Devoluciones) y Módulo 4 (Consultas y Panel de Control) en MySQL.
    /// Incluye transacciones para actualizar el stock del libro junto con el préstamo.
    /// </summary>
    public class PrestamoDatos
    {
        /// <summary>
        /// Lista los préstamos aplicando filtros opcionales por texto y por estado ("Todos", "Activos", "Devueltos", "Vencidos").
        /// </summary>
        public List<Prestamo> ListarPrestamos(string filtroTexto = "", string filtroEstado = "Todos")
        {
            List<Prestamo> lista = new List<Prestamo>();
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                SELECT P.Id, P.IdLibro, L.Titulo, L.ISBN,
                       P.IdLector, Lec.NombreCompleto, Lec.Documento,
                       P.IdUsuarioRegistro, U.NombreCompleto,
                       P.FechaPrestamo, P.FechaDevolucionEsperada, P.FechaDevolucionReal,
                       P.Estado, P.MultaPagada, P.Observaciones
                FROM Prestamos P
                INNER JOIN Libros L ON P.IdLibro = L.Id
                INNER JOIN Lectores Lec ON P.IdLector = Lec.Id
                INNER JOIN Usuarios U ON P.IdUsuarioRegistro = U.Id
                WHERE (@texto = '' OR L.Titulo LIKE CONCAT('%', @texto, '%')
                                   OR L.ISBN LIKE CONCAT('%', @texto, '%')
                                   OR Lec.NombreCompleto LIKE CONCAT('%', @texto, '%')
                                   OR Lec.Documento LIKE CONCAT('%', @texto, '%'))
                ORDER BY P.Id DESC;";

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@texto", filtroTexto.Trim());

            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Prestamo p = new Prestamo
                {
                    Id = reader.GetInt32(0),
                    IdLibro = reader.GetInt32(1),
                    TituloLibro = reader.GetString(2),
                    IsbnLibro = reader.GetString(3),
                    IdLector = reader.GetInt32(4),
                    NombreLector = reader.GetString(5),
                    DocumentoLector = reader.GetString(6),
                    IdUsuarioRegistro = reader.GetInt32(7),
                    NombreUsuarioRegistro = reader.GetString(8),
                    FechaPrestamo = DateTime.Parse(reader.GetString(9)),
                    FechaDevolucionEsperada = DateTime.Parse(reader.GetString(10)),
                    FechaDevolucionReal = reader.IsDBNull(11) ? null : DateTime.Parse(reader.GetString(11)),
                    Estado = reader.GetString(12),
                    MultaPagada = reader.GetDecimal(13),
                    Observaciones = reader.GetString(14)
                };

                // Filtrado en memoria usando los métodos orientados a objetos de la clase Prestamo
                if (filtroEstado == "Activos" && p.Estado != "Activo")
                    continue;
                if (filtroEstado == "Devueltos" && p.Estado != "Devuelto")
                    continue;
                if (filtroEstado == "Vencidos" && !p.EstaVencido())
                    continue;

                lista.Add(p);
            }

            return lista;
        }

        /// <summary>
        /// Cuenta cuántos préstamos activos tiene actualmente un lector (para validar su límite según sea Estudiante o Docente).
        /// </summary>
        public int ContarPrestamosActivosPorLector(int idLector)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT COUNT(*) FROM Prestamos WHERE IdLector = @idLector AND Estado = 'Activo';";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idLector", idLector);
            return Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
        }

        /// <summary>
        /// Registra un nuevo préstamo y descuenta en 1 el StockDisponible del libro.
        /// </summary>
        public void RegistrarPrestamo(Prestamo nuevoPrestamo)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();
            using MySqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                // 1. Verificamos que el libro tenga stock disponible
                string sqlStock = "SELECT StockDisponible FROM Libros WHERE Id = @idLibro;";
                using (MySqlCommand cmdStock = new MySqlCommand(sqlStock, conexion, transaccion))
                {
                    cmdStock.Parameters.AddWithValue("@idLibro", nuevoPrestamo.IdLibro);
                    int disponible = Convert.ToInt32(cmdStock.ExecuteScalar() ?? 0);
                    if (disponible <= 0)
                    {
                        throw new InvalidOperationException("El libro seleccionado ya no tiene ejemplares disponibles.");
                    }
                }

                // 2. Insertamos el préstamo
                string sqlInsert = @"
                    INSERT INTO Prestamos (IdLibro, IdLector, IdUsuarioRegistro, FechaPrestamo, FechaDevolucionEsperada, FechaDevolucionReal, Estado, MultaPagada, Observaciones)
                    VALUES (@idLibro, @idLector, @idUsuario, @fechaPrestamo, @fechaEsperada, NULL, 'Activo', 0, @obs);";

                using (MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conexion, transaccion))
                {
                    cmdInsert.Parameters.AddWithValue("@idLibro", nuevoPrestamo.IdLibro);
                    cmdInsert.Parameters.AddWithValue("@idLector", nuevoPrestamo.IdLector);
                    cmdInsert.Parameters.AddWithValue("@idUsuario", nuevoPrestamo.IdUsuarioRegistro);
                    cmdInsert.Parameters.AddWithValue("@fechaPrestamo", nuevoPrestamo.FechaPrestamo.ToString("yyyy-MM-dd"));
                    cmdInsert.Parameters.AddWithValue("@fechaEsperada", nuevoPrestamo.FechaDevolucionEsperada.ToString("yyyy-MM-dd"));
                    cmdInsert.Parameters.AddWithValue("@obs", nuevoPrestamo.Observaciones.Trim());
                    cmdInsert.ExecuteNonQuery();
                }

                // 3. Restamos 1 al stock disponible del libro
                string sqlUpdateLibro = "UPDATE Libros SET StockDisponible = StockDisponible - 1 WHERE Id = @idLibro;";
                using (MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdateLibro, conexion, transaccion))
                {
                    cmdUpdate.Parameters.AddWithValue("@idLibro", nuevoPrestamo.IdLibro);
                    cmdUpdate.ExecuteNonQuery();
                }

                transaccion.Commit();
            }
            catch
            {
                transaccion.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Registra la devolución de un préstamo activo, guarda la multa cobrada (si hubo retraso)
        /// e incrementa en 1 el StockDisponible del libro.
        /// </summary>
        public void RegistrarDevolucion(int idPrestamo, int idLibro, decimal multaPagada, string observaciones)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();
            using MySqlTransaction transaccion = conexion.BeginTransaction();

            try
            {
                string sqlUpdatePrestamo = @"
                    UPDATE Prestamos
                    SET Estado = 'Devuelto',
                        FechaDevolucionReal = @fechaReal,
                        MultaPagada = @multa,
                        Observaciones = @obs
                    WHERE Id = @idPrestamo AND Estado = 'Activo';";

                using (MySqlCommand cmdPrestamo = new MySqlCommand(sqlUpdatePrestamo, conexion, transaccion))
                {
                    cmdPrestamo.Parameters.AddWithValue("@fechaReal", DateTime.Today.ToString("yyyy-MM-dd"));
                    cmdPrestamo.Parameters.AddWithValue("@multa", multaPagada);
                    cmdPrestamo.Parameters.AddWithValue("@obs", observaciones.Trim());
                    cmdPrestamo.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                    int filas = cmdPrestamo.ExecuteNonQuery();

                    if (filas == 0)
                    {
                        throw new InvalidOperationException("El préstamo seleccionado ya fue devuelto anteriormente.");
                    }
                }

                // Reponemos 1 ejemplar al StockDisponible sin superar el StockTotal
                string sqlReponeStock = @"
                    UPDATE Libros
                    SET StockDisponible = CASE WHEN StockDisponible < StockTotal THEN StockDisponible + 1 ELSE StockTotal END
                    WHERE Id = @idLibro;";

                using (MySqlCommand cmdLibro = new MySqlCommand(sqlReponeStock, conexion, transaccion))
                {
                    cmdLibro.Parameters.AddWithValue("@idLibro", idLibro);
                    cmdLibro.ExecuteNonQuery();
                }

                transaccion.Commit();
            }
            catch
            {
                transaccion.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Obtiene los indicadores resumidos para las tarjetas del Panel de Control (Módulo 4).
        /// </summary>
        public (int TotalTitulos, int EjemplaresDisponibles, int PrestamosActivos, int PrestamosVencidos) ObtenerIndicadoresDashboard()
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            int totalTitulos = Convert.ToInt32(new MySqlCommand("SELECT COUNT(*) FROM Libros;", conexion).ExecuteScalar() ?? 0);
            int ejemplaresDisp = Convert.ToInt32(new MySqlCommand("SELECT IFNULL(SUM(StockDisponible), 0) FROM Libros;", conexion).ExecuteScalar() ?? 0);

            List<Prestamo> activos = ListarPrestamos("", "Activos");
            int totalActivos = activos.Count;
            int totalVencidos = activos.Count(p => p.EstaVencido());

            return (totalTitulos, ejemplaresDisp, totalActivos, totalVencidos);
        }
    }
}
