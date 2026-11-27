using System.Data.Common;
using Microsoft.Data.SqlClient;
using MySqlConnector;

namespace BiblioTech.Datos
{
    // Motores de base de datos soportados por el proyecto
    public enum MotorBD
    {
        MySQL,
        SqlServer
    }

    // Gestiona la conexión a la base de datos (MySQL o SQL Server) y la creación inicial de tablas
    public static class ConexionBD
    {
        // =========================================================================
        // 1. SELECCIÓN DEL MOTOR DE BASE DE DATOS
        // Cambie entre MotorBD.MySQL y MotorBD.SqlServer según lo que necesite usar
        // =========================================================================
        public static MotorBD MotorActual { get; set; } = MotorBD.SqlServer;

        // Nombre de la base de datos (común para ambos motores)
        public static string BaseDatos { get; set; } = "bibliotech";

        // =========================================================================
        // 2. PARÁMETROS PARA MYSQL
        // =========================================================================
        public static string Servidor { get; set; } = "mysql-15b9c7e7-lanselot777hailander-1948.e.aivencloud.com";
        public static string Puerto { get; set; } = "18260";
        public static string Usuario { get; set; } = "avnadmin";
        public static string Contrasena { get; set; } = CargarContrasenaLocal();
        public static bool UsarSslMySql { get; set; } = true; // Cambiar a false si usa XAMPP / MySQL local sin SSL

        // =========================================================================
        // 3. PARÁMETROS PARA SQL SERVER
        // Ejemplos de ServidorSqlServer: "localhost", "localhost\\SQLEXPRESS", "."
        // =========================================================================
        public static string ServidorSqlServer { get; set; } = "localhost";
        public static bool AutenticacionWindowsSqlServer { get; set; } = true; // true = Windows Authentication, false = SQL Server Authentication
        public static bool ConfiarCertificadoSqlServer { get; set; } = true; // Trust Server Certificate
        public static string UsuarioSqlServer { get; set; } = "sa";
        public static string ContrasenaSqlServer { get; set; } = "1234";

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

        // Cadena de conexión hacia el servidor (sin especificar la base de datos o apuntando a master) para poder crear la BD
        private static string CadenaConexionServidor
        {
            get
            {
                if (MotorActual == MotorBD.SqlServer)
                {
                    return ConstruirCadenaSqlServer("master");
                }

                string ssl = UsarSslMySql ? "SslMode=Required;" : "SslMode=None;";
                return $"Server={Servidor};Port={Puerto};User ID={Usuario};Password={Contrasena};{ssl}AllowUserVariables=True;";
            }
        }

        // Cadena de conexión hacia la base de datos de la aplicación
        private static string CadenaConexion
        {
            get
            {
                if (MotorActual == MotorBD.SqlServer)
                {
                    return ConstruirCadenaSqlServer(BaseDatos);
                }

                string ssl = UsarSslMySql ? "SslMode=Required;" : "SslMode=None;";
                return $"Server={Servidor};Port={Puerto};Database={BaseDatos};User ID={Usuario};Password={Contrasena};{ssl}AllowUserVariables=True;";
            }
        }

        private static string ConstruirCadenaSqlServer(string nombreBaseDatos)
        {
            string trustCert = ConfiarCertificadoSqlServer ? "True" : "False";

            if (AutenticacionWindowsSqlServer)
            {
                return $"Server={ServidorSqlServer};Database={nombreBaseDatos};Integrated Security=True;TrustServerCertificate={trustCert};";
            }
            return $"Server={ServidorSqlServer};Database={nombreBaseDatos};User ID={UsuarioSqlServer};Password={ContrasenaSqlServer};TrustServerCertificate={trustCert};";
        }

        public static string ObtenerResumenDestino()
        {
            return MotorActual == MotorBD.SqlServer
                ? $"SQL Server ({ServidorSqlServer})"
                : $"MySQL ({Servidor}:{Puerto})";
        }

        // Devuelve una conexión abierta/lista según el motor seleccionado (Polimorfismo ADO.NET con DbConnection)
        public static DbConnection ObtenerConexion()
        {
            if (MotorActual == MotorBD.SqlServer)
            {
                return new SqlConnection(CadenaConexion);
            }
            return new MySqlConnection(CadenaConexion);
        }

        private static DbConnection ObtenerConexionServidor()
        {
            if (MotorActual == MotorBD.SqlServer)
            {
                return new SqlConnection(CadenaConexionServidor);
            }
            return new MySqlConnection(CadenaConexionServidor);
        }

        // Crea un comando SQL asociado a la conexión y transacción opcional
        public static DbCommand CrearComando(string sql, DbConnection conexion, DbTransaction? transaccion = null)
        {
            DbCommand cmd = conexion.CreateCommand();
            cmd.CommandText = sql;
            if (transaccion != null)
            {
                cmd.Transaction = transaccion;
            }
            return cmd;
        }

        // Método auxiliar para agregar parámetros de forma compatible con cualquier motor ADO.NET
        public static void AgregarParametro(DbCommand cmd, string nombre, object? valor)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = nombre;
            param.Value = valor ?? DBNull.Value;
            cmd.Parameters.Add(param);
        }

        // Verifica que la base de datos y las tablas existan al iniciar la aplicación
        public static void InicializarBaseDeDatos()
        {
            // 1. Crear la base de datos si no existe
            using (DbConnection conexionServidor = ObtenerConexionServidor())
            {
                conexionServidor.Open();
                string sqlCrearBD = MotorActual == MotorBD.SqlServer
                    ? $"IF DB_ID(N'{BaseDatos}') IS NULL CREATE DATABASE [{BaseDatos}];"
                    : $"CREATE DATABASE IF NOT EXISTS `{BaseDatos}` CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;";

                using DbCommand cmdCrearBD = CrearComando(sqlCrearBD, conexionServidor);
                cmdCrearBD.ExecuteNonQuery();
            }

            // 2. Conectar a la base de datos y crear las tablas si no existen
            using DbConnection conexion = ObtenerConexion();
            conexion.Open();

            string scriptTablas = MotorActual == MotorBD.SqlServer
                ? ObtenerScriptTablasSqlServer()
                : ObtenerScriptTablasMySql();

            using (DbCommand cmdTablas = CrearComando(scriptTablas, conexion))
            {
                cmdTablas.ExecuteNonQuery();
            }

            // 3. Si la tabla de usuarios está vacía, cargamos los registros de prueba
            using DbCommand cmdContar = CrearComando("SELECT COUNT(*) FROM Usuarios;", conexion);
            long totalUsuarios = Convert.ToInt64(cmdContar.ExecuteScalar() ?? 0L);

            if (totalUsuarios == 0)
            {
                InsertarDatosIniciales(conexion);
            }
        }

        private static string ObtenerScriptTablasMySql()
        {
            return @"
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
        }

        private static string ObtenerScriptTablasSqlServer()
        {
            return @"
                IF OBJECT_ID(N'dbo.Configuracion', N'U') IS NULL
                CREATE TABLE Configuracion (
                    Id INT PRIMARY KEY CHECK (Id = 1),
                    NombreBiblioteca VARCHAR(150) NOT NULL,
                    DiasMaximoPrestamo INT NOT NULL,
                    MultaPorDiaRetraso DECIMAL(10, 2) NOT NULL
                );

                IF OBJECT_ID(N'dbo.Usuarios', N'U') IS NULL
                CREATE TABLE Usuarios (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    NombreCompleto VARCHAR(120) NOT NULL,
                    Documento VARCHAR(50) NOT NULL,
                    Email VARCHAR(120) NOT NULL,
                    NombreUsuario VARCHAR(60) NOT NULL UNIQUE,
                    Contrasena VARCHAR(120) NOT NULL,
                    Rol VARCHAR(40) NOT NULL,
                    Activo INT NOT NULL DEFAULT 1
                );

                IF OBJECT_ID(N'dbo.Categorias', N'U') IS NULL
                CREATE TABLE Categorias (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Nombre VARCHAR(100) NOT NULL UNIQUE,
                    Descripcion VARCHAR(255) NOT NULL
                );

                IF OBJECT_ID(N'dbo.Autores', N'U') IS NULL
                CREATE TABLE Autores (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    NombreCompleto VARCHAR(120) NOT NULL,
                    Nacionalidad VARCHAR(80) NOT NULL
                );

                IF OBJECT_ID(N'dbo.Libros', N'U') IS NULL
                CREATE TABLE Libros (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    ISBN VARCHAR(40) NOT NULL UNIQUE,
                    Titulo VARCHAR(200) NOT NULL,
                    IdAutor INT NOT NULL,
                    IdCategoria INT NOT NULL,
                    AnioPublicacion INT NOT NULL,
                    StockTotal INT NOT NULL,
                    StockDisponible INT NOT NULL,
                    FOREIGN KEY (IdAutor) REFERENCES Autores(Id),
                    FOREIGN KEY (IdCategoria) REFERENCES Categorias(Id)
                );

                IF OBJECT_ID(N'dbo.Lectores', N'U') IS NULL
                CREATE TABLE Lectores (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    NombreCompleto VARCHAR(120) NOT NULL,
                    Documento VARCHAR(50) NOT NULL UNIQUE,
                    Email VARCHAR(120) NOT NULL,
                    TipoLector VARCHAR(40) NOT NULL,
                    Telefono VARCHAR(40) NOT NULL,
                    Activo INT NOT NULL DEFAULT 1
                );

                IF OBJECT_ID(N'dbo.Prestamos', N'U') IS NULL
                CREATE TABLE Prestamos (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
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
                );
            ";
        }

        // Carga datos iniciales de prueba (compatible con MySQL y SQL Server)
        private static void InsertarDatosIniciales(DbConnection conexion)
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

            using DbCommand cmdSemilla = CrearComando(scriptSemilla, conexion);
            cmdSemilla.ExecuteNonQuery();
        }
    }
}
