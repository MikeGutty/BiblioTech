using BiblioTech.Datos;
using BiblioTech.Modelos;

namespace BiblioTech.Formularios
{
    public partial class FrmCategoriasAutores : Form
    {
        private readonly CatalogoDatos _datos = new CatalogoDatos();
        private int _idCategoriaSeleccionada = 0;
        private int _idAutorSeleccionado = 0;

        public FrmCategoriasAutores()
        {
            InitializeComponent();
            CargarCategorias();
            CargarAutores();
        }

        // Categorías
        private void CargarCategorias()
        {
            dgvCategorias.DataSource = null;
            dgvCategorias.DataSource = _datos.ListarCategorias();
            LimpiarCategoria();
        }

        private void LimpiarCategoria()
        {
            _idCategoriaSeleccionada = 0;
            txtCatNombre.Clear();
            txtCatDescripcion.Clear();
            dgvCategorias.ClearSelection();
        }

        private void BtnLimpiarCat_Click(object? sender, EventArgs e)
        {
            LimpiarCategoria();
        }

        private void DgvCategorias_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCategorias.CurrentRow?.DataBoundItem is Categoria cat)
            {
                _idCategoriaSeleccionada = cat.Id;
                txtCatNombre.Text = cat.Nombre;
                txtCatDescripcion.Text = cat.Descripcion;
            }
        }

        private void BtnGuardarCat_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCatNombre.Text))
            {
                MessageBox.Show("El nombre de la categoría es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Categoria cat = new Categoria(_idCategoriaSeleccionada, txtCatNombre.Text, txtCatDescripcion.Text);
                if (_idCategoriaSeleccionada == 0)
                {
                    _datos.InsertarCategoria(cat);
                    MessageBox.Show("Categoría registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _datos.ActualizarCategoria(cat);
                    MessageBox.Show("Categoría actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar categoría: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarCat_Click(object? sender, EventArgs e)
        {
            if (_idCategoriaSeleccionada == 0)
            {
                MessageBox.Show("Seleccione una categoría de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar esta categoría?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _datos.EliminarCategoria(_idCategoriaSeleccionada);
                    CargarCategorias();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // Autores
        private void CargarAutores()
        {
            dgvAutores.DataSource = null;
            dgvAutores.DataSource = _datos.ListarAutores();
            LimpiarAutor();
        }

        private void LimpiarAutor()
        {
            _idAutorSeleccionado = 0;
            txtAutNombre.Clear();
            txtAutNacionalidad.Clear();
            dgvAutores.ClearSelection();
        }

        private void BtnLimpiarAut_Click(object? sender, EventArgs e)
        {
            LimpiarAutor();
        }

        private void DgvAutores_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvAutores.CurrentRow?.DataBoundItem is Autor autor)
            {
                _idAutorSeleccionado = autor.Id;
                txtAutNombre.Text = autor.NombreCompleto;
                txtAutNacionalidad.Text = autor.Nacionalidad;
            }
        }

        private void BtnGuardarAut_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAutNombre.Text))
            {
                MessageBox.Show("El nombre del autor es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Autor autor = new Autor(_idAutorSeleccionado, txtAutNombre.Text, txtAutNacionalidad.Text);
                if (_idAutorSeleccionado == 0)
                {
                    _datos.InsertarAutor(autor);
                    MessageBox.Show("Autor registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _datos.ActualizarAutor(autor);
                    MessageBox.Show("Autor actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                CargarAutores();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar autor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEliminarAut_Click(object? sender, EventArgs e)
        {
            if (_idAutorSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un autor de la tabla para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este autor?", "Confirmar eliminación",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _datos.EliminarAutor(_idAutorSeleccionado);
                    CargarAutores();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "No se puede eliminar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
