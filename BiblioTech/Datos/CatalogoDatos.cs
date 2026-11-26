using BiblioTech.Modelos;
using MySqlConnector;

namespace BiblioTech.Datos
{
    /// <summary>
    /// Acceso a datos para el Módulo 2: Gestión de Catálogos (CRUDs de Categorías, Autores, Libros y Lectores) en MySQL.
    /// Escrito con consultas SQL claras para que los estudiantes comprendan cómo se relacionan las tablas.
    /// </summary>
    public class CatalogoDatos
    {
        // =========================================================================
        // 1. CRUD DE CATEGORÍAS
        // =========================================================================
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT Id, Nombre, Descripcion FROM Categorias ORDER BY Nombre;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            using MySqlDataReader reader = cmd.ExecuteReader();

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
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "INSERT INTO Categorias (Nombre, Descripcion) VALUES (@nombre, @descripcion);";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", cat.Nombre.Trim());
            cmd.Parameters.AddWithValue("@descripcion", cat.Descripcion.Trim());
            cmd.ExecuteNonQuery();
        }

        public void ActualizarCategoria(Categoria cat)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "UPDATE Categorias SET Nombre = @nombre, Descripcion = @descripcion WHERE Id = @id;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", cat.Nombre.Trim());
            cmd.Parameters.AddWithValue("@descripcion", cat.Descripcion.Trim());
            cmd.Parameters.AddWithValue("@id", cat.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminarCategoria(int idCategoria)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            // Validamos que no tenga libros asociados antes de eliminar
            using (MySqlCommand cmdValidar = new MySqlCommand("SELECT COUNT(*) FROM Libros WHERE IdCategoria = @id;", conexion))
            {
                cmdValidar.Parameters.AddWithValue("@id", idCategoria);
                long cantidadLibros = Convert.ToInt64(cmdValidar.ExecuteScalar() ?? 0L);
                if (cantidadLibros > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar la categoría porque tiene libros registrados.");
                }
            }

            using MySqlCommand cmd = new MySqlCommand("DELETE FROM Categorias WHERE Id = @id;", conexion);
            cmd.Parameters.AddWithValue("@id", idCategoria);
            cmd.ExecuteNonQuery();
        }

        // =========================================================================
        // 2. CRUD DE AUTORES
        // =========================================================================
        public List<Autor> ListarAutores()
        {
            List<Autor> lista = new List<Autor>();
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT Id, NombreCompleto, Nacionalidad FROM Autores ORDER BY NombreCompleto;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            using MySqlDataReader reader = cmd.ExecuteReader();

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
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "INSERT INTO Autores (NombreCompleto, Nacionalidad) VALUES (@nombre, @nacionalidad);";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", autor.NombreCompleto.Trim());
            cmd.Parameters.AddWithValue("@nacionalidad", autor.Nacionalidad.Trim());
            cmd.ExecuteNonQuery();
        }

        public void ActualizarAutor(Autor autor)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "UPDATE Autores SET NombreCompleto = @nombre, Nacionalidad = @nacionalidad WHERE Id = @id;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", autor.NombreCompleto.Trim());
            cmd.Parameters.AddWithValue("@nacionalidad", autor.Nacionalidad.Trim());
            cmd.Parameters.AddWithValue("@id", autor.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminarAutor(int idAutor)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            using (MySqlCommand cmdValidar = new MySqlCommand("SELECT COUNT(*) FROM Libros WHERE IdAutor = @id;", conexion))
            {
                cmdValidar.Parameters.AddWithValue("@id", idAutor);
                long cantidadLibros = Convert.ToInt64(cmdValidar.ExecuteScalar() ?? 0L);
                if (cantidadLibros > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el autor porque tiene libros asociados en el catálogo.");
                }
            }

            using MySqlCommand cmd = new MySqlCommand("DELETE FROM Autores WHERE Id = @id;", conexion);
            cmd.Parameters.AddWithValue("@id", idAutor);
            cmd.ExecuteNonQuery();
        }

        // =========================================================================
        // 3. CRUD DE LIBROS (Con INNER JOIN a Autores y Categorías)
        // =========================================================================
        public List<Libro> ListarLibros(string filtroTexto = "", int idCategoria = 0, int idAutor = 0)
        {
            List<Libro> lista = new List<Libro>();
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
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

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@texto", filtroTexto.Trim());
            cmd.Parameters.AddWithValue("@idCat", idCategoria);
            cmd.Parameters.AddWithValue("@idAut", idAutor);

            using MySqlDataReader reader = cmd.ExecuteReader();
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
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                INSERT INTO Libros (ISBN, Titulo, IdAutor, IdCategoria, AnioPublicacion, StockTotal, StockDisponible)
                VALUES (@isbn, @titulo, @idAutor, @idCategoria, @anio, @stockTotal, @stockDisponible);";

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@isbn", libro.ISBN.Trim());
            cmd.Parameters.AddWithValue("@titulo", libro.Titulo.Trim());
            cmd.Parameters.AddWithValue("@idAutor", libro.IdAutor);
            cmd.Parameters.AddWithValue("@idCategoria", libro.IdCategoria);
            cmd.Parameters.AddWithValue("@anio", libro.AnioPublicacion);
            cmd.Parameters.AddWithValue("@stockTotal", libro.StockTotal);
            cmd.Parameters.AddWithValue("@stockDisponible", libro.StockDisponible);
            cmd.ExecuteNonQuery();
        }

        public void ActualizarLibro(Libro libro)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
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

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@isbn", libro.ISBN.Trim());
            cmd.Parameters.AddWithValue("@titulo", libro.Titulo.Trim());
            cmd.Parameters.AddWithValue("@idAutor", libro.IdAutor);
            cmd.Parameters.AddWithValue("@idCategoria", libro.IdCategoria);
            cmd.Parameters.AddWithValue("@anio", libro.AnioPublicacion);
            cmd.Parameters.AddWithValue("@stockTotal", libro.StockTotal);
            cmd.Parameters.AddWithValue("@stockDisponible", libro.StockDisponible);
            cmd.Parameters.AddWithValue("@id", libro.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminarLibro(int idLibro)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            using (MySqlCommand cmdValidar = new MySqlCommand("SELECT COUNT(*) FROM Prestamos WHERE IdLibro = @id;", conexion))
            {
                cmdValidar.Parameters.AddWithValue("@id", idLibro);
                long prestamosAsociados = Convert.ToInt64(cmdValidar.ExecuteScalar() ?? 0L);
                if (prestamosAsociados > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el libro porque tiene historial de préstamos registrados.");
                }
            }

            using MySqlCommand cmd = new MySqlCommand("DELETE FROM Libros WHERE Id = @id;", conexion);
            cmd.Parameters.AddWithValue("@id", idLibro);
            cmd.ExecuteNonQuery();
        }

        // =========================================================================
        // 4. CRUD DE LECTORES (Estudiantes y Docentes)
        // =========================================================================
        public List<Lector> ListarLectores(string filtroTexto = "", bool soloActivos = false)
        {
            List<Lector> lista = new List<Lector>();
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                SELECT Id, NombreCompleto, Documento, Email, TipoLector, Telefono, Activo
                FROM Lectores
                WHERE (@texto = '' OR NombreCompleto LIKE CONCAT('%', @texto, '%') OR Documento LIKE CONCAT('%', @texto, '%'))
                  AND (@soloActivos = 0 OR Activo = 1)
                ORDER BY NombreCompleto;";

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@texto", filtroTexto.Trim());
            cmd.Parameters.AddWithValue("@soloActivos", soloActivos ? 1 : 0);

            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                lista.Add(new Lector(
                    id: reader.GetInt32(0),
                    nombreCompleto: reader.GetString(1),
                    documento: reader.GetString(2),
                    email: reader.GetString(3),
                    tipoLector: reader.GetString(4),
                    telefono: reader.GetString(5),
                    activo: reader.GetInt32(6) == 1
                ));
            }
            return lista;
        }

        public void InsertarLector(Lector lector)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                INSERT INTO Lectores (NombreCompleto, Documento, Email, TipoLector, Telefono, Activo)
                VALUES (@nombre, @documento, @email, @tipo, @telefono, @activo);";

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", lector.NombreCompleto.Trim());
            cmd.Parameters.AddWithValue("@documento", lector.Documento.Trim());
            cmd.Parameters.AddWithValue("@email", lector.Email.Trim());
            cmd.Parameters.AddWithValue("@tipo", lector.TipoLector);
            cmd.Parameters.AddWithValue("@telefono", lector.Telefono.Trim());
            cmd.Parameters.AddWithValue("@activo", lector.Activo ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void ActualizarLector(Lector lector)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
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

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", lector.NombreCompleto.Trim());
            cmd.Parameters.AddWithValue("@documento", lector.Documento.Trim());
            cmd.Parameters.AddWithValue("@email", lector.Email.Trim());
            cmd.Parameters.AddWithValue("@tipo", lector.TipoLector);
            cmd.Parameters.AddWithValue("@telefono", lector.Telefono.Trim());
            cmd.Parameters.AddWithValue("@activo", lector.Activo ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", lector.Id);
            cmd.ExecuteNonQuery();
        }

        public void EliminarLector(int idLector)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            using (MySqlCommand cmdValidar = new MySqlCommand("SELECT COUNT(*) FROM Prestamos WHERE IdLector = @id;", conexion))
            {
                cmdValidar.Parameters.AddWithValue("@id", idLector);
                long prestamos = Convert.ToInt64(cmdValidar.ExecuteScalar() ?? 0L);
                if (prestamos > 0)
                {
                    throw new InvalidOperationException("No se puede eliminar el lector porque tiene préstamos asociados. Puede desactivarlo desmarcando la casilla 'Activo'.");
                }
            }

            using MySqlCommand cmd = new MySqlCommand("DELETE FROM Lectores WHERE Id = @id;", conexion);
            cmd.Parameters.AddWithValue("@id", idLector);
            cmd.ExecuteNonQuery();
        }
    }
}
