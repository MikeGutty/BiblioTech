namespace BiblioTech.Formularios
{
    partial class FrmLectores
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
            grpDatos = new GroupBox();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblDoc = new Label();
            txtDocumento = new TextBox();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTel = new Label();
            txtTelefono = new TextBox();
            chkActivo = new CheckBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            dgvLectores = new DataGridView();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLectores).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.BackColor = Color.White;
            grpDatos.Controls.Add(lblNombre);
            grpDatos.Controls.Add(txtNombre);
            grpDatos.Controls.Add(lblDoc);
            grpDatos.Controls.Add(txtDocumento);
            grpDatos.Controls.Add(lblTipo);
            grpDatos.Controls.Add(cboTipo);
            grpDatos.Controls.Add(lblEmail);
            grpDatos.Controls.Add(txtEmail);
            grpDatos.Controls.Add(lblTel);
            grpDatos.Controls.Add(txtTelefono);
            grpDatos.Controls.Add(chkActivo);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnLimpiar);
            grpDatos.Controls.Add(btnEliminar);
            grpDatos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDatos.Location = new Point(20, 15);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(865, 185);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "🎓 Datos del Lector";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblNombre.Location = new Point(20, 35);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(118, 17);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre Completo:";
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtNombre.Location = new Point(150, 32);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(280, 24);
            txtNombre.TabIndex = 1;
            // 
            // lblDoc
            // 
            lblDoc.AutoSize = true;
            lblDoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblDoc.Location = new Point(450, 35);
            lblDoc.Name = "lblDoc";
            lblDoc.Size = new Size(88, 17);
            lblDoc.TabIndex = 2;
            lblDoc.Text = "Matrícula / CI:";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtDocumento.Location = new Point(555, 32);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(140, 24);
            txtDocumento.TabIndex = 3;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblTipo.Location = new Point(710, 35);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(36, 17);
            lblTipo.TabIndex = 4;
            lblTipo.Text = "Tipo:";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            cboTipo.FormattingEnabled = true;
            cboTipo.Items.AddRange(new object[] { "Estudiante", "Docente" });
            cboTipo.Location = new Point(750, 32);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(95, 25);
            cboTipo.TabIndex = 5;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblEmail.Location = new Point(20, 80);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(118, 17);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Correo Electrónico:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtEmail.Location = new Point(150, 77);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(280, 24);
            txtEmail.TabIndex = 7;
            // 
            // lblTel
            // 
            lblTel.AutoSize = true;
            lblTel.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblTel.Location = new Point(450, 80);
            lblTel.Name = "lblTel";
            lblTel.Size = new Size(60, 17);
            lblTel.TabIndex = 8;
            lblTel.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtTelefono.Location = new Point(555, 77);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(140, 24);
            txtTelefono.TabIndex = 9;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            chkActivo.Location = new Point(715, 78);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(103, 21);
            chkActivo.TabIndex = 10;
            chkActivo.Text = "Lector Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(25, 55, 109);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(150, 128);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(180, 36);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "💾 Guardar / Actualizar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatAppearance.BorderSize = 0;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(345, 128);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(180, 36);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "🧹 Limpiar / Nuevo";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(192, 57, 43);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatAppearance.BorderSize = 0;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(540, 128);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(180, 36);
            btnEliminar.TabIndex = 13;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBuscar.Location = new Point(20, 218);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(305, 17);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "🔍 Buscar por Nombre o Matrícula/Documento:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(340, 215);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(320, 24);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            // 
            // dgvLectores
            // 
            dgvLectores.AllowUserToAddRows = false;
            dgvLectores.AllowUserToDeleteRows = false;
            dgvLectores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLectores.BackgroundColor = Color.White;
            dgvLectores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLectores.Location = new Point(20, 255);
            dgvLectores.MultiSelect = false;
            dgvLectores.Name = "dgvLectores";
            dgvLectores.ReadOnly = true;
            dgvLectores.RowHeadersVisible = false;
            dgvLectores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLectores.Size = new Size(865, 270);
            dgvLectores.TabIndex = 3;
            dgvLectores.SelectionChanged += DgvLectores_SelectionChanged;
            // 
            // FrmLectores
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(904, 541);
            Controls.Add(grpDatos);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(dgvLectores);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLectores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Gestión de Lectores";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLectores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpDatos;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblDoc;
        private TextBox txtDocumento;
        private Label lblTipo;
        private ComboBox cboTipo;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTel;
        private TextBox txtTelefono;
        private CheckBox chkActivo;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private DataGridView dgvLectores;
    }
}
