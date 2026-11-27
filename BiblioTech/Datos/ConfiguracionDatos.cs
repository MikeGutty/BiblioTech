using System.Data.Common;
using BiblioTech.Modelos;

namespace BiblioTech.Datos
{
    public class ConfiguracionDatos
    {
        public ConfiguracionSistema ObtenerConfiguracion()
        {
            ConfiguracionSistema config = new ConfiguracionSistema();

            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT NombreBiblioteca, DiasMaximoPrestamo, MultaPorDiaRetraso FROM Configuracion WHERE Id = 1;";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            using DbDataReader reader = cmd.ExecuteReader();

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
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                UPDATE Configuracion
                SET NombreBiblioteca = @nombre,
                    DiasMaximoPrestamo = @dias,
                    MultaPorDiaRetraso = @multa
                WHERE Id = 1;";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", config.NombreBiblioteca);
            ConexionBD.AgregarParametro(cmd, "@dias", config.DiasMaximoPrestamo);
            ConexionBD.AgregarParametro(cmd, "@multa", config.MultaPorDiaRetraso);
            cmd.ExecuteNonQuery();
        }
    }
}
