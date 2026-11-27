using System.Data.Common;
using BiblioTech.Modelos;

namespace BiblioTech.Datos
{
    public class UsuarioDatos
    {
        public UsuarioSistema? Autenticar(string nombreUsuario, string contrasena)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                SELECT Id, NombreCompleto, Documento, Email, NombreUsuario, Contrasena, Rol, Activo
                FROM Usuarios
                WHERE NombreUsuario = @usuario AND Contrasena = @contrasena AND Activo = 1;";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@usuario", nombreUsuario.Trim());
            ConexionBD.AgregarParametro(cmd, "@contrasena", contrasena.Trim());

            using DbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapearUsuario(reader);
            }

            return null;
        }

        public List<UsuarioSistema> ListarTodos()
        {
            List<UsuarioSistema> lista = new List<UsuarioSistema>();

            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT Id, NombreCompleto, Documento, Email, NombreUsuario, Contrasena, Rol, Activo FROM Usuarios ORDER BY Id;";
            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            using DbDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(MapearUsuario(reader));
            }

            return lista;
        }

        public void Insertar(UsuarioSistema usuario)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                INSERT INTO Usuarios (NombreCompleto, Documento, Email, NombreUsuario, Contrasena, Rol, Activo)
                VALUES (@nombre, @documento, @email, @usuario, @contrasena, @rol, @activo);";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", usuario.NombreCompleto.Trim());
            ConexionBD.AgregarParametro(cmd, "@documento", usuario.Documento.Trim());
            ConexionBD.AgregarParametro(cmd, "@email", usuario.Email.Trim());
            ConexionBD.AgregarParametro(cmd, "@usuario", usuario.NombreUsuario.Trim());
            ConexionBD.AgregarParametro(cmd, "@contrasena", usuario.Contrasena.Trim());
            ConexionBD.AgregarParametro(cmd, "@rol", usuario.Rol);
            ConexionBD.AgregarParametro(cmd, "@activo", usuario.Activo ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(UsuarioSistema usuario)
        {
            using DbConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                UPDATE Usuarios
                SET NombreCompleto = @nombre,
                    Documento = @documento,
                    Email = @email,
                    NombreUsuario = @usuario,
                    Contrasena = @contrasena,
                    Rol = @rol,
                    Activo = @activo
                WHERE Id = @id;";

            using DbCommand cmd = ConexionBD.CrearComando(sql, conexion);
            ConexionBD.AgregarParametro(cmd, "@nombre", usuario.NombreCompleto.Trim());
            ConexionBD.AgregarParametro(cmd, "@documento", usuario.Documento.Trim());
            ConexionBD.AgregarParametro(cmd, "@email", usuario.Email.Trim());
            ConexionBD.AgregarParametro(cmd, "@usuario", usuario.NombreUsuario.Trim());
            ConexionBD.AgregarParametro(cmd, "@contrasena", usuario.Contrasena.Trim());
            ConexionBD.AgregarParametro(cmd, "@rol", usuario.Rol);
            ConexionBD.AgregarParametro(cmd, "@activo", usuario.Activo ? 1 : 0);
            ConexionBD.AgregarParametro(cmd, "@id", usuario.Id);
            cmd.ExecuteNonQuery();
        }

        private static UsuarioSistema MapearUsuario(DbDataReader reader)
        {
            return new UsuarioSistema(
                id: reader.GetInt32(0),
                nombreCompleto: reader.GetString(1),
                documento: reader.GetString(2),
                email: reader.GetString(3),
                nombreUsuario: reader.GetString(4),
                contrasena: reader.GetString(5),
                rol: reader.GetString(6),
                activo: Convert.ToInt32(reader.GetValue(7)) == 1
            );
        }
    }
}
