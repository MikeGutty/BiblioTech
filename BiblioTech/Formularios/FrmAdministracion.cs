using BiblioTech.Datos;
using BiblioTech.Modelos;

namespace BiblioTech.Formularios
{
    /// <summary>
    /// MÓDULO 5: Administración (Solo accesible para el rol Administrador).
    /// Pestaña 1: Gestión de Usuarios del Sistema y Roles (Administrador / Bibliotecario).
    /// Pestaña 2: Configuración de Reglas de la Biblioteca (Días máximos de préstamo y Multa por día).
    /// </summary>
    public partial class FrmAdministracion : Form
    {
        private readonly UsuarioDatos _usuarioDatos = new UsuarioDatos();
        private readonly ConfiguracionDatos _configDatos = new ConfiguracionDatos();
        private int _idUsuarioSeleccionado = 0;

        public FrmAdministracion()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarConfiguracion();
        }

        // =====================================================================
        // PESTAÑA 1: USUARIOS DEL SISTEMA
        // =====================================================================
        private void CargarUsuarios()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = _usuarioDatos.ListarTodos();
            LimpiarUsuario();
        }

        private void LimpiarUsuario()
        {
            _idUsuarioSeleccionado = 0;
            txtNombreCompleto.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            if (cboRol.Items.Count > 1) cboRol.SelectedIndex = 1;
            chkActivo.Checked = true;
            dgvUsuarios.ClearSelection();
        }

        private void BtnLimpiarUsuario_Click(object? sender, EventArgs e)
        {
            LimpiarUsuario();
        }

        private void DgvUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow?.DataBoundItem is UsuarioSistema u)
            {
                _idUsuarioSeleccionado = u.Id;
                txtNombreCompleto.Text = u.NombreCompleto;
                txtDocumento.Text = u.Documento;
                txtEmail.Text = u.Email;
                txtNombreUsuario.Text = u.NombreUsuario;
                txtContrasena.Text = u.Contrasena;
                cboRol.SelectedItem = u.Rol;
                chkActivo.Checked = u.Activo;
            }
        }

        private void BtnGuardarUsuario_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text) ||
                string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Nombre completo, usuario y contraseña son obligatorios.", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UsuarioSistema u = new UsuarioSistema(
                    id: _idUsuarioSeleccionado,
                    nombreCompleto: txtNombreCompleto.Text,
                    documento: txtDocumento.Text,
                    email: txtEmail.Text,
                    nombreUsuario: txtNombreUsuario.Text,
                    contrasena: txtContrasena.Text,
                    rol: cboRol.SelectedItem?.ToString() ?? "Bibliotecario",
                    activo: chkActivo.Checked
                );

                if (_idUsuarioSeleccionado == 0)
                {
                    _usuarioDatos.Insertar(u);
                    MessageBox.Show($"Usuario creado correctamente.\n{u.ObtenerResumen()}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _usuarioDatos.Actualizar(u);
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // =====================================================================
        // PESTAÑA 2: REGLAS Y PARÁMETROS DE LA BIBLIOTECA
        // =====================================================================
        private void CargarConfiguracion()
        {
            ConfiguracionSistema config = _configDatos.ObtenerConfiguracion();
            SesionActual.Configuracion = config;

            txtNombreBiblio.Text = config.NombreBiblioteca;
            numDiasPrestamo.Value = config.DiasMaximoPrestamo;
            numMultaDiaria.Value = config.MultaPorDiaRetraso;
        }

        private void BtnGuardarConfig_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreBiblio.Text))
            {
                MessageBox.Show("El nombre de la biblioteca no puede estar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConfiguracionSistema nuevaConfig = new ConfiguracionSistema
            {
                NombreBiblioteca = txtNombreBiblio.Text.Trim(),
                DiasMaximoPrestamo = (int)numDiasPrestamo.Value,
                MultaPorDiaRetraso = numMultaDiaria.Value
            };

            _configDatos.GuardarConfiguracion(nuevaConfig);
            SesionActual.Configuracion = nuevaConfig;

            MessageBox.Show("Parámetros de la biblioteca actualizados correctamente.", "Configuración Guardada",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
