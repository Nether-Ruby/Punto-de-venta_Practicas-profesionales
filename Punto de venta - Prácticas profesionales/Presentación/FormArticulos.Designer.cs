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
            btnAgregar = new Button();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtMarca = new TextBox();
            txtRubro = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dataGridView1 = new DataGridView();
            texboxs1 = new controlesPersonalizados.Texboxs();
            texboxs2 = new controlesPersonalizados.Texboxs();
            texboxs3 = new controlesPersonalizados.Texboxs();
            texboxs4 = new controlesPersonalizados.Texboxs();
            texboxs5 = new controlesPersonalizados.Texboxs();
            texboxs6 = new controlesPersonalizados.Texboxs();
            label1 = new Label();
            texboxs7 = new controlesPersonalizados.Texboxs();
            label2 = new Label();
            dataGridViewInactivos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInactivos).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(28, 219);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += button1_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(12, 12);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(100, 23);
            txtCodigo.TabIndex = 1;
            txtCodigo.TextChanged += txtCodigo_TextChanged;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 51);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 2;
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(12, 90);
            txtMarca.Name = "txtMarca";
            txtMarca.Size = new Size(100, 23);
            txtMarca.TabIndex = 3;
            // 
            // txtRubro
            // 
            txtRubro.Location = new Point(12, 119);
            txtRubro.Name = "txtRubro";
            txtRubro.Size = new Size(100, 23);
            txtRubro.TabIndex = 4;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(12, 148);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 5;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(12, 190);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(100, 23);
            txtStock.TabIndex = 6;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(109, 219);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(75, 23);
            btnActualizar.TabIndex = 7;
            btnActualizar.Text = "actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(28, 248);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.TabIndex = 8;
            btnEliminar.Text = "eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(109, 248);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 23);
            btnLimpiar.TabIndex = 9;
            btnLimpiar.Text = "limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(127, 21);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(240, 150);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // texboxs1
            // 
            texboxs1.BackColor = SystemColors.Window;
            texboxs1.BorderColor = Color.DarkSlateGray;
            texboxs1.BorderFocusColor = Color.DarkGray;
            texboxs1.BorderSize = 2;
            texboxs1.Font = new Font("Segoe UI", 9.5F);
            texboxs1.ForeColor = Color.DimGray;
            texboxs1.Location = new Point(418, 81);
            texboxs1.Name = "texboxs1";
            texboxs1.Padding = new Padding(7);
            texboxs1.Size = new Size(147, 32);
            texboxs1.TabIndex = 11;
            texboxs1.Texts = "";
            texboxs1.UnderlinedStyle1 = false;
            // 
            // texboxs2
            // 
            texboxs2.BackColor = SystemColors.Window;
            texboxs2.BorderColor = Color.Teal;
            texboxs2.BorderFocusColor = Color.DarkGray;
            texboxs2.BorderSize = 2;
            texboxs2.Font = new Font("Segoe UI", 9.5F);
            texboxs2.ForeColor = Color.DimGray;
            texboxs2.Location = new Point(588, 123);
            texboxs2.Name = "texboxs2";
            texboxs2.Padding = new Padding(7);
            texboxs2.Size = new Size(178, 32);
            texboxs2.TabIndex = 12;
            texboxs2.Texts = "";
            texboxs2.UnderlinedStyle1 = true;
            // 
            // texboxs3
            // 
            texboxs3.BackColor = SystemColors.Window;
            texboxs3.BorderColor = Color.Teal;
            texboxs3.BorderFocusColor = Color.DarkGray;
            texboxs3.BorderSize = 2;
            texboxs3.Font = new Font("Segoe UI", 9.5F);
            texboxs3.ForeColor = Color.DimGray;
            texboxs3.Location = new Point(418, 123);
            texboxs3.Name = "texboxs3";
            texboxs3.Padding = new Padding(7);
            texboxs3.Size = new Size(147, 32);
            texboxs3.TabIndex = 13;
            texboxs3.Texts = "";
            texboxs3.UnderlinedStyle1 = false;
            // 
            // texboxs4
            // 
            texboxs4.BackColor = SystemColors.Window;
            texboxs4.BorderColor = Color.DarkSlateGray;
            texboxs4.BorderFocusColor = Color.DarkGray;
            texboxs4.BorderSize = 2;
            texboxs4.Font = new Font("Segoe UI", 9.5F);
            texboxs4.ForeColor = Color.DimGray;
            texboxs4.Location = new Point(588, 81);
            texboxs4.Name = "texboxs4";
            texboxs4.Padding = new Padding(7);
            texboxs4.Size = new Size(178, 32);
            texboxs4.TabIndex = 14;
            texboxs4.Texts = "";
            texboxs4.UnderlinedStyle1 = true;
            // 
            // texboxs5
            // 
            texboxs5.BackColor = SystemColors.Window;
            texboxs5.BorderColor = Color.SteelBlue;
            texboxs5.BorderFocusColor = Color.DarkGray;
            texboxs5.BorderSize = 2;
            texboxs5.Font = new Font("Segoe UI", 9.5F);
            texboxs5.ForeColor = Color.DimGray;
            texboxs5.Location = new Point(418, 161);
            texboxs5.Name = "texboxs5";
            texboxs5.Padding = new Padding(7);
            texboxs5.Size = new Size(147, 32);
            texboxs5.TabIndex = 15;
            texboxs5.Texts = "";
            texboxs5.UnderlinedStyle1 = false;
            // 
            // texboxs6
            // 
            texboxs6.BackColor = SystemColors.Window;
            texboxs6.BorderColor = Color.FromArgb(0, 0, 64);
            texboxs6.BorderFocusColor = Color.DarkGray;
            texboxs6.BorderSize = 2;
            texboxs6.Font = new Font("Segoe UI", 9.5F);
            texboxs6.ForeColor = Color.DimGray;
            texboxs6.Location = new Point(736, 42);
            texboxs6.Name = "texboxs6";
            texboxs6.Padding = new Padding(7);
            texboxs6.Size = new Size(148, 32);
            texboxs6.TabIndex = 16;
            texboxs6.Texts = "";
            texboxs6.UnderlinedStyle1 = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(521, 42);
            label1.Name = "label1";
            label1.Size = new Size(66, 17);
            label1.TabIndex = 17;
            label1.Text = "Nombre: ";
            // 
            // texboxs7
            // 
            texboxs7.BackColor = SystemColors.Window;
            texboxs7.BorderColor = Color.Teal;
            texboxs7.BorderFocusColor = Color.DarkGray;
            texboxs7.BorderSize = 2;
            texboxs7.Font = new Font("Segoe UI", 9.5F);
            texboxs7.ForeColor = Color.DimGray;
            texboxs7.Location = new Point(736, 90);
            texboxs7.Name = "texboxs7";
            texboxs7.Padding = new Padding(7);
            texboxs7.Size = new Size(157, 32);
            texboxs7.TabIndex = 18;
            texboxs7.Texts = "";
            texboxs7.UnderlinedStyle1 = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(621, 42);
            label2.Name = "label2";
            label2.Size = new Size(53, 17);
            label2.TabIndex = 19;
            label2.Text = "Marca: ";
            // 
            // dataGridViewInactivos
            // 
            dataGridViewInactivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInactivos.Location = new Point(579, 219);
            dataGridViewInactivos.Name = "dataGridViewInactivos";
            dataGridViewInactivos.ReadOnly = true;
            dataGridViewInactivos.Size = new Size(240, 150);
            dataGridViewInactivos.TabIndex = 20;
            // 
            // FormArtic
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(927, 450);
            Controls.Add(dataGridViewInactivos);
            Controls.Add(label2);
            Controls.Add(texboxs7);
            Controls.Add(label1);
            Controls.Add(texboxs6);
            Controls.Add(texboxs5);
            Controls.Add(texboxs4);
            Controls.Add(texboxs3);
            Controls.Add(texboxs2);
            Controls.Add(texboxs1);
            Controls.Add(dataGridView1);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(txtStock);
            Controls.Add(txtPrecio);
            Controls.Add(txtRubro);
            Controls.Add(txtMarca);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(btnAgregar);
            Name = "FormArtic";
            Text = "FormArtic";
            Load += FormArtic_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInactivos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAgregar;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtMarca;
        private TextBox txtRubro;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dataGridView1;
        private controlesPersonalizados.Texboxs texboxs1;
        private controlesPersonalizados.Texboxs texboxs2;
        private controlesPersonalizados.Texboxs texboxs3;
        private controlesPersonalizados.Texboxs texboxs4;
        private controlesPersonalizados.Texboxs texboxs5;
        private controlesPersonalizados.Texboxs texboxs6;
        private Label label1;
        private controlesPersonalizados.Texboxs texboxs7;
        private Label label2;
        private DataGridView dataGridViewInactivos;
    }
}