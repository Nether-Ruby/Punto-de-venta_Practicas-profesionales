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
            txtCuil = new controlesPersonalizados.Texboxs();
            panel1 = new Panel();
            classBtnPersonalizado1 = new controlesPersonalizados.ClassBtnPersonalizado();
            btGuardar = new controlesPersonalizados.ClassBtnPersonalizado();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtEmail = new controlesPersonalizados.Texboxs();
            txtDomicilio = new controlesPersonalizados.Texboxs();
            txtTelefono = new controlesPersonalizados.Texboxs();
            txtApellido = new controlesPersonalizados.Texboxs();
            txtNombre = new controlesPersonalizados.Texboxs();
            dgvClientes = new DataGridView();
            btNuevoCliente = new controlesPersonalizados.ClassBtnPersonalizado();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // txtCuil
            // 
            txtCuil.BackColor = Color.FromArgb(0, 0, 64);
            txtCuil.BorderColor = Color.MediumBlue;
            txtCuil.BorderFocusColor = Color.DarkGray;
            txtCuil.BorderSize = 2;
            txtCuil.Font = new Font("Segoe UI", 9.5F);
            txtCuil.ForeColor = Color.DimGray;
            txtCuil.Location = new Point(59, 52);
            txtCuil.Name = "txtCuil";
            txtCuil.Padding = new Padding(7);
            txtCuil.Size = new Size(285, 36);
            txtCuil.TabIndex = 3;
            txtCuil.Texts = "";
            txtCuil.UnderlinedStyle1 = false;
            txtCuil._TextChanged += txtCuil__TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Navy;
            panel1.Controls.Add(classBtnPersonalizado1);
            panel1.Controls.Add(btGuardar);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(txtEmail);
            panel1.Controls.Add(txtDomicilio);
            panel1.Controls.Add(txtTelefono);
            panel1.Controls.Add(txtApellido);
            panel1.Controls.Add(txtNombre);
            panel1.Controls.Add(txtCuil);
            panel1.ForeColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(345, 47);
            panel1.Name = "panel1";
            panel1.Size = new Size(429, 588);
            panel1.TabIndex = 4;
            panel1.Paint += panel1_Paint;
            // 
            // classBtnPersonalizado1
            // 
            classBtnPersonalizado1.BackColor = Color.MidnightBlue;
            classBtnPersonalizado1.BackgroundColor = Color.MidnightBlue;
            classBtnPersonalizado1.BorderColor = Color.PaleVioletRed;
            classBtnPersonalizado1.BorderRadius = 40;
            classBtnPersonalizado1.BorderSize = 0;
            classBtnPersonalizado1.FlatAppearance.BorderSize = 0;
            classBtnPersonalizado1.FlatStyle = FlatStyle.Flat;
            classBtnPersonalizado1.ForeColor = Color.White;
            classBtnPersonalizado1.IconAlignment = ContentAlignment.MiddleLeft;
            classBtnPersonalizado1.IconChar = FontAwesome.Sharp.IconChar.None;
            classBtnPersonalizado1.IconColor = Color.White;
            classBtnPersonalizado1.IconPadding = 5;
            classBtnPersonalizado1.IconSize = 24;
            classBtnPersonalizado1.Location = new Point(44, 502);
            classBtnPersonalizado1.Name = "classBtnPersonalizado1";
            classBtnPersonalizado1.Size = new Size(151, 50);
            classBtnPersonalizado1.TabIndex = 16;
            classBtnPersonalizado1.Text = "Cancelar";
            classBtnPersonalizado1.TextColor = Color.White;
            classBtnPersonalizado1.UseVisualStyleBackColor = false;
            classBtnPersonalizado1.Click += classBtnPersonalizado1_Click;
            // 
            // btGuardar
            // 
            btGuardar.BackColor = Color.RoyalBlue;
            btGuardar.BackgroundColor = Color.RoyalBlue;
            btGuardar.BorderColor = Color.PaleVioletRed;
            btGuardar.BorderRadius = 40;
            btGuardar.BorderSize = 0;
            btGuardar.FlatAppearance.BorderSize = 0;
            btGuardar.FlatStyle = FlatStyle.Flat;
            btGuardar.ForeColor = Color.White;
            btGuardar.IconAlignment = ContentAlignment.MiddleLeft;
            btGuardar.IconChar = FontAwesome.Sharp.IconChar.None;
            btGuardar.IconColor = Color.White;
            btGuardar.IconPadding = 5;
            btGuardar.IconSize = 24;
            btGuardar.Location = new Point(245, 502);
            btGuardar.Name = "btGuardar";
            btGuardar.Size = new Size(151, 50);
            btGuardar.TabIndex = 15;
            btGuardar.Text = "Agregar";
            btGuardar.TextColor = Color.White;
            btGuardar.UseVisualStyleBackColor = false;
            btGuardar.Click += btGuardar_Click_1;
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
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(0, 0, 64);
            txtEmail.BorderColor = Color.MediumBlue;
            txtEmail.BorderFocusColor = Color.DarkGray;
            txtEmail.BorderSize = 2;
            txtEmail.Font = new Font("Segoe UI", 9.5F);
            txtEmail.ForeColor = Color.DimGray;
            txtEmail.Location = new Point(59, 428);
            txtEmail.Name = "txtEmail";
            txtEmail.Padding = new Padding(7);
            txtEmail.Size = new Size(285, 36);
            txtEmail.TabIndex = 10;
            txtEmail.Texts = "";
            txtEmail.UnderlinedStyle1 = false;
            // 
            // txtDomicilio
            // 
            txtDomicilio.BackColor = Color.FromArgb(0, 0, 64);
            txtDomicilio.BorderColor = Color.MediumBlue;
            txtDomicilio.BorderFocusColor = Color.DarkGray;
            txtDomicilio.BorderSize = 2;
            txtDomicilio.Font = new Font("Segoe UI", 9.5F);
            txtDomicilio.ForeColor = Color.DimGray;
            txtDomicilio.Location = new Point(59, 352);
            txtDomicilio.Name = "txtDomicilio";
            txtDomicilio.Padding = new Padding(7);
            txtDomicilio.Size = new Size(285, 36);
            txtDomicilio.TabIndex = 9;
            txtDomicilio.Texts = "";
            txtDomicilio.UnderlinedStyle1 = false;
            // 
            // txtTelefono
            // 
            txtTelefono.BackColor = Color.FromArgb(0, 0, 64);
            txtTelefono.BorderColor = Color.MediumBlue;
            txtTelefono.BorderFocusColor = Color.DarkGray;
            txtTelefono.BorderSize = 2;
            txtTelefono.Font = new Font("Segoe UI", 9.5F);
            txtTelefono.ForeColor = Color.DimGray;
            txtTelefono.Location = new Point(59, 276);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Padding = new Padding(7);
            txtTelefono.Size = new Size(285, 36);
            txtTelefono.TabIndex = 8;
            txtTelefono.Texts = "";
            txtTelefono.UnderlinedStyle1 = false;
            // 
            // txtApellido
            // 
            txtApellido.BackColor = Color.FromArgb(0, 0, 64);
            txtApellido.BorderColor = Color.MediumBlue;
            txtApellido.BorderFocusColor = Color.DarkGray;
            txtApellido.BorderSize = 2;
            txtApellido.Font = new Font("Segoe UI", 9.5F);
            txtApellido.ForeColor = Color.DimGray;
            txtApellido.Location = new Point(59, 203);
            txtApellido.Name = "txtApellido";
            txtApellido.Padding = new Padding(7);
            txtApellido.Size = new Size(285, 36);
            txtApellido.TabIndex = 7;
            txtApellido.Texts = "";
            txtApellido.UnderlinedStyle1 = false;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(0, 0, 64);
            txtNombre.BorderColor = Color.MediumBlue;
            txtNombre.BorderFocusColor = Color.DarkGray;
            txtNombre.BorderSize = 2;
            txtNombre.Font = new Font("Segoe UI", 9.5F);
            txtNombre.ForeColor = Color.DimGray;
            txtNombre.Location = new Point(59, 131);
            txtNombre.Name = "txtNombre";
            txtNombre.Padding = new Padding(7);
            txtNombre.Size = new Size(285, 36);
            txtNombre.TabIndex = 6;
            txtNombre.Texts = "";
            txtNombre.UnderlinedStyle1 = false;
            // 
            // dgvClientes
            // 
            dgvClientes.BackgroundColor = Color.FromArgb(0, 0, 55);
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.GridColor = Color.Goldenrod;
            dgvClientes.Location = new Point(27, 118);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(1024, 335);
            dgvClientes.TabIndex = 16;
            // 
            // btNuevoCliente
            // 
            btNuevoCliente.BackColor = Color.RoyalBlue;
            btNuevoCliente.BackgroundColor = Color.RoyalBlue;
            btNuevoCliente.BorderColor = Color.PaleVioletRed;
            btNuevoCliente.BorderRadius = 40;
            btNuevoCliente.BorderSize = 0;
            btNuevoCliente.FlatAppearance.BorderSize = 0;
            btNuevoCliente.FlatStyle = FlatStyle.Flat;
            btNuevoCliente.ForeColor = Color.White;
            btNuevoCliente.IconAlignment = ContentAlignment.MiddleCenter;
            btNuevoCliente.IconChar = FontAwesome.Sharp.IconChar.None;
            btNuevoCliente.IconColor = Color.White;
            btNuevoCliente.IconPadding = 5;
            btNuevoCliente.IconSize = 24;
            btNuevoCliente.Location = new Point(881, 12);
            btNuevoCliente.Name = "btNuevoCliente";
            btNuevoCliente.Size = new Size(172, 48);
            btNuevoCliente.TabIndex = 16;
            btNuevoCliente.Text = "Registrar";
            btNuevoCliente.TextColor = Color.White;
            btNuevoCliente.UseVisualStyleBackColor = false;
            btNuevoCliente.Click += classBtnPersonalizado2_Click;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 45);
            ClientSize = new Size(1077, 775);
            Controls.Add(panel1);
            Controls.Add(dgvClientes);
            Controls.Add(btNuevoCliente);
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
        private controlesPersonalizados.Texboxs txtCuil;
        private Panel panel1;
        private controlesPersonalizados.Texboxs txtEmail;
        private controlesPersonalizados.Texboxs txtDomicilio;
        private controlesPersonalizados.Texboxs txtTelefono;
        private controlesPersonalizados.Texboxs txtApellido;
        private controlesPersonalizados.Texboxs txtNombre;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DataGridView dgvClientes;
        private controlesPersonalizados.ClassBtnPersonalizado btGuardar;
        private controlesPersonalizados.ClassBtnPersonalizado btNuevoCliente;
        private controlesPersonalizados.ClassBtnPersonalizado classBtnPersonalizado1;
    }
}