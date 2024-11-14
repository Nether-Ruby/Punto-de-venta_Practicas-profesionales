namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    partial class FormClientes
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
            txtC = new controlesPersonalizados.Texboxs();
            panel1 = new Panel();
            txtEmail = new TextBox();
            txtDomicilio = new TextBox();
            txtTelefono = new TextBox();
            txtApellido = new TextBox();
            btGuardar = new Button();
            txtNombre = new TextBox();
            txtCuil = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtEm = new controlesPersonalizados.Texboxs();
            txtDom = new controlesPersonalizados.Texboxs();
            txtTel = new controlesPersonalizados.Texboxs();
            txtApe = new controlesPersonalizados.Texboxs();
            txtNo = new controlesPersonalizados.Texboxs();
            button1 = new Button();
            dgvClientes = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // txtC
            // 
            txtC.BackColor = Color.FromArgb(0, 0, 64);
            txtC.BorderColor = Color.MediumBlue;
            txtC.BorderFocusColor = Color.DarkGray;
            txtC.BorderSize = 2;
            txtC.Font = new Font("Segoe UI", 9.5F);
            txtC.ForeColor = Color.DimGray;
            txtC.Location = new Point(59, 52);
            txtC.Name = "txtC";
            txtC.Padding = new Padding(7);
            txtC.Size = new Size(285, 36);
            txtC.TabIndex = 3;
            txtC.Texts = "";
            txtC.UnderlinedStyle1 = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtDomicilio);
            panel1.Controls.Add(txtTelefono);
            panel1.Controls.Add(txtApellido);
            panel1.Controls.Add(btGuardar);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(txtCuil);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtEm);
            panel1.Controls.Add(txtDom);
            panel1.Controls.Add(txtTel);
            panel1.Controls.Add(txtApe);
            panel1.Controls.Add(txtNo);
            panel1.Controls.Add(txtC);
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(27, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(532, 588);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(0, 0, 64);
            txtEmail.ForeColor = Color.DimGray;
            txtEmail.Location = new Point(378, 437);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(125, 27);
            txtEmail.TabIndex = 18;
            // 
            // txtDomicilio
            // 
            txtDomicilio.BackColor = Color.FromArgb(0, 0, 64);
            txtDomicilio.ForeColor = Color.DimGray;
            txtDomicilio.Location = new Point(378, 361);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Size = new Size(125, 27);
            txtDomicilio.TabIndex = 17;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.FromArgb(0, 0, 64);
            txtTelefono.ForeColor = Color.DimGray;
            txtTelefono.Location = new Point(378, 285);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(125, 27);
            txtTelefono.TabIndex = 16;
            txtTelefono.TextChanged += textBox2_TextChanged;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(0, 0, 64);
            txtApellido.ForeColor = Color.DimGray;
            txtApellido.Location = new Point(378, 212);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(125, 27);
            txtApellido.TabIndex = 15;
            // 
            // btGuardar
            // 
            btGuardar.Location = new Point(400, 503);
            btGuardar.Name = "btGuardar";
            btGuardar.Size = new Size(94, 29);
            btGuardar.TabIndex = 14;
            btGuardar.Text = "button1";
            btGuardar.UseVisualStyleBackColor = true;
            btGuardar.Click += btGuardar_Click;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(0, 0, 64);
            txtNombre.ForeColor = Color.DimGray;
            txtNombre.Location = new Point(378, 131);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(125, 27);
            txtNombre.TabIndex = 13;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // txtCuil
            // 
            txtCuil.BackColor = Color.FromArgb(0, 0, 64);
            txtCuil.ForeColor = Color.DimGray;
            txtCuil.Location = new Point(378, 56);
            txtCuil.Name = "txtCuil";
            txtCuil.Size = new Size(125, 27);
            txtCuil.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaptionText;
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(59, 29);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 6;
            label2.Text = "CUIL :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaptionText;
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(59, 108);
            label3.Name = "label3";
            label3.Size = new Size(71, 20);
            label3.TabIndex = 7;
            label3.Text = "Nombre :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaptionText;
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(59, 180);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 8;
            label4.Text = "Apellido :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaptionText;
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(59, 253);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 9;
            label5.Text = "Telefono :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ActiveCaptionText;
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(59, 325);
            label6.Name = "label6";
            label6.Size = new Size(81, 20);
            label6.TabIndex = 10;
            label6.Text = "Domicilio :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ActiveCaptionText;
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(59, 405);
            label7.Name = "label7";
            label7.Size = new Size(53, 20);
            label7.TabIndex = 11;
            label7.Text = "Email :";
            // 
            // txtEm
            // 
            txtEm.BackColor = Color.FromArgb(0, 0, 64);
            txtEm.BorderColor = Color.MediumBlue;
            txtEm.BorderFocusColor = Color.DarkGray;
            txtEm.BorderSize = 2;
            txtEm.Font = new Font("Segoe UI", 9.5F);
            txtEm.ForeColor = Color.DimGray;
            txtEm.Location = new Point(59, 428);
            txtEm.Name = "txtEm";
            txtEm.Padding = new Padding(7);
            txtEm.Size = new Size(285, 36);
            txtEm.TabIndex = 10;
            txtEm.Texts = "";
            txtEm.UnderlinedStyle1 = false;
            // 
            // txtDom
            // 
            txtDom.BackColor = Color.FromArgb(0, 0, 64);
            txtDom.BorderColor = Color.MediumBlue;
            txtDom.BorderFocusColor = Color.DarkGray;
            txtDom.BorderSize = 2;
            txtDom.Font = new Font("Segoe UI", 9.5F);
            txtDom.ForeColor = Color.DimGray;
            txtDom.Location = new Point(59, 352);
            txtDom.Name = "txtDom";
            txtDom.Padding = new Padding(7);
            txtDom.Size = new Size(285, 36);
            txtDom.TabIndex = 9;
            txtDom.Texts = "";
            txtDom.UnderlinedStyle1 = false;
            // 
            // txtTel
            // 
            txtTel.BackColor = Color.FromArgb(0, 0, 64);
            txtTel.BorderColor = Color.MediumBlue;
            txtTel.BorderFocusColor = Color.DarkGray;
            txtTel.BorderSize = 2;
            txtTel.Font = new Font("Segoe UI", 9.5F);
            txtTel.ForeColor = Color.DimGray;
            txtTel.Location = new Point(59, 276);
            txtTel.Name = "txtTel";
            txtTel.Padding = new Padding(7);
            txtTel.Size = new Size(285, 36);
            txtTel.TabIndex = 8;
            txtTel.Texts = "";
            txtTel.UnderlinedStyle1 = false;
            // 
            // txtApe
            // 
            txtApe.BackColor = Color.FromArgb(0, 0, 64);
            txtApe.BorderColor = Color.MediumBlue;
            txtApe.BorderFocusColor = Color.DarkGray;
            txtApe.BorderSize = 2;
            txtApe.Font = new Font("Segoe UI", 9.5F);
            txtApe.ForeColor = Color.DimGray;
            txtApe.Location = new Point(59, 203);
            txtApe.Name = "txtApe";
            txtApe.Padding = new Padding(7);
            txtApe.Size = new Size(285, 36);
            txtApe.TabIndex = 7;
            txtApe.Texts = "";
            txtApe.UnderlinedStyle1 = false;
            // 
            // txtNo
            // 
            txtNo.BackColor = Color.FromArgb(0, 0, 64);
            txtNo.BorderColor = Color.MediumBlue;
            txtNo.BorderFocusColor = Color.DarkGray;
            txtNo.BorderSize = 2;
            txtNo.Font = new Font("Segoe UI", 9.5F);
            txtNo.ForeColor = Color.DimGray;
            txtNo.Location = new Point(59, 131);
            txtNo.Name = "txtNo";
            txtNo.Padding = new Padding(7);
            txtNo.Size = new Size(285, 36);
            txtNo.TabIndex = 6;
            txtNo.Texts = "";
            txtNo.UnderlinedStyle1 = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkGoldenrod;
            button1.ForeColor = Color.LightYellow;
            button1.Location = new Point(894, 12);
            button1.Name = "button1";
            button1.Size = new Size(157, 29);
            button1.TabIndex = 15;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = Color.FromArgb(0, 0, 55);
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.GridColor = Color.Goldenrod;
            dgvClientes.Location = new Point(27, 73);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(1024, 304);
            dgvClientes.TabIndex = 16;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 45);
            ClientSize = new Size(1077, 775);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(dgvClientes);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormClientes";
            Text = "FormClientes";
            Load += FormClientes_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private controlesPersonalizados.Texboxs txtC;
        private Panel panel1;
        private controlesPersonalizados.Texboxs txtEm;
        private controlesPersonalizados.Texboxs txtDom;
        private controlesPersonalizados.Texboxs txtTel;
        private controlesPersonalizados.Texboxs txtApe;
        private controlesPersonalizados.Texboxs txtNo;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtCuil;
        private Button btGuardar;
        private TextBox txtNombre;
        private Button button1;
        private TextBox txtEmail;
        private TextBox txtDomicilio;
        private TextBox txtTelefono;
        private TextBox txtApellido;
        private DataGridView dgvClientes;
    }
}