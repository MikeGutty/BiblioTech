namespace BiblioTech.Formularios
{
    partial class FrmPrincipal
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
            pnlSuperior = new Panel();
            lblNombreInstitucion = new Label();
            lblUsuarioActivo = new Label();
            btnModLibros = new Button();
            btnModCatAut = new Button();
            btnModLectores = new Button();
            btnModPrestamos = new Button();
            btnModAdmin = new Button();
            btnCerrarSesion = new Button();
            pnlDashboard = new Panel();
            card1 = new Panel();
            lblKpiTitulos = new Label();
            lblTitCard1 = new Label();
            barraColor1 = new Panel();
            card2 = new Panel();
            lblKpiDisponibles = new Label();
            lblTitCard2 = new Label();
            barraColor2 = new Panel();
            card3 = new Panel();
            lblKpiActivos = new Label();
            lblTitCard3 = new Label();
            barraColor3 = new Panel();
            card4 = new Panel();
            lblKpiVencidos = new Label();
            lblTitCard4 = new Label();
            barraColor4 = new Panel();
            pnlContenedorCentral = new Panel();
            tabConsultas = new TabControl();
            tabCat = new TabPage();
            dgvConsultaLibros = new DataGridView();
            pnlFiltrosLibros = new Panel();
            lblTextoLibro = new Label();
            txtFiltroLibro = new TextBox();
            lblCatLibro = new Label();
            cboFiltroCategoria = new ComboBox();
            lblAutLibro = new Label();
            cboFiltroAutor = new ComboBox();
            btnLimpiarFiltroLibros = new Button();
            tabHist = new TabPage();
            dgvConsultaPrestamos = new DataGridView();
            pnlFiltrosPrestamos = new Panel();
            lblTextoPrestamo = new Label();
            txtFiltroPrestamo = new TextBox();
            lblEstadoPrestamo = new Label();
            cboFiltroEstadoPrestamo = new ComboBox();
            btnRefrescarPrestamos = new Button();
            pnlSuperior.SuspendLayout();
            pnlDashboard.SuspendLayout();
            card1.SuspendLayout();
            card2.SuspendLayout();
            card3.SuspendLayout();
            card4.SuspendLayout();
            pnlContenedorCentral.SuspendLayout();
            tabConsultas.SuspendLayout();
            tabCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaLibros).BeginInit();
            pnlFiltrosLibros.SuspendLayout();
            tabHist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvConsultaPrestamos).BeginInit();
            pnlFiltrosPrestamos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlSuperior
            // 
            pnlSuperior.BackColor = Color.FromArgb(25, 55, 109);
            pnlSuperior.Controls.Add(lblNombreInstitucion);
            pnlSuperior.Controls.Add(lblUsuarioActivo);
            pnlSuperior.Controls.Add(btnModLibros);
            pnlSuperior.Controls.Add(btnModCatAut);
            pnlSuperior.Controls.Add(btnModLectores);
            pnlSuperior.Controls.Add(btnModPrestamos);
            pnlSuperior.Controls.Add(btnModAdmin);
            pnlSuperior.Controls.Add(btnCerrarSesion);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(1164, 110);
            pnlSuperior.TabIndex = 0;
            // 
            // lblNombreInstitucion
            // 
            lblNombreInstitucion.AutoSize = true;
            lblNombreInstitucion.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblNombreInstitucion.ForeColor = Color.White;
            lblNombreInstitucion.Location = new Point(22, 12);
            lblNombreInstitucion.Name = "lblNombreInstitucion";
            lblNombreInstitucion.Size = new Size(271, 28);
            lblNombreInstitucion.TabIndex = 0;
            lblNombreInstitucion.Text = "📚 BiblioTech Universitaria";
            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblUsuarioActivo.ForeColor = Color.FromArgb(165, 215, 232);
            lblUsuarioActivo.Location = new Point(820, 18);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(224, 17);
            lblUsuarioActivo.TabIndex = 1;
            lblUsuarioActivo.Text = "👤 Usuario Activo (Administrador)";
            // 
            // btnModLibros
            // 
            btnModLibros.BackColor = Color.FromArgb(41, 128, 185);
            btnModLibros.Cursor = Cursors.Hand;
            btnModLibros.FlatAppearance.BorderSize = 0;
            btnModLibros.FlatStyle = FlatStyle.Flat;
            btnModLibros.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModLibros.ForeColor = Color.White;
            btnModLibros.Location = new Point(22, 55);
            btnModLibros.Name = "btnModLibros";
            btnModLibros.Size = new Size(150, 40);
            btnModLibros.TabIndex = 2;
            btnModLibros.Text = "📘 Libros";
            btnModLibros.UseVisualStyleBackColor = false;
            btnModLibros.Click += BtnModLibros_Click;
            // 
            // btnModCatAut
            // 
            btnModCatAut.BackColor = Color.FromArgb(41, 128, 185);
            btnModCatAut.Cursor = Cursors.Hand;
            btnModCatAut.FlatAppearance.BorderSize = 0;
            btnModCatAut.FlatStyle = FlatStyle.Flat;
            btnModCatAut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModCatAut.ForeColor = Color.White;
            btnModCatAut.Location = new Point(182, 55);
            btnModCatAut.Name = "btnModCatAut";
            btnModCatAut.Size = new Size(210, 40);
            btnModCatAut.TabIndex = 3;
            btnModCatAut.Text = "📂 Categorías / Autores";
            btnModCatAut.UseVisualStyleBackColor = false;
            btnModCatAut.Click += BtnModCatAut_Click;
            // 
            // btnModLectores
            // 
            btnModLectores.BackColor = Color.FromArgb(41, 128, 185);
            btnModLectores.Cursor = Cursors.Hand;
            btnModLectores.FlatAppearance.BorderSize = 0;
            btnModLectores.FlatStyle = FlatStyle.Flat;
            btnModLectores.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModLectores.ForeColor = Color.White;
            btnModLectores.Location = new Point(402, 55);
            btnModLectores.Name = "btnModLectores";
            btnModLectores.Size = new Size(150, 40);
            btnModLectores.TabIndex = 4;
            btnModLectores.Text = "🎓 Lectores";
            btnModLectores.UseVisualStyleBackColor = false;
            btnModLectores.Click += BtnModLectores_Click;
            // 
            // btnModPrestamos
            // 
            btnModPrestamos.BackColor = Color.FromArgb(39, 174, 96);
            btnModPrestamos.Cursor = Cursors.Hand;
            btnModPrestamos.FlatAppearance.BorderSize = 0;
            btnModPrestamos.FlatStyle = FlatStyle.Flat;
            btnModPrestamos.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModPrestamos.ForeColor = Color.White;
            btnModPrestamos.Location = new Point(562, 55);
            btnModPrestamos.Name = "btnModPrestamos";
            btnModPrestamos.Size = new Size(245, 40);
            btnModPrestamos.TabIndex = 5;
            btnModPrestamos.Text = "🔄 Préstamos y Devoluciones";
            btnModPrestamos.UseVisualStyleBackColor = false;
            btnModPrestamos.Click += BtnModPrestamos_Click;
            // 
            // btnModAdmin
            // 
            btnModAdmin.BackColor = Color.FromArgb(142, 68, 173);
            btnModAdmin.Cursor = Cursors.Hand;
            btnModAdmin.FlatAppearance.BorderSize = 0;
            btnModAdmin.FlatStyle = FlatStyle.Flat;
            btnModAdmin.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnModAdmin.ForeColor = Color.White;
            btnModAdmin.Location = new Point(817, 55);
            btnModAdmin.Name = "btnModAdmin";
            btnModAdmin.Size = new Size(190, 40);
            btnModAdmin.TabIndex = 6;
            btnModAdmin.Text = "⚙️ Administración";
            btnModAdmin.UseVisualStyleBackColor = false;
            btnModAdmin.Click += BtnModAdmin_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(192, 57, 43);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(1017, 55);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(125, 40);
            btnCerrarSesion.TabIndex = 7;
            btnCerrarSesion.Text = "🚪 Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += BtnCerrarSesion_Click;
            // 
            // pnlDashboard
            // 
            pnlDashboard.Controls.Add(card1);
            pnlDashboard.Controls.Add(card2);
            pnlDashboard.Controls.Add(card3);
            pnlDashboard.Controls.Add(card4);
            pnlDashboard.Dock = DockStyle.Top;
            pnlDashboard.Location = new Point(0, 110);
            pnlDashboard.Name = "pnlDashboard";
            pnlDashboard.Padding = new Padding(20, 12, 20, 10);
            pnlDashboard.Size = new Size(1164, 115);
            pnlDashboard.TabIndex = 1;
            // 
            // card1
            // 
            card1.BackColor = Color.White;
            card1.BorderStyle = BorderStyle.FixedSingle;
            card1.Controls.Add(lblKpiTitulos);
            card1.Controls.Add(lblTitCard1);
            card1.Controls.Add(barraColor1);
            card1.Location = new Point(22, 12);
            card1.Name = "card1";
            card1.Size = new Size(265, 88);
            card1.TabIndex = 0;
            // 
            // lblKpiTitulos
            // 
            lblKpiTitulos.AutoSize = true;
            lblKpiTitulos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiTitulos.ForeColor = Color.FromArgb(41, 128, 185);
            lblKpiTitulos.Location = new Point(20, 34);
            lblKpiTitulos.Name = "lblKpiTitulos";
            lblKpiTitulos.Size = new Size(35, 41);
            lblKpiTitulos.TabIndex = 2;
            lblKpiTitulos.Text = "0";
            // 
            // lblTitCard1
            // 
            lblTitCard1.AutoSize = true;
            lblTitCard1.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitCard1.ForeColor = Color.FromArgb(100, 110, 120);
            lblTitCard1.Location = new Point(20, 12);
            lblTitCard1.Name = "lblTitCard1";
            lblTitCard1.Size = new Size(138, 15);
            lblTitCard1.TabIndex = 1;
            lblTitCard1.Text = "TÍTULOS EN CATÁLOGO";
            // 
            // barraColor1
            // 
            barraColor1.BackColor = Color.FromArgb(41, 128, 185);
            barraColor1.Dock = DockStyle.Left;
            barraColor1.Location = new Point(0, 0);
            barraColor1.Name = "barraColor1";
            barraColor1.Size = new Size(8, 86);
            barraColor1.TabIndex = 0;
            // 
            // card2
            // 
            card2.BackColor = Color.White;
            card2.BorderStyle = BorderStyle.FixedSingle;
            card2.Controls.Add(lblKpiDisponibles);
            card2.Controls.Add(lblTitCard2);
            card2.Controls.Add(barraColor2);
            card2.Location = new Point(302, 12);
            card2.Name = "card2";
            card2.Size = new Size(265, 88);
            card2.TabIndex = 1;
            // 
            // lblKpiDisponibles
            // 
            lblKpiDisponibles.AutoSize = true;
            lblKpiDisponibles.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiDisponibles.ForeColor = Color.FromArgb(39, 174, 96);
            lblKpiDisponibles.Location = new Point(20, 34);
            lblKpiDisponibles.Name = "lblKpiDisponibles";
            lblKpiDisponibles.Size = new Size(35, 41);
            lblKpiDisponibles.TabIndex = 2;
            lblKpiDisponibles.Text = "0";
            // 
            // lblTitCard2
            // 
            lblTitCard2.AutoSize = true;
            lblTitCard2.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitCard2.ForeColor = Color.FromArgb(100, 110, 120);
            lblTitCard2.Location = new Point(20, 12);
            lblTitCard2.Name = "lblTitCard2";
            lblTitCard2.Size = new Size(156, 15);
            lblTitCard2.TabIndex = 1;
            lblTitCard2.Text = "EJEMPLARES DISPONIBLES";
            // 
            // barraColor2
            // 
            barraColor2.BackColor = Color.FromArgb(39, 174, 96);
            barraColor2.Dock = DockStyle.Left;
            barraColor2.Location = new Point(0, 0);
            barraColor2.Name = "barraColor2";
            barraColor2.Size = new Size(8, 86);
            barraColor2.TabIndex = 0;
            // 
            // card3
            // 
            card3.BackColor = Color.White;
            card3.BorderStyle = BorderStyle.FixedSingle;
            card3.Controls.Add(lblKpiActivos);
            card3.Controls.Add(lblTitCard3);
            card3.Controls.Add(barraColor3);
            card3.Location = new Point(582, 12);
            card3.Name = "card3";
            card3.Size = new Size(265, 88);
            card3.TabIndex = 2;
            // 
            // lblKpiActivos
            // 
            lblKpiActivos.AutoSize = true;
            lblKpiActivos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiActivos.ForeColor = Color.FromArgb(243, 156, 18);
            lblKpiActivos.Location = new Point(20, 34);
            lblKpiActivos.Name = "lblKpiActivos";
            lblKpiActivos.Size = new Size(35, 41);
            lblKpiActivos.TabIndex = 2;
            lblKpiActivos.Text = "0";
            // 
            // lblTitCard3
            // 
            lblTitCard3.AutoSize = true;
            lblTitCard3.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitCard3.ForeColor = Color.FromArgb(100, 110, 120);
            lblTitCard3.Location = new Point(20, 12);
            lblTitCard3.Name = "lblTitCard3";
            lblTitCard3.Size = new Size(129, 15);
            lblTitCard3.TabIndex = 1;
            lblTitCard3.Text = "PRÉSTAMOS ACTIVOS";
            // 
            // barraColor3
            // 
            barraColor3.BackColor = Color.FromArgb(243, 156, 18);
            barraColor3.Dock = DockStyle.Left;
            barraColor3.Location = new Point(0, 0);
            barraColor3.Name = "barraColor3";
            barraColor3.Size = new Size(8, 86);
            barraColor3.TabIndex = 0;
            // 
            // card4
            // 
            card4.BackColor = Color.White;
            card4.BorderStyle = BorderStyle.FixedSingle;
            card4.Controls.Add(lblKpiVencidos);
            card4.Controls.Add(lblTitCard4);
            card4.Controls.Add(barraColor4);
            card4.Location = new Point(862, 12);
            card4.Name = "card4";
            card4.Size = new Size(265, 88);
            card4.TabIndex = 3;
            // 
            // lblKpiVencidos
            // 
            lblKpiVencidos.AutoSize = true;
            lblKpiVencidos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblKpiVencidos.ForeColor = Color.FromArgb(192, 57, 43);
            lblKpiVencidos.Location = new Point(20, 34);
            lblKpiVencidos.Name = "lblKpiVencidos";
            lblKpiVencidos.Size = new Size(35, 41);
            lblKpiVencidos.TabIndex = 2;
            lblKpiVencidos.Text = "0";
            // 
            // lblTitCard4
            // 
            lblTitCard4.AutoSize = true;
            lblTitCard4.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblTitCard4.ForeColor = Color.FromArgb(100, 110, 120);
            lblTitCard4.Location = new Point(20, 12);
            lblTitCard4.Name = "lblTitCard4";
            lblTitCard4.Size = new Size(138, 15);
            lblTitCard4.TabIndex = 1;
            lblTitCard4.Text = "PRÉSTAMOS VENCIDOS";
            // 
            // barraColor4
            // 
            barraColor4.BackColor = Color.FromArgb(192, 57, 43);
            barraColor4.Dock = DockStyle.Left;
            barraColor4.Location = new Point(0, 0);
            barraColor4.Name = "barraColor4";
            barraColor4.Size = new Size(8, 86);
            barraColor4.TabIndex = 0;
            // 
            // pnlContenedorCentral
            // 
            pnlContenedorCentral.Controls.Add(tabConsultas);
            pnlContenedorCentral.Dock = DockStyle.Fill;
            pnlContenedorCentral.Location = new Point(0, 225);
            pnlContenedorCentral.Name = "pnlContenedorCentral";
            pnlContenedorCentral.Padding = new Padding(20, 5, 20, 15);
            pnlContenedorCentral.Size = new Size(1164, 476);
            pnlContenedorCentral.TabIndex = 2;
            // 
            // tabConsultas
            // 
            tabConsultas.Controls.Add(tabCat);
            tabConsultas.Controls.Add(tabHist);
            tabConsultas.Dock = DockStyle.Fill;
            tabConsultas.Location = new Point(20, 5);
            tabConsultas.Name = "tabConsultas";
            tabConsultas.Padding = new Point(14, 8);
            tabConsultas.SelectedIndex = 0;
            tabConsultas.Size = new Size(1124, 456);
            tabConsultas.TabIndex = 0;
            // 
            // tabCat
            // 
            tabCat.BackColor = Color.White;
            tabCat.Controls.Add(dgvConsultaLibros);
            tabCat.Controls.Add(pnlFiltrosLibros);
            tabCat.Location = new Point(4, 36);
            tabCat.Name = "tabCat";
            tabCat.Padding = new Padding(15);
            tabCat.Size = new Size(1116, 416);
            tabCat.TabIndex = 0;
            tabCat.Text = "🔎 Consulta del Catálogo de Libros";
            // 
            // dgvConsultaLibros
            // 
            dgvConsultaLibros.AllowUserToAddRows = false;
            dgvConsultaLibros.AllowUserToDeleteRows = false;
            dgvConsultaLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultaLibros.BackgroundColor = Color.White;
            dgvConsultaLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaLibros.Dock = DockStyle.Fill;
            dgvConsultaLibros.Location = new Point(15, 67);
            dgvConsultaLibros.MultiSelect = false;
            dgvConsultaLibros.Name = "dgvConsultaLibros";
            dgvConsultaLibros.ReadOnly = true;
            dgvConsultaLibros.RowHeadersVisible = false;
            dgvConsultaLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultaLibros.Size = new Size(1086, 334);
            dgvConsultaLibros.TabIndex = 1;
            // 
            // pnlFiltrosLibros
            // 
            pnlFiltrosLibros.Controls.Add(lblTextoLibro);
            pnlFiltrosLibros.Controls.Add(txtFiltroLibro);
            pnlFiltrosLibros.Controls.Add(lblCatLibro);
            pnlFiltrosLibros.Controls.Add(cboFiltroCategoria);
            pnlFiltrosLibros.Controls.Add(lblAutLibro);
            pnlFiltrosLibros.Controls.Add(cboFiltroAutor);
            pnlFiltrosLibros.Controls.Add(btnLimpiarFiltroLibros);
            pnlFiltrosLibros.Dock = DockStyle.Top;
            pnlFiltrosLibros.Location = new Point(15, 15);
            pnlFiltrosLibros.Name = "pnlFiltrosLibros";
            pnlFiltrosLibros.Size = new Size(1086, 52);
            pnlFiltrosLibros.TabIndex = 0;
            // 
            // lblTextoLibro
            // 
            lblTextoLibro.AutoSize = true;
            lblTextoLibro.Location = new Point(5, 15);
            lblTextoLibro.Name = "lblTextoLibro";
            lblTextoLibro.Size = new Size(125, 17);
            lblTextoLibro.TabIndex = 0;
            lblTextoLibro.Text = "Buscar (Título/ISBN):";
            // 
            // txtFiltroLibro
            // 
            txtFiltroLibro.Location = new Point(145, 12);
            txtFiltroLibro.Name = "txtFiltroLibro";
            txtFiltroLibro.Size = new Size(230, 24);
            txtFiltroLibro.TabIndex = 1;
            txtFiltroLibro.TextChanged += TxtFiltroLibro_TextChanged;
            // 
            // lblCatLibro
            // 
            lblCatLibro.AutoSize = true;
            lblCatLibro.Location = new Point(395, 15);
            lblCatLibro.Name = "lblCatLibro";
            lblCatLibro.Size = new Size(68, 17);
            lblCatLibro.TabIndex = 2;
            lblCatLibro.Text = "Categoría:";
            // 
            // cboFiltroCategoria
            // 
            cboFiltroCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroCategoria.FormattingEnabled = true;
            cboFiltroCategoria.Location = new Point(468, 12);
            cboFiltroCategoria.Name = "cboFiltroCategoria";
            cboFiltroCategoria.Size = new Size(200, 25);
            cboFiltroCategoria.TabIndex = 3;
            cboFiltroCategoria.SelectedIndexChanged += CboFiltroCategoria_SelectedIndexChanged;
            // 
            // lblAutLibro
            // 
            lblAutLibro.AutoSize = true;
            lblAutLibro.Location = new Point(685, 15);
            lblAutLibro.Name = "lblAutLibro";
            lblAutLibro.Size = new Size(43, 17);
            lblAutLibro.TabIndex = 4;
            lblAutLibro.Text = "Autor:";
            // 
            // cboFiltroAutor
            // 
            cboFiltroAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroAutor.FormattingEnabled = true;
            cboFiltroAutor.Location = new Point(735, 12);
            cboFiltroAutor.Name = "cboFiltroAutor";
            cboFiltroAutor.Size = new Size(210, 25);
            cboFiltroAutor.TabIndex = 5;
            cboFiltroAutor.SelectedIndexChanged += CboFiltroAutor_SelectedIndexChanged;
            // 
            // btnLimpiarFiltroLibros
            // 
            btnLimpiarFiltroLibros.BackColor = Color.FromArgb(230, 235, 240);
            btnLimpiarFiltroLibros.FlatStyle = FlatStyle.Flat;
            btnLimpiarFiltroLibros.Location = new Point(960, 10);
            btnLimpiarFiltroLibros.Name = "btnLimpiarFiltroLibros";
            btnLimpiarFiltroLibros.Size = new Size(110, 30);
            btnLimpiarFiltroLibros.TabIndex = 6;
            btnLimpiarFiltroLibros.Text = "🔄 Todos";
            btnLimpiarFiltroLibros.UseVisualStyleBackColor = false;
            btnLimpiarFiltroLibros.Click += BtnLimpiarFiltroLibros_Click;
            // 
            // tabHist
            // 
            tabHist.BackColor = Color.White;
            tabHist.Controls.Add(dgvConsultaPrestamos);
            tabHist.Controls.Add(pnlFiltrosPrestamos);
            tabHist.Location = new Point(4, 36);
            tabHist.Name = "tabHist";
            tabHist.Padding = new Padding(15);
            tabHist.Size = new Size(1116, 416);
            tabHist.TabIndex = 1;
            tabHist.Text = "📋 Historial y Monitor de Préstamos";
            // 
            // dgvConsultaPrestamos
            // 
            dgvConsultaPrestamos.AllowUserToAddRows = false;
            dgvConsultaPrestamos.AllowUserToDeleteRows = false;
            dgvConsultaPrestamos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvConsultaPrestamos.BackgroundColor = Color.White;
            dgvConsultaPrestamos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvConsultaPrestamos.Dock = DockStyle.Fill;
            dgvConsultaPrestamos.Location = new Point(15, 67);
            dgvConsultaPrestamos.MultiSelect = false;
            dgvConsultaPrestamos.Name = "dgvConsultaPrestamos";
            dgvConsultaPrestamos.ReadOnly = true;
            dgvConsultaPrestamos.RowHeadersVisible = false;
            dgvConsultaPrestamos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvConsultaPrestamos.Size = new Size(1086, 334);
            dgvConsultaPrestamos.TabIndex = 1;
            // 
            // pnlFiltrosPrestamos
            // 
            pnlFiltrosPrestamos.Controls.Add(lblTextoPrestamo);
            pnlFiltrosPrestamos.Controls.Add(txtFiltroPrestamo);
            pnlFiltrosPrestamos.Controls.Add(lblEstadoPrestamo);
            pnlFiltrosPrestamos.Controls.Add(cboFiltroEstadoPrestamo);
            pnlFiltrosPrestamos.Controls.Add(btnRefrescarPrestamos);
            pnlFiltrosPrestamos.Dock = DockStyle.Top;
            pnlFiltrosPrestamos.Location = new Point(15, 15);
            pnlFiltrosPrestamos.Name = "pnlFiltrosPrestamos";
            pnlFiltrosPrestamos.Size = new Size(1086, 52);
            pnlFiltrosPrestamos.TabIndex = 0;
            // 
            // lblTextoPrestamo
            // 
            lblTextoPrestamo.AutoSize = true;
            lblTextoPrestamo.Location = new Point(5, 15);
            lblTextoPrestamo.Name = "lblTextoPrestamo";
            lblTextoPrestamo.Size = new Size(255, 17);
            lblTextoPrestamo.TabIndex = 0;
            lblTextoPrestamo.Text = "Buscar por Libro, ISBN, Lector o Matrícula:";
            // 
            // txtFiltroPrestamo
            // 
            txtFiltroPrestamo.Location = new Point(280, 12);
            txtFiltroPrestamo.Name = "txtFiltroPrestamo";
            txtFiltroPrestamo.Size = new Size(280, 24);
            txtFiltroPrestamo.TabIndex = 1;
            txtFiltroPrestamo.TextChanged += TxtFiltroPrestamo_TextChanged;
            // 
            // lblEstadoPrestamo
            // 
            lblEstadoPrestamo.AutoSize = true;
            lblEstadoPrestamo.Location = new Point(585, 15);
            lblEstadoPrestamo.Name = "lblEstadoPrestamo";
            lblEstadoPrestamo.Size = new Size(132, 17);
            lblEstadoPrestamo.TabIndex = 2;
            lblEstadoPrestamo.Text = "Estado del Préstamo:";
            // 
            // cboFiltroEstadoPrestamo
            // 
            cboFiltroEstadoPrestamo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroEstadoPrestamo.FormattingEnabled = true;
            cboFiltroEstadoPrestamo.Items.AddRange(new object[] { "Todos", "Activos", "Devueltos", "Vencidos" });
            cboFiltroEstadoPrestamo.Location = new Point(725, 12);
            cboFiltroEstadoPrestamo.Name = "cboFiltroEstadoPrestamo";
            cboFiltroEstadoPrestamo.Size = new Size(170, 25);
            cboFiltroEstadoPrestamo.TabIndex = 3;
            cboFiltroEstadoPrestamo.SelectedIndexChanged += CboFiltroEstadoPrestamo_SelectedIndexChanged;
            // 
            // btnRefrescarPrestamos
            // 
            btnRefrescarPrestamos.BackColor = Color.FromArgb(230, 235, 240);
            btnRefrescarPrestamos.FlatStyle = FlatStyle.Flat;
            btnRefrescarPrestamos.Location = new Point(915, 10);
            btnRefrescarPrestamos.Name = "btnRefrescarPrestamos";
            btnRefrescarPrestamos.Size = new Size(130, 30);
            btnRefrescarPrestamos.TabIndex = 4;
            btnRefrescarPrestamos.Text = "🔄 Actualizar";
            btnRefrescarPrestamos.UseVisualStyleBackColor = false;
            btnRefrescarPrestamos.Click += BtnRefrescarPrestamos_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1164, 701);
            Controls.Add(pnlContenedorCentral);
            Controls.Add(pnlDashboard);
            Controls.Add(pnlSuperior);
            Font = new Font("Segoe UI", 9.5F);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BiblioTech - Panel Principal";
            pnlSuperior.ResumeLayout(false);
            pnlSuperior.PerformLayout();
            pnlDashboard.ResumeLayout(false);
            card1.ResumeLayout(false);
            card1.PerformLayout();
            card2.ResumeLayout(false);
            card2.PerformLayout();
            card3.ResumeLayout(false);
            card3.PerformLayout();
            card4.ResumeLayout(false);
            card4.PerformLayout();
            pnlContenedorCentral.ResumeLayout(false);
            tabConsultas.ResumeLayout(false);
            tabCat.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConsultaLibros).EndInit();
            pnlFiltrosLibros.ResumeLayout(false);
            pnlFiltrosLibros.PerformLayout();
            tabHist.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvConsultaPrestamos).EndInit();
            pnlFiltrosPrestamos.ResumeLayout(false);
            pnlFiltrosPrestamos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSuperior;
        private Label lblNombreInstitucion;
        private Label lblUsuarioActivo;
        private Button btnModLibros;
        private Button btnModCatAut;
        private Button btnModLectores;
        private Button btnModPrestamos;
        private Button btnModAdmin;
        private Button btnCerrarSesion;
        private Panel pnlDashboard;
        private Panel card1;
        private Label lblKpiTitulos;
        private Label lblTitCard1;
        private Panel barraColor1;
        private Panel card2;
        private Label lblKpiDisponibles;
        private Label lblTitCard2;
        private Panel barraColor2;
        private Panel card3;
        private Label lblKpiActivos;
        private Label lblTitCard3;
        private Panel barraColor3;
        private Panel card4;
        private Label lblKpiVencidos;
        private Label lblTitCard4;
        private Panel barraColor4;
        private Panel pnlContenedorCentral;
        private TabControl tabConsultas;
        private TabPage tabCat;
        private DataGridView dgvConsultaLibros;
        private Panel pnlFiltrosLibros;
        private Label lblTextoLibro;
        private TextBox txtFiltroLibro;
        private Label lblCatLibro;
        private ComboBox cboFiltroCategoria;
        private Label lblAutLibro;
        private ComboBox cboFiltroAutor;
        private Button btnLimpiarFiltroLibros;
        private TabPage tabHist;
        private DataGridView dgvConsultaPrestamos;
        private Panel pnlFiltrosPrestamos;
        private Label lblTextoPrestamo;
        private TextBox txtFiltroPrestamo;
        private Label lblEstadoPrestamo;
        private ComboBox cboFiltroEstadoPrestamo;
        private Button btnRefrescarPrestamos;
    }
}
