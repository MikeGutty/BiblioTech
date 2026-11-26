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
                    $"No se pudo conectar al servidor MySQL ({ConexionBD.Servidor}:{ConexionBD.Puerto}).\n\n" +
                    "Verifique que el servicio MySQL esté activo y revise los parámetros en ConexionBD.cs.\n\n" +
                    $"Detalle: {ex.Message}",
                    "Error de Conexión a MySQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmLogin());
        }
    }
}
