using BiblioTech.Datos;
using BiblioTech.Modelos;

namespace BiblioTech.Formularios
{
    public partial class FrmLogin : Form
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();
        private readonly ConfiguracionDatos _configDatos = new ConfiguracionDatos();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void BtnIngresar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Campos requeridos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioSistema? usuarioAutenticado = _usuarioDatos.Autenticar(txtUsuario.Text, txtContrasena.Text);

            if (usuarioAutenticado == null)
            {
                MessageBox.Show("Usuario o contraseña incorrectos, o la cuenta está inactiva.",
                    "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContrasena.Clear();
                txtContrasena.Focus();
                return;
            }

            // Guardamos en la sesión estática el usuario autenticado y la configuración del sistema
            SesionActual.Usuario = usuarioAutenticado;
            SesionActual.Configuracion = _configDatos.ObtenerConfiguracion();

            // Abrimos el formulario principal
            Hide();
            using (FrmPrincipal frmPrincipal = new FrmPrincipal())
            {
                frmPrincipal.ShowDialog();
            }

            // Si cerró sesión desde FrmPrincipal, volvemos a mostrar el Login
            if (SesionActual.Usuario == null)
            {
                txtContrasena.Clear();
                Show();
                txtUsuario.Focus();
            }
            else
            {
                Close();
            }
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
