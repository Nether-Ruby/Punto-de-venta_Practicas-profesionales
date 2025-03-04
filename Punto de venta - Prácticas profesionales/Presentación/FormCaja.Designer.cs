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
            dataGridView1 = new DataGridView();
            abrirBtn = new controlesPersonalizados.ClassBtnPersonalizado();
            cerrarBtn = new controlesPersonalizados.ClassBtnPersonalizado();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            totallbl = new Label();
            label5 = new Label();
            efectivolbl = new Label();
            label7 = new Label();
            tarjetalbl = new Label();
            ingresostxt = new TextBox();
            egresostxt = new TextBox();
            ingresoBtn = new controlesPersonalizados.ClassBtnPersonalizado();
            egresosBtn = new controlesPersonalizados.ClassBtnPersonalizado();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(24, 43);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(558, 302);
            dataGridView1.TabIndex = 0;
            // 
            // abrirBtn
            // 
            abrirBtn.BackColor = Color.MediumSlateBlue;
            abrirBtn.BackgroundColor = Color.MediumSlateBlue;
            abrirBtn.BorderColor = Color.PaleVioletRed;
            abrirBtn.BorderRadius = 40;
            abrirBtn.BorderSize = 0;
            abrirBtn.FlatAppearance.BorderSize = 0;
            abrirBtn.FlatStyle = FlatStyle.Flat;
            abrirBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            abrirBtn.ForeColor = Color.White;
            abrirBtn.IconAlignment = ContentAlignment.MiddleLeft;
            abrirBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            abrirBtn.IconColor = Color.White;
            abrirBtn.IconPadding = 5;
            abrirBtn.IconSize = 24;
            abrirBtn.Location = new Point(24, 375);
            abrirBtn.Name = "abrirBtn";
            abrirBtn.Size = new Size(150, 40);
            abrirBtn.TabIndex = 1;
            abrirBtn.Text = "Abrir Caja";
            abrirBtn.TextColor = Color.White;
            abrirBtn.UseVisualStyleBackColor = false;
            abrirBtn.Click += abrirBtn_Click;
            // 
            // cerrarBtn
            // 
            cerrarBtn.BackColor = Color.MediumSlateBlue;
            cerrarBtn.BackgroundColor = Color.MediumSlateBlue;
            cerrarBtn.BorderColor = Color.PaleVioletRed;
            cerrarBtn.BorderRadius = 40;
            cerrarBtn.BorderSize = 0;
            cerrarBtn.FlatAppearance.BorderSize = 0;
            cerrarBtn.FlatStyle = FlatStyle.Flat;
            cerrarBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cerrarBtn.ForeColor = Color.White;
            cerrarBtn.IconAlignment = ContentAlignment.MiddleLeft;
            cerrarBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            cerrarBtn.IconColor = Color.White;
            cerrarBtn.IconPadding = 5;
            cerrarBtn.IconSize = 24;
            cerrarBtn.Location = new Point(227, 375);
            cerrarBtn.Name = "cerrarBtn";
            cerrarBtn.Size = new Size(150, 40);
            cerrarBtn.TabIndex = 2;
            cerrarBtn.Text = "Cerrar Caja";
            cerrarBtn.TextColor = Color.White;
            cerrarBtn.UseVisualStyleBackColor = false;
            cerrarBtn.Click += cerrarBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 17);
            label1.Name = "label1";
            label1.Size = new Size(57, 15);
            label1.TabIndex = 5;
            label1.Text = "Ingresos:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(190, 17);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 6;
            label2.Text = "Egresos:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 171);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 7;
            label3.Text = "Total:";
            // 
            // totallbl
            // 
            totallbl.AutoSize = true;
            totallbl.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            totallbl.Location = new Point(6, 197);
            totallbl.Name = "totallbl";
            totallbl.Size = new Size(71, 40);
            totallbl.TabIndex = 8;
            totallbl.Text = "0.00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 93);
            label5.Name = "label5";
            label5.Size = new Size(52, 15);
            label5.TabIndex = 9;
            label5.Text = "Efectivo:";
            // 
            // efectivolbl
            // 
            efectivolbl.AutoSize = true;
            efectivolbl.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            efectivolbl.Location = new Point(6, 117);
            efectivolbl.Name = "efectivolbl";
            efectivolbl.Size = new Size(71, 40);
            efectivolbl.TabIndex = 10;
            efectivolbl.Text = "0.00";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 28);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 11;
            label7.Text = "Tarjeta:";
            // 
            // tarjetalbl
            // 
            tarjetalbl.AutoSize = true;
            tarjetalbl.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tarjetalbl.Location = new Point(6, 53);
            tarjetalbl.Name = "tarjetalbl";
            tarjetalbl.Size = new Size(71, 40);
            tarjetalbl.TabIndex = 12;
            tarjetalbl.Text = "0.00";
            // 
            // ingresostxt
            // 
            ingresostxt.Location = new Point(84, 14);
            ingresostxt.Name = "ingresostxt";
            ingresostxt.Size = new Size(100, 23);
            ingresostxt.TabIndex = 13;
            // 
            // egresostxt
            // 
            egresostxt.Location = new Point(246, 14);
            egresostxt.Name = "egresostxt";
            egresostxt.Size = new Size(100, 23);
            egresostxt.TabIndex = 14;
            // 
            // ingresoBtn
            // 
            ingresoBtn.BackColor = Color.MediumSlateBlue;
            ingresoBtn.BackgroundColor = Color.MediumSlateBlue;
            ingresoBtn.BorderColor = Color.PaleVioletRed;
            ingresoBtn.BorderRadius = 40;
            ingresoBtn.BorderSize = 0;
            ingresoBtn.FlatAppearance.BorderSize = 0;
            ingresoBtn.FlatStyle = FlatStyle.Flat;
            ingresoBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ingresoBtn.ForeColor = Color.White;
            ingresoBtn.IconAlignment = ContentAlignment.MiddleLeft;
            ingresoBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            ingresoBtn.IconColor = Color.White;
            ingresoBtn.IconPadding = 5;
            ingresoBtn.IconSize = 24;
            ingresoBtn.Location = new Point(432, 375);
            ingresoBtn.Name = "ingresoBtn";
            ingresoBtn.Size = new Size(150, 40);
            ingresoBtn.TabIndex = 15;
            ingresoBtn.Text = "Ingresos";
            ingresoBtn.TextColor = Color.White;
            ingresoBtn.UseVisualStyleBackColor = false;
            ingresoBtn.Click += ingresoBtn_Click;
            // 
            // egresosBtn
            // 
            egresosBtn.BackColor = Color.MediumSlateBlue;
            egresosBtn.BackgroundColor = Color.MediumSlateBlue;
            egresosBtn.BorderColor = Color.PaleVioletRed;
            egresosBtn.BorderRadius = 40;
            egresosBtn.BorderSize = 0;
            egresosBtn.FlatAppearance.BorderSize = 0;
            egresosBtn.FlatStyle = FlatStyle.Flat;
            egresosBtn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            egresosBtn.ForeColor = Color.White;
            egresosBtn.IconAlignment = ContentAlignment.MiddleLeft;
            egresosBtn.IconChar = FontAwesome.Sharp.IconChar.None;
            egresosBtn.IconColor = Color.White;
            egresosBtn.IconPadding = 5;
            egresosBtn.IconSize = 24;
            egresosBtn.Location = new Point(638, 375);
            egresosBtn.Name = "egresosBtn";
            egresosBtn.Size = new Size(150, 40);
            egresosBtn.TabIndex = 18;
            egresosBtn.Text = "Egresos";
            egresosBtn.TextColor = Color.White;
            egresosBtn.UseVisualStyleBackColor = false;
            egresosBtn.Click += egresosBtn_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(efectivolbl);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(totallbl);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(tarjetalbl);
            groupBox1.Location = new Point(588, 43);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 302);
            groupBox1.TabIndex = 20;
            groupBox1.TabStop = false;
            // 
            // FormCaja
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(egresosBtn);
            Controls.Add(ingresoBtn);
            Controls.Add(egresostxt);
            Controls.Add(ingresostxt);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cerrarBtn);
            Controls.Add(abrirBtn);
            Controls.Add(dataGridView1);
            Name = "FormCaja";
            Text = "FormCaja";
            Load += FormCaja_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private controlesPersonalizados.ClassBtnPersonalizado abrirBtn;
        private controlesPersonalizados.ClassBtnPersonalizado cerrarBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label totallbl;
        private Label label5;
        private Label efectivolbl;
        private Label label7;
        private Label tarjetalbl;
        private TextBox ingresostxt;
        private TextBox egresostxt;
        private controlesPersonalizados.ClassBtnPersonalizado ingresoBtn;
        private controlesPersonalizados.ClassBtnPersonalizado egresosBtn;
        private GroupBox groupBox1;
    }
}