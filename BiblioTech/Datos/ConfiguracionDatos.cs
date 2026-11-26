using BiblioTech.Modelos;
using MySqlConnector;

namespace BiblioTech.Datos
{
    public class ConfiguracionDatos
    {
        public ConfiguracionSistema ObtenerConfiguracion()
        {
            ConfiguracionSistema config = new ConfiguracionSistema();

            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT NombreBiblioteca, DiasMaximoPrestamo, MultaPorDiaRetraso FROM Configuracion WHERE Id = 1;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            using MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                config.NombreBiblioteca = reader.GetString(0);
                config.DiasMaximoPrestamo = reader.GetInt32(1);
                config.MultaPorDiaRetraso = reader.GetDecimal(2);
            }

            return config;
        }

        public void GuardarConfiguracion(ConfiguracionSistema config)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                UPDATE Configuracion
                SET NombreBiblioteca = @nombre,
                    DiasMaximoPrestamo = @dias,
                    MultaPorDiaRetraso = @multa
                WHERE Id = 1;";

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", config.NombreBiblioteca);
            cmd.Parameters.AddWithValue("@dias", config.DiasMaximoPrestamo);
            cmd.Parameters.AddWithValue("@multa", config.MultaPorDiaRetraso);
            cmd.ExecuteNonQuery();
        }
    }
}
