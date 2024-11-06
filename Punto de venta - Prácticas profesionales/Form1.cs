using FontAwesome.Sharp;
namespace Punto_de_venta___Prácticas_profesionales
{
    public partial class Form1 : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //saca los bordes del formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private struct RGBcolors
        {
            //opcional
            public static Color color1 = Color.Orange;
            //public static Color color2 = Color.Orange;
            //public static Color color3 = Color.FromArgb(15, 8, 196);
            //public static Color color4 = Color.FromArgb(172, 126, 241);
            //public static Color color5 = Color.FromArgb(172, 126, 241);
            //public static Color color6 = Color.FromArgb(172, 126, 241);

        }
        //metodo
        private void ActivateButton(object senderBtn, Color color)
        {
            DisableButton();
            if (senderBtn != null)
            {
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                // currentBtn.IconColor = Color.Orange; //esto es para q al dar click cambe el color del icono pero no mg

                iconoActual.IconChar = currentBtn.IconChar;
                iconoActual.IconColor = color;

            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(21, 9, 49);
                currentBtn.ForeColor = Color.White;

            }
        }

        private void openChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(childForm);
            panelEscritorio.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // esta condicion la podes usar en el caso que quieras que reportes solo se muestre en caja 
            //(o en cualquier formuario q necesites git add "Punto de venta - Prácticas profesionales/controlesPersonalizados/Botones.Designer.cs")
            //if (childForm is Presentación.FormCaja)
            //{
            //    menuStrip2.Visible = true;  // Mostrar el MenuStrip si es FormCaja
            //}
            //else
            //{
            //    menuStrip2.Visible = false; // Ocultar el MenuStrip para otros formularios
            //}

            // labelEtiqueta.Text = childForm.Text;
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {

            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormArticulos());
            // openChildForm(new FormArticulos());
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            currentChildForm.Close();
            Reset();

        }
        private void Reset()
        {

            DisableButton();
            leftBorderBtn.Visible = false;

            iconoActual.IconChar = IconChar.HomeLg;
            iconoActual.IconColor = Color.FromArgb(172, 126, 241);
            labelEtiqueta.Text = "Home";


        }



        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormVentas());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormCaja());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormProveedores());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormClientes());
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormCompras());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormEmpleados());
        }

        private void classBtnPersonalizado1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new controlesPersonalizados.Botones());
        }

        private void panelEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            WindowState=FormWindowState.Minimized;
        }
    }
}
