using Punto_de_venta___Prácticas_profesionales.Lógica;
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
    public partial class FormCaja : Form
    {
        private Form1 formpadre;

        public FormCaja(Form1 padre)
        {

            InitializeComponent();
            formpadre = padre;
            InicializarEventos();
        }
        public void InicializarEventos()
        {
            if (formpadre.IsOpen == true)
            {
                abrirBtn.Enabled = false;
                cerrarBtn.Enabled = true;
                dataGridView1.DataSource = cajaLogica.ventasHoy();

            }
            else
            {
                cerrarBtn.Enabled = false;
                abrirBtn.Enabled=true;
            }

        }
        private void abrirBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = cajaLogica.ventasHoy();
            formpadre.IsOpen = true;
            InicializarEventos();
        }

        private void cerrarBtn_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = null;
            formpadre.IsOpen = false;
            InicializarEventos();
        }
    }
}
