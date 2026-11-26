namespace BiblioTech.Formularios
{
    partial class FrmPrestamos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpNuevo = new GroupBox();
            lblLector = new Label();
            cboLector = new ComboBox();
            lblLibro = new Label();
            cboLibro = new ComboBox();
            lblFechaEsp = new Label();
            dtpFechaDevolucion = new DateTimePicker();
            lblRegla = new Label();
            lblObs = new Label();
            txtObsPrestamo = new TextBox();
            btnRegistrarPrestamo = new Button();
            grpDevolucion = new GroupBox();
            lblDetallePrestamo = new Label();
            lblEstadoRetraso = new Label();
            lblMulta = new Label();
            numMultaCobrar = new NumericUpDown();
            lblTarifaInfo = new Label();
            lblObsDev = new Label();
            txtObsDevolucion = new TextBox();
            btnConfirmarDevolucion = new Button();
            lblTabla = new Label();
            dgvActivos = new DataGridView();
            grpNuevo.SuspendLayout();
            grpDevolucion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numMultaCobrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvActivos).BeginInit();
            SuspendLayout();
            // 
            // grpNuevo
            // 
            grpNuevo.BackColor = Color.White;
            grpNuevo.Controls.Add(lblLector);
            grpNuevo.Controls.Add(cboLector);
            grpNuevo.Controls.Add(lblLibro);
            grpNuevo.Controls.Add(cboLibro);
            grpNuevo.Controls.Add(lblFechaEsp);
            grpNuevo.Controls.Add(dtpFechaDevolucion);
            grpNuevo.Controls.Add(lblRegla);
            grpNuevo.Controls.Add(lblObs);
            grpNuevo.Controls.Add(txtObsPrestamo);
            grpNuevo.Controls.Add(btnRegistrarPrestamo);
            grpNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpNuevo.Location = new Point(20, 15);
            grpNuevo.Name = "grpNuevo";
            grpNuevo.Size = new Size(475, 240);
            grpNuevo.TabIndex = 0;
            grpNuevo.TabStop = false;
            grpNuevo.Text = "📤 1. Registrar Nuevo Préstamo";
            // 
            // lblLector
            // 
            lblLector.AutoSize = true;
            lblLector.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblLector.Location = new Point(18, 35);
            lblLector.Name = "lblLector";
            lblLector.Size = new Size(92, 17);
            lblLector.TabIndex = 0;
            lblLector.Text = "Lector / Socio:";
            // 
            // cboLector
            // 
            cboLector.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLector.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            cboLector.FormattingEnabled = true;
            cboLector.Location = new Point(145, 32);
            cboLector.Name = "cboLector";
            cboLector.Size = new Size(310, 25);
            cboLector.TabIndex = 1;
            // 
            // lblLibro
            // 
            lblLibro.AutoSize = true;
            lblLibro.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblLibro.Location = new Point(18, 75);
            lblLibro.Name = "lblLibro";
            lblLibro.Size = new Size(106, 17);
            lblLibro.TabIndex = 2;
            lblLibro.Text = "Libro Disponible:";
            // 
            // cboLibro
            // 
            cboLibro.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLibro.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            cboLibro.FormattingEnabled = true;
            cboLibro.Location = new Point(145, 72);
            cboLibro.Name = "cboLibro";
            cboLibro.Size = new Size(310, 25);
            cboLibro.TabIndex = 3;
            // 
            // lblFechaEsp
            // 
            lblFechaEsp.AutoSize = true;
            lblFechaEsp.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblFechaEsp.Location = new Point(18, 115);
            lblFechaEsp.Name = "lblFechaEsp";
            lblFechaEsp.Size = new Size(112, 17);
            lblFechaEsp.TabIndex = 4;
            lblFechaEsp.Text = "Devolución límite:";
            // 
            // dtpFechaDevolucion
            // 
            dtpFechaDevolucion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dtpFechaDevolucion.Format = DateTimePickerFormat.Short;
            dtpFechaDevolucion.Location = new Point(145, 112);
            dtpFechaDevolucion.Name = "dtpFechaDevolucion";
            dtpFechaDevolucion.Size = new Size(160, 24);
            dtpFechaDevolucion.TabIndex = 5;
            // 
            // lblRegla
            // 
            lblRegla.AutoSize = true;
            lblRegla.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblRegla.ForeColor = Color.Gray;
            lblRegla.Location = new Point(312, 116);
            lblRegla.Name = "lblRegla";
            lblRegla.Size = new Size(115, 15);
            lblRegla.TabIndex = 6;
            lblRegla.Text = "(7 días por defecto)";
            // 
            // lblObs
            // 
            lblObs.AutoSize = true;
            lblObs.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblObs.Location = new Point(18, 152);
            lblObs.Name = "lblObs";
            lblObs.Size = new Size(94, 17);
            lblObs.TabIndex = 7;
            lblObs.Text = "Observaciones:";
            // 
            // txtObsPrestamo
            // 
            txtObsPrestamo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtObsPrestamo.Location = new Point(145, 149);
            txtObsPrestamo.Name = "txtObsPrestamo";
            txtObsPrestamo.Size = new Size(310, 24);
            txtObsPrestamo.TabIndex = 8;
            // 
            // btnRegistrarPrestamo
            // 
            btnRegistrarPrestamo.BackColor = Color.FromArgb(25, 55, 109);
            btnRegistrarPrestamo.Cursor = Cursors.Hand;
            btnRegistrarPrestamo.FlatAppearance.BorderSize = 0;
            btnRegistrarPrestamo.FlatStyle = FlatStyle.Flat;
            btnRegistrarPrestamo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnRegistrarPrestamo.ForeColor = Color.White;
            btnRegistrarPrestamo.Location = new Point(145, 188);
            btnRegistrarPrestamo.Name = "btnRegistrarPrestamo";
            btnRegistrarPrestamo.Size = new Size(310, 38);
            btnRegistrarPrestamo.TabIndex = 9;
            btnRegistrarPrestamo.Text = "✅ Confirmar y Entregar Libro";
            btnRegistrarPrestamo.UseVisualStyleBackColor = false;
            btnRegistrarPrestamo.Click += BtnRegistrarPrestamo_Click;
            // 
            // grpDevolucion
            // 
            grpDevolucion.BackColor = Color.White;
            grpDevolucion.Controls.Add(lblDetallePrestamo);
            grpDevolucion.Controls.Add(lblEstadoRetraso);
            grpDevolucion.Controls.Add(lblMulta);
            grpDevolucion.Controls.Add(numMultaCobrar);
            grpDevolucion.Controls.Add(lblTarifaInfo);
            grpDevolucion.Controls.Add(lblObsDev);
            grpDevolucion.Controls.Add(txtObsDevolucion);
            grpDevolucion.Controls.Add(btnConfirmarDevolucion);
            grpDevolucion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDevolucion.Location = new Point(510, 15);
            grpDevolucion.Name = "grpDevolucion";
            grpDevolucion.Size = new Size(475, 240);
            grpDevolucion.TabIndex = 1;
            grpDevolucion.TabStop = false;
            grpDevolucion.Text = "📥 2. Recepción de Devolución y Cálculo de Multa";
            // 
            // lblDetallePrestamo
            // 
            lblDetallePrestamo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblDetallePrestamo.ForeColor = Color.FromArgb(60, 60, 60);
            lblDetallePrestamo.Location = new Point(18, 30);
            lblDetallePrestamo.Name = "lblDetallePrestamo";
            lblDetallePrestamo.Size = new Size(440, 42);
            lblDetallePrestamo.TabIndex = 0;
            lblDetallePrestamo.Text = "Seleccione un préstamo activo en la tabla inferior para procesarlo.";
            // 
            // lblEstadoRetraso
            // 
            lblEstadoRetraso.AutoSize = true;
            lblEstadoRetraso.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblEstadoRetraso.ForeColor = Color.FromArgb(39, 174, 96);
            lblEstadoRetraso.Location = new Point(18, 75);
            lblEstadoRetraso.Name = "lblEstadoRetraso";
            lblEstadoRetraso.Size = new Size(134, 17);
            lblEstadoRetraso.TabIndex = 1;
            lblEstadoRetraso.Text = "Estado: Sin selección";
            // 
            // lblMulta
            // 
            lblMulta.AutoSize = true;
            lblMulta.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblMulta.Location = new Point(18, 112);
            lblMulta.Name = "lblMulta";
            lblMulta.Size = new Size(135, 17);
            lblMulta.TabIndex = 2;
            lblMulta.Text = "Multa a cobrar ($/Bs):";
            // 
            // numMultaCobrar
            // 
            numMultaCobrar.DecimalPlaces = 2;
            numMultaCobrar.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            numMultaCobrar.Location = new Point(165, 109);
            numMultaCobrar.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numMultaCobrar.Name = "numMultaCobrar";
            numMultaCobrar.Size = new Size(110, 24);
            numMultaCobrar.TabIndex = 3;
            // 
            // lblTarifaInfo
            // 
            lblTarifaInfo.AutoSize = true;
            lblTarifaInfo.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblTarifaInfo.ForeColor = Color.Gray;
            lblTarifaInfo.Location = new Point(285, 113);
            lblTarifaInfo.Name = "lblTarifaInfo";
            lblTarifaInfo.Size = new Size(111, 15);
            lblTarifaInfo.TabIndex = 4;
            lblTarifaInfo.Text = "(Tarifa diaria: 5.00)";
            // 
            // lblObsDev
            // 
            lblObsDev.AutoSize = true;
            lblObsDev.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblObsDev.Location = new Point(18, 150);
            lblObsDev.Name = "lblObsDev";
            lblObsDev.Size = new Size(106, 17);
            lblObsDev.TabIndex = 5;
            lblObsDev.Text = "Nota devolución:";
            // 
            // txtObsDevolucion
            // 
            txtObsDevolucion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtObsDevolucion.Location = new Point(165, 147);
            txtObsDevolucion.Name = "txtObsDevolucion";
            txtObsDevolucion.Size = new Size(290, 24);
            txtObsDevolucion.TabIndex = 6;
            // 
            // btnConfirmarDevolucion
            // 
            btnConfirmarDevolucion.BackColor = Color.FromArgb(39, 174, 96);
            btnConfirmarDevolucion.Cursor = Cursors.Hand;
            btnConfirmarDevolucion.Enabled = false;
            btnConfirmarDevolucion.FlatAppearance.BorderSize = 0;
            btnConfirmarDevolucion.FlatStyle = FlatStyle.Flat;
            btnConfirmarDevolucion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnConfirmarDevolucion.ForeColor = Color.White;
            btnConfirmarDevolucion.Location = new Point(165, 188);
            btnConfirmarDevolucion.Name = "btnConfirmarDevolucion";
            btnConfirmarDevolucion.Size = new Size(290, 38);
            btnConfirmarDevolucion.TabIndex = 7;
            btnConfirmarDevolucion.Text = "📥 Registrar Devolución y Reponer Stock";
            btnConfirmarDevolucion.UseVisualStyleBackColor = false;
            btnConfirmarDevolucion.Click += BtnConfirmarDevolucion_Click;
            // 
            // lblTabla
            // 
            lblTabla.AutoSize = true;
            lblTabla.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTabla.ForeColor = Color.FromArgb(25, 55, 109);
            lblTabla.Location = new Point(20, 268);
            lblTabla.Name = "lblTabla";
            lblTabla.Size = new Size(574, 19);
            lblTabla.TabIndex = 2;
            lblTabla.Text = "📋 Préstamos Activos Pendientes de Devolución (Haga clic en una fila para devolver):";
            // 
            // dgvActivos
            // 
            dgvActivos.AllowUserToAddRows = false;
            dgvActivos.AllowUserToDeleteRows = false;
            dgvActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvActivos.BackgroundColor = Color.White;
            dgvActivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActivos.Location = new Point(20, 295);
            dgvActivos.MultiSelect = false;
            dgvActivos.Name = "dgvActivos";
            dgvActivos.ReadOnly = true;
            dgvActivos.RowHeadersVisible = false;
            dgvActivos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvActivos.Size = new Size(965, 300);
            dgvActivos.TabIndex = 3;
            dgvActivos.SelectionChanged += DgvActivos_SelectionChanged;
            // 
            // FrmPrestamos
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1004, 611);
            Controls.Add(grpNuevo);
            Controls.Add(grpDevolucion);
            Controls.Add(lblTabla);
            Controls.Add(dgvActivos);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmPrestamos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Módulo 3 - Proceso Central: Préstamos y Devoluciones";
            grpNuevo.ResumeLayout(false);
            grpNuevo.PerformLayout();
            grpDevolucion.ResumeLayout(false);
            grpDevolucion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numMultaCobrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvActivos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpNuevo;
        private Label lblLector;
        private ComboBox cboLector;
        private Label lblLibro;
        private ComboBox cboLibro;
        private Label lblFechaEsp;
        private DateTimePicker dtpFechaDevolucion;
        private Label lblRegla;
        private Label lblObs;
        private TextBox txtObsPrestamo;
        private Button btnRegistrarPrestamo;
        private GroupBox grpDevolucion;
        private Label lblDetallePrestamo;
        private Label lblEstadoRetraso;
        private Label lblMulta;
        private NumericUpDown numMultaCobrar;
        private Label lblTarifaInfo;
        private Label lblObsDev;
        private TextBox txtObsDevolucion;
        private Button btnConfirmarDevolucion;
        private Label lblTabla;
        private DataGridView dgvActivos;
    }
}
