using System.Data.Common;
using BiblioTech.Modelos;

namespace BiblioTech.Datos
{
    public class PrestamoDatos
    {
        public List<Prestamo> ListarPrestamos(string filtroTexto = "", string filtroEstado = "Todos")
        {
            List<Prestamo> lista = new List<Prestamo>();
            using DbConnection conexion = ConexionBD.ObtenerConexion();
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

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@texto", filtroTexto.Trim());

            using DbDataReader reader = cmd.ExecuteReader();
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

                // Filtrado por estado
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

        public int ContarPrestamosActivosPorLector(int idLector)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT COUNT(*) FROM Prestamos WHERE IdLector = @idLector AND Estado = 'Activo';";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@idLector", idLector);
            return Convert.ToInt32(cmd.ExecuteScalar() ?? 0);
        }

        // Registra el préstamo y descuenta el stock del libro dentro de una misma transacción
        public void RegistrarPrestamo(Prestamo nuevoPrestamo)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();
            using DbTransaction transaccion = conexion.BeginTransaction();

            try
            {
                // Verificar stock disponible
                string sqlStock = "SELECT StockDisponible FROM Libros WHERE Id = @idLibro;";
                using (DbCommand cmdStock = ConexionBD.CrearComando(sqlStock, conexion, transaccion))
                {
                    ConexionBD.AgregarParametro(cmdStock, "@idLibro", nuevoPrestamo.IdLibro);
                    int disponible = Convert.ToInt32(cmdStock.ExecuteScalar() ?? 0);
                    if (disponible <= 0)
                    {
                        throw new InvalidOperationException("El libro seleccionado ya no tiene ejemplares disponibles.");
                    }
                }

                // Insertar el préstamo
                string sqlInsert = @"
                    INSERT INTO Prestamos (IdLibro, IdLector, IdUsuarioRegistro, FechaPrestamo, FechaDevolucionEsperada, FechaDevolucionReal, Estado, MultaPagada, Observaciones)
                    VALUES (@idLibro, @idLector, @idUsuario, @fechaPrestamo, @fechaEsperada, NULL, 'Activo', 0, @obs);";

                using (DbCommand cmdInsert = ConexionBD.CrearComando(sqlInsert, conexion, transaccion))
                {
                    ConexionBD.AgregarParametro(cmdInsert, "@idLibro", nuevoPrestamo.IdLibro);
                    ConexionBD.AgregarParametro(cmdInsert, "@idLector", nuevoPrestamo.IdLector);
                    ConexionBD.AgregarParametro(cmdInsert, "@idUsuario", nuevoPrestamo.IdUsuarioRegistro);
                    ConexionBD.AgregarParametro(cmdInsert, "@fechaPrestamo", nuevoPrestamo.FechaPrestamo.ToString("yyyy-MM-dd"));
                    ConexionBD.AgregarParametro(cmdInsert, "@fechaEsperada", nuevoPrestamo.FechaDevolucionEsperada.ToString("yyyy-MM-dd"));
                    ConexionBD.AgregarParametro(cmdInsert, "@obs", nuevoPrestamo.Observaciones.Trim());
                    cmdInsert.ExecuteNonQuery();
                }

                // Descontar 1 al stock disponible
                string sqlUpdateLibro = "UPDATE Libros SET StockDisponible = StockDisponible - 1 WHERE Id = @idLibro;";
                using (DbCommand cmdUpdate = ConexionBD.CrearComando(sqlUpdateLibro, conexion, transaccion))
                {
                    ConexionBD.AgregarParametro(cmdUpdate, "@idLibro", nuevoPrestamo.IdLibro);
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

        // Registra la devolución y repone el stock del ejemplar
        public void RegistrarDevolucion(int idPrestamo, int idLibro, decimal multaPagada, string observaciones)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();
            using DbTransaction transaccion = conexion.BeginTransaction();

            try
            {
                string sqlUpdatePrestamo = @"
                    UPDATE Prestamos
                    SET Estado = 'Devuelto',
                        FechaDevolucionReal = @fechaReal,
                        MultaPagada = @multa,
                        Observaciones = @obs
                    WHERE Id = @idPrestamo AND Estado = 'Activo';";

                using (DbCommand cmdPrestamo = ConexionBD.CrearComando(sqlUpdatePrestamo, conexion, transaccion))
                {
                    ConexionBD.AgregarParametro(cmdPrestamo, "@fechaReal", DateTime.Today.ToString("yyyy-MM-dd"));
                    ConexionBD.AgregarParametro(cmdPrestamo, "@multa", multaPagada);
                    ConexionBD.AgregarParametro(cmdPrestamo, "@obs", observaciones.Trim());
                    ConexionBD.AgregarParametro(cmdPrestamo, "@idPrestamo", idPrestamo);
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

                using (DbCommand cmdLibro = ConexionBD.CrearComando(sqlReponeStock, conexion, transaccion))
                {
                    ConexionBD.AgregarParametro(cmdLibro, "@idLibro", idLibro);
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

        public (int TotalTitulos, int EjemplaresDisponibles, int PrestamosActivos, int PrestamosVencidos) ObtenerIndicadoresDashboard()
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            using DbCommand cmdTitulos = ConexionBD.CrearComando("SELECT COUNT(*) FROM Libros;", conexion);
            int totalTitulos = Convert.ToInt32(cmdTitulos.ExecuteScalar() ?? 0);

            using DbCommand cmdDisponibles = ConexionBD.CrearComando("SELECT COALESCE(SUM(StockDisponible), 0) FROM Libros;", conexion);
            int ejemplaresDisp = Convert.ToInt32(cmdDisponibles.ExecuteScalar() ?? 0);

            List<Prestamo> activos = ListarPrestamos("", "Activos");
            int totalActivos = activos.Count;
            int totalVencidos = activos.Count(p => p.EstaVencido());

            return (totalTitulos, ejemplaresDisp, totalActivos, totalVencidos);
        }
    }
}
