using BiblioTech.Datos;
using BiblioTech.Formularios;

namespace BiblioTech
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                ConexionBD.InicializarBaseDeDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo conectar al servidor {ConexionBD.ObtenerResumenDestino()}.\n\n" +
                    "Verifique que el servicio de base de datos esté activo y revise los parámetros en ConexionBD.cs.\n\n" +
                    $"Detalle: {ex.Message}",
                    $"Error de Conexión a {ConexionBD.MotorActual}",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmLogin());
        }
    }
}
