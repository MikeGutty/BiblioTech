namespace BiblioTech.Formularios
{
    partial class FrmCategoriasAutores
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
            tabControl = new TabControl();
            tabCategorias = new TabPage();
            grpDatosCat = new GroupBox();
            lblCatNombre = new Label();
            txtCatNombre = new TextBox();
            lblCatDesc = new Label();
            txtCatDescripcion = new TextBox();
            btnGuardarCat = new Button();
            btnLimpiarCat = new Button();
            btnEliminarCat = new Button();
            dgvCategorias = new DataGridView();
            tabAutores = new TabPage();
            grpDatosAut = new GroupBox();
            lblAutNombre = new Label();
            txtAutNombre = new TextBox();
            lblAutNac = new Label();
            txtAutNacionalidad = new TextBox();
            btnGuardarAut = new Button();
            btnLimpiarAut = new Button();
            btnEliminarAut = new Button();
            dgvAutores = new DataGridView();
            tabControl.SuspendLayout();
            tabCategorias.SuspendLayout();
            grpDatosCat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            tabAutores.SuspendLayout();
            grpDatosAut.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabCategorias);
            tabControl.Controls.Add(tabAutores);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(14, 8);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(864, 521);
            tabControl.TabIndex = 0;
            // 
            // tabCategorias
            // 
            tabCategorias.BackColor = Color.White;
            tabCategorias.Controls.Add(grpDatosCat);
            tabCategorias.Controls.Add(dgvCategorias);
            tabCategorias.Location = new Point(4, 34);
            tabCategorias.Name = "tabCategorias";
            tabCategorias.Padding = new Padding(15);
            tabCategorias.Size = new Size(856, 483);
            tabCategorias.TabIndex = 0;
            tabCategorias.Text = "📂 Categorías Literarias";
            // 
            // grpDatosCat
            // 
            grpDatosCat.Controls.Add(lblCatNombre);
            grpDatosCat.Controls.Add(txtCatNombre);
            grpDatosCat.Controls.Add(lblCatDesc);
            grpDatosCat.Controls.Add(txtCatDescripcion);
            grpDatosCat.Controls.Add(btnGuardarCat);
            grpDatosCat.Controls.Add(btnLimpiarCat);
            grpDatosCat.Controls.Add(btnEliminarCat);
            grpDatosCat.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDatosCat.Location = new Point(15, 10);
            grpDatosCat.Name = "grpDatosCat";
            grpDatosCat.Size = new Size(815, 135);
            grpDatosCat.TabIndex = 0;
            grpDatosCat.TabStop = false;
            grpDatosCat.Text = "Datos de la Categoría";
            // 
            // lblCatNombre
            // 
            lblCatNombre.AutoSize = true;
            lblCatNombre.Font = new Font("Segoe UI", 9.5F);
            lblCatNombre.Location = new Point(20, 32);
            lblCatNombre.Name = "lblCatNombre";
            lblCatNombre.Size = new Size(58, 17);
            lblCatNombre.TabIndex = 0;
            lblCatNombre.Text = "Nombre:";
            // 
            // txtCatNombre
            // 
            txtCatNombre.Font = new Font("Segoe UI", 9.5F);
            txtCatNombre.Location = new Point(110, 29);
            txtCatNombre.Name = "txtCatNombre";
            txtCatNombre.Size = new Size(270, 24);
            txtCatNombre.TabIndex = 1;
            // 
            // lblCatDesc
            // 
            lblCatDesc.AutoSize = true;
            lblCatDesc.Font = new Font("Segoe UI", 9.5F);
            lblCatDesc.Location = new Point(400, 32);
            lblCatDesc.Name = "lblCatDesc";
            lblCatDesc.Size = new Size(79, 17);
            lblCatDesc.TabIndex = 2;
            lblCatDesc.Text = "Descripción:";
            // 
            // txtCatDescripcion
            // 
            txtCatDescripcion.Font = new Font("Segoe UI", 9.5F);
            txtCatDescripcion.Location = new Point(495, 29);
            txtCatDescripcion.Name = "txtCatDescripcion";
            txtCatDescripcion.Size = new Size(295, 24);
            txtCatDescripcion.TabIndex = 3;
            // 
            // btnGuardarCat
            // 
            btnGuardarCat.BackColor = Color.FromArgb(25, 55, 109);
            btnGuardarCat.Cursor = Cursors.Hand;
            btnGuardarCat.FlatAppearance.BorderSize = 0;
            btnGuardarCat.FlatStyle = FlatStyle.Flat;
            btnGuardarCat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardarCat.ForeColor = Color.White;
            btnGuardarCat.Location = new Point(110, 78);
            btnGuardarCat.Name = "btnGuardarCat";
            btnGuardarCat.Size = new Size(185, 36);
            btnGuardarCat.TabIndex = 4;
            btnGuardarCat.Text = "💾 Guardar / Actualizar";
            btnGuardarCat.UseVisualStyleBackColor = false;
            btnGuardarCat.Click += BtnGuardarCat_Click;
            // 
            // btnLimpiarCat
            // 
            btnLimpiarCat.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarCat.Cursor = Cursors.Hand;
            btnLimpiarCat.FlatAppearance.BorderSize = 0;
            btnLimpiarCat.FlatStyle = FlatStyle.Flat;
            btnLimpiarCat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarCat.ForeColor = Color.White;
            btnLimpiarCat.Location = new Point(310, 78);
            btnLimpiarCat.Name = "btnLimpiarCat";
            btnLimpiarCat.Size = new Size(170, 36);
            btnLimpiarCat.TabIndex = 5;
            btnLimpiarCat.Text = "🧹 Limpiar / Nuevo";
            btnLimpiarCat.UseVisualStyleBackColor = false;
            btnLimpiarCat.Click += BtnLimpiarCat_Click;
            // 
            // btnEliminarCat
            // 
            btnEliminarCat.BackColor = Color.FromArgb(192, 57, 43);
            btnEliminarCat.Cursor = Cursors.Hand;
            btnEliminarCat.FlatAppearance.BorderSize = 0;
            btnEliminarCat.FlatStyle = FlatStyle.Flat;
            btnEliminarCat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminarCat.ForeColor = Color.White;
            btnEliminarCat.Location = new Point(495, 78);
            btnEliminarCat.Name = "btnEliminarCat";
            btnEliminarCat.Size = new Size(150, 36);
            btnEliminarCat.TabIndex = 6;
            btnEliminarCat.Text = "🗑️ Eliminar";
            btnEliminarCat.UseVisualStyleBackColor = false;
            btnEliminarCat.Click += BtnEliminarCat_Click;
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.BackgroundColor = Color.White;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(15, 160);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(815, 310);
            dgvCategorias.TabIndex = 1;
            dgvCategorias.SelectionChanged += DgvCategorias_SelectionChanged;
            // 
            // tabAutores
            // 
            tabAutores.BackColor = Color.White;
            tabAutores.Controls.Add(grpDatosAut);
            tabAutores.Controls.Add(dgvAutores);
            tabAutores.Location = new Point(4, 34);
            tabAutores.Name = "tabAutores";
            tabAutores.Padding = new Padding(15);
            tabAutores.Size = new Size(856, 483);
            tabAutores.TabIndex = 1;
            tabAutores.Text = "✍️ Autores";
            // 
            // grpDatosAut
            // 
            grpDatosAut.Controls.Add(lblAutNombre);
            grpDatosAut.Controls.Add(txtAutNombre);
            grpDatosAut.Controls.Add(lblAutNac);
            grpDatosAut.Controls.Add(txtAutNacionalidad);
            grpDatosAut.Controls.Add(btnGuardarAut);
            grpDatosAut.Controls.Add(btnLimpiarAut);
            grpDatosAut.Controls.Add(btnEliminarAut);
            grpDatosAut.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpDatosAut.Location = new Point(15, 10);
            grpDatosAut.Name = "grpDatosAut";
            grpDatosAut.Size = new Size(815, 135);
            grpDatosAut.TabIndex = 0;
            grpDatosAut.TabStop = false;
            grpDatosAut.Text = "Datos del Autor";
            // 
            // lblAutNombre
            // 
            lblAutNombre.AutoSize = true;
            lblAutNombre.Font = new Font("Segoe UI", 9.5F);
            lblAutNombre.Location = new Point(20, 32);
            lblAutNombre.Name = "lblAutNombre";
            lblAutNombre.Size = new Size(118, 17);
            lblAutNombre.TabIndex = 0;
            lblAutNombre.Text = "Nombre Completo:";
            // 
            // txtAutNombre
            // 
            txtAutNombre.Font = new Font("Segoe UI", 9.5F);
            txtAutNombre.Location = new Point(150, 29);
            txtAutNombre.Name = "txtAutNombre";
            txtAutNombre.Size = new Size(260, 24);
            txtAutNombre.TabIndex = 1;
            // 
            // lblAutNac
            // 
            lblAutNac.AutoSize = true;
            lblAutNac.Font = new Font("Segoe UI", 9.5F);
            lblAutNac.Location = new Point(430, 32);
            lblAutNac.Name = "lblAutNac";
            lblAutNac.Size = new Size(86, 17);
            lblAutNac.TabIndex = 2;
            lblAutNac.Text = "Nacionalidad:";
            // 
            // txtAutNacionalidad
            // 
            txtAutNacionalidad.Font = new Font("Segoe UI", 9.5F);
            txtAutNacionalidad.Location = new Point(530, 29);
            txtAutNacionalidad.Name = "txtAutNacionalidad";
            txtAutNacionalidad.Size = new Size(260, 24);
            txtAutNacionalidad.TabIndex = 3;
            // 
            // btnGuardarAut
            // 
            btnGuardarAut.BackColor = Color.FromArgb(25, 55, 109);
            btnGuardarAut.Cursor = Cursors.Hand;
            btnGuardarAut.FlatAppearance.BorderSize = 0;
            btnGuardarAut.FlatStyle = FlatStyle.Flat;
            btnGuardarAut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardarAut.ForeColor = Color.White;
            btnGuardarAut.Location = new Point(150, 78);
            btnGuardarAut.Name = "btnGuardarAut";
            btnGuardarAut.Size = new Size(185, 36);
            btnGuardarAut.TabIndex = 4;
            btnGuardarAut.Text = "💾 Guardar / Actualizar";
            btnGuardarAut.UseVisualStyleBackColor = false;
            btnGuardarAut.Click += BtnGuardarAut_Click;
            // 
            // btnLimpiarAut
            // 
            btnLimpiarAut.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarAut.Cursor = Cursors.Hand;
            btnLimpiarAut.FlatAppearance.BorderSize = 0;
            btnLimpiarAut.FlatStyle = FlatStyle.Flat;
            btnLimpiarAut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarAut.ForeColor = Color.White;
            btnLimpiarAut.Location = new Point(350, 78);
            btnLimpiarAut.Name = "btnLimpiarAut";
            btnLimpiarAut.Size = new Size(165, 36);
            btnLimpiarAut.TabIndex = 5;
            btnLimpiarAut.Text = "🧹 Limpiar / Nuevo";
            btnLimpiarAut.UseVisualStyleBackColor = false;
            btnLimpiarAut.Click += BtnLimpiarAut_Click;
            // 
            // btnEliminarAut
            // 
            btnEliminarAut.BackColor = Color.FromArgb(192, 57, 43);
            btnEliminarAut.Cursor = Cursors.Hand;
            btnEliminarAut.FlatAppearance.BorderSize = 0;
            btnEliminarAut.FlatStyle = FlatStyle.Flat;
            btnEliminarAut.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminarAut.ForeColor = Color.White;
            btnEliminarAut.Location = new Point(530, 78);
            btnEliminarAut.Name = "btnEliminarAut";
            btnEliminarAut.Size = new Size(150, 36);
            btnEliminarAut.TabIndex = 6;
            btnEliminarAut.Text = "🗑️ Eliminar";
            btnEliminarAut.UseVisualStyleBackColor = false;
            btnEliminarAut.Click += BtnEliminarAut_Click;
            // 
            // dgvAutores
            // 
            dgvAutores.AllowUserToAddRows = false;
            dgvAutores.AllowUserToDeleteRows = false;
            dgvAutores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAutores.BackgroundColor = Color.White;
            dgvAutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAutores.Location = new Point(15, 160);
            dgvAutores.MultiSelect = false;
            dgvAutores.Name = "dgvAutores";
            dgvAutores.ReadOnly = true;
            dgvAutores.RowHeadersVisible = false;
            dgvAutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutores.Size = new Size(815, 310);
            dgvAutores.TabIndex = 1;
            dgvAutores.SelectionChanged += DgvAutores_SelectionChanged;
            // 
            // FrmCategoriasAutores
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(864, 521);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmCategoriasAutores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Categorías y Autores";
            tabControl.ResumeLayout(false);
            tabCategorias.ResumeLayout(false);
            grpDatosCat.ResumeLayout(false);
            grpDatosCat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            tabAutores.ResumeLayout(false);
            grpDatosAut.ResumeLayout(false);
            grpDatosAut.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabCategorias;
        private GroupBox grpDatosCat;
        private Label lblCatNombre;
        private TextBox txtCatNombre;
        private Label lblCatDesc;
        private TextBox txtCatDescripcion;
        private Button btnGuardarCat;
        private Button btnLimpiarCat;
        private Button btnEliminarCat;
        private DataGridView dgvCategorias;
        private TabPage tabAutores;
        private GroupBox grpDatosAut;
        private Label lblAutNombre;
        private TextBox txtAutNombre;
        private Label lblAutNac;
        private TextBox txtAutNacionalidad;
        private Button btnGuardarAut;
        private Button btnLimpiarAut;
        private Button btnEliminarAut;
        private DataGridView dgvAutores;
    }
}
