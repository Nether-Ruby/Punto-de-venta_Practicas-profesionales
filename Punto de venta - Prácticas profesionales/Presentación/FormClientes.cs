using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta___Prácticas_profesionales.Lógica;
namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    public partial class FormClientes : Form
    {
        private readonly clientesLogica _clientesLogica = new clientesLogica();

        public FormClientes()
        {
            InitializeComponent();
            _clientesLogica = new clientesLogica();
            panel1.Visible = false;
            CargarPersonasEnGrilla();
            //dgvClientes.KeyDown += KeyEventHandler(dgvClientes_KeyDown);
            //dgvClientes.CellEndEdit += dgvClientes_CellEndEdit;
            //dgvClientes.AllowUserToAddRows = false;
            //dgvClientes.KeyDown += dgvClientes_KeyDown;
        }
         


        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void btNuevoCliente_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void btGuardar_Click_1(object sender, EventArgs e)
        //{
        //    panel1.Visible = false;

        //    // string cuilStr = txtCuil.Text;
        //    string nombre = txtNo.Text;
        //    // string apellido = txtApellido.Text;
        //    //string telefonoStr = txtTelefono.Text;
        //    //string domicilio = txtDomicilio.Text;
        //    // string email = txtEmail.Text;
        //    //int cuil = Convert.ToInt32(txtC.Text);
        //    // long telefono =Convert.ToInt64(txtTelefono.Text);

        //    //_clientesLogica.GuardarPersona(cuil, nombre);
        //    //MessageBox.Show("Cliente registrado correctamente ");

        //    //string mensajeError = _clientesLogica.ValidarDatosPersona(cuilStr,nombre,apellido,telefonoStr,domicilio,email,out long cuil, out long telefono);

        //    //if (!string.IsNullOrEmpty(mensajeError))
        //    //{
        //    //    MessageBox.Show(mensajeError);
        //    //}
        //    //else
        //    //{
        //    //    _clientesLogica.GuardarPersona(cuil,nombre,apellido,telefono,domicilio,email);
        //    //    MessageBox.Show("Cliente registrado correctamente ");

        //    //}
        //}

        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarPersonasEnGrilla();
        }



        private void btGuardar_Click(object sender, EventArgs e)
        {
           
            string cuilStr = txtCuil.Text;
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string telefonoStr = txtTelefono.Text;
            string domicilio = txtDomicilio.Text;
            string email = txtEmail.Text;
          

            string mensajeError = _clientesLogica.ValidarDatosPersona(cuilStr, nombre, apellido, telefonoStr, domicilio, email, out long cuil, out long telefono);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError);
                CargarPersonasEnGrilla();
                panel1.Visible = false;     
            }
            else
            {
                _clientesLogica.GuardarPersona(cuil, nombre, apellido, telefono, domicilio, email);
                MessageBox.Show("Cliente registrado correctamente ");
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void CargarPersonasEnGrilla()
        {
            try
            {
                var tablaPersonas = _clientesLogica.ObtenerPersonas();
                dgvClientes.DataSource = tablaPersonas;
                dgvClientes.DataSource = _clientesLogica.ObtenerPersonas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dvgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        {
            dgvClientes.ReadOnly = false;
        }
        private void dvgClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string cuilStr = dgvClientes.Rows[e.RowIndex].Cells["CUIL"].Value.ToString();
                string nombre = dgvClientes.Rows[e.RowIndex].Cells["nombres"].Value.ToString();
                string apellido = dgvClientes.Rows[e.RowIndex].Cells["apellido"].Value.ToString();
                string telefonoStr = dgvClientes.Rows[e.RowIndex].Cells["telefono"].Value.ToString();
                string domicilio = dgvClientes.Rows[e.RowIndex].Cells["domicilio"].Value.ToString();
                string email = dgvClientes.Rows[e.RowIndex].Cells["email"].Value.ToString();

                string mensajeError = _clientesLogica.ValidarYActualizarPersona(cuilStr, nombre, apellido, telefonoStr, domicilio, email, out long cuil, out long telefono);

                if (!string.IsNullOrEmpty(mensajeError))
                {
                    MessageBox.Show(mensajeError);
                    dgvClientes.CancelEdit();
                }
                else
                {
                    MessageBox.Show("Datos actualizados correctamente");
                    CargarPersonasEnGrilla();
                }
            }
        }


        private void dvgClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var cell = dgvClientes.CurrentCell;
                if (cell != null)
                {
                    dvgClientes_CellEndEdit(this, new DataGridViewCellEventArgs(cell.ColumnIndex, cell.RowIndex));
                    e.Handled = true;
                }
            }
        }


    }
}
