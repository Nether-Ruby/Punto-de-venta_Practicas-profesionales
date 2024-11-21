namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    partial class FormCaja
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
            dataGridViewTransacciones = new DataGridView();
            btnCargarTransacciones = new controlesPersonalizados.ClassBtnPersonalizado();
            btnIngreso = new controlesPersonalizados.ClassBtnPersonalizado();
            btnEgreso = new controlesPersonalizados.ClassBtnPersonalizado();
            txtMonto = new controlesPersonalizados.Texboxs();
            dataGridViewMovimientos = new DataGridView();
            txtTotalIngresos = new controlesPersonalizados.Texboxs();
            txtTotalEgresos = new controlesPersonalizados.Texboxs();
            txtEfectivo = new controlesPersonalizados.Texboxs();
            txtTarjeta = new controlesPersonalizados.Texboxs();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            btnCierreDeCaja = new controlesPersonalizados.ClassBtnPersonalizado();
            dataGridViewVentas = new DataGridView();
            panelOpciones = new Panel();
            btnVentas = new controlesPersonalizados.ClassBtnPersonalizado();
            btnMovimientos = new controlesPersonalizados.ClassBtnPersonalizado();
            classBtnPersonalizado1 = new controlesPersonalizados.ClassBtnPersonalizado();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransacciones).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimientos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVentas).BeginInit();
            panelOpciones.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewTransacciones
            // 
            dataGridViewTransacciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTransacciones.Location = new Point(21, 296);
            dataGridViewTransacciones.Name = "dataGridViewTransacciones";
            dataGridViewTransacciones.Size = new Size(240, 150);
            dataGridViewTransacciones.TabIndex = 0;
            // 
            // btnCargarTransacciones
            // 
            btnCargarTransacciones.BackColor = Color.MediumSlateBlue;
            btnCargarTransacciones.BackgroundColor = Color.MediumSlateBlue;
            btnCargarTransacciones.BorderColor = Color.PaleVioletRed;
            btnCargarTransacciones.BorderRadius = 40;
            btnCargarTransacciones.BorderSize = 0;
            btnCargarTransacciones.FlatAppearance.BorderSize = 0;
            btnCargarTransacciones.FlatStyle = FlatStyle.Flat;
            btnCargarTransacciones.ForeColor = Color.White;
            btnCargarTransacciones.IconAlignment = ContentAlignment.MiddleLeft;
            btnCargarTransacciones.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCargarTransacciones.IconColor = Color.White;
            btnCargarTransacciones.IconPadding = 5;
            btnCargarTransacciones.IconSize = 24;
            btnCargarTransacciones.Location = new Point(270, 12);
            btnCargarTransacciones.Name = "btnCargarTransacciones";
            btnCargarTransacciones.Size = new Size(141, 42);
            btnCargarTransacciones.TabIndex = 1;
            btnCargarTransacciones.Text = "ver transacciones del dia ";
            btnCargarTransacciones.TextColor = Color.White;
            btnCargarTransacciones.UseVisualStyleBackColor = false;
            // 
            // btnIngreso
            // 
            btnIngreso.BackColor = Color.MediumSlateBlue;
            btnIngreso.BackgroundColor = Color.MediumSlateBlue;
            btnIngreso.BorderColor = Color.PaleVioletRed;
            btnIngreso.BorderRadius = 40;
            btnIngreso.BorderSize = 0;
            btnIngreso.FlatAppearance.BorderSize = 0;
            btnIngreso.FlatStyle = FlatStyle.Flat;
            btnIngreso.ForeColor = Color.White;
            btnIngreso.IconAlignment = ContentAlignment.MiddleLeft;
            btnIngreso.IconChar = FontAwesome.Sharp.IconChar.None;
            btnIngreso.IconColor = Color.White;
            btnIngreso.IconPadding = 5;
            btnIngreso.IconSize = 24;
            btnIngreso.Location = new Point(312, 122);
            btnIngreso.Name = "btnIngreso";
            btnIngreso.Size = new Size(150, 40);
            btnIngreso.TabIndex = 2;
            btnIngreso.Text = "Ingreso";
            btnIngreso.TextColor = Color.White;
            btnIngreso.UseVisualStyleBackColor = false;
            btnIngreso.Click += btnIngreso_Click;
            // 
            // btnEgreso
            // 
            btnEgreso.BackColor = Color.MediumSlateBlue;
            btnEgreso.BackgroundColor = Color.MediumSlateBlue;
            btnEgreso.BorderColor = Color.PaleVioletRed;
            btnEgreso.BorderRadius = 40;
            btnEgreso.BorderSize = 0;
            btnEgreso.FlatAppearance.BorderSize = 0;
            btnEgreso.FlatStyle = FlatStyle.Flat;
            btnEgreso.ForeColor = Color.White;
            btnEgreso.IconAlignment = ContentAlignment.MiddleLeft;
            btnEgreso.IconChar = FontAwesome.Sharp.IconChar.None;
            btnEgreso.IconColor = Color.White;
            btnEgreso.IconPadding = 5;
            btnEgreso.IconSize = 24;
            btnEgreso.Location = new Point(312, 177);
            btnEgreso.Name = "btnEgreso";
            btnEgreso.Size = new Size(150, 40);
            btnEgreso.TabIndex = 3;
            btnEgreso.Text = "Egreso";
            btnEgreso.TextColor = Color.White;
            btnEgreso.UseVisualStyleBackColor = false;
            btnEgreso.Click += btnEgreso_Click;
            // 
            // txtMonto
            // 
            txtMonto.BackColor = SystemColors.Window;
            txtMonto.BorderColor = Color.MediumBlue;
            txtMonto.BorderFocusColor = Color.DarkGray;
            txtMonto.BorderSize = 2;
            txtMonto.Font = new Font("Segoe UI", 9.5F);
            txtMonto.ForeColor = Color.DimGray;
            txtMonto.Location = new Point(374, 327);
            txtMonto.Name = "txtMonto";
            txtMonto.Padding = new Padding(7);
            txtMonto.Size = new Size(228, 32);
            txtMonto.TabIndex = 4;
            txtMonto.Texts = "";
            txtMonto.UnderlinedStyle1 = false;
            // 
            // dataGridViewMovimientos
            // 
            dataGridViewMovimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMovimientos.Location = new Point(14, 44);
            dataGridViewMovimientos.Name = "dataGridViewMovimientos";
            dataGridViewMovimientos.Size = new Size(240, 150);
            dataGridViewMovimientos.TabIndex = 5;
            // 
            // txtTotalIngresos
            // 
            txtTotalIngresos.BackColor = SystemColors.Window;
            txtTotalIngresos.BorderColor = Color.MediumBlue;
            txtTotalIngresos.BorderFocusColor = Color.DarkGray;
            txtTotalIngresos.BorderSize = 2;
            txtTotalIngresos.Font = new Font("Segoe UI", 9.5F);
            txtTotalIngresos.ForeColor = Color.DimGray;
            txtTotalIngresos.Location = new Point(133, 122);
            txtTotalIngresos.Name = "txtTotalIngresos";
            txtTotalIngresos.Padding = new Padding(7);
            txtTotalIngresos.Size = new Size(173, 32);
            txtTotalIngresos.TabIndex = 6;
            txtTotalIngresos.Texts = "";
            txtTotalIngresos.UnderlinedStyle1 = false;
            // 
            // txtTotalEgresos
            // 
            txtTotalEgresos.BackColor = SystemColors.Window;
            txtTotalEgresos.BorderColor = Color.MediumBlue;
            txtTotalEgresos.BorderFocusColor = Color.DarkGray;
            txtTotalEgresos.BorderSize = 2;
            txtTotalEgresos.Font = new Font("Segoe UI", 9.5F);
            txtTotalEgresos.ForeColor = Color.DimGray;
            txtTotalEgresos.Location = new Point(133, 177);
            txtTotalEgresos.Name = "txtTotalEgresos";
            txtTotalEgresos.Padding = new Padding(7);
            txtTotalEgresos.Size = new Size(173, 32);
            txtTotalEgresos.TabIndex = 7;
            txtTotalEgresos.Texts = "";
            txtTotalEgresos.UnderlinedStyle1 = false;
            // 
            // txtEfectivo
            // 
            txtEfectivo.BackColor = SystemColors.Window;
            txtEfectivo.BorderColor = Color.MediumBlue;
            txtEfectivo.BorderFocusColor = Color.DarkGray;
            txtEfectivo.BorderSize = 2;
            txtEfectivo.Font = new Font("Segoe UI", 9.5F);
            txtEfectivo.ForeColor = Color.DimGray;
            txtEfectivo.Location = new Point(133, 15);
            txtEfectivo.Name = "txtEfectivo";
            txtEfectivo.Padding = new Padding(7);
            txtEfectivo.Size = new Size(173, 32);
            txtEfectivo.TabIndex = 8;
            txtEfectivo.Texts = "";
            txtEfectivo.UnderlinedStyle1 = false;
            // 
            // txtTarjeta
            // 
            txtTarjeta.BackColor = SystemColors.Window;
            txtTarjeta.BorderColor = Color.MediumBlue;
            txtTarjeta.BorderFocusColor = Color.DarkGray;
            txtTarjeta.BorderSize = 2;
            txtTarjeta.Font = new Font("Segoe UI", 9.5F);
            txtTarjeta.ForeColor = Color.DimGray;
            txtTarjeta.Location = new Point(133, 72);
            txtTarjeta.Name = "txtTarjeta";
            txtTarjeta.Padding = new Padding(7);
            txtTarjeta.Size = new Size(173, 32);
            txtTarjeta.TabIndex = 9;
            txtTarjeta.Texts = "";
            txtTarjeta.UnderlinedStyle1 = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(9, 30);
            label1.Name = "label1";
            label1.Size = new Size(115, 17);
            label1.TabIndex = 10;
            label1.Text = "Total de efectivo:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(15, 83);
            label2.Name = "label2";
            label2.Size = new Size(112, 17);
            label2.TabIndex = 11;
            label2.Text = "Total de tarjetas:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(15, 133);
            label3.Name = "label3";
            label3.Size = new Size(106, 17);
            label3.TabIndex = 12;
            label3.Text = "Ingresos Varios:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(21, 177);
            label4.Name = "label4";
            label4.Size = new Size(100, 17);
            label4.TabIndex = 13;
            label4.Text = "Egresos varios:";
            // 
            // btnCierreDeCaja
            // 
            btnCierreDeCaja.BackColor = Color.MediumSlateBlue;
            btnCierreDeCaja.BackgroundColor = Color.MediumSlateBlue;
            btnCierreDeCaja.BorderColor = Color.PaleVioletRed;
            btnCierreDeCaja.BorderRadius = 40;
            btnCierreDeCaja.BorderSize = 0;
            btnCierreDeCaja.FlatAppearance.BorderSize = 0;
            btnCierreDeCaja.FlatStyle = FlatStyle.Flat;
            btnCierreDeCaja.ForeColor = Color.White;
            btnCierreDeCaja.IconAlignment = ContentAlignment.MiddleLeft;
            btnCierreDeCaja.IconChar = FontAwesome.Sharp.IconChar.None;
            btnCierreDeCaja.IconColor = Color.White;
            btnCierreDeCaja.IconPadding = 5;
            btnCierreDeCaja.IconSize = 24;
            btnCierreDeCaja.Location = new Point(292, 223);
            btnCierreDeCaja.Name = "btnCierreDeCaja";
            btnCierreDeCaja.Size = new Size(150, 40);
            btnCierreDeCaja.TabIndex = 14;
            btnCierreDeCaja.Text = "Cierre de caja";
            btnCierreDeCaja.TextColor = Color.White;
            btnCierreDeCaja.UseVisualStyleBackColor = false;
            btnCierreDeCaja.Click += btnCierreDeCaja_Click_1;
            // 
            // dataGridViewVentas
            // 
            dataGridViewVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewVentas.Location = new Point(272, 44);
            dataGridViewVentas.Name = "dataGridViewVentas";
            dataGridViewVentas.Size = new Size(240, 150);
            dataGridViewVentas.TabIndex = 15;
            // 
            // panelOpciones
            // 
            panelOpciones.Controls.Add(btnVentas);
            panelOpciones.Controls.Add(dataGridViewMovimientos);
            panelOpciones.Controls.Add(btnMovimientos);
            panelOpciones.Controls.Add(dataGridViewVentas);
            panelOpciones.Location = new Point(468, 15);
            panelOpciones.Name = "panelOpciones";
            panelOpciones.Size = new Size(526, 202);
            panelOpciones.TabIndex = 16;
         //   panelOpciones.Paint += panel1_Paint;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.MediumSlateBlue;
            btnVentas.BackgroundColor = Color.MediumSlateBlue;
            btnVentas.BorderColor = Color.PaleVioletRed;
            btnVentas.BorderRadius = 40;
            btnVentas.BorderSize = 0;
            btnVentas.FlatAppearance.BorderSize = 0;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.ForeColor = Color.White;
            btnVentas.IconAlignment = ContentAlignment.MiddleLeft;
            btnVentas.IconChar = FontAwesome.Sharp.IconChar.None;
            btnVentas.IconColor = Color.White;
            btnVentas.IconPadding = 5;
            btnVentas.IconSize = 24;
            btnVentas.Location = new Point(299, 4);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(150, 40);
            btnVentas.TabIndex = 18;
            btnVentas.Text = "Ventas";
            btnVentas.TextColor = Color.White;
            btnVentas.UseVisualStyleBackColor = false;
          //  btnVentas.Click += btnVentas_Click;
            // 
            // btnMovimientos
            // 
            btnMovimientos.BackColor = Color.MediumSlateBlue;
            btnMovimientos.BackgroundColor = Color.MediumSlateBlue;
            btnMovimientos.BorderColor = Color.PaleVioletRed;
            btnMovimientos.BorderRadius = 40;
            btnMovimientos.BorderSize = 0;
            btnMovimientos.FlatAppearance.BorderSize = 0;
            btnMovimientos.FlatStyle = FlatStyle.Flat;
            btnMovimientos.ForeColor = Color.White;
            btnMovimientos.IconAlignment = ContentAlignment.MiddleLeft;
            btnMovimientos.IconChar = FontAwesome.Sharp.IconChar.None;
            btnMovimientos.IconColor = Color.White;
            btnMovimientos.IconPadding = 5;
            btnMovimientos.IconSize = 24;
            btnMovimientos.Location = new Point(43, 3);
            btnMovimientos.Name = "btnMovimientos";
            btnMovimientos.Size = new Size(150, 40);
            btnMovimientos.TabIndex = 17;
            btnMovimientos.Text = "Movimientos";
            btnMovimientos.TextColor = Color.White;
            btnMovimientos.UseVisualStyleBackColor = false;
          //  btnMovimientos.Click += btnMovimientos_Click;
            // 
            // classBtnPersonalizado1
            // 
            classBtnPersonalizado1.BackColor = Color.MediumSlateBlue;
            classBtnPersonalizado1.BackgroundColor = Color.MediumSlateBlue;
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
            classBtnPersonalizado1.Location = new Point(682, 287);
            classBtnPersonalizado1.Name = "classBtnPersonalizado1";
            classBtnPersonalizado1.Size = new Size(141, 42);
            classBtnPersonalizado1.TabIndex = 17;
            classBtnPersonalizado1.Text = "ver transacciones del dia ";
            classBtnPersonalizado1.TextColor = Color.White;
            classBtnPersonalizado1.UseVisualStyleBackColor = false;
       //     classBtnPersonalizado1.Click += classBtnPersonalizado1_Click;
            // 
            // FormCaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(21, 8, 38);
            ClientSize = new Size(1006, 500);
            Controls.Add(classBtnPersonalizado1);
            Controls.Add(panelOpciones);
            Controls.Add(btnCierreDeCaja);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTarjeta);
            Controls.Add(txtEfectivo);
            Controls.Add(txtTotalEgresos);
            Controls.Add(txtTotalIngresos);
            Controls.Add(txtMonto);
            Controls.Add(btnEgreso);
            Controls.Add(btnIngreso);
            Controls.Add(btnCargarTransacciones);
            Controls.Add(dataGridViewTransacciones);
            Name = "FormCaja";
            Text = "FormCaja";
            Load += FormCaja_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewTransacciones).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMovimientos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewVentas).EndInit();
            panelOpciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridViewTransacciones;
        private controlesPersonalizados.ClassBtnPersonalizado btnCargarTransacciones;
        private controlesPersonalizados.ClassBtnPersonalizado btnIngreso;
        private controlesPersonalizados.ClassBtnPersonalizado btnEgreso;
        private controlesPersonalizados.Texboxs txtMonto;
        private DataGridView dataGridViewMovimientos;
        private controlesPersonalizados.Texboxs txtTotalIngresos;
        private controlesPersonalizados.Texboxs txtTotalEgresos;
        private controlesPersonalizados.Texboxs txtEfectivo;
        private controlesPersonalizados.Texboxs txtTarjeta;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private controlesPersonalizados.ClassBtnPersonalizado btnCierreDeCaja;
        private DataGridView dataGridViewVentas;
        private Panel panelOpciones;
        private controlesPersonalizados.ClassBtnPersonalizado btnMovimientos;
        private controlesPersonalizados.ClassBtnPersonalizado btnVentas;
        private controlesPersonalizados.ClassBtnPersonalizado classBtnPersonalizado1;
    }
}