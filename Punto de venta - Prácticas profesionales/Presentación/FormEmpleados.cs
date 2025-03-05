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
    public partial class FormEmpleados : Form
    {
        vendedoresLogica cn = new vendedoresLogica();

        public FormEmpleados()
        {
            InitializeComponent();
            dataGridView1.DataSource = cn.consultaVendedores();
            dataGridView1.Columns["CUIL"].ReadOnly = true; // El CUIL no debe modificarse
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        private void FormEmpleados_Resize(object sender, EventArgs e)
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

        private void classBtnPersonalizado2_Click(object sender, EventArgs e)
        {
            // Capturar los datos del formulario
            string cuil = texboxs1.Texts;
            string nombre = texboxs2.Texts;
            string apellido = texboxs3.Texts;
            string telefono = texboxs4.Texts;
            string domicilio = texboxs5.Texts;

            // Intentar registrar el vendedor
            string mensaje;
            bool exito = cn.registrarVendedor(cuil, nombre, apellido, telefono, domicilio, out mensaje);

            // Mostrar el resultado al usuario
            MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);


            // Limpiar los campos si el registro fue exitoso
            if (exito)
            {
                texboxs1.Clear();
                texboxs2.Clear();
                texboxs3.Clear();
                texboxs4.Clear();
                texboxs5.Clear();

            }
            dataGridView1.DataSource = cn.consultaVendedores();
        }

        private void classBtnPersonalizado3_Click(object sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show("¿Estás seguro de que deseas eliminar este vendedor?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion == DialogResult.Yes)
            {
                // Capturar el CUIL del formulario
                string cuil = texboxs1.Texts;

                // Intentar eliminar el vendedor
                string mensaje;
                bool exito = cn.eliminarVendedor(cuil, out mensaje);

                // Mostrar el resultado al usuario
                MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                // Limpiar los campos si la eliminación fue exitosa
                if (exito)
                {
                    texboxs1.Clear();
                    // Actualizar la lista de vendedores o realizar otras acciones según sea necesario
                }
                dataGridView1.DataSource = cn.consultaVendedores();
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Asegurarse de que no sea el encabezado
            {
                // Obtener los datos editados
                DataGridViewRow fila = dataGridView1.Rows[e.RowIndex];
                string cuil = fila.Cells["CUIL"].Value.ToString();
                string nombre = fila.Cells["nombres"].Value.ToString();
                string apellido = fila.Cells["apellido"].Value.ToString();
                string telefono = fila.Cells["telefono"].Value.ToString();
                string domicilio = fila.Cells["domicilio"].Value.ToString();

                // Llamar a la lógica para modificar
                string mensaje;
                bool exito = cn.ModificarVendedorDesdeGrid(cuil, nombre, apellido, telefono, domicilio, out mensaje);

                // Mostrar un mensaje al usuario
                if (!exito)
                {
                    MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataGridView1.DataSource = cn.consultaVendedores(); // Recargar los datos para revertir cambios inválidos
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
