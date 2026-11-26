using MySqlConnector;

namespace BiblioTech.Datos
{
    /// Clase encargada de gestionar la conexión a la base de datos MySQL (bibliotech).
    /// Si la base de datos o las tablas no existen, las crea automáticamente e inserta datos de ejemplo.
    public static class ConexionBD
    {
        // Parámetros de conexión a MySQL en la nube (Aiven)
        public static string Servidor { get; set; } = "mysql-15b9c7e7-lanselot777hailander-1948.e.aivencloud.com";
        public static string Puerto { get; set; } = "18260";
        public static string BaseDatos { get; set; } = "bibliotech";
        public static string Usuario { get; set; } = "avnadmin";
        public static string Contrasena { get; set; } = CargarContrasenaLocal();

        private static string CargarContrasenaLocal()
        {
            string[] rutasPosibles =
            {
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "db.secret.txt"),
                Path.Combine(Directory.GetCurrentDirectory(), "db.secret.txt"),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\db.secret.txt")),
                Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\db.secret.txt"))
            };

            foreach (string ruta in rutasPosibles)
            {
                if (File.Exists(ruta))
                {
                    return File.ReadAllText(ruta).Trim();
                }
            }

            return Environment.GetEnvironmentVariable("BIBLIOTECH_DB_PASSWORD") ?? "";
        }

        private static string CadenaConexionServidor =>
            $"Server={Servidor};Port={Puerto};User ID={Usuario};Password={Contrasena};SslMode=Required;AllowUserVariables=True;";

        private static string CadenaConexion =>
            $"Server={Servidor};Port={Puerto};Database={BaseDatos};User ID={Usuario};Password={Contrasena};SslMode=Required;AllowUserVariables=True;";

        /// Devuelve una nueva conexión a MySQL lista para abrirse con connection.Open().
        public static MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(CadenaConexion);
        }

        /// Se llama al iniciar el programa (en Program.cs) para asegurar que la base de datos y las tablas existan en MySQL.
        public static void InicializarBaseDeDatos()
        {
            // 1. Nos conectamos al servidor MySQL para crear la base de datos si aún no existe
            using (MySqlConnection conexionServidor = new MySqlConnection(CadenaConexionServidor))
            {
                conexionServidor.Open();
                string sqlCrearBD = $"CREATE DATABASE IF NOT EXISTS `{BaseDatos}` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;";
                using MySqlCommand cmdCrearBD = new MySqlCommand(sqlCrearBD, conexionServidor);
                cmdCrearBD.ExecuteNonQuery();
            }

            // 2. Nos conectamos a la base de datos bibliotech y creamos las tablas si no existen
            using MySqlConnection conexion = ObtenerConexion();
            conexion.Open();

            string scriptTablas = @"
                CREATE TABLE IF NOT EXISTS Configuracion (
                    Id INT PRIMARY KEY CHECK (Id = 1),
                    NombreBiblioteca VARCHAR(150) NOT NULL,
                    DiasMaximoPrestamo INT NOT NULL,
                    MultaPorDiaRetraso DECIMAL(10, 2) NOT NULL
                ) ENGINE=InnoDB;

                CREATE TABLE IF NOT EXISTS Usuarios (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    NombreCompleto VARCHAR(120) NOT NULL,
                    Documento VARCHAR(50) NOT NULL,
                    Email VARCHAR(120) NOT NULL,
                    NombreUsuario VARCHAR(60) NOT NULL UNIQUE,
                    Contrasena VARCHAR(120) NOT NULL,
                    Rol VARCHAR(40) NOT NULL,
                    Activo TINYINT(1) NOT NULL DEFAULT 1
                ) ENGINE=InnoDB;

                CREATE TABLE IF NOT EXISTS Categorias (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    Nombre VARCHAR(100) NOT NULL UNIQUE,
                    Descripcion VARCHAR(255) NOT NULL
                ) ENGINE=InnoDB;

                CREATE TABLE IF NOT EXISTS Autores (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    NombreCompleto VARCHAR(120) NOT NULL,
                    Nacionalidad VARCHAR(80) NOT NULL
                ) ENGINE=InnoDB;

                CREATE TABLE IF NOT EXISTS Libros (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    ISBN VARCHAR(40) NOT NULL UNIQUE,
                    Titulo VARCHAR(200) NOT NULL,
                    IdAutor INT NOT NULL,
                    IdCategoria INT NOT NULL,
                    AnioPublicacion INT NOT NULL,
                    StockTotal INT NOT NULL,
                    StockDisponible INT NOT NULL,
                    FOREIGN KEY (IdAutor) REFERENCES Autores(Id),
                    FOREIGN KEY (IdCategoria) REFERENCES Categorias(Id)
                ) ENGINE=InnoDB;

                CREATE TABLE IF NOT EXISTS Lectores (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    NombreCompleto VARCHAR(120) NOT NULL,
                    Documento VARCHAR(50) NOT NULL UNIQUE,
                    Email VARCHAR(120) NOT NULL,
                    TipoLector VARCHAR(40) NOT NULL,
                    Telefono VARCHAR(40) NOT NULL,
                    Activo TINYINT(1) NOT NULL DEFAULT 1
                ) ENGINE=InnoDB;

                CREATE TABLE IF NOT EXISTS Prestamos (
                    Id INT PRIMARY KEY AUTO_INCREMENT,
                    IdLibro INT NOT NULL,
                    IdLector INT NOT NULL,
                    IdUsuarioRegistro INT NOT NULL,
                    FechaPrestamo VARCHAR(20) NOT NULL,
                    FechaDevolucionEsperada VARCHAR(20) NOT NULL,
                    FechaDevolucionReal VARCHAR(20) NULL,
                    Estado VARCHAR(30) NOT NULL,
                    MultaPagada DECIMAL(10, 2) NOT NULL DEFAULT 0.00,
                    Observaciones VARCHAR(255) NOT NULL DEFAULT '',
                    FOREIGN KEY (IdLibro) REFERENCES Libros(Id),
                    FOREIGN KEY (IdLector) REFERENCES Lectores(Id),
                    FOREIGN KEY (IdUsuarioRegistro) REFERENCES Usuarios(Id)
                ) ENGINE=InnoDB;
            ";

            using (MySqlCommand cmdTablas = new MySqlCommand(scriptTablas, conexion))
            {
                cmdTablas.ExecuteNonQuery();
            }

            // 3. Verificamos si ya existen usuarios; si no hay ninguno, insertamos los datos semilla (Seed Data)
            using MySqlCommand cmdContar = new MySqlCommand("SELECT COUNT(*) FROM Usuarios;", conexion);
            long totalUsuarios = Convert.ToInt64(cmdContar.ExecuteScalar() ?? 0L);

            if (totalUsuarios == 0)
            {
                InsertarDatosSemilla(conexion);
            }
        }

        /// Inserta datos iniciales para que los alumnos puedan probar todos los módulos desde el primer momento.
        private static void InsertarDatosSemilla(MySqlConnection conexion)
        {
            string fechaHoy = DateTime.Today.ToString("yyyy-MM-dd");
            string fechaMas7Dias = DateTime.Today.AddDays(7).ToString("yyyy-MM-dd");
            string fechaHace10Dias = DateTime.Today.AddDays(-10).ToString("yyyy-MM-dd");
            string fechaHace3Dias = DateTime.Today.AddDays(-3).ToString("yyyy-MM-dd");

            string scriptSemilla = $@"
                -- Configuración inicial
                INSERT INTO Configuracion (Id, NombreBiblioteca, DiasMaximoPrestamo, MultaPorDiaRetraso)
                VALUES (1, 'BiblioTech Universitaria - Facultad de Ingeniería', 7, 5.00);

                -- Usuarios del sistema (Administrador y Bibliotecario)
                INSERT INTO Usuarios (NombreCompleto, Documento, Email, NombreUsuario, Contrasena, Rol, Activo) VALUES
                ('Carlos Mendoza (Admin)', '10020030', 'admin@bibliotech.edu', 'admin', '1234', 'Administrador', 1),
                ('Ana Gómez (Bibliotecaria)', '40050060', 'biblio@bibliotech.edu', 'biblio', '1234', 'Bibliotecario', 1);

                -- Categorías
                INSERT INTO Categorias (Nombre, Descripcion) VALUES
                ('Programación y Software', 'Libros de algoritmos, POO, lenguajes y arquitectura de software'),
                ('Bases de Datos', 'Modelado relacional, SQL y administración de datos'),
                ('Matemáticas y Lógica', 'Cálculo, álgebra lineal y matemática discreta'),
                ('Literatura Clásica', 'Obras literarias universales y novelas');

                -- Autores
                INSERT INTO Autores (NombreCompleto, Nacionalidad) VALUES
                ('Robert C. Martin (Uncle Bob)', 'Estados Unidos'),
                ('Luis Joyanes Aguilar', 'España'),
                ('Thomas H. Cormen', 'Estados Unidos'),
                ('Gabriel García Márquez', 'Colombia'),
                ('Grady Booch', 'Estados Unidos');

                -- Libros
                INSERT INTO Libros (ISBN, Titulo, IdAutor, IdCategoria, AnioPublicacion, StockTotal, StockDisponible) VALUES
                ('978-8448198442', 'Fundamentos de Programación: Algoritmos y Estructuras', 2, 1, 2020, 5, 4),
                ('978-0132350884', 'Clean Code: Manual de estilo para el desarrollo ágil', 1, 1, 2008, 3, 2),
                ('978-0262033848', 'Introducción a los Algoritmos (CLRS)', 3, 3, 2009, 4, 4),
                ('978-0307474728', 'Cien años de soledad', 4, 4, 1967, 3, 3),
                ('978-0201895513', 'Análisis y Diseño Orientado a Objetos con Aplicaciones', 5, 1, 2007, 2, 2);

                -- Lectores (Estudiantes y Docentes)
                INSERT INTO Lectores (NombreCompleto, Documento, Email, TipoLector, Telefono, Activo) VALUES
                ('Lucía Fernández Rojas', 'EST-202601', 'lucia.fernandez@uni.edu', 'Estudiante', '70011223', 1),
                ('Mateo Quispe Vargas', 'EST-202602', 'mateo.quispe@uni.edu', 'Estudiante', '70044556', 1),
                ('Ing. Roberto Salazar', 'DOC-1045', 'roberto.salazar@uni.edu', 'Docente', '71122334', 1),
                ('Sofía Torrez Camacho', 'EST-202603', 'sofia.torrez@uni.edu', 'Estudiante', '72288990', 1);

                -- Préstamos de ejemplo:
                -- 1) Un préstamo activo al día (Libro 1 a Lucía)
                INSERT INTO Prestamos (IdLibro, IdLector, IdUsuarioRegistro, FechaPrestamo, FechaDevolucionEsperada, FechaDevolucionReal, Estado, MultaPagada, Observaciones)
                VALUES (1, 1, 1, '{fechaHoy}', '{fechaMas7Dias}', NULL, 'Activo', 0, 'Préstamo regular para estudio de primer parcial');

                -- 2) Un préstamo activo pero VENCIDO (Libro 2 a Mateo, venció hace 3 días para probar el cálculo de multas)
                INSERT INTO Prestamos (IdLibro, IdLector, IdUsuarioRegistro, FechaPrestamo, FechaDevolucionEsperada, FechaDevolucionReal, Estado, MultaPagada, Observaciones)
                VALUES (2, 2, 2, '{fechaHace10Dias}', '{fechaHace3Dias}', NULL, 'Activo', 0, 'Ejemplar en buen estado');
            ";

            using MySqlCommand cmdSemilla = new MySqlCommand(scriptSemilla, conexion);
            cmdSemilla.ExecuteNonQuery();
        }
    }
}
