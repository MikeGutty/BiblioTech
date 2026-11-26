# BiblioTech - Sistema de Gestión Bibliotecaria

Aplicación de escritorio desarrollada en **C# (.NET 10 / Windows Forms)** con base de datos **MySQL**, estructurada en 3 capas (`Modelos`, `Datos` y `Formularios`) aplicando Programación Orientada a Objetos.

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
- `Datos/`: Conexión y consultas SQL con `MySqlConnector` (`ConexionBD`, `UsuarioDatos`, `CatalogoDatos`, `PrestamoDatos`, `ConfiguracionDatos`).
- `Formularios/`: Interfaz gráfica en Windows Forms (`FrmLogin`, `FrmPrincipal`, `FrmLibros`, `FrmCategoriasAutores`, `FrmLectores`, `FrmPrestamos`, `FrmAdministracion`).

## Configuración de la Base de Datos

Al iniciar la aplicación, `ConexionBD.InicializarBaseDeDatos()` verifica que exista el esquema `bibliotech`, crea las tablas si no existen y carga datos de prueba iniciales.

Para conectar a la instancia configurada en `ConexionBD.cs`:
1. Crear un archivo `db.secret.txt` en la raíz del proyecto con la contraseña de MySQL.
2. Si se prefiere trabajar con un servidor MySQL local (por ejemplo XAMPP o MySQL Workbench), modificar los parámetros en `BiblioTech/Datos/ConexionBD.cs` (`Servidor = "localhost"`, `Puerto = "3306"`, `Usuario = "root"`, `Contrasena = ""`) y quitar `SslMode=Required;` de la cadena de conexión.

## Usuarios de Prueba

| Rol | Usuario | Contraseña |
| :--- | :--- | :--- |
| Administrador | `admin` | `1234` |
| Bibliotecario | `biblio` | `1234` |

## Requisitos

- Visual Studio 2022 / 2026 o .NET SDK 10.0 en Windows.
- Paquete NuGet `MySqlConnector` (2.5.0).
