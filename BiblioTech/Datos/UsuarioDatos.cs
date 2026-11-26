using BiblioTech.Modelos;
using MySqlConnector;

namespace BiblioTech.Datos
{
    public class UsuarioDatos
    {
        public UsuarioSistema? Autenticar(string nombreUsuario, string contrasena)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                SELECT Id, NombreCompleto, Documento, Email, NombreUsuario, Contrasena, Rol, Activo
                FROM Usuarios
                WHERE NombreUsuario = @usuario AND Contrasena = @contrasena AND Activo = 1;";

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@usuario", nombreUsuario.Trim());
            cmd.Parameters.AddWithValue("@contrasena", contrasena.Trim());

            using MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return MapearUsuario(reader);
            }

            return null;
        }

        public List<UsuarioSistema> ListarTodos()
        {
            List<UsuarioSistema> lista = new List<UsuarioSistema>();

            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = "SELECT Id, NombreCompleto, Documento, Email, NombreUsuario, Contrasena, Rol, Activo FROM Usuarios ORDER BY Id;";
            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                lista.Add(MapearUsuario(reader));
            }

            return lista;
        }

        public void Insertar(UsuarioSistema usuario)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
            conexion.Open();

            string sql = @"
                INSERT INTO Usuarios (NombreCompleto, Documento, Email, NombreUsuario, Contrasena, Rol, Activo)
                VALUES (@nombre, @documento, @email, @usuario, @contrasena, @rol, @activo);";

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto.Trim());
            cmd.Parameters.AddWithValue("@documento", usuario.Documento.Trim());
            cmd.Parameters.AddWithValue("@email", usuario.Email.Trim());
            cmd.Parameters.AddWithValue("@usuario", usuario.NombreUsuario.Trim());
            cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena.Trim());
            cmd.Parameters.AddWithValue("@rol", usuario.Rol);
            cmd.Parameters.AddWithValue("@activo", usuario.Activo ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void Actualizar(UsuarioSistema usuario)
        {
            using MySqlConnection conexion = ConexionBD.ObtenerConexion();
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

            using MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@nombre", usuario.NombreCompleto.Trim());
            cmd.Parameters.AddWithValue("@documento", usuario.Documento.Trim());
            cmd.Parameters.AddWithValue("@email", usuario.Email.Trim());
            cmd.Parameters.AddWithValue("@usuario", usuario.NombreUsuario.Trim());
            cmd.Parameters.AddWithValue("@contrasena", usuario.Contrasena.Trim());
            cmd.Parameters.AddWithValue("@rol", usuario.Rol);
            cmd.Parameters.AddWithValue("@activo", usuario.Activo ? 1 : 0);
            cmd.Parameters.AddWithValue("@id", usuario.Id);
            cmd.ExecuteNonQuery();
        }

        private static UsuarioSistema MapearUsuario(MySqlDataReader reader)
        {
            return new UsuarioSistema(
                id: reader.GetInt32(0),
                nombreCompleto: reader.GetString(1),
                documento: reader.GetString(2),
                email: reader.GetString(3),
                nombreUsuario: reader.GetString(4),
                contrasena: reader.GetString(5),
                rol: reader.GetString(6),
                activo: reader.GetInt32(7) == 1
            );
        }
    }
}
