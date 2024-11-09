namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    partial class FormProveedores
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
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            groupBox1 = new GroupBox();
            button3 = new controlesPersonalizados.ClassBtnPersonalizado();
            button1 = new controlesPersonalizados.ClassBtnPersonalizado();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            button2 = new controlesPersonalizados.ClassBtnPersonalizado();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Size = new Size(942, 581);
            splitContainer1.SplitterDistance = 233;
            splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(0, 0);
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(groupBox2);
            splitContainer2.Size = new Size(942, 233);
            splitContainer2.SplitterDistance = 188;
            splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(188, 233);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Búsqueda";
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.BackColor = Color.MediumSlateBlue;
            button3.BackgroundColor = Color.MediumSlateBlue;
            button3.BorderColor = Color.PaleVioletRed;
            button3.BorderRadius = 40;
            button3.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.IconAlignment = ContentAlignment.MiddleRight;
            button3.IconChar = FontAwesome.Sharp.IconChar.Database;
            button3.IconColor = Color.White;
            button3.IconPadding = 5;
            button3.IconSize = 24;
            button3.Location = new Point(21, 177);
            button3.Name = "button3";
            button3.Size = new Size(150, 40);
            button3.TabIndex = 3;
            button3.Text = "Mostrar todo";
            button3.TextColor = Color.White;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.BackColor = Color.MediumSlateBlue;
            button1.BackgroundColor = Color.MediumSlateBlue;
            button1.BorderColor = Color.PaleVioletRed;
            button1.BorderRadius = 40;
            button1.BorderSize = 0;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.IconAlignment = ContentAlignment.MiddleRight;
            button1.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlassChart;
            button1.IconColor = Color.White;
            button1.IconPadding = 5;
            button1.IconSize = 24;
            button1.Location = new Point(21, 122);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 2;
            button1.Text = "Buscar";
            button1.TextColor = Color.White;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Font = new Font("Segoe UI", 12F);
            textBox1.Location = new Point(6, 38);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Inserte término a buscar";
            textBox1.Size = new Size(176, 29);
            textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Dock = DockStyle.Fill;
            groupBox2.Location = new Point(0, 0);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(750, 233);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Agregar proveedor";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.BackColor = Color.MediumSlateBlue;
            button2.BackgroundColor = Color.MediumSlateBlue;
            button2.BorderColor = Color.PaleVioletRed;
            button2.BorderRadius = 40;
            button2.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.IconAlignment = ContentAlignment.MiddleLeft;
            button2.IconChar = FontAwesome.Sharp.IconChar.None;
            button2.IconColor = Color.White;
            button2.IconPadding = 5;
            button2.IconSize = 24;
            button2.Location = new Point(290, 122);
            button2.Name = "button2";
            button2.Size = new Size(150, 40);
            button2.TabIndex = 8;
            button2.Text = "Agregar proveedor";
            button2.TextColor = Color.White;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(557, 19);
            label4.Name = "label4";
            label4.Size = new Size(76, 15);
            label4.TabIndex = 7;
            label4.Text = "Deuda actual";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(381, 19);
            label3.Name = "label3";
            label3.Size = new Size(36, 15);
            label3.TabIndex = 6;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(202, 19);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 5;
            label2.Text = "Teléfono";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(23, 20);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.None;
            textBox5.Font = new Font("Segoe UI", 12F);
            textBox5.Location = new Point(557, 38);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 29);
            textBox5.TabIndex = 3;
            textBox5.KeyPress += textBox5_KeyPress;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.None;
            textBox4.Font = new Font("Segoe UI", 12F);
            textBox4.Location = new Point(381, 38);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 29);
            textBox4.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.None;
            textBox3.Font = new Font("Segoe UI", 12F);
            textBox3.Location = new Point(202, 38);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(150, 29);
            textBox3.TabIndex = 1;
            textBox3.KeyPress += textBox3_KeyPress;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Font = new Font("Segoe UI", 12F);
            textBox2.Location = new Point(23, 38);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(150, 29);
            textBox2.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(942, 344);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;
            // 
            // FormProveedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(942, 581);
            Controls.Add(splitContainer1);
            Name = "FormProveedores";
            Text = "FormProveedores";
            Resize += FormProveedores_Resize;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private SplitContainer splitContainer2;
        private GroupBox groupBox1;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private TextBox textBox2;
        private DataGridView dataGridView1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label4;
        private controlesPersonalizados.ClassBtnPersonalizado button1;
        private controlesPersonalizados.ClassBtnPersonalizado button2;
        private controlesPersonalizados.ClassBtnPersonalizado button3;
    }
}