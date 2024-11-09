namespace Punto_de_venta___Prácticas_profesionales
{
    partial class FormArticulos
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
            btnActualizar = new Button();
            btnDeshabilitar = new Button();
            btnLimpiar = new Button();
            dataGridView1 = new DataGridView();
            texboxs1 = new controlesPersonalizados.Texboxs();
            label1 = new Label();
            dataGridViewInactivos = new DataGridView();
            txtCodigo = new controlesPersonalizados.Texboxs();
            txtNombre = new controlesPersonalizados.Texboxs();
            txtMarca = new controlesPersonalizados.Texboxs();
            txtRubro = new controlesPersonalizados.Texboxs();
            txtPrecio = new controlesPersonalizados.Texboxs();
            txtStock = new controlesPersonalizados.Texboxs();
            txtBuscar = new controlesPersonalizados.Texboxs();
            btnBuscar = new controlesPersonalizados.ClassBtnPersonalizado();
            cmbCriterio = new ComboBox();
            panelOpciones = new Panel();
            btnHabilitar = new Button();
            btnArticulosDeshabilitados = new controlesPersonalizados.ClassBtnPersonalizado();
            btnArticulosActivos = new controlesPersonalizados.ClassBtnPersonalizado();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnAgregar = new controlesPersonalizados.ClassBtnPersonalizado();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInactivos).BeginInit();
            panelOpciones.SuspendLayout();
            SuspendLayout();
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(206, 12);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnDeshabilitar
            // 
            btnDeshabilitar.Location = new Point(110, 414);
            btnDeshabilitar.Name = "btnDeshabilitar";
            btnDeshabilitar.Size = new Size(126, 25);
            btnDeshabilitar.TabIndex = 8;
            btnDeshabilitar.Text = "eliminar";
            btnDeshabilitar.UseVisualStyleBackColor = true;
            btnDeshabilitar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(12, 341);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(624, 360);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // texboxs1
            // 
            texboxs1.BackColor = SystemColors.Window;
            texboxs1.BorderColor = Color.DarkSlateGray;
            texboxs1.BorderFocusColor = Color.DarkGray;
            texboxs1.BorderSize = 2;
            texboxs1.Font = new Font("Segoe UI", 9.5F);
            texboxs1.ForeColor = Color.DimGray;
            texboxs1.Location = new Point(205, 416);
            texboxs1.Name = "texboxs1";
            texboxs1.Padding = new Padding(7);
            texboxs1.Size = new Size(147, 32);
            texboxs1.TabIndex = 11;
            texboxs1.Texts = "";
            texboxs1.UnderlinedStyle1 = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(247, 88);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 17;
            label1.Text = "Nombre: ";
            // 
            // dataGridViewInactivos
            // 
            dataGridViewInactivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInactivos.Location = new Point(206, 68);
            dataGridViewInactivos.Name = "dataGridViewInactivos";
            dataGridViewInactivos.ReadOnly = true;
            dataGridViewInactivos.Size = new Size(73, 150);
            dataGridViewInactivos.TabIndex = 20;
            // 
            // txtCodigo
            // 
            txtCodigo.BackColor = SystemColors.Control;
            txtCodigo.BorderColor = Color.DarkSlateGray;
            txtCodigo.BorderFocusColor = Color.DarkGray;
            txtCodigo.BorderSize = 2;
            txtCodigo.Font = new Font("Segoe UI", 9.5F);
            txtCodigo.ForeColor = Color.DimGray;
            txtCodigo.Location = new Point(314, 35);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Padding = new Padding(7);
            txtCodigo.Size = new Size(115, 32);
            txtCodigo.TabIndex = 21;
            txtCodigo.Texts = "";
            txtCodigo.UnderlinedStyle1 = true;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.Control;
            txtNombre.BorderColor = Color.DarkSlateGray;
            txtNombre.BorderFocusColor = Color.DarkGray;
            txtNombre.BorderSize = 2;
            txtNombre.Font = new Font("Segoe UI", 9.5F);
            txtNombre.ForeColor = Color.DimGray;
            txtNombre.Location = new Point(314, 73);
            txtNombre.Name = "txtNombre";
            txtNombre.Padding = new Padding(7);
            txtNombre.Size = new Size(115, 32);
            txtNombre.TabIndex = 22;
            txtNombre.Texts = "";
            txtNombre.UnderlinedStyle1 = true;
            // 
            // txtMarca
            // 
            txtMarca.BackColor = SystemColors.Control;
            txtMarca.BorderColor = Color.DarkSlateGray;
            txtMarca.BorderFocusColor = Color.DarkGray;
            txtMarca.BorderSize = 2;
            txtMarca.Font = new Font("Segoe UI", 9.5F);
            txtMarca.ForeColor = Color.DimGray;
            txtMarca.Location = new Point(314, 111);
            txtMarca.Name = "txtMarca";
            txtMarca.Padding = new Padding(7);
            txtMarca.Size = new Size(115, 32);
            txtMarca.TabIndex = 23;
            txtMarca.Texts = "";
            txtMarca.UnderlinedStyle1 = true;
            // 
            // txtRubro
            // 
            txtRubro.BackColor = SystemColors.Control;
            txtRubro.BorderColor = Color.DarkSlateGray;
            txtRubro.BorderFocusColor = Color.DarkGray;
            txtRubro.BorderSize = 2;
            txtRubro.Font = new Font("Segoe UI", 9.5F);
            txtRubro.ForeColor = Color.DimGray;
            txtRubro.Location = new Point(314, 152);
            txtRubro.Name = "txtRubro";
            txtRubro.Padding = new Padding(7);
            txtRubro.Size = new Size(115, 32);
            txtRubro.TabIndex = 24;
            txtRubro.Texts = "";
            txtRubro.UnderlinedStyle1 = true;
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = SystemColors.Control;
            txtPrecio.BorderColor = Color.DarkSlateGray;
            txtPrecio.BorderFocusColor = Color.DarkGray;
            txtPrecio.BorderSize = 2;
            txtPrecio.Font = new Font("Segoe UI", 9.5F);
            txtPrecio.ForeColor = Color.DimGray;
            txtPrecio.Location = new Point(314, 190);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Padding = new Padding(7);
            txtPrecio.Size = new Size(115, 32);
            txtPrecio.TabIndex = 25;
            txtPrecio.Texts = "";
            txtPrecio.UnderlinedStyle1 = true;
            // 
            // txtStock
            // 
            txtStock.BackColor = SystemColors.Control;
            txtStock.BorderColor = Color.DarkSlateGray;
            txtStock.BorderFocusColor = Color.DarkGray;
            txtStock.BorderSize = 2;
            txtStock.Font = new Font("Segoe UI", 9.5F);
            txtStock.ForeColor = Color.DimGray;
            txtStock.Location = new Point(314, 226);
            txtStock.Name = "txtStock";
            txtStock.Padding = new Padding(7);
            txtStock.Size = new Size(115, 32);
            txtStock.TabIndex = 26;
            txtStock.Texts = "";
            txtStock.UnderlinedStyle1 = true;
            // 
            // txtBuscar
            // 
            txtBuscar.BackColor = SystemColors.Window;
            txtBuscar.BorderColor = Color.SteelBlue;
            txtBuscar.BorderFocusColor = Color.Navy;
            txtBuscar.BorderSize = 2;
            txtBuscar.Cursor = Cursors.IBeam;
            txtBuscar.Font = new Font("Segoe UI", 9.5F);
            txtBuscar.ForeColor = Color.DimGray;
            txtBuscar.Location = new Point(12, 9);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Padding = new Padding(7);
            txtBuscar.Size = new Size(147, 32);
            txtBuscar.TabIndex = 27;
            txtBuscar.Texts = "Buscar...";
            txtBuscar.UnderlinedStyle1 = false;
            txtBuscar._TextChanged += txtBuscar__TextChanged;
            // 
            // btnBuscar
            // 
            btnBuscar.BackColor = SystemColors.Control;
            btnBuscar.BackgroundColor = SystemColors.Control;
            btnBuscar.BorderColor = Color.PaleVioletRed;
            btnBuscar.BorderRadius = 40;
            btnBuscar.BorderSize = 0;
            btnBuscar.Cursor = Cursors.AppStarting;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.ForeColor = Color.White;
            btnBuscar.IconAlignment = ContentAlignment.MiddleCenter;
            btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            btnBuscar.IconColor = Color.Blue;
            btnBuscar.IconPadding = 5;
            btnBuscar.IconSize = 30;
            btnBuscar.Location = new Point(165, 9);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(44, 32);
            btnBuscar.TabIndex = 28;
            btnBuscar.TextColor = Color.White;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // cmbCriterio
            // 
            cmbCriterio.FormattingEnabled = true;
            cmbCriterio.Items.AddRange(new object[] { "Codigo", "Nombre", "Marca", "Rubro" });
            cmbCriterio.Location = new Point(12, 44);
            cmbCriterio.Name = "cmbCriterio";
            cmbCriterio.Size = new Size(121, 23);
            cmbCriterio.TabIndex = 29;
            // 
            // panelOpciones
            // 
            panelOpciones.Controls.Add(dataGridView1);
            panelOpciones.Controls.Add(btnHabilitar);
            panelOpciones.Controls.Add(btnArticulosDeshabilitados);
            panelOpciones.Controls.Add(btnArticulosActivos);
            panelOpciones.Controls.Add(btnDeshabilitar);
            panelOpciones.Controls.Add(dataGridViewInactivos);
            panelOpciones.Controls.Add(btnActualizar);
            panelOpciones.Location = new Point(446, 9);
            panelOpciones.Name = "panelOpciones";
            panelOpciones.Size = new Size(627, 465);
            panelOpciones.TabIndex = 30;
            // 
            // btnHabilitar
            // 
            btnHabilitar.Location = new Point(458, 414);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(126, 25);
            btnHabilitar.TabIndex = 33;
            btnHabilitar.Text = "Activar";
            btnHabilitar.UseVisualStyleBackColor = true;
            btnHabilitar.Visible = false;
            // 
            // btnArticulosDeshabilitados
            // 
            btnArticulosDeshabilitados.BackColor = Color.Azure;
            btnArticulosDeshabilitados.BackgroundColor = Color.Azure;
            btnArticulosDeshabilitados.BorderColor = Color.PaleVioletRed;
            btnArticulosDeshabilitados.BorderRadius = 50;
            btnArticulosDeshabilitados.BorderSize = 0;
            btnArticulosDeshabilitados.FlatAppearance.BorderSize = 0;
            btnArticulosDeshabilitados.FlatStyle = FlatStyle.Flat;
            btnArticulosDeshabilitados.Font = new Font("Calibri", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnArticulosDeshabilitados.ForeColor = Color.Black;
            btnArticulosDeshabilitados.IconAlignment = ContentAlignment.MiddleLeft;
            btnArticulosDeshabilitados.IconChar = FontAwesome.Sharp.IconChar.None;
            btnArticulosDeshabilitados.IconColor = Color.White;
            btnArticulosDeshabilitados.IconPadding = 5;
            btnArticulosDeshabilitados.IconSize = 24;
            btnArticulosDeshabilitados.Location = new Point(327, 3);
            btnArticulosDeshabilitados.Name = "btnArticulosDeshabilitados";
            btnArticulosDeshabilitados.Size = new Size(150, 40);
            btnArticulosDeshabilitados.TabIndex = 31;
            btnArticulosDeshabilitados.Text = "Articulos Desactivado";
            btnArticulosDeshabilitados.TextColor = Color.Black;
            btnArticulosDeshabilitados.UseVisualStyleBackColor = false;
            btnArticulosDeshabilitados.Click += btnArticulosDeshabilitados_Click;
            // 
            // btnArticulosActivos
            // 
            btnArticulosActivos.BackColor = Color.Azure;
            btnArticulosActivos.BackgroundColor = Color.Azure;
            btnArticulosActivos.BorderColor = Color.Purple;
            btnArticulosActivos.BorderRadius = 50;
            btnArticulosActivos.BorderSize = 0;
            btnArticulosActivos.FlatAppearance.BorderSize = 0;
            btnArticulosActivos.FlatStyle = FlatStyle.Flat;
            btnArticulosActivos.Font = new Font("Cambria", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnArticulosActivos.ForeColor = Color.Black;
            btnArticulosActivos.IconAlignment = ContentAlignment.MiddleLeft;
            btnArticulosActivos.IconChar = FontAwesome.Sharp.IconChar.None;
            btnArticulosActivos.IconColor = Color.White;
            btnArticulosActivos.IconPadding = 5;
            btnArticulosActivos.IconSize = 24;
            btnArticulosActivos.Location = new Point(16, 3);
            btnArticulosActivos.Name = "btnArticulosActivos";
            btnArticulosActivos.Size = new Size(150, 40);
            btnArticulosActivos.TabIndex = 32;
            btnArticulosActivos.Text = "Articulos Activos";
            btnArticulosActivos.TextColor = Color.Black;
            btnArticulosActivos.UseVisualStyleBackColor = false;
            btnArticulosActivos.Click += btnArticulosActivos_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(248, 50);
            label3.Name = "label3";
            label3.Size = new Size(60, 17);
            label3.TabIndex = 31;
            label3.Text = "Codigo: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(247, 126);
            label4.Name = "label4";
            label4.Size = new Size(53, 17);
            label4.TabIndex = 32;
            label4.Text = "Marca: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(248, 167);
            label5.Name = "label5";
            label5.Size = new Size(53, 17);
            label5.TabIndex = 33;
            label5.Text = "Rubro: ";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(248, 205);
            label6.Name = "label6";
            label6.Size = new Size(54, 17);
            label6.TabIndex = 34;
            label6.Text = "Precio: ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(248, 241);
            label7.Name = "label7";
            label7.Size = new Size(50, 17);
            label7.TabIndex = 35;
            label7.Text = "Stock: ";
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.Navy;
            btnAgregar.BackgroundColor = Color.Navy;
            btnAgregar.BorderColor = Color.PaleVioletRed;
            btnAgregar.BorderRadius = 25;
            btnAgregar.BorderSize = 0;
            btnAgregar.FlatAppearance.BorderSize = 0;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.IconAlignment = ContentAlignment.MiddleRight;
            btnAgregar.IconChar = FontAwesome.Sharp.IconChar.Add;
            btnAgregar.IconColor = Color.White;
            btnAgregar.IconPadding = 4;
            btnAgregar.IconSize = 24;
            btnAgregar.Location = new Point(300, 277);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 40);
            btnAgregar.TabIndex = 38;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextColor = Color.White;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // FormArticulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 475);
            Controls.Add(btnAgregar);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panelOpciones);
            Controls.Add(cmbCriterio);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(txtStock);
            Controls.Add(txtPrecio);
            Controls.Add(txtRubro);
            Controls.Add(txtMarca);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(label1);
            Controls.Add(texboxs1);
            Controls.Add(btnLimpiar);
            Name = "FormArticulos";
            Text = "FormArticulos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInactivos).EndInit();
            panelOpciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnActualizar;
        private Button btnDeshabilitar;
        private Button btnLimpiar;
        private DataGridView dataGridView1;
        private controlesPersonalizados.Texboxs texboxs1;
        private Label label1;
        private DataGridView dataGridViewInactivos;
        private controlesPersonalizados.Texboxs txtCodigo;
        private controlesPersonalizados.Texboxs txtNombre;
        private controlesPersonalizados.Texboxs txtMarca;
        private controlesPersonalizados.Texboxs txtRubro;
        private controlesPersonalizados.Texboxs txtPrecio;
        private controlesPersonalizados.Texboxs txtStock;
        private controlesPersonalizados.Texboxs txtBuscar;
        private controlesPersonalizados.ClassBtnPersonalizado btnBuscar;
        private ComboBox cmbCriterio;
        private Panel panelOpciones;
        private controlesPersonalizados.ClassBtnPersonalizado btnArticulosDeshabilitados;
        private controlesPersonalizados.ClassBtnPersonalizado btnArticulosActivos;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnHabilitar;
        private controlesPersonalizados.ClassBtnPersonalizado btnAgregar;
    }
}