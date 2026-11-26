using BiblioTech.Datos;
using BiblioTech.Modelos;

namespace BiblioTech.Formularios
{
    public partial class FrmPrestamos : Form
    {
        private readonly CatalogoDatos _catalogoDatos = new CatalogoDatos();
        private readonly PrestamoDatos _prestamoDatos = new PrestamoDatos();
        private Prestamo? _prestamoSeleccionado;

        public FrmPrestamos()
        {
            InitializeComponent();
            ConfigurarParametrosReglas();
            CargarCombos();
            CargarPrestamosActivos();
        }

        private void ConfigurarParametrosReglas()
        {
            dtpFechaDevolucion.MinDate = DateTime.Today;
            dtpFechaDevolucion.Value = DateTime.Today.AddDays(SesionActual.Configuracion.DiasMaximoPrestamo);
            lblRegla.Text = $"({SesionActual.Configuracion.DiasMaximoPrestamo} días por defecto)";
            lblTarifaInfo.Text = $"(Tarifa diaria: {SesionActual.Configuracion.MultaPorDiaRetraso:N2})";
        }

        private void CargarCombos()
        {
            cboLector.DataSource = _catalogoDatos.ListarLectores("", soloActivos: true);

            // Solo libros con stock disponible
            List<Libro> librosDisponibles = _catalogoDatos.ListarLibros()
                .Where(l => l.TieneEjemplaresDisponibles())
                .ToList();
            cboLibro.DataSource = librosDisponibles;
        }

        private void CargarPrestamosActivos()
        {
            dgvActivos.DataSource = null;
            List<Prestamo> activos = _prestamoDatos.ListarPrestamos("", "Activos");
            dgvActivos.DataSource = activos;

            // Ocultamos columnas internas de IDs para que la tabla sea limpia
            string[] ocultar = { "IdLibro", "IdLector", "IdUsuarioRegistro", "FechaDevolucionReal", "Estado", "MultaPagada" };
            foreach (string col in ocultar)
            {
                if (dgvActivos.Columns[col] != null)
                    dgvActivos.Columns[col]!.Visible = false;
            }

            // Coloreamos en rojo suave los préstamos vencidos
            foreach (DataGridViewRow row in dgvActivos.Rows)
            {
                if (row.DataBoundItem is Prestamo p && p.EstaVencido())
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(253, 237, 236);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(146, 43, 33);
                }
            }

            LimpiarSeleccionDevolucion();
        }

        private void LimpiarSeleccionDevolucion()
        {
            _prestamoSeleccionado = null;
            lblDetallePrestamo.Text = "Seleccione un préstamo activo en la tabla inferior para procesarlo.";
            lblEstadoRetraso.Text = "Estado: Sin selección";
            lblEstadoRetraso.ForeColor = Color.Gray;
            numMultaCobrar.Value = 0;
            txtObsDevolucion.Clear();
            btnConfirmarDevolucion.Enabled = false;
            dgvActivos.ClearSelection();
        }

        private void DgvActivos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvActivos.CurrentRow?.DataBoundItem is Prestamo p)
            {
                _prestamoSeleccionado = p;
                lblDetallePrestamo.Text = $"Préstamo #{p.Id}: \"{p.TituloLibro}\"\nLector: {p.NombreLector} ({p.DocumentoLector})";
                txtObsDevolucion.Text = p.Observaciones;
                btnConfirmarDevolucion.Enabled = true;

                int diasRetraso = p.ObtenerDiasRetraso();
                decimal multaSugerida = p.CalcularMulta(SesionActual.Configuracion.MultaPorDiaRetraso);

                if (diasRetraso > 0)
                {
                    lblEstadoRetraso.Text = $"⚠️ VENCIDO ({diasRetraso} días de retraso) - Multa sugerida: {multaSugerida:N2}";
                    lblEstadoRetraso.ForeColor = Color.FromArgb(192, 57, 43);
                }
                else
                {
                    lblEstadoRetraso.Text = "✅ En plazo (0 días de retraso - Sin multa)";
                    lblEstadoRetraso.ForeColor = Color.FromArgb(39, 174, 96);
                }

                numMultaCobrar.Value = multaSugerida;
            }
        }

        private void BtnRegistrarPrestamo_Click(object? sender, EventArgs e)
        {
            if (cboLector.SelectedItem is not Lector lector)
            {
                MessageBox.Show("Seleccione un lector válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cboLibro.SelectedItem is not Libro libro)
            {
                MessageBox.Show("No hay un libro disponible seleccionado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validamos el límite de préstamos simultáneos según sea Estudiante (3) o Docente (5)
            int prestamosActuales = _prestamoDatos.ContarPrestamosActivosPorLector(lector.Id);
            int limitePermitido = lector.ObtenerLimiteLibros();

            if (prestamosActuales >= limitePermitido)
            {
                MessageBox.Show($"El lector {lector.NombreCompleto} ({lector.TipoLector}) ya tiene {prestamosActuales} préstamos activos y alcanzó su límite máximo permitido ({limitePermitido} libros).",
                    "Límite alcanzado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Prestamo nuevo = new Prestamo
                {
                    IdLibro = libro.Id,
                    IdLector = lector.Id,
                    IdUsuarioRegistro = SesionActual.Usuario?.Id ?? 1,
                    FechaPrestamo = DateTime.Today,
                    FechaDevolucionEsperada = dtpFechaDevolucion.Value.Date,
                    Observaciones = txtObsPrestamo.Text
                };

                _prestamoDatos.RegistrarPrestamo(nuevo);

                MessageBox.Show($"Préstamo registrado exitosamente.\n\nLibro: {libro.Titulo}\nLector: {lector.NombreCompleto}\nFecha límite de devolución: {nuevo.FechaDevolucionEsperada:dd/MM/yyyy}",
                    "Préstamo Registrado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtObsPrestamo.Clear();
                dtpFechaDevolucion.Value = DateTime.Today.AddDays(SesionActual.Configuracion.DiasMaximoPrestamo);
                CargarCombos();
                CargarPrestamosActivos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar préstamo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConfirmarDevolucion_Click(object? sender, EventArgs e)
        {
            if (_prestamoSeleccionado == null)
                return;

            string mensajeConfirmacion = $"¿Confirmar la devolución del libro \"{_prestamoSeleccionado.TituloLibro}\"?";
            if (numMultaCobrar.Value > 0)
            {
                mensajeConfirmacion += $"\n\nSe registrará un cobro de multa por retraso de: {numMultaCobrar.Value:N2}";
            }

            if (MessageBox.Show(mensajeConfirmacion, "Confirmar Devolución",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    _prestamoDatos.RegistrarDevolucion(
                        _prestamoSeleccionado.Id,
                        _prestamoSeleccionado.IdLibro,
                        numMultaCobrar.Value,
                        txtObsDevolucion.Text
                    );

                    MessageBox.Show("Devolución registrada con éxito. El ejemplar fue repuesto al stock disponible.",
                        "Devolución Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarCombos();
                    CargarPrestamosActivos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al registrar devolución: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
