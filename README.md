# 📚 BiblioTech - Sistema de Gestión Bibliotecaria Universitaria

**BiblioTech** es una aplicación de escritorio desarrollada en **C# (.NET 10 / Windows Forms)** con conexión a **MySQL en la nube (Aiven)**, diseñada bajo una **Arquitectura en 3 Capas** y aplicando los **4 pilares de la Programación Orientada a Objetos (POO)**.

---

## 🚀 Características y Módulos del Sistema

El sistema está dividido en **4 módulos integrados**:

### 1. 🔐 Módulo de Autenticación y Usuarios (Login y Roles)
- Inicio de sesión con validación de credenciales y verificación de estado (`Activo` / `Inactivo`).
- Control de acceso basado en roles:
  - **Administrador**: Acceso total al catálogo, lectores, préstamos y panel de administración del sistema.
  - **Bibliotecario**: Acceso operativo a catálogo, registro de lectores, préstamos y devoluciones.

### 2. 📖 Módulo de Catálogo Bibliográfico y Lectores
- **Gestión de Libros**: Registro, edición y búsqueda por ISBN, título, autor o categoría, con control automático de `StockTotal` y `StockDisponible`.
- **Gestión de Autores y Categorías**: Mantenimiento de catálogos auxiliares relacionados.
- **Gestión de Lectores**: Registro de **Estudiantes** y **Docentes** con reglas de negocio diferenciadas (límite de libros simultáneos según el tipo de lector).

### 3. 🔄 Módulo de Préstamos y Devoluciones (Transaccional)
- **Registro de Préstamos**:
  - Validación automática de stock disponible del libro.
  - Validación del límite máximo de préstamos activos según el tipo de lector (**Estudiante**: máx. 3 libros | **Docente**: máx. 5 libros).
  - Transacción SQL (`MySqlTransaction`) que registra el préstamo y descuenta en `1` el stock disponible de forma atómica.
- **Recepción y Devoluciones**:
  - Detección automática de préstamos vencidos.
  - Cálculo automático de días de retraso y monto de multa según la tarifa diaria configurada.
  - Transacción SQL que actualiza el estado a `Devuelto`, registra la fecha real y la multa cobrada, y repone `+1` al stock disponible del ejemplar.

### 4. 📊 Módulo de Consultas, Dashboard y Administración
- **Panel de Control (Dashboard)**: Indicadores en tiempo real de *Títulos Registrados*, *Ejemplares Disponibles*, *Préstamos Activos* y *Préstamos Vencidos*.
- **Buscador General**: Consulta rápida de disponibilidad en todo el catálogo.
- **Administración**: Gestión de usuarios del sistema y configuración de parámetros globales (nombre de la biblioteca, días máximos de préstamo y multa diaria por retraso).

---

## 🏗️ Arquitectura y Programación Orientada a Objetos (POO)

El proyecto implementa una **Arquitectura en 3 Capas**:

```text
BiblioTech/
├── Modelos/        # Capa de Dominio y Lógica de Negocio (POO)
│   ├── Persona.cs              # Clase base abstracta
│   ├── UsuarioSistema.cs       # Hereda de Persona (operadores del sistema)
│   ├── Lector.cs               # Hereda de Persona (Estudiantes y Docentes)
│   ├── Libro.cs                # Entidad Libro con validación de disponibilidad
│   ├── Autor.cs                # Entidad Autor
│   ├── Categoria.cs            # Entidad Categoría
│   ├── Prestamo.cs             # Lógica de vencimientos y cálculo de multas
│   └── ConfiguracionSistema.cs # Parámetros globales de la biblioteca
│
├── Datos/          # Capa de Acceso a Datos (DAO + MySqlConnector)
│   ├── ConexionBD.cs           # Conexión MySQL (Aiven SSL), creación de BD y Seed Data
│   ├── UsuarioDatos.cs         # Consultas y CRUD de Usuarios y Lectores
│   ├── CatalogoDatos.cs        # Consultas y CRUD de Libros, Autores y Categorías
│   ├── PrestamoDatos.cs        # Transacciones SQL de préstamos, devoluciones y KPIs
│   └── ConfiguracionDatos.cs   # Lectura y guardado de parámetros del sistema
│
└── Formularios/    # Capa de Presentación (Windows Forms UI)
    ├── FrmLogin.cs             # Inicio de sesión
    ├── FrmPrincipal.cs         # Dashboard principal y navegación por módulos
    ├── FrmLibros.cs            # Gestión del catálogo de libros
    ├── FrmCategoriasAutores.cs # Gestión de autores y categorías
    ├── FrmLectores.cs          # Gestión de lectores
    ├── FrmPrestamos.cs         # Operaciones de préstamo y devolución
    └── FrmAdministracion.cs    # Gestión de usuarios y configuración
```

### Pilares de POO Aplicados:
1. **Abstracción**: La clase abstracta `Persona` define la estructura base común para cualquier persona dentro del sistema sin permitir su instanciación directa.
2. **Herencia**: `UsuarioSistema` y `Lector` heredan atributos y constructores de `Persona` (`: Persona`).
3. **Polimorfismo**: El método virtual `ObtenerResumen()` en `Persona` es sobrescrito (`override`) en `UsuarioSistema` y `Lector` para adaptar su comportamiento según la clase hija.
4. **Encapsulamiento**: Cada modelo protege su estado y expone métodos de negocio claros (`EstaVencido()`, `CalcularMulta()`, `ObtenerLimiteLibros()`, `TieneEjemplaresDisponibles()`).

---

## 🗄️ Base de Datos MySQL (Aiven Cloud / Local)

El sistema utiliza **MySQL** a través del paquete NuGet `MySqlConnector`. Al iniciar la aplicación (`ConexionBD.InicializarBaseDeDatos()`), el sistema crea automáticamente el esquema `bibliotech`, las **7 tablas relacionales (`InnoDB`)** y carga los **datos semilla (Seed Data)** si la base está vacía.

### Configuración de la contraseña (Aiven Cloud)
Por seguridad en repositorios públicos, la contraseña de la base de datos en la nube no se sube al repositorio:
1. Crea un archivo llamado `db.secret.txt` en la raíz de la solución (`BiblioTech/db.secret.txt`).
2. Pega dentro únicamente la contraseña del servidor MySQL de Aiven (o define la variable de entorno `BIBLIOTECH_DB_PASSWORD`).
3. *(Opcional)* Si deseas usar **MySQL local (XAMPP / Workbench)**, cambia los valores en `BiblioTech/Datos/ConexionBD.cs` a `Servidor = "localhost"`, `Puerto = "3306"`, `Usuario = "root"`, `Contrasena = ""` y quita `SslMode=Required;`.

---

## 🔑 Credenciales de Prueba (Seed Data)

Al ejecutar el proyecto por primera vez, puedes iniciar sesión con cualquiera de las siguientes cuentas preconfiguradas:

| Rol | Usuario | Contraseña | Permisos |
| :--- | :---: | :---: | :--- |
| **Administrador** | `admin` | `1234` | Acceso completo (incluye Módulo de Administración) |
| **Bibliotecario** | `biblio` | `1234` | Acceso a Catálogo, Lectores, Préstamos y Consultas |

---

## 🛠️ Requisitos para Ejecutar

- **Visual Studio 2022 / 2026** o **.NET SDK 10.0** en Windows.
- Paquete NuGet: `MySqlConnector` (v2.5.0).
- Conexión a Internet (para conectar a la instancia MySQL de Aiven) o servidor MySQL local.
