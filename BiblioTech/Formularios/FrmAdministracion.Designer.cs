namespace BiblioTech.Formularios
{
    partial class FrmAdministracion
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
            tabUsuarios = new TabPage();
            grpUsuario = new GroupBox();
            lblNombre = new Label();
            txtNombreCompleto = new TextBox();
            lblDoc = new Label();
            txtDocumento = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblUser = new Label();
            txtNombreUsuario = new TextBox();
            lblPass = new Label();
            txtContrasena = new TextBox();
            lblRol = new Label();
            cboRol = new ComboBox();
            chkActivo = new CheckBox();
            btnGuardarUsuario = new Button();
            btnLimpiarUsuario = new Button();
            dgvUsuarios = new DataGridView();
            tabReglas = new TabPage();
            grpReglas = new GroupBox();
            lblNombreBiblio = new Label();
            txtNombreBiblio = new TextBox();
            lblDias = new Label();
            numDiasPrestamo = new NumericUpDown();
            lblMulta = new Label();
            numMultaDiaria = new NumericUpDown();
            btnGuardarConfig = new Button();
            tabControl.SuspendLayout();
            tabUsuarios.SuspendLayout();
            grpUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tabReglas.SuspendLayout();
            grpReglas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDiasPrestamo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMultaDiaria).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabUsuarios);
            tabControl.Controls.Add(tabReglas);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(14, 8);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(904, 541);
            tabControl.TabIndex = 0;
            // 
            // tabUsuarios
            // 
            tabUsuarios.BackColor = Color.White;
            tabUsuarios.Controls.Add(grpUsuario);
            tabUsuarios.Controls.Add(dgvUsuarios);
            tabUsuarios.Location = new Point(4, 34);
            tabUsuarios.Name = "tabUsuarios";
            tabUsuarios.Padding = new Padding(15);
            tabUsuarios.Size = new Size(896, 503);
            tabUsuarios.TabIndex = 0;
            tabUsuarios.Text = "👥 Usuarios del Sistema y Roles";
            // 
            // grpUsuario
            // 
            grpUsuario.Controls.Add(lblNombre);
            grpUsuario.Controls.Add(txtNombreCompleto);
            grpUsuario.Controls.Add(lblDoc);
            grpUsuario.Controls.Add(txtDocumento);
            grpUsuario.Controls.Add(lblEmail);
            grpUsuario.Controls.Add(txtEmail);
            grpUsuario.Controls.Add(lblUser);
            grpUsuario.Controls.Add(txtNombreUsuario);
            grpUsuario.Controls.Add(lblPass);
            grpUsuario.Controls.Add(txtContrasena);
            grpUsuario.Controls.Add(lblRol);
            grpUsuario.Controls.Add(cboRol);
            grpUsuario.Controls.Add(chkActivo);
            grpUsuario.Controls.Add(btnGuardarUsuario);
            grpUsuario.Controls.Add(btnLimpiarUsuario);
            grpUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            grpUsuario.Location = new Point(15, 10);
            grpUsuario.Name = "grpUsuario";
            grpUsuario.Size = new Size(855, 195);
            grpUsuario.TabIndex = 0;
            grpUsuario.TabStop = false;
            grpUsuario.Text = "Datos de la Cuenta (UsuarioSistema hereda de Persona)";
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
            // txtNombreCompleto
            // 
            txtNombreCompleto.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtNombreCompleto.Location = new Point(145, 32);
            txtNombreCompleto.Name = "txtNombreCompleto";
            txtNombreCompleto.Size = new Size(260, 24);
            txtNombreCompleto.TabIndex = 1;
            // 
            // lblDoc
            // 
            lblDoc.AutoSize = true;
            lblDoc.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblDoc.Location = new Point(425, 35);
            lblDoc.Name = "lblDoc";
            lblDoc.Size = new Size(78, 17);
            lblDoc.TabIndex = 2;
            lblDoc.Text = "Documento:";
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtDocumento.Location = new Point(510, 32);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(120, 24);
            txtDocumento.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblEmail.Location = new Point(645, 35);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 17);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtEmail.Location = new Point(695, 32);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(140, 24);
            txtEmail.TabIndex = 5;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblUser.Location = new Point(20, 80);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(98, 17);
            lblUser.TabIndex = 6;
            lblUser.Text = "Usuario (Login):";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtNombreUsuario.Location = new Point(145, 77);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(155, 24);
            txtNombreUsuario.TabIndex = 7;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblPass.Location = new Point(320, 80);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(76, 17);
            lblPass.TabIndex = 8;
            lblPass.Text = "Contraseña:";
            // 
            // txtContrasena
            // 
            txtContrasena.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            txtContrasena.Location = new Point(405, 77);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(145, 24);
            txtContrasena.TabIndex = 9;
            // 
            // lblRol
            // 
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblRol.Location = new Point(570, 80);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(29, 17);
            lblRol.TabIndex = 10;
            lblRol.Text = "Rol:";
            // 
            // cboRol
            // 
            cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRol.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            cboRol.FormattingEnabled = true;
            cboRol.Items.AddRange(new object[] { "Administrador", "Bibliotecario" });
            cboRol.Location = new Point(610, 77);
            cboRol.Name = "cboRol";
            cboRol.Size = new Size(135, 25);
            cboRol.TabIndex = 11;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Checked = true;
            chkActivo.CheckState = CheckState.Checked;
            chkActivo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            chkActivo.Location = new Point(760, 78);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(62, 21);
            chkActivo.TabIndex = 12;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.BackColor = Color.FromArgb(25, 55, 109);
            btnGuardarUsuario.Cursor = Cursors.Hand;
            btnGuardarUsuario.FlatAppearance.BorderSize = 0;
            btnGuardarUsuario.FlatStyle = FlatStyle.Flat;
            btnGuardarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardarUsuario.ForeColor = Color.White;
            btnGuardarUsuario.Location = new Point(145, 132);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(235, 38);
            btnGuardarUsuario.TabIndex = 13;
            btnGuardarUsuario.Text = "💾 Guardar / Actualizar Usuario";
            btnGuardarUsuario.UseVisualStyleBackColor = false;
            btnGuardarUsuario.Click += BtnGuardarUsuario_Click;
            // 
            // btnLimpiarUsuario
            // 
            btnLimpiarUsuario.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarUsuario.Cursor = Cursors.Hand;
            btnLimpiarUsuario.FlatAppearance.BorderSize = 0;
            btnLimpiarUsuario.FlatStyle = FlatStyle.Flat;
            btnLimpiarUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLimpiarUsuario.ForeColor = Color.White;
            btnLimpiarUsuario.Location = new Point(400, 132);
            btnLimpiarUsuario.Name = "btnLimpiarUsuario";
            btnLimpiarUsuario.Size = new Size(210, 38);
            btnLimpiarUsuario.TabIndex = 14;
            btnLimpiarUsuario.Text = "🧹 Limpiar / Nuevo Usuario";
            btnLimpiarUsuario.UseVisualStyleBackColor = false;
            btnLimpiarUsuario.Click += BtnLimpiarUsuario_Click;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = Color.White;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(15, 220);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(855, 270);
            dgvUsuarios.TabIndex = 1;
            dgvUsuarios.SelectionChanged += DgvUsuarios_SelectionChanged;
            // 
            // tabReglas
            // 
            tabReglas.BackColor = Color.White;
            tabReglas.Controls.Add(grpReglas);
            tabReglas.Location = new Point(4, 34);
            tabReglas.Name = "tabReglas";
            tabReglas.Padding = new Padding(15);
            tabReglas.Size = new Size(896, 503);
            tabReglas.TabIndex = 1;
            tabReglas.Text = "⚙️ Reglas de Préstamo y Multas";
            // 
            // grpReglas
            // 
            grpReglas.Controls.Add(lblNombreBiblio);
            grpReglas.Controls.Add(txtNombreBiblio);
            grpReglas.Controls.Add(lblDias);
            grpReglas.Controls.Add(numDiasPrestamo);
            grpReglas.Controls.Add(lblMulta);
            grpReglas.Controls.Add(numMultaDiaria);
            grpReglas.Controls.Add(btnGuardarConfig);
            grpReglas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpReglas.Location = new Point(25, 20);
            grpReglas.Name = "grpReglas";
            grpReglas.Size = new Size(820, 280);
            grpReglas.TabIndex = 0;
            grpReglas.TabStop = false;
            grpReglas.Text = "Parámetros Globales de Operación";
            // 
            // lblNombreBiblio
            // 
            lblNombreBiblio.AutoSize = true;
            lblNombreBiblio.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblNombreBiblio.Location = new Point(30, 48);
            lblNombreBiblio.Name = "lblNombreBiblio";
            lblNombreBiblio.Size = new Size(254, 19);
            lblNombreBiblio.TabIndex = 0;
            lblNombreBiblio.Text = "Nombre de la Institución / Biblioteca:";
            // 
            // txtNombreBiblio
            // 
            txtNombreBiblio.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtNombreBiblio.Location = new Point(310, 45);
            txtNombreBiblio.Name = "txtNombreBiblio";
            txtNombreBiblio.Size = new Size(440, 25);
            txtNombreBiblio.TabIndex = 1;
            // 
            // lblDias
            // 
            lblDias.AutoSize = true;
            lblDias.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblDias.Location = new Point(30, 100);
            lblDias.Name = "lblDias";
            lblDias.Size = new Size(258, 19);
            lblDias.TabIndex = 2;
            lblDias.Text = "Días máximos por defecto de préstamo:";
            // 
            // numDiasPrestamo
            // 
            numDiasPrestamo.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            numDiasPrestamo.Location = new Point(310, 97);
            numDiasPrestamo.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            numDiasPrestamo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDiasPrestamo.Name = "numDiasPrestamo";
            numDiasPrestamo.Size = new Size(120, 25);
            numDiasPrestamo.TabIndex = 3;
            numDiasPrestamo.Value = new decimal(new int[] { 7, 0, 0, 0 });
            // 
            // lblMulta
            // 
            lblMulta.AutoSize = true;
            lblMulta.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblMulta.Location = new Point(30, 152);
            lblMulta.Name = "lblMulta";
            lblMulta.Size = new Size(265, 19);
            lblMulta.TabIndex = 4;
            lblMulta.Text = "Monto de multa por cada día de retraso:";
            // 
            // numMultaDiaria
            // 
            numMultaDiaria.DecimalPlaces = 2;
            numMultaDiaria.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            numMultaDiaria.Location = new Point(310, 149);
            numMultaDiaria.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numMultaDiaria.Name = "numMultaDiaria";
            numMultaDiaria.Size = new Size(120, 25);
            numMultaDiaria.TabIndex = 5;
            numMultaDiaria.Value = new decimal(new int[] { 500, 0, 0, 131072 });
            // 
            // btnGuardarConfig
            // 
            btnGuardarConfig.BackColor = Color.FromArgb(25, 55, 109);
            btnGuardarConfig.Cursor = Cursors.Hand;
            btnGuardarConfig.FlatAppearance.BorderSize = 0;
            btnGuardarConfig.FlatStyle = FlatStyle.Flat;
            btnGuardarConfig.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardarConfig.ForeColor = Color.White;
            btnGuardarConfig.Location = new Point(310, 205);
            btnGuardarConfig.Name = "btnGuardarConfig";
            btnGuardarConfig.Size = new Size(280, 42);
            btnGuardarConfig.TabIndex = 6;
            btnGuardarConfig.Text = "💾 Guardar Configuración del Sistema";
            btnGuardarConfig.UseVisualStyleBackColor = false;
            btnGuardarConfig.Click += BtnGuardarConfig_Click;
            // 
            // FrmAdministracion
            // 
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(904, 541);
            Controls.Add(tabControl);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmAdministracion";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Módulo 5 - Administración del Sistema (Solo Administrador)";
            tabControl.ResumeLayout(false);
            tabUsuarios.ResumeLayout(false);
            grpUsuario.ResumeLayout(false);
            grpUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tabReglas.ResumeLayout(false);
            grpReglas.ResumeLayout(false);
            grpReglas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDiasPrestamo).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMultaDiaria).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabUsuarios;
        private GroupBox grpUsuario;
        private Label lblNombre;
        private TextBox txtNombreCompleto;
        private Label lblDoc;
        private TextBox txtDocumento;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblUser;
        private TextBox txtNombreUsuario;
        private Label lblPass;
        private TextBox txtContrasena;
        private Label lblRol;
        private ComboBox cboRol;
        private CheckBox chkActivo;
        private Button btnGuardarUsuario;
        private Button btnLimpiarUsuario;
        private DataGridView dgvUsuarios;
        private TabPage tabReglas;
        private GroupBox grpReglas;
        private Label lblNombreBiblio;
        private TextBox txtNombreBiblio;
        private Label lblDias;
        private NumericUpDown numDiasPrestamo;
        private Label lblMulta;
        private NumericUpDown numMultaDiaria;
        private Button btnGuardarConfig;
    }
}
