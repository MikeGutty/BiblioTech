namespace BiblioTech.Formularios
{
    partial class FrmLibros
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
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblAutor = new Label();
            cboAutor = new ComboBox();
            lblCategoria = new Label();
            cboCategoria = new ComboBox();
            lblAnio = new Label();
            numAnio = new NumericUpDown();
            lblStockTotal = new Label();
            numStockTotal = new NumericUpDown();
            lblStockDisp = new Label();
            numStockDisponible = new NumericUpDown();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnCatAutores = new Button();
            dgvLibros = new DataGridView();
            grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockTotal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numStockDisponible).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // grpDatos
            // 
            grpDatos.BackColor = Color.White;
            grpDatos.Controls.Add(lblIsbn);
            grpDatos.Controls.Add(txtIsbn);
            grpDatos.Controls.Add(lblTitulo);
            grpDatos.Controls.Add(txtTitulo);
            grpDatos.Controls.Add(lblAutor);
            grpDatos.Controls.Add(cboAutor);
            grpDatos.Controls.Add(lblCategoria);
            grpDatos.Controls.Add(cboCategoria);
            grpDatos.Controls.Add(lblAnio);
            grpDatos.Controls.Add(numAnio);
            grpDatos.Controls.Add(lblStockTotal);
            grpDatos.Controls.Add(numStockTotal);
            grpDatos.Controls.Add(lblStockDisp);
            grpDatos.Controls.Add(numStockDisponible);
            grpDatos.Controls.Add(btnGuardar);
            grpDatos.Controls.Add(btnLimpiar);
            grpDatos.Controls.Add(btnEliminar);
            grpDatos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grpDatos.Location = new Point(20, 15);
            grpDatos.Name = "grpDatos";
            grpDatos.Size = new Size(925, 195);
            grpDatos.TabIndex = 0;
            grpDatos.TabStop = false;
            grpDatos.Text = "📘 Datos del Libro";
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Font = new Font("Segoe UI", 9.5F);
            lblIsbn.Location = new Point(20, 35);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(38, 17);
            lblIsbn.TabIndex = 0;
            lblIsbn.Text = "ISBN:";
            // 
            // txtIsbn
            // 
            txtIsbn.Font = new Font("Segoe UI", 9.5F);
            txtIsbn.Location = new Point(95, 32);
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(180, 24);
            txtIsbn.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 9.5F);
            lblTitulo.Location = new Point(300, 35);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(43, 17);
            lblTitulo.TabIndex = 2;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Font = new Font("Segoe UI", 9.5F);
            txtTitulo.Location = new Point(360, 32);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(540, 24);
            txtTitulo.TabIndex = 3;
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.Font = new Font("Segoe UI", 9.5F);
            lblAutor.Location = new Point(20, 80);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(43, 17);
            lblAutor.TabIndex = 4;
            lblAutor.Text = "Autor:";
            // 
            // cboAutor
            // 
            cboAutor.DropDownStyle = ComboBoxStyle.DropDownList;
            cboAutor.Font = new Font("Segoe UI", 9.5F);
            cboAutor.FormattingEnabled = true;
            cboAutor.Location = new Point(95, 77);
            cboAutor.Name = "cboAutor";
            cboAutor.Size = new Size(290, 25);
            cboAutor.TabIndex = 5;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Font = new Font("Segoe UI", 9.5F);
            lblCategoria.Location = new Point(410, 80);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(68, 17);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoría:";
            // 
            // cboCategoria
            // 
            cboCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCategoria.Font = new Font("Segoe UI", 9.5F);
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(495, 77);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(240, 25);
            cboCategoria.TabIndex = 7;
            // 
            // lblAnio
            // 
            lblAnio.AutoSize = true;
            lblAnio.Font = new Font("Segoe UI", 9.5F);
            lblAnio.Location = new Point(755, 80);
            lblAnio.Name = "lblAnio";
            lblAnio.Size = new Size(34, 17);
            lblAnio.TabIndex = 8;
            lblAnio.Text = "Año:";
            // 
            // numAnio
            // 
            numAnio.Font = new Font("Segoe UI", 9.5F);
            numAnio.Location = new Point(800, 77);
            numAnio.Maximum = new decimal(new int[] { 2100, 0, 0, 0 });
            numAnio.Minimum = new decimal(new int[] { 1500, 0, 0, 0 });
            numAnio.Name = "numAnio";
            numAnio.Size = new Size(100, 24);
            numAnio.TabIndex = 9;
            numAnio.Value = new decimal(new int[] { 2026, 0, 0, 0 });
            // 
            // lblStockTotal
            // 
            lblStockTotal.AutoSize = true;
            lblStockTotal.Font = new Font("Segoe UI", 9.5F);
            lblStockTotal.Location = new Point(20, 128);
            lblStockTotal.Name = "lblStockTotal";
            lblStockTotal.Size = new Size(74, 17);
            lblStockTotal.TabIndex = 10;
            lblStockTotal.Text = "Stock Total:";
            // 
            // numStockTotal
            // 
            numStockTotal.Font = new Font("Segoe UI", 9.5F);
            numStockTotal.Location = new Point(105, 125);
            numStockTotal.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numStockTotal.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numStockTotal.Name = "numStockTotal";
            numStockTotal.Size = new Size(80, 24);
            numStockTotal.TabIndex = 11;
            numStockTotal.Value = new decimal(new int[] { 3, 0, 0, 0 });
            numStockTotal.ValueChanged += NumStockTotal_ValueChanged;
            // 
            // lblStockDisp
            // 
            lblStockDisp.AutoSize = true;
            lblStockDisp.Font = new Font("Segoe UI", 9.5F);
            lblStockDisp.Location = new Point(205, 128);
            lblStockDisp.Name = "lblStockDisp";
            lblStockDisp.Size = new Size(108, 17);
            lblStockDisp.TabIndex = 12;
            lblStockDisp.Text = "Stock Disponible:";
            // 
            // numStockDisponible
            // 
            numStockDisponible.Font = new Font("Segoe UI", 9.5F);
            numStockDisponible.Location = new Point(325, 125);
            numStockDisponible.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            numStockDisponible.Name = "numStockDisponible";
            numStockDisponible.Size = new Size(80, 24);
            numStockDisponible.TabIndex = 13;
            numStockDisponible.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(25, 55, 109);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(430, 122);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(175, 36);
            btnGuardar.TabIndex = 14;
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
            btnLimpiar.Location = new Point(615, 122);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(145, 36);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "\U0001f9f9 Limpiar / Nuevo";
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
            btnEliminar.Location = new Point(770, 122);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 36);
            btnEliminar.TabIndex = 16;
            btnEliminar.Text = "🗑️ Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblBuscar.Location = new Point(20, 228);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(230, 17);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "🔍 Buscar por Título, ISBN o Autor:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(265, 225);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(350, 24);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            // 
            // btnCatAutores
            // 
            btnCatAutores.BackColor = Color.FromArgb(41, 128, 185);
            btnCatAutores.Cursor = Cursors.Hand;
            btnCatAutores.FlatAppearance.BorderSize = 0;
            btnCatAutores.FlatStyle = FlatStyle.Flat;
            btnCatAutores.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCatAutores.ForeColor = Color.White;
            btnCatAutores.Location = new Point(705, 220);
            btnCatAutores.Name = "btnCatAutores";
            btnCatAutores.Size = new Size(240, 36);
            btnCatAutores.TabIndex = 3;
            btnCatAutores.Text = "📂 Gestionar Categorías/Autores";
            btnCatAutores.UseVisualStyleBackColor = false;
            btnCatAutores.Click += BtnCatAutores_Click;
            // 
            // dgvLibros
            // 
            dgvLibros.AllowUserToAddRows = false;
            dgvLibros.AllowUserToDeleteRows = false;
            dgvLibros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibros.BackgroundColor = Color.White;
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(20, 265);
            dgvLibros.MultiSelect = false;
            dgvLibros.Name = "dgvLibros";
            dgvLibros.ReadOnly = true;
            dgvLibros.RowHeadersVisible = false;
            dgvLibros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibros.Size = new Size(925, 295);
            dgvLibros.TabIndex = 4;
            dgvLibros.CellContentClick += dgvLibros_CellContentClick;
            dgvLibros.SelectionChanged += DgvLibros_SelectionChanged;
            // 
            // FrmLibros
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(964, 581);
            Controls.Add(grpDatos);
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnCatAutores);
            Controls.Add(dgvLibros);
            Font = new Font("Segoe UI", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmLibros";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Módulo 2 - Gestión del Catálogo de Libros";
            grpDatos.ResumeLayout(false);
            grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numAnio).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockTotal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numStockDisponible).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpDatos;
        private Label lblIsbn;
        private TextBox txtIsbn;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblAutor;
        private ComboBox cboAutor;
        private Label lblCategoria;
        private ComboBox cboCategoria;
        private Label lblAnio;
        private NumericUpDown numAnio;
        private Label lblStockTotal;
        private NumericUpDown numStockTotal;
        private Label lblStockDisp;
        private NumericUpDown numStockDisponible;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnCatAutores;
        private DataGridView dgvLibros;
    }
}
