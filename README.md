# BiblioTech - Sistema de Gestión Bibliotecaria

Aplicación de escritorio desarrollada en **C# (.NET 10 / Windows Forms)** con soporte para bases de datos **MySQL** y **SQL Server**, estructurada en 3 capas (`Modelos`, `Datos` y `Formularios`) aplicando Programación Orientada a Objetos y polimorfismo en ADO.NET (`System.Data.Common`).

## Funcionalidades Principales

1. **Autenticación y Roles**
   - Inicio de sesión con validación de usuario activo.
   - Roles de **Administrador** (acceso total y configuración) y **Bibliotecario** (operaciones de catálogo, lectores y préstamos).

2. **Catálogo y Lectores**
   - ABM de Libros con control de stock total y stock disponible.
   - ABM de Autores y Categorías.
   - Registro de Lectores (Estudiantes y Docentes) con límite de préstamos simultáneos según el tipo (3 para estudiantes, 5 para docentes).

3. **Préstamos y Devoluciones**
   - Registro de préstamos validando disponibilidad de ejemplares y cupo del lector.
   - Devolución de libros con cálculo de días de retraso y multa según la tarifa diaria configurada.
   - Actualización de stock mediante transacciones SQL.

4. **Panel Principal y Administración**
   - Resumen de indicadores (títulos registrados, ejemplares disponibles, préstamos activos y vencidos).
   - Consultas y filtros por título, ISBN, autor, categoría y estado de préstamo.
   - Gestión de cuentas de usuario y parámetros de la biblioteca.

## Estructura del Proyecto

- `Modelos/`: Clases de dominio (`Persona`, `UsuarioSistema`, `Lector`, `Libro`, `Autor`, `Categoria`, `Prestamo`, `ConfiguracionSistema`).
- `Datos/`: Conexión y consultas SQL compatibles con MySQL y SQL Server (`ConexionBD`, `UsuarioDatos`, `CatalogoDatos`, `PrestamoDatos`, `ConfiguracionDatos`).
- `Formularios/`: Interfaz gráfica en Windows Forms (`FrmLogin`, `FrmPrincipal`, `FrmLibros`, `FrmCategoriasAutores`, `FrmLectores`, `FrmPrestamos`, `FrmAdministracion`).

## Configuración de la Base de Datos (MySQL o SQL Server)

Al iniciar la aplicación, `ConexionBD.InicializarBaseDeDatos()` verifica que exista la base de datos `bibliotech`, crea las tablas automáticamente según el motor elegido y carga datos de prueba iniciales.

Para elegir qué motor de base de datos utilizar, abra el archivo `BiblioTech/Datos/ConexionBD.cs` y modifique la propiedad `MotorActual`:

```csharp
// Para usar MySQL:
public static MotorBD MotorActual { get; set; } = MotorBD.MySQL;

// Para usar SQL Server:
public static MotorBD MotorActual { get; set; } = MotorBD.SqlServer;
```

### Opción A: Trabajar con SQL Server
En `BiblioTech/Datos/ConexionBD.cs` puede ajustar los parámetros en la sección **3. PARÁMETROS PARA SQL SERVER**:
- **Autenticación de Windows (por defecto)**:
  - `ServidorSqlServer = "localhost"` (o `@"localhost\SQLEXPRESS"`, `"."`, según su instancia).
  - `AutenticacionWindowsSqlServer = true` (Windows Authentication).
  - `ConfiarCertificadoSqlServer = true` (Trust Server Certificate).
- **Autenticación de SQL Server (Usuario y Contraseña)**:
  - Cambie `AutenticacionWindowsSqlServer = false` y configure `UsuarioSqlServer` (ej. `"sa"`) y `ContrasenaSqlServer`.

### Opción B: Trabajar con MySQL
En `BiblioTech/Datos/ConexionBD.cs` puede ajustar los parámetros en la sección **2. PARÁMETROS PARA MYSQL**:
1. Para conectar a la instancia en la nube configurada por defecto, asegúrese de tener el archivo `db.secret.txt` con la contraseña de MySQL y `UsarSslMySql = true`.
2. Si prefiere trabajar con un servidor MySQL local (por ejemplo XAMPP o MySQL Workbench), modifique:
   - `Servidor = "localhost"`, `Puerto = "3306"`, `Usuario = "root"`, `Contrasena = ""` y `UsarSslMySql = false`.

## Usuarios de Prueba

| Rol | Usuario | Contraseña |
| :--- | :--- | :--- |
| Administrador | `admin` | `1234` |
| Bibliotecario | `biblio` | `1234` |

## Requisitos

- Visual Studio 2022 / 2026 o .NET SDK 10.0 en Windows.
- Paquetes NuGet:
  - `MySqlConnector` (2.5.0)
  - `Microsoft.Data.SqlClient` (6.0.1)
