namespace Punto_de_venta___Prácticas_profesionales
{
    partial class AriculosForm
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
            btnAgregar = new controlesPersonalizados.ClassBtnPersonalizado();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnHabilitar = new Button();
            btnArticulosDeshabilitados = new controlesPersonalizados.ClassBtnPersonalizado();
            btnArticulosActivos = new controlesPersonalizados.ClassBtnPersonalizado();
            panel1 = new Panel();
            label7 = new Label();
            panelOpciones = new Panel();
            dataGridView1 = new DataGridView();
            btnDeshabilitar = new Button();
            dataGridViewInactivos = new DataGridView();
            cmbCriterio = new ComboBox();
            btnBuscar = new controlesPersonalizados.ClassBtnPersonalizado();
            txtStock = new controlesPersonalizados.Texboxs();
            txtPrecio = new controlesPersonalizados.Texboxs();
            txtRubro = new controlesPersonalizados.Texboxs();
            txtMarca = new controlesPersonalizados.Texboxs();
            txtNombre = new controlesPersonalizados.Texboxs();
            label1 = new Label();
            txtBuscar = new controlesPersonalizados.Texboxs();
            txtPrecioLista = new controlesPersonalizados.Texboxs();
            label2 = new Label();
            panel1.SuspendLayout();
            panelOpciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInactivos).BeginInit();
            SuspendLayout();
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
            btnAgregar.Location = new Point(88, 391);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(140, 40);
            btnAgregar.TabIndex = 55;
            btnAgregar.Text = "Agregar";
            btnAgregar.TextColor = Color.White;
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(71, 253);
            label6.Name = "label6";
            label6.Size = new Size(54, 17);
            label6.TabIndex = 53;
            label6.Text = "Precio: ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(71, 215);
            label5.Name = "label5";
            label5.Size = new Size(53, 17);
            label5.TabIndex = 52;
            label5.Text = "Rubro: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(70, 174);
            label4.Name = "label4";
            label4.Size = new Size(53, 17);
            label4.TabIndex = 51;
            label4.Text = "Marca: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(71, 98);
            label3.Name = "label3";
            label3.Size = new Size(60, 17);
            label3.TabIndex = 50;
            label3.Text = "Codigo: ";
            // 
            // btnHabilitar
            // 
            btnHabilitar.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHabilitar.Location = new Point(458, 414);
            btnHabilitar.Name = "btnHabilitar";
            btnHabilitar.Size = new Size(126, 25);
            btnHabilitar.TabIndex = 33;
            btnHabilitar.Text = "Activar";
            btnHabilitar.UseVisualStyleBackColor = true;
            btnHabilitar.Visible = false;
            btnHabilitar.Click += btnHabilitar_Click;
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
            btnArticulosDeshabilitados.Location = new Point(400, 3);
            btnArticulosDeshabilitados.Name = "btnArticulosDeshabilitados";
            btnArticulosDeshabilitados.Size = new Size(153, 34);
            btnArticulosDeshabilitados.TabIndex = 31;
            btnArticulosDeshabilitados.Text = "Articulos Desactivados";
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
            btnArticulosActivos.Location = new Point(59, 3);
            btnArticulosActivos.Name = "btnArticulosActivos";
            btnArticulosActivos.Size = new Size(150, 34);
            btnArticulosActivos.TabIndex = 32;
            btnArticulosActivos.Text = "Articulos Activos";
            btnArticulosActivos.TextColor = Color.Black;
            btnArticulosActivos.UseVisualStyleBackColor = false;
            btnArticulosActivos.Click += btnArticulosActivos_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Azure;
            panel1.Controls.Add(btnArticulosDeshabilitados);
            panel1.Controls.Add(btnArticulosActivos);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(627, 40);
            panel1.TabIndex = 39;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(70, 291);
            label7.Name = "label7";
            label7.Size = new Size(50, 17);
            label7.TabIndex = 54;
            label7.Text = "Stock: ";
            // 
            // panelOpciones
            // 
            panelOpciones.Controls.Add(panel1);
            panelOpciones.Controls.Add(dataGridView1);
            panelOpciones.Controls.Add(btnHabilitar);
            panelOpciones.Controls.Add(btnDeshabilitar);
            panelOpciones.Controls.Add(dataGridViewInactivos);
            panelOpciones.Location = new Point(335, 12);
            panelOpciones.Name = "panelOpciones";
            panelOpciones.Size = new Size(627, 465);
            panelOpciones.TabIndex = 49;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(624, 360);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // btnDeshabilitar
            // 
            btnDeshabilitar.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDeshabilitar.Location = new Point(110, 414);
            btnDeshabilitar.Name = "btnDeshabilitar";
            btnDeshabilitar.Size = new Size(126, 25);
            btnDeshabilitar.TabIndex = 8;
            btnDeshabilitar.Text = "Desactivar";
            btnDeshabilitar.UseVisualStyleBackColor = true;
            btnDeshabilitar.Click += btnDeshabilitar_Click;
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
            // cmbCriterio
            // 
            cmbCriterio.FormattingEnabled = true;
            cmbCriterio.Items.AddRange(new object[] { "Codigo", "Nombre", "Marca", "Rubro" });
            cmbCriterio.Location = new Point(78, 34);
            cmbCriterio.Name = "cmbCriterio";
            cmbCriterio.Size = new Size(121, 23);
            cmbCriterio.TabIndex = 48;
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
            btnBuscar.Location = new Point(219, -4);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(44, 32);
            btnBuscar.TabIndex = 47;
            btnBuscar.TextColor = Color.White;
            btnBuscar.UseVisualStyleBackColor = false;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtStock
            // 
            txtStock.BackColor = SystemColors.Control;
            txtStock.BorderColor = Color.DarkSlateGray;
            txtStock.BorderFocusColor = Color.DarkGray;
            txtStock.BorderSize = 2;
            txtStock.Font = new Font("Segoe UI", 9.5F);
            txtStock.ForeColor = Color.DimGray;
            txtStock.Location = new Point(137, 276);
            txtStock.Name = "txtStock";
            txtStock.Padding = new Padding(7);
            txtStock.Size = new Size(115, 32);
            txtStock.TabIndex = 45;
            txtStock.Texts = "";
            txtStock.UnderlinedStyle1 = true;
            // 
            // txtPrecio
            // 
            txtPrecio.BackColor = SystemColors.Control;
            txtPrecio.BorderColor = Color.DarkSlateGray;
            txtPrecio.BorderFocusColor = Color.DarkGray;
            txtPrecio.BorderSize = 2;
            txtPrecio.Font = new Font("Segoe UI", 9.5F);
            txtPrecio.ForeColor = Color.DimGray;
            txtPrecio.Location = new Point(137, 238);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Padding = new Padding(7);
            txtPrecio.Size = new Size(115, 32);
            txtPrecio.TabIndex = 44;
            txtPrecio.Texts = "";
            txtPrecio.UnderlinedStyle1 = true;
            // 
            // txtRubro
            // 
            txtRubro.BackColor = SystemColors.Control;
            txtRubro.BorderColor = Color.DarkSlateGray;
            txtRubro.BorderFocusColor = Color.DarkGray;
            txtRubro.BorderSize = 2;
            txtRubro.Font = new Font("Segoe UI", 9.5F);
            txtRubro.ForeColor = Color.DimGray;
            txtRubro.Location = new Point(137, 200);
            txtRubro.Name = "txtRubro";
            txtRubro.Padding = new Padding(7);
            txtRubro.Size = new Size(115, 32);
            txtRubro.TabIndex = 43;
            txtRubro.Texts = "";
            txtRubro.UnderlinedStyle1 = true;
            // 
            // txtMarca
            // 
            txtMarca.BackColor = SystemColors.Control;
            txtMarca.BorderColor = Color.DarkSlateGray;
            txtMarca.BorderFocusColor = Color.DarkGray;
            txtMarca.BorderSize = 2;
            txtMarca.Font = new Font("Segoe UI", 9.5F);
            txtMarca.ForeColor = Color.DimGray;
            txtMarca.Location = new Point(137, 159);
            txtMarca.Name = "txtMarca";
            txtMarca.Padding = new Padding(7);
            txtMarca.Size = new Size(115, 32);
            txtMarca.TabIndex = 42;
            txtMarca.Texts = "";
            txtMarca.UnderlinedStyle1 = true;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = SystemColors.Control;
            txtNombre.BorderColor = Color.DarkSlateGray;
            txtNombre.BorderFocusColor = Color.DarkGray;
            txtNombre.BorderSize = 2;
            txtNombre.Font = new Font("Segoe UI", 9.5F);
            txtNombre.ForeColor = Color.DimGray;
            txtNombre.Location = new Point(137, 121);
            txtNombre.Name = "txtNombre";
            txtNombre.Padding = new Padding(7);
            txtNombre.Size = new Size(115, 32);
            txtNombre.TabIndex = 41;
            txtNombre.Texts = "";
            txtNombre.UnderlinedStyle1 = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(70, 136);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 39;
            label1.Text = "Nombre: ";
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
            txtBuscar.Location = new Point(78, -4);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Padding = new Padding(7);
            txtBuscar.Size = new Size(135, 32);
            txtBuscar.TabIndex = 46;
            txtBuscar.Texts = "Buscar...";
            txtBuscar.UnderlinedStyle1 = false;
            // 
            // txtPrecioLista
            // 
            txtPrecioLista.BackColor = SystemColors.Control;
            txtPrecioLista.BorderColor = Color.DarkSlateGray;
            txtPrecioLista.BorderFocusColor = Color.DarkGray;
            txtPrecioLista.BorderSize = 2;
            txtPrecioLista.Font = new Font("Segoe UI", 9.5F);
            txtPrecioLista.ForeColor = Color.DimGray;
            txtPrecioLista.Location = new Point(137, 322);
            txtPrecioLista.Name = "txtPrecioLista";
            txtPrecioLista.Padding = new Padding(7);
            txtPrecioLista.Size = new Size(115, 32);
            txtPrecioLista.TabIndex = 56;
            txtPrecioLista.Texts = "";
            txtPrecioLista.UnderlinedStyle1 = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(70, 337);
            label2.Name = "label2";
            label2.Size = new Size(87, 17);
            label2.TabIndex = 57;
            label2.Text = "Precio Lista: ";
            // 
            // AriculosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 518);
            Controls.Add(label2);
            Controls.Add(txtPrecioLista);
            Controls.Add(btnAgregar);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label7);
            Controls.Add(panelOpciones);
            Controls.Add(cmbCriterio);
            Controls.Add(btnBuscar);
            Controls.Add(txtStock);
            Controls.Add(txtPrecio);
            Controls.Add(txtRubro);
            Controls.Add(txtMarca);
            Controls.Add(txtNombre);
            Controls.Add(label1);
            Controls.Add(txtBuscar);
            Name = "AriculosForm";
            Text = "AriculosForm";
            Load += AriculosForm_Load;
            panel1.ResumeLayout(false);
            panelOpciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInactivos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private controlesPersonalizados.ClassBtnPersonalizado btnAgregar;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Button btnHabilitar;
        private controlesPersonalizados.ClassBtnPersonalizado btnArticulosDeshabilitados;
        private controlesPersonalizados.ClassBtnPersonalizado btnArticulosActivos;
        private Panel panel1;
        private Label label7;
        private Panel panelOpciones;
        private DataGridView dataGridView1;
        private Button btnDeshabilitar;
        private DataGridView dataGridViewInactivos;
        private ComboBox cmbCriterio;
        private controlesPersonalizados.ClassBtnPersonalizado btnBuscar;
        private controlesPersonalizados.Texboxs txtStock;
        private controlesPersonalizados.Texboxs txtPrecio;
        private controlesPersonalizados.Texboxs txtRubro;
        private controlesPersonalizados.Texboxs txtMarca;
        private controlesPersonalizados.Texboxs txtNombre;
        private Label label1;
        private controlesPersonalizados.Texboxs txtBuscar;
        private controlesPersonalizados.Texboxs txtPrecioLista;
        private Label label2;
    }
}