using System.Data.Common;
using BiblioTech.Modelos;

namespace BiblioTech.Datos
{
    public class CatalogoDatos
    {
        // Categorías
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT Id, Nombre, Descripcion FROM Categorias ORDER BY Nombre;";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            using DbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Categoria(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                ));
            }
            return lista;
        }

        public void InsertarCategoria(Categoria cat)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@nombre, @descripcion);";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", cat.Nombre.Trim());
            ConexionBD.AgregarParametro(cmd, "@descripcion", cat.Descripcion.Trim());
            cmd.ExecuteNonQuery();
        }

        public void ActualizarCategoria(Categoria cat)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "UPDATE Categorias SET Nombre = @nombre, Descripcion = @descripcion WHERE Id = @id;";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", cat.Nombre.Trim());
            ConexionBD.AgregarParametro(cmd, "@descripcion", cat.Descripcion.Trim());
            ConexionBD.AgregarParametro(cmd, "@id", cat.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminarCategoria(int idCategoria)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            // Validamos que no tenga libros asociados antes de eliminar
            using (DbCommand cmdValidar = ConexionBD.CrearComando("SELECT COUNT(*) FROM Libros WHERE IdCategoria = @id;", conexion))
            {
                ConexionBD.AgregarParametro(cmdValidar, "@id", idCategoria);
                long cantidadLibros = Convert.ToInt64(cmdValidar.ExecuteScalar() ?? 0L);
                if (cantidadLibros > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar la categoría porque tiene libros registrados.");
                }
            }

            using DbCommand cmd = ConexionBD.CrearComando("DELETE FROM Categorias WHERE Id = @id;", conexion);
            ConexionBD.AgregarParametro(cmd, "@id", idCategoria);
            cmd.ExecuteNonQuery();
        }

        // Autores
        public List<Autor> ListarAutores()
        {
            List<Autor> lista = new List<Autor>();
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT Id, NombreCompleto, Nacionalidad FROM Autores ORDER BY NombreCompleto;";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            using DbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(new Autor(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                ));
            }
            return lista;
        }

        public void InsertarAutor(Autor autor)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "INSERT INTO Autores (NombreCompleto, Nacionalidad) VALUES (@nombre, @nacionalidad);";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", autor.NombreCompleto.Trim());
            ConexionBD.AgregarParametro(cmd, "@nacionalidad", autor.Nacionalidad.Trim());
            cmd.ExecuteNonQuery();
        }

        public void ActualizarAutor(Autor autor)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "UPDATE Autores SET NombreCompleto = @nombre, Nacionalidad = @nacionalidad WHERE Id = @id;";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", autor.NombreCompleto.Trim());
            ConexionBD.AgregarParametro(cmd, "@nacionalidad", autor.Nacionalidad.Trim());
            ConexionBD.AgregarParametro(cmd, "@id", autor.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminarAutor(int idAutor)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            using (DbCommand cmdValidar = ConexionBD.CrearComando("SELECT COUNT(*) FROM Libros WHERE IdAutor = @id;", conexion))
            {
                ConexionBD.AgregarParametro(cmdValidar, "@id", idAutor);
                long cantidadLibros = Convert.ToInt64(cmdValidar.ExecuteScalar() ?? 0L);
                if (cantidadLibros > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el autor porque tiene libros asociados en el catálogo.");
                }
            }

            using DbCommand cmd = ConexionBD.CrearComando("DELETE FROM Autores WHERE Id = @id;", conexion);
            ConexionBD.AgregarParametro(cmd, "@id", idAutor);
            cmd.ExecuteNonQuery();
        }

        // Libros
        public List<Libro> ListarLibros(string filtroTexto = "", int idCategoria = 0, int idAutor = 0)
        {
            List<Libro> lista = new List<Libro>();
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                SELECT L.Id, L.ISBN, L.Titulo, L.IdAutor, A.NombreCompleto AS NombreAutor,
                       L.IdCategoria, C.Nombre AS NombreCategoria, L.AnioPublicacion,
                       L.StockTotal, L.StockDisponible
                FROM Libros L
                INNER JOIN Autores A ON L.IdAutor = A.Id
                INNER JOIN Categorias C ON L.IdCategoria = C.Id
                WHERE (@texto = '' OR L.Titulo LIKE CONCAT('%', @texto, '%') OR L.ISBN LIKE CONCAT('%', @texto, '%') OR A.NombreCompleto LIKE CONCAT('%', @texto, '%'))
                  AND (@idCat = 0 OR L.IdCategoria = @idCat)
                  AND (@idAut = 0 OR L.IdAutor = @idAut)
                ORDER BY L.Titulo;";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@texto", filtroTexto.Trim());
            ConexionBD.AgregarParametro(cmd, "@idCat", idCategoria);
            ConexionBD.AgregarParametro(cmd, "@idAut", idAutor);

            using DbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Libro libro = new Libro
                {
                    Id = reader.GetInt32(0),
                    ISBN = reader.GetString(1),
                    Titulo = reader.GetString(2),
                    IdAutor = reader.GetInt32(3),
                    NombreAutor = reader.GetString(4),
                    IdCategoria = reader.GetInt32(5),
                    NombreCategoria = reader.GetString(6),
                    AnioPublicacion = reader.GetInt32(7),
                    StockTotal = reader.GetInt32(8),
                    StockDisponible = reader.GetInt32(9)
                };
                lista.Add(libro);
            }
            return lista;
        }

        public void InsertarLibro(Libro libro)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                INSERT INTO Libros (ISBN, Titulo, IdAutor, IdCategoria, AnioPublicacion, StockTotal, StockDisponible)
                VALUES (@isbn, @titulo, @idAutor, @idCategoria, @anio, @stockTotal, @stockDisponible);";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@isbn", libro.ISBN.Trim());
            ConexionBD.AgregarParametro(cmd, "@titulo", libro.Titulo.Trim());
            ConexionBD.AgregarParametro(cmd, "@idAutor", libro.IdAutor);
            ConexionBD.AgregarParametro(cmd, "@idCategoria", libro.IdCategoria);
            ConexionBD.AgregarParametro(cmd, "@anio", libro.AnioPublicacion);
            ConexionBD.AgregarParametro(cmd, "@stockTotal", libro.StockTotal);
            ConexionBD.AgregarParametro(cmd, "@stockDisponible", libro.StockDisponible);
            cmd.ExecuteNonQuery();
        }

        public void ActualizarLibro(Libro libro)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                UPDATE Libros
                SET ISBN = @isbn,
                    Titulo = @titulo,
                    IdAutor = @idAutor,
                    IdCategoria = @idCategoria,
                    AnioPublicacion = @anio,
                    StockTotal = @stockTotal,
                    StockDisponible = @stockDisponible
                WHERE Id = @id;";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@isbn", libro.ISBN.Trim());
            ConexionBD.AgregarParametro(cmd, "@titulo", libro.Titulo.Trim());
            ConexionBD.AgregarParametro(cmd, "@idAutor", libro.IdAutor);
            ConexionBD.AgregarParametro(cmd, "@idCategoria", libro.IdCategoria);
            ConexionBD.AgregarParametro(cmd, "@anio", libro.AnioPublicacion);
            ConexionBD.AgregarParametro(cmd, "@stockTotal", libro.StockTotal);
            ConexionBD.AgregarParametro(cmd, "@stockDisponible", libro.StockDisponible);
            ConexionBD.AgregarParametro(cmd, "@id", libro.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminarLibro(int idLibro)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            using (DbCommand cmdValidar = ConexionBD.CrearComando("SELECT COUNT(*) FROM Prestamos WHERE IdLibro = @id;", conexion))
            {
                ConexionBD.AgregarParametro(cmdValidar, "@id", idLibro);
                long prestamosAsociados = Convert.ToInt64(cmdValidar.ExecuteScalar() ?? 0L);
                if (prestamosAsociados > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el libro porque tiene historial de préstamos registrados.");
                }
            }

            using DbCommand cmd = ConexionBD.CrearComando("DELETE FROM Libros WHERE Id = @id;", conexion);
            ConexionBD.AgregarParametro(cmd, "@id", idLibro);
            cmd.ExecuteNonQuery();
        }

        // Lectores
        public List<Lector> ListarLectores(string filtroTexto = "", bool soloActivos = false)
        {
            List<Lector> lista = new List<Lector>();
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                SELECT Id, NombreCompleto, Documento, Email, TipoLector, Telefono, Activo
                FROM Lectores
                WHERE (@texto = '' OR NombreCompleto LIKE CONCAT('%', @texto, '%') OR Documento LIKE CONCAT('%', @texto, '%'))
                  AND (@soloActivos = 0 OR Activo = 1)
                ORDER BY NombreCompleto;";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@texto", filtroTexto.Trim());
            ConexionBD.AgregarParametro(cmd, "@soloActivos", soloActivos ? 1 : 0);

            using DbDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Lector(
                    id: reader.GetInt32(0),
                    nombreCompleto: reader.GetString(1),
                    documento: reader.GetString(2),
                    email: reader.GetString(3),
                    tipoLector: reader.GetString(4),
                    telefono: reader.GetString(5),
                    activo: Convert.ToInt32(reader.GetValue(6)) == 1
                ));
            }
            return lista;
        }

        public void InsertarLector(Lector lector)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                INSERT INTO Lectores (NombreCompleto, Documento, Email, TipoLector, Telefono, Activo)
                VALUES (@nombre, @documento, @email, @tipo, @telefono, @activo);";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", lector.NombreCompleto.Trim());
            ConexionBD.AgregarParametro(cmd, "@documento", lector.Documento.Trim());
            ConexionBD.AgregarParametro(cmd, "@email", lector.Email.Trim());
            ConexionBD.AgregarParametro(cmd, "@tipo", lector.TipoLector);
            ConexionBD.AgregarParametro(cmd, "@telefono", lector.Telefono.Trim());
            ConexionBD.AgregarParametro(cmd, "@activo", lector.Activo ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void ActualizarLector(Lector lector)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                UPDATE Lectores
                SET NombreCompleto = @nombre,
                    Documento = @documento,
                    Email = @email,
                    TipoLector = @tipo,
                    Telefono = @telefono,
                    Activo = @activo
                WHERE Id = @id;";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", lector.NombreCompleto.Trim());
            ConexionBD.AgregarParametro(cmd, "@documento", lector.Documento.Trim());
            ConexionBD.AgregarParametro(cmd, "@email", lector.Email.Trim());
            ConexionBD.AgregarParametro(cmd, "@tipo", lector.TipoLector);
            ConexionBD.AgregarParametro(cmd, "@telefono", lector.Telefono.Trim());
            ConexionBD.AgregarParametro(cmd, "@activo", lector.Activo ? 1 : 0);
            ConexionBD.AgregarParametro(cmd, "@id", lector.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminarLector(int idLector)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            using (DbCommand cmdValidar = ConexionBD.CrearComando("SELECT COUNT(*) FROM Prestamos WHERE IdLector = @id;", conexion))
            {
                ConexionBD.AgregarParametro(cmdValidar, "@id", idLector);
                long prestamos = Convert.ToInt64(cmdValidar.ExecuteScalar() ?? 0L);
                if (prestamos > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el lector porque tiene préstamos asociados. Puede desactivarlo desmarcando la casilla 'Activo'.");
                }
            }

            using DbCommand cmd = ConexionBD.CrearComando("DELETE FROM Lectores WHERE Id = @id;", conexion);
            ConexionBD.AgregarParametro(cmd, "@id", idLector);
            cmd.ExecuteNonQuery();
        }
    }
}
