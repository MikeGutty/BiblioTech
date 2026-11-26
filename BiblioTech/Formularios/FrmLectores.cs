using BiblioTech.Datos;
using BiblioTech.Modelos;

namespace BiblioTech.Formularios
{
    /// <summary>
    /// MÓDULO 2 (Parte 3): Gestión de Lectores / Socios (Estudiantes y Docentes).
    /// Muestra en acción la clase Lector que hereda de Persona.
    /// </summary>
    public partial class FrmLectores : Form
    {
        private readonly CatalogoDatos _datos = new CatalogoDatos();
        private int _idLectorSeleccionado = 0;

        public FrmLectores()
        {
            InitializeComponent();
            CargarLectores();
        }

        private void CargarLectores()
        {
            dgvLectores.DataSource = null;
            dgvLectores.DataSource = _datos.ListarLectores(txtBuscar?.Text ?? "");
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _idLectorSeleccionado = 0;
            txtNombre.Clear();
            txtDocumento.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
            if (cboTipo.Items.Count > 0) cboTipo.SelectedIndex = 0;
            chkActivo.Checked = true;
            dgvLectores.ClearSelection();
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void TxtBuscar_TextChanged(object? sender, EventArgs e)
        {
            CargarLectores();
        }

        private void DgvLectores_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvLectores.CurrentRow?.DataBoundItem is Lector lector)
            {
                _idLectorSeleccionado = lector.Id;
                txtNombre.Text = lector.NombreCompleto;
                txtDocumento.Text = lector.Documento;
                txtEmail.Text = lector.Email;
                txtTelefono.Text = lector.Telefono;
                cboTipo.SelectedItem = lector.TipoLector;
                chkActivo.Checked = lector.Activo;
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("El Nombre Completo y la Matrícula/Documento son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Lector lector = new Lector(
                    id: _idLectorSeleccionado,
                    nombreCompleto: txtNombre.Text,
                    documento: txtDocumento.Text,
                    email: txtEmail.Text,
                    tipoLector: cboTipo.SelectedItem?.ToString() ?? "Estudiante",
                    telefono: txtTelefono.Text,
                    activo: chkActivo.Checked
                );

                if (_idLectorSeleccionado == 0)
                {
                    _datos.InsertarLector(lector);
                    MessageBox.Show($"Lector registrado correctamente.\n\nResumen POO: {lector.ObtenerResumen()}\nLímite de libros permitidos: {lector.ObtenerLimiteLibros()}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _datos.ActualizarLector(lector);
                    MessageBox.Show("Datos del lector actualizados correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarLectores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar lector: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_idLectorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un lector de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este lector?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _datos.EliminarLector(_idLectorSeleccionado);
                    CargarLectores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
