//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Data.SQLite;
//using System.IO;
//using Punto_de_venta___Prácticas_profesionales.Datos;
//////using CrudArticulosApp;

//using Punto_de_venta___Prácticas_profesionales.Logica;

//namespace Punto_de_venta___Prácticas_profesionales
//{
//    public partial class FormArticulos : Form
//    {
//        private ArticulosLogica articuloService; 

//        public FormArticulos()
//        {
//            InitializeComponent();
//            ArticulosDatos.InitializeDatabase();
//            articuloService = new ArticulosLogica();

//            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
//        }

//        //private void button1_Click(object sender, EventArgs e)
//        //{
//        //    if (double.TryParse(txtPrecio.Texts, out double precio) &&
//        //        int.TryParse(txtStock.Texts, out int stock))
//        //    {
//        //        if (articuloService.AgregarArticulo(txtCodigo.Texts, txtNombre.Texts, txtMarca.Texts, txtRubro.Texts, precio, stock))
//        //        {
//        //            MessageBox.Show("Artículo procesado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        //            CargarArticulos();
//        //            LimpiarCampos();
//        //        }
//        //    }
//        //    else
//        //    {
//        //        MessageBox.Show("Datos inválidos en precio o stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //    }
//        //}



//        //private void btnEliminar_Click(object sender, EventArgs e)
//        //{
//        //    if (articuloService.DeshabilitarArticulo(txtCodigo.Texts))
//        //    {
//        //        MessageBox.Show("Artículo deshabilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        //        CargarArticulos();
//        //        LimpiarCampos();
//        //    }
//        //    else
//        //    {
//        //        MessageBox.Show("No se encontró el artículo para deshabilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //    }
//        //}


//        private void CargarArticulos()
//        {

//            dataGridView1.DataSource = articuloService.CargarArticulos(true);

//            dataGridViewInactivos.DataSource = articuloService.CargarArticulos(false);
//        }


//        private void LimpiarCampos()
//        {
//            txtCodigo.Clear();
//            txtNombre.Clear();
//            txtMarca.Clear();
//            txtRubro.Clear();
//            txtPrecio.Clear();
//            txtStock.Clear();
//        }

//        private void btnLimpiar_Click(object sender, EventArgs e)
//        {
//            txtCodigo.Clear();
//            txtNombre.Clear();
//            txtMarca.Clear();
//            txtRubro.Clear();
//            txtPrecio.Clear();
//            txtStock.Clear();
//        }




//        private void btnBuscar_Click(object sender, EventArgs e)
//        {

//            string criterioBusqueda = txtBuscar.Texts.Trim();

//            if (string.IsNullOrEmpty(criterioBusqueda))
//            {
//                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            // Verificar si se ha seleccionado un campo en el ComboBox
//            string campoSeleccionado = cmbCriterio.SelectedItem?.ToString();

//            DataTable resultados;

//            if (string.IsNullOrEmpty(campoSeleccionado))
//            {
//                // Si no se seleccionó un campo, buscar en todos los campos (Código, Nombre, Marca)
//                resultados = articuloService.BuscarArticulosEnTodosLosCampos(criterioBusqueda);
//            }
//            else
//            {
//                // Si se seleccionó un campo, buscar en el campo específico
//                resultados = articuloService.BuscarArticulosPorCampo(criterioBusqueda, campoSeleccionado);
//            }

//            // Mostrar los resultados en el DataGridView
//            if (resultados.Rows.Count > 0)
//            {
//                dataGridView1.DataSource = resultados;
//            }
//            else
//            {
//                MessageBox.Show("No se encontraron artículos con ese criterio.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void btnArticulosActivos_Click(object sender, EventArgs e)
//        {

//            dataGridView1.DataSource = articuloService.CargarArticulos(true);


//            btnDeshabilitar.Visible = true;
//            btnHabilitar.Visible = false;
//        }

//        private void btnArticulosDeshabilitados_Click(object sender, EventArgs e)
//        {

//            dataGridView1.DataSource = articuloService.CargarArticulos(false);

//            btnDeshabilitar.Visible = false;
//            btnHabilitar.Visible = true;
//        }


//        private void label4_Click(object sender, EventArgs e)
//        {

//        }

//        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
//        {

//        }
//        //no borres por las dudas
//        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
//        //{

//        //    // Obtener la fila editada
//        //    var fila = dataGridView1.Rows[e.RowIndex];
//        //    string codigo = fila.Cells["Codigo"].Value.ToString();
//        //    string nombre = fila.Cells["Nombre"].Value.ToString();
//        //    string marca = fila.Cells["Marca"].Value.ToString();
//        //    string rubro = fila.Cells["Rubro"].Value.ToString();
//        //    double precio;
//        //    int stock;

//        //    // Validar y convertir los datos de Precio y Stock
//        //    if (!double.TryParse(fila.Cells["Precio"].Value.ToString(), out precio) ||
//        //        !int.TryParse(fila.Cells["Stock"].Value.ToString(), out stock))
//        //    {
//        //        MessageBox.Show("Error en los datos de Precio o Stock. Verifica la información ingresada.",
//        //                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //        return;
//        //    }


//        //    if (articuloService.ActualizarArticulo(codigo, nombre, marca, rubro, precio, stock))
//        //    {
//        //        MessageBox.Show("Artículo actualizado correctamente desde la grilla.",
//        //                        "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        //    }
//        //    else
//        //    {
//        //        MessageBox.Show("Error al actualizar el artículo.",
//        //                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //    }
//        //}
//        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
//        //{
//        //    // Obtener la fila editada
//        //    var fila = dataGridView1.Rows[e.RowIndex];

//        //    // Asegurarse de que todos los campos necesarios no sean nulos ni vacíos
//        //    string codigo = fila.Cells["Codigo"].Value?.ToString()?.Trim();
//        //    string nombre = fila.Cells["Nombre"].Value?.ToString()?.Trim();
//        //    string marca = fila.Cells["Marca"].Value?.ToString()?.Trim();
//        //    string rubro = fila.Cells["Rubro"].Value?.ToString()?.Trim();

//        //    // Validar que los campos no sean nulos ni vacíos
//        //    if (string.IsNullOrEmpty(codigo) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(rubro))
//        //    {
//        //        MessageBox.Show("Todos los campos deben estar llenos y no nulos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//        //        return;
//        //    }

//        //    // Validar y convertir los datos de Precio y Stock
//        //    if (!double.TryParse(fila.Cells["Precio"].Value?.ToString(), out double precio) ||
//        //        !int.TryParse(fila.Cells["Stock"].Value?.ToString(), out int stock))
//        //    {
//        //        MessageBox.Show("Error en los datos de Precio o Stock. Verifica la información ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //        return;
//        //    }

//        //    // Intentar actualizar el artículo usando la lógica de negocio
//        //    if (articuloService.ActualizarArticulo(codigo, nombre, marca, rubro, precio, stock))
//        //    {
//        //        MessageBox.Show("Artículo actualizado correctamente desde la grilla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        //    }
//        //    else
//        //    {
//        //        MessageBox.Show("Error al actualizar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //    }
//        //}



//        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
//        {
//            // Obtener la fila editada
//            var fila = dataGridView1.Rows[e.RowIndex];

//            // Obtener los valores actuales de las celdas
//            string codigo = fila.Cells["Codigo"].Value?.ToString()?.Trim();
//            string nombre = fila.Cells["Nombre"].Value?.ToString()?.Trim();
//            string marca = fila.Cells["Marca"].Value?.ToString()?.Trim();
//            string rubro = fila.Cells["Rubro"].Value?.ToString()?.Trim();
//            double.TryParse(fila.Cells["Precio"].Value?.ToString(), out double precio);
//            int.TryParse(fila.Cells["Stock"].Value?.ToString(), out int stock);

//            // Verificar si la fila tiene valores originales almacenados
//            if (fila.Tag is DataRow filaOriginal)
//            {
//                // Comparar los valores actuales con los originales
//                bool seModifico =
//                    codigo != filaOriginal["Codigo"].ToString().Trim() ||
//                    nombre != filaOriginal["Nombre"].ToString().Trim() ||
//                    marca != filaOriginal["Marca"].ToString().Trim() ||
//                    rubro != filaOriginal["Rubro"].ToString().Trim() ||
//                    precio != Convert.ToDouble(filaOriginal["Precio"]) ||
//                    stock != Convert.ToInt32(filaOriginal["Stock"]);

//                // Si no se modificó nada, salir sin mostrar mensaje
//                if (!seModifico)
//                {
//                    return;
//                }
//            }

//            // Intentar actualizar el artículo usando la lógica de negocio
//            if (articuloService.ActualizarArticulo(codigo, nombre, marca, rubro, precio, stock))
//            {
//                MessageBox.Show("Artículo actualizado correctamente desde la grilla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("Error al actualizar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void txtBuscar__TextChanged(object sender, EventArgs e)
//        {

//        }

//        private void classBtnPersonalizado9_Click(object sender, EventArgs e)
//        {

//        }

//        private void btnAgregar_Click(object sender, EventArgs e)
//        {
//            if (double.TryParse(txtPrecio.Texts, out double precio) &&
//                int.TryParse(txtStock.Texts, out int stock))
//            {
//                if (articuloService.AgregarArticulo(txtCodigo.Texts, txtNombre.Texts, txtMarca.Texts, txtRubro.Texts, precio, stock))
//                {
//                    MessageBox.Show("Artículo procesado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    CargarArticulos();
//                    LimpiarCampos();
//                }
//            }
//            else
//            {
//                MessageBox.Show("Datos inválidos en precio o stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        //private void btnHabilitar_Click_1(object sender, EventArgs e)
//        //{

//        //        // Obtener el código del artículo que se quiere habilitar
//        //        string codigo = txtCodigo.Texts.Trim();

//        //        if (string.IsNullOrEmpty(codigo))
//        //        {
//        //            MessageBox.Show("Por favor, ingrese el código del artículo a habilitar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        //            return;
//        //        }

//        //        // Intentar habilitar el artículo usando la lógica de negocio
//        //        if (articuloService.HabilitarArticulo(codigo))
//        //        {
//        //            MessageBox.Show("Artículo habilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

//        //            // Recargar la grilla con los artículos actualizados
//        //            CargarArticulos();
//        //            LimpiarCampos();
//        //        }
//        //        else
//        //        {
//        //            MessageBox.Show("No se encontró el artículo desactivado para habilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        //        }
//        //    }

//        private void btnEliminar_Click(object sender, EventArgs e)
//        {
//            // Verificar si hay una fila seleccionada en el DataGridView
//            if (dataGridView1.SelectedRows.Count == 0)
//            {
//                MessageBox.Show("Por favor, seleccione una fila para deshabilitar el artículo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            // Obtener el código del artículo de la fila seleccionada
//            var filaSeleccionada = dataGridView1.SelectedRows[0];
//            string codigo = filaSeleccionada.Cells["Codigo"].Value?.ToString();

//            // Verificar que el código no sea nulo o vacío
//            if (string.IsNullOrEmpty(codigo))
//            {
//                MessageBox.Show("El código del artículo no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Llamar al método para deshabilitar el artículo
//            if (articuloService.DeshabilitarArticulo(codigo))
//            {
//                MessageBox.Show("Artículo deshabilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                CargarArticulos();
//                LimpiarCampos();
//            }
//            else
//            {
//                MessageBox.Show("No se encontró el artículo para deshabilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnHabilitar_Click_1(object sender, EventArgs e)
//        {
//            // Verificar si hay una fila seleccionada en el DataGridView
//            if (dataGridView1.SelectedRows.Count == 0)
//            {
//                MessageBox.Show("Por favor, seleccione una fila para habilitar el artículo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            // Obtener el código del artículo de la fila seleccionada
//            var filaSeleccionada = dataGridView1.SelectedRows[0];
//            string codigo = filaSeleccionada.Cells["Codigo"].Value?.ToString();

//            // Verificar que el código no sea nulo o vacío
//            if (string.IsNullOrEmpty(codigo))
//            {
//                MessageBox.Show("El código del artículo no es válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                return;
//            }

//            // Llamar al método para habilitar el artículo
//            if (articuloService.HabilitarArticulo(codigo))
//            {
//                MessageBox.Show("Artículo habilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                CargarArticulos();
//                LimpiarCampos();
//            }
//            else
//            {
//                MessageBox.Show("No se encontró el artículo desactivado para habilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//    }
//}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

//codigo sin id: 






        
    





