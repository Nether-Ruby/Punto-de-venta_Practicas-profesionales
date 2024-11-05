using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    public partial class FormProveedores : Form
    {
        public FormProveedores()
        {
            InitializeComponent();
        }

        private void FormProveedores_Resize(object sender, EventArgs e)
        {

                int baseWidth = 800; // Your base form width
                int baseHeight = 600; // Your base form height

                float widthRatio = (float)this.Width / baseWidth;
                float heightRatio = (float)this.Height / baseHeight;

                foreach (Control control in this.Controls)
                {
                    control.Width = (int)(control.Width * widthRatio);
                    control.Height = (int)(control.Height * heightRatio);
                    control.Left = (int)(control.Left * widthRatio);
                    control.Top = (int)(control.Top * heightRatio);
                }

        }
    }
}
