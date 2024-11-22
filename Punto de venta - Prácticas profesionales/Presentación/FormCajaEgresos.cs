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
    public partial class FormCajaEgresos : Form
    {
        public double MontoEgreso { get; private set; }
        public FormCajaEgresos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Intentamos convertir el valor ingresado a decimal
            if (double.TryParse(textBox1.Text, out double monto))
            {
                MontoEgreso = monto; // Guardamos el monto ingresado
                this.DialogResult = DialogResult.OK; // Establecemos el resultado como OK
                this.Close(); // Cerramos el formulario
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un monto válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Si el usuario hace clic en Volver, simplemente cerramos el formulario sin hacer nada
            this.DialogResult = DialogResult.Cancel; // Establecemos el resultado como Cancel
            this.Close(); // Cerramos el formulario
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, tecla de retroceso y teclas de control (e.g., Ctrl+C)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Rechazar el carácter
            }
        }
    }
}
