using BiblioTech.Datos;
using BiblioTech.Modelos;

namespace BiblioTech.Formularios
{
    public partial class FrmPrincipal : Form
    {
        private readonly CatalogoDatos _catalogoDatos = new CatalogoDatos();
        private readonly PrestamoDatos _prestamoDatos = new PrestamoDatos();

        public FrmPrincipal()
        {
            InitializeComponent();
            ConfigurarSesionUsuario();
            CargarFiltrosCombos();
            ActualizarPanelYConsultas();
        }

        private void ConfigurarSesionUsuario()
        {
            if (cboFiltroEstadoPrestamo.Items.Count > 0)
            {
                cboFiltroEstadoPrestamo.SelectedIndex = 0;
            }

            if (SesionActual.Usuario != null)
            {
                UsuarioSistema usuario = SesionActual.Usuario;
                Text = $"BiblioTech - Panel Principal [{usuario.ObtenerResumen()}]";
                lblUsuarioActivo.Text = $"👤 {usuario.NombreCompleto} ({usuario.Rol})";

                // Restricción de acceso por rol
                btnModAdmin.Enabled = usuario.EsAdministrador();
                if (!usuario.EsAdministrador())
                {
                    btnModAdmin.BackColor = Color.FromArgb(100, 110, 120);
                    btnModAdmin.Text = "🔒 Solo Admin";
                }
            }
        }

        private void CargarFiltrosCombos()
        {
            List<Categoria> categorias = new List<Categoria> { new Categoria(0, "-- Todas las Categorías --", "") };
            categorias.AddRange(_catalogoDatos.ListarCategorias());
            cboFiltroCategoria.DataSource = categorias;
            cboFiltroCategoria.DisplayMember = "Nombre";
            cboFiltroCategoria.ValueMember = "Id";

            List<Autor> autores = new List<Autor> { new Autor(0, "-- Todos los Autores --", "") };
            autores.AddRange(_catalogoDatos.ListarAutores());
            cboFiltroAutor.DataSource = autores;
            cboFiltroAutor.DisplayMember = "NombreCompleto";
            cboFiltroAutor.ValueMember = "Id";
        }

        private void ActualizarPanelYConsultas()
        {
            lblNombreInstitucion.Text = $"📚 {SesionActual.Configuracion.NombreBiblioteca}";

            var kpis = _prestamoDatos.ObtenerIndicadoresDashboard();
            lblKpiTitulos.Text = kpis.TotalTitulos.ToString();
            lblKpiDisponibles.Text = kpis.EjemplaresDisponibles.ToString();
            lblKpiActivos.Text = kpis.PrestamosActivos.ToString();
            lblKpiVencidos.Text = kpis.PrestamosVencidos.ToString();

            FiltrarCatalogo();
            FiltrarPrestamos();
        }

        private void FiltrarCatalogo()
        {
            int idCat = cboFiltroCategoria.SelectedItem is Categoria c ? c.Id : 0;
            int idAut = cboFiltroAutor.SelectedItem is Autor a ? a.Id : 0;

            dgvConsultaLibros.DataSource = null;
            dgvConsultaLibros.DataSource = _catalogoDatos.ListarLibros(txtFiltroLibro?.Text ?? "", idCat, idAut);

            if (dgvConsultaLibros.Columns["IdAutor"] != null) dgvConsultaLibros.Columns["IdAutor"]!.Visible = false;
            if (dgvConsultaLibros.Columns["IdCategoria"] != null) dgvConsultaLibros.Columns["IdCategoria"]!.Visible = false;
        }

        private void FiltrarPrestamos()
        {
            string estado = cboFiltroEstadoPrestamo?.SelectedItem?.ToString() ?? "Todos";
            dgvConsultaPrestamos.DataSource = null;
            dgvConsultaPrestamos.DataSource = _prestamoDatos.ListarPrestamos(txtFiltroPrestamo?.Text ?? "", estado);

            string[] ocultar = { "IdLibro", "IdLector", "IdUsuarioRegistro", "Estado" };
            foreach (string col in ocultar)
            {
                if (dgvConsultaPrestamos.Columns[col] != null)
                    dgvConsultaPrestamos.Columns[col]!.Visible = false;
            }
        }

        private void AbrirFormularioModal(Form formulario)
        {
            using (formulario)
            {
                formulario.ShowDialog(this);
            }
            CargarFiltrosCombos();
            ActualizarPanelYConsultas();
        }

        private void BtnModLibros_Click(object? sender, EventArgs e)
        {
            AbrirFormularioModal(new FrmLibros());
        }

        private void BtnModCatAut_Click(object? sender, EventArgs e)
        {
            AbrirFormularioModal(new FrmCategoriasAutores());
        }

        private void BtnModLectores_Click(object? sender, EventArgs e)
        {
            AbrirFormularioModal(new FrmLectores());
        }

        private void BtnModPrestamos_Click(object? sender, EventArgs e)
        {
            AbrirFormularioModal(new FrmPrestamos());
        }

        private void BtnModAdmin_Click(object? sender, EventArgs e)
        {
            AbrirFormularioModal(new FrmAdministracion());
        }

        private void BtnCerrarSesion_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea cerrar la sesión actual?", "Cerrar Sesión",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SesionActual.Usuario = null;
                Close();
            }
        }

        private void TxtFiltroLibro_TextChanged(object? sender, EventArgs e)
        {
            FiltrarCatalogo();
        }

        private void CboFiltroCategoria_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FiltrarCatalogo();
        }

        private void CboFiltroAutor_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FiltrarCatalogo();
        }

        private void BtnLimpiarFiltroLibros_Click(object? sender, EventArgs e)
        {
            txtFiltroLibro.Clear();
            if (cboFiltroCategoria.Items.Count > 0) cboFiltroCategoria.SelectedIndex = 0;
            if (cboFiltroAutor.Items.Count > 0) cboFiltroAutor.SelectedIndex = 0;
            FiltrarCatalogo();
        }

        private void TxtFiltroPrestamo_TextChanged(object? sender, EventArgs e)
        {
            FiltrarPrestamos();
        }

        private void CboFiltroEstadoPrestamo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FiltrarPrestamos();
        }

        private void BtnRefrescarPrestamos_Click(object? sender, EventArgs e)
        {
            txtFiltroPrestamo.Clear();
            if (cboFiltroEstadoPrestamo.Items.Count > 0) cboFiltroEstadoPrestamo.SelectedIndex = 0;
            ActualizarPanelYConsultas();
        }
    }
}
