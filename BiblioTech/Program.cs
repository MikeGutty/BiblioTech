using BiblioTech.Datos;
using BiblioTech.Formularios;

namespace BiblioTech
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal de la aplicación BiblioTech.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                // 1. Crea la base de datos MySQL (bibliotech), las 7 tablas y los datos de ejemplo si no existen
                ConexionBD.InicializarBaseDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo conectar al servidor MySQL ({ConexionBD.Servidor}:{ConexionBD.Puerto}).\n\n" +
                    "Asegúrese de que el servicio MySQL (ej. XAMPP, WAMP o MySQL Server) esté encendido y verifique las credenciales en ConexionBD.cs.\n\n" +
                    $"Detalle técnico: {ex.Message}",
                    "Error de Conexión a MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            // 2. Inicia con el Módulo 1: Formulario de Login
            Application.Run(new FrmLogin());
        }
    }
}
