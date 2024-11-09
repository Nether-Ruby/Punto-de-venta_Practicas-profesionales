using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using Punto_de_venta___Prácticas_profesionales.Datos;
////using CrudArticulosApp;

using Punto_de_venta___Prácticas_profesionales.Logica;

namespace Punto_de_venta___Prácticas_profesionales
{
    public partial class FormArticulos : Form
    {
        private ArticulosLogica articuloService;

        public FormArticulos()
        {
            InitializeComponent();
            ArticulosDatos.InitializeDatabase(); 
            articuloService = new ArticulosLogica();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtPrecio.Texts, out double precio) &&
                int.TryParse(txtStock.Texts, out int stock))
            {
                if (articuloService.AgregarArticulo(txtCodigo.Texts, txtNombre.Texts, txtMarca.Texts, txtRubro.Texts, precio, stock))
                {
                    MessageBox.Show("Artículo procesado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarArticulos();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Datos inválidos en precio o stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (articuloService.DeshabilitarArticulo(txtCodigo.Texts))
            {
                MessageBox.Show("Artículo deshabilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarArticulos();
                LimpiarCampos();
            }
            else
            {
                MessageBox.Show("No se encontró el artículo para deshabilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarArticulos()
        {
            dataGridView1.DataSource = articuloService.CargarArticulos(true);
            dataGridViewInactivos.DataSource = articuloService.CargarArticulos(false);
        }

        private void LimpiarCampos()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            txtRubro.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtMarca.Clear();
            txtRubro.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }


        //private void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    // Obtener el texto de búsqueda del usuario
        //    string criterioBusqueda = txtBuscar.Texts.Trim();

        //    if (string.IsNullOrEmpty(criterioBusqueda))
        //    {
        //        MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    // Llamar al método de búsqueda en ArticuloService
        //    DataTable resultados = articuloService.BuscarArticulos(criterioBusqueda);

        //    // Mostrar los resultados en el DataGridView
        //    if (resultados.Rows.Count > 0)
        //    {
        //        dataGridView1.DataSource = resultados;
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se encontraron artículos con ese criterio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void btnBuscar_Click(object sender, EventArgs e)
        //{
        //    // Obtener el texto de búsqueda y el criterio seleccionado
        //    string criterioBusqueda = txtBuscar.Texts.Trim();
        //    string campoSeleccionado = cmbCriterio.SelectedItem?.ToString();

        //    if (string.IsNullOrEmpty(criterioBusqueda) || string.IsNullOrEmpty(campoSeleccionado))
        //    {
        //        MessageBox.Show("Por favor, ingrese un criterio de búsqueda y seleccione un campo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    // Llamar al método de búsqueda en ArticuloService con el campo seleccionado
        //    DataTable resultados = articuloService.BuscarArticulosPorCampo(criterioBusqueda, campoSeleccionado);

        //    // Mostrar los resultados en el DataGridView
        //    if (resultados.Rows.Count > 0)
        //    {
        //        dataGridView1.DataSource = resultados;
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se encontraron artículos con ese criterio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
        //

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            string criterioBusqueda = txtBuscar.Texts.Trim();

            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Verificar si se ha seleccionado un campo en el ComboBox
            string campoSeleccionado = cmbCriterio.SelectedItem?.ToString();

            DataTable resultados;

            if (string.IsNullOrEmpty(campoSeleccionado))
            {
                // Si no se seleccionó un campo, buscar en todos los campos (Código, Nombre, Marca)
                resultados = articuloService.BuscarArticulosEnTodosLosCampos(criterioBusqueda);
            }
            else
            {
                // Si se seleccionó un campo, buscar en el campo específico
                resultados = articuloService.BuscarArticulosPorCampo(criterioBusqueda, campoSeleccionado);
            }

            // Mostrar los resultados en el DataGridView
            if (resultados.Rows.Count > 0)
            {
                dataGridView1.DataSource = resultados;
            }
            else
            {
                MessageBox.Show("No se encontraron artículos con ese criterio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnArticulosActivos_Click(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = articuloService.CargarArticulos(true);

         
            btnDeshabilitar.Visible = true;
            btnHabilitar.Visible = false;
        }

        private void btnArticulosDeshabilitados_Click(object sender, EventArgs e)
        {
          
            dataGridView1.DataSource = articuloService.CargarArticulos(false);

            btnDeshabilitar.Visible = false;
            btnHabilitar.Visible = true;
        }

        private void btnHabilitar_Click(object sender, EventArgs e)
        {
            // Obtener el código del artículo que se quiere habilitar
            string codigo = txtCodigo.Texts.Trim();

            if (string.IsNullOrEmpty(codigo))
            {
                MessageBox.Show("Por favor, ingrese el código del artículo a habilitar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

           
            if (articuloService.HabilitarArticulo(codigo))
            {
                MessageBox.Show("Artículo habilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Recargar la grilla con los artículos deshabilitados
                dataGridView1.DataSource = articuloService.CargarArticulos(false);
                LimpiarCampos(); 
            }
            else
            {
                MessageBox.Show("No se encontró el artículo para habilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            // Obtener la fila editada
            var fila = dataGridView1.Rows[e.RowIndex];
            string codigo = fila.Cells["Codigo"].Value.ToString();
            string nombre = fila.Cells["Nombre"].Value.ToString();
            string marca = fila.Cells["Marca"].Value.ToString();
            string rubro = fila.Cells["Rubro"].Value.ToString();
            double precio;
            int stock;

            // Validar y convertir los datos de Precio y Stock
            if (!double.TryParse(fila.Cells["Precio"].Value.ToString(), out precio) ||
                !int.TryParse(fila.Cells["Stock"].Value.ToString(), out stock))
            {
                MessageBox.Show("Error en los datos de Precio o Stock. Verifica la información ingresada.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           
            if (articuloService.ActualizarArticulo(codigo, nombre, marca, rubro, precio, stock))
            {
                MessageBox.Show("Artículo actualizado correctamente desde la grilla.",
                                "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar el artículo.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar__TextChanged(object sender, EventArgs e)
        {

        }

        private void classBtnPersonalizado9_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (double.TryParse(txtPrecio.Texts, out double precio) &&
                int.TryParse(txtStock.Texts, out int stock))
            {
                if (articuloService.AgregarArticulo(txtCodigo.Texts, txtNombre.Texts, txtMarca.Texts, txtRubro.Texts, precio, stock))
                {
                    MessageBox.Show("Artículo procesado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarArticulos();
                    LimpiarCampos();
                }
            }
            else
            {
                MessageBox.Show("Datos inválidos en precio o stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

    

