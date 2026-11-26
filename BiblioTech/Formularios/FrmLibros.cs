using BiblioTech.Datos;
using BiblioTech.Modelos;

namespace BiblioTech.Formularios
{
    /// <summary>
    /// MÓDULO 2 (Parte 2): Gestión del Catálogo de Libros (CRUD completo).
    /// Relaciona cada Libro con su Autor y su Categoría usando ComboBox cargados con objetos.
    /// </summary>
    public partial class FrmLibros : Form
    {
        private readonly CatalogoDatos _datos = new CatalogoDatos();
        private int _idLibroSeleccionado = 0;

        public FrmLibros()
        {
            InitializeComponent();
            CargarCombos();
            CargarLibros();
        }

        private void CargarCombos()
        {
            cboAutor.DataSource = _datos.ListarAutores();
            cboAutor.DisplayMember = "NombreCompleto";
            cboAutor.ValueMember = "Id";

            cboCategoria.DataSource = _datos.ListarCategorias();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";
        }

        private void CargarLibros()
        {
            dgvLibros.DataSource = null;
            dgvLibros.DataSource = _datos.ListarLibros(txtBuscar?.Text ?? "");

            if (dgvLibros.Columns["IdAutor"] != null) dgvLibros.Columns["IdAutor"]!.Visible = false;
            if (dgvLibros.Columns["IdCategoria"] != null) dgvLibros.Columns["IdCategoria"]!.Visible = false;

            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            _idLibroSeleccionado = 0;
            txtIsbn.Clear();
            txtTitulo.Clear();
            numAnio.Value = DateTime.Now.Year;
            numStockTotal.Value = 3;
            numStockDisponible.Value = 3;
            dgvLibros.ClearSelection();
        }

        private void NumStockTotal_ValueChanged(object? sender, EventArgs e)
        {
            if (_idLibroSeleccionado == 0)
            {
                numStockDisponible.Value = numStockTotal.Value;
            }
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void TxtBuscar_TextChanged(object? sender, EventArgs e)
        {
            CargarLibros();
        }

        private void BtnCatAutores_Click(object? sender, EventArgs e)
        {
            using FrmCategoriasAutores frm = new FrmCategoriasAutores();
            frm.ShowDialog();
            CargarCombos();
            CargarLibros();
        }

        private void DgvLibros_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow?.DataBoundItem is Libro libro)
            {
                _idLibroSeleccionado = libro.Id;
                txtIsbn.Text = libro.ISBN;
                txtTitulo.Text = libro.Titulo;
                cboAutor.SelectedValue = libro.IdAutor;
                cboCategoria.SelectedValue = libro.IdCategoria;
                numAnio.Value = libro.AnioPublicacion;
                numStockTotal.Value = libro.StockTotal;
                numStockDisponible.Value = libro.StockDisponible;
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIsbn.Text) || string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El ISBN y el Título son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboAutor.SelectedValue == null || cboCategoria.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un Autor y una Categoría.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numStockDisponible.Value > numStockTotal.Value)
            {
                MessageBox.Show("El Stock Disponible no puede ser mayor al Stock Total.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Libro libro = new Libro
                {
                    Id = _idLibroSeleccionado,
                    ISBN = txtIsbn.Text,
                    Titulo = txtTitulo.Text,
                    IdAutor = (int)cboAutor.SelectedValue,
                    IdCategoria = (int)cboCategoria.SelectedValue,
                    AnioPublicacion = (int)numAnio.Value,
                    StockTotal = (int)numStockTotal.Value,
                    StockDisponible = (int)numStockDisponible.Value
                };

                if (_idLibroSeleccionado == 0)
                {
                    _datos.InsertarLibro(libro);
                    MessageBox.Show("Libro agregado al catálogo con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _datos.ActualizarLibro(libro);
                    MessageBox.Show("Datos del libro actualizados con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarLibros();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar libro: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminar_Click(object? sender, EventArgs e)
        {
            if (_idLibroSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un libro de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este libro del catálogo?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _datos.EliminarLibro(_idLibroSeleccionado);
                    CargarLibros();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
