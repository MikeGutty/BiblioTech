namespace BiblioTech.Formularios
{
    partial class FrmLogin
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
            pnlEncabezado = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblContrasena = new Label();
            txtContrasena = new TextBox();
            btnIngresar = new Button();
            btnSalir = new Button();
            lblAyuda = new Label();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.FromArgb(25, 55, 109);
            pnlEncabezado.Controls.Add(lblSubtitulo);
            pnlEncabezado.Controls.Add(lblTitulo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(0, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(424, 95);
            pnlEncabezado.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Dock = DockStyle.Fill;
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblSubtitulo.ForeColor = Color.FromArgb(165, 215, 232);
            lblSubtitulo.Location = new Point(0, 52);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(424, 43);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Sistema de Gestión Bibliotecaria (POO + SQLite)";
            lblSubtitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(424, 52);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "📚 BIBLIOTECH";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUsuario.ForeColor = Color.FromArgb(40, 40, 40);
            lblUsuario.Location = new Point(55, 120);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(139, 19);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Nombre de Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(55, 145);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(310, 25);
            txtUsuario.TabIndex = 2;
            txtUsuario.Text = "admin";
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblContrasena.ForeColor = Color.FromArgb(40, 40, 40);
            lblContrasena.Location = new Point(55, 190);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(85, 19);
            lblContrasena.TabIndex = 3;
            lblContrasena.Text = "Contraseña:";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(55, 215);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(310, 25);
            txtContrasena.TabIndex = 4;
            txtContrasena.Text = "1234";
            txtContrasena.UseSystemPasswordChar = true;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(25, 55, 109);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(55, 268);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(185, 40);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "Iniciar Sesión";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += BtnIngresar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(210, 215, 220);
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.FromArgb(50, 50, 50);
            btnSalir.Location = new Point(250, 268);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(115, 40);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // lblAyuda
            // 
            lblAyuda.Font = new Font("Segoe UI", 8.5F, FontStyle.Italic);
            lblAyuda.ForeColor = Color.FromArgb(90, 100, 110);
            lblAyuda.Location = new Point(55, 322);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(320, 55);
            lblAyuda.TabIndex = 7;
            lblAyuda.Text = "💡 Cuentas de prueba para clase:\r\n• Administrador: admin / 1234\r\n• Bibliotecario: biblio / 1234";
            // 
            // FrmLogin
            // 
            AcceptButton = btnIngresar;
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(424, 381);
            Controls.Add(pnlEncabezado);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);
            Controls.Add(btnIngresar);
            Controls.Add(btnSalir);
            Controls.Add(lblAyuda);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BiblioTech - Inicio de Sesión";
            pnlEncabezado.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlEncabezado;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblContrasena;
        private TextBox txtContrasena;
        private Button btnIngresar;
        private Button btnSalir;
        private Label lblAyuda;
    }
}
