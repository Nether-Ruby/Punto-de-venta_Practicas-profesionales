namespace Punto_de_venta___Prácticas_profesionales.Presentación
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
            dgvArticulos = new DataGridView();
            nombre = new DataGridViewTextBoxColumn();
            marca = new DataGridViewTextBoxColumn();
            rubro = new DataGridViewTextBoxColumn();
            precio = new DataGridViewTextBoxColumn();
            stock = new DataGridViewTextBoxColumn();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button8 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).BeginInit();
            SuspendLayout();
            // 
            // dgvArticulos
            // 
            dgvArticulos.BackgroundColor = SystemColors.ButtonFace;
            dgvArticulos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvArticulos.Columns.AddRange(new DataGridViewColumn[] { nombre, marca, rubro, precio, stock });
            dgvArticulos.GridColor = SystemColors.MenuText;
            dgvArticulos.Location = new Point(12, 12);
            dgvArticulos.Name = "dgvArticulos";
            dgvArticulos.Size = new Size(541, 298);
            dgvArticulos.TabIndex = 1;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            // 
            // marca
            // 
            marca.HeaderText = "marca";
            marca.Name = "marca";
            // 
            // rubro
            // 
            rubro.HeaderText = "rubro";
            rubro.Name = "rubro";
            // 
            // precio
            // 
            precio.HeaderText = "Precio";
            precio.Name = "precio";
            // 
            // stock
            // 
            stock.HeaderText = "stock";
            stock.Name = "stock";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Location = new Point(568, 12);
            button3.Name = "button3";
            button3.Size = new Size(134, 38);
            button3.TabIndex = 3;
            button3.Text = "Agregar";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.BackColor = Color.White;
            button4.Font = new Font("Mongolian Baiti", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.MidnightBlue;
            button4.Location = new Point(175, 328);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 4;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.Location = new Point(568, 56);
            button5.Name = "button5";
            button5.Size = new Size(134, 38);
            button5.TabIndex = 5;
            button5.Text = "Editar";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(568, 100);
            button6.Name = "button6";
            button6.Size = new Size(134, 38);
            button6.TabIndex = 6;
            button6.Text = "Eliminar";
            button6.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            button8.BackColor = Color.LavenderBlush;
            button8.FlatStyle = FlatStyle.Flat;
            button8.ForeColor = SystemColors.ActiveCaptionText;
            button8.Location = new Point(275, 328);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 8;
            button8.Text = "button8";
            button8.UseVisualStyleBackColor = false;
            // 
            // FormArticulos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(942, 581);
            Controls.Add(button8);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(dgvArticulos);
            Name = "FormArticulos";
            Text = "FormArticulos";
            ((System.ComponentModel.ISupportInitialize)dgvArticulos).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private DataGridView dgvArticulos;
        private DataGridViewTextBoxColumn nombre;
        private DataGridViewTextBoxColumn marca;
        private DataGridViewTextBoxColumn rubro;
        private DataGridViewTextBoxColumn precio;
        private DataGridViewTextBoxColumn stock;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button8;
    }
}