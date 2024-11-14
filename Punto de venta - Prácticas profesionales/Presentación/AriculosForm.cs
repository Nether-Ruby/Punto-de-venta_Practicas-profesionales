
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
    public partial class AriculosForm : Form
    {
        // private ArticulosLogica articuloService;
        private logicaArticulos articuloService;
        //  private object? valorOriginalCodigo;
        public AriculosForm()
        {
            InitializeComponent();
            articuloService = new logicaArticulos();
            CargarArticulos(); // Cargar datos al iniciar el formulario
                               //  dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            dataGridView1.Columns[0].ReadOnly = true;                 // dataGridView1.CellEndEdit += dataGridView1_CellEndEdit;

        }

        private void CargarArticulos()
        {
            // Cargar los artículos activos e inactivos en los DataGridViews correspondientes
            dataGridView1.DataSource = articuloService.CargarArticulos(true);
            dataGridViewInactivos.DataSource = articuloService.CargarArticulos(false);

            //dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
            // dataGridView1.CellBeginEdit += dataGridView1_CellBeginEdit;
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtMarca.Clear();
            txtRubro.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string criterioBusqueda = txtBuscar.Texts.Trim();

            // Si el criterio de búsqueda está vacío, mostrar un mensaje
            if (string.IsNullOrEmpty(criterioBusqueda))
            {
                MessageBox.Show("Por favor, ingrese un criterio de búsqueda.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable resultados;

            // Verificar si se ha seleccionado un campo en el ComboBox
            string campoSeleccionado = cmbCriterio.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(campoSeleccionado))
            {
                // Si no se seleccionó un campo en el ComboBox, buscar en todos los campos
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



        private void btnAgregar_Click(object sender, EventArgs e)
        {


            // Validar que los campos de precio y stock tengan valores válidos
            if (double.TryParse(txtPrecio.Texts, out double precio) && int.TryParse(txtStock.Texts, out int stock))
            {
                string nombre = txtNombre.Texts.Trim();
                string marca = txtMarca.Texts.Trim();

                // Verificar si el artículo ya existe pero está deshabilitado
                if (articuloService.ArticuloDeshabilitadoExiste(nombre, marca, out int codigoExistente))
                {
                    // Mostrar un mensaje y preguntar si desea reactivarlo
                    DialogResult result = MessageBox.Show(
                        "El artículo con el mismo Nombre y Marca ya existe pero está deshabilitado. ¿Desea volver a activarlo?",
                        "Artículo Deshabilitado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Reactivar el artículo
                        if (articuloService.HabilitarArticulo(codigoExistente))
                        {
                            MessageBox.Show("Artículo reactivado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarArticulos(); // Recargar la lista de artículos
                            LimpiarCampos(); // Limpiar los campos
                        }
                        else
                        {
                            MessageBox.Show("Error al reactivar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    return; // Salir del método si se eligió reactivar el artículo
                }

                // Si el artículo no existe o no está deshabilitado, agregarlo como nuevo
                if (articuloService.AgregarArticulo(nombre, marca, txtRubro.Texts.Trim(), precio, stock))
                {
                    MessageBox.Show("Artículo agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarArticulos(); // Recargar la lista de artículos
                    LimpiarCampos(); // Limpiar los campos
                }
            }
            else
            {
                MessageBox.Show("Datos inválidos en precio o stock.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDeshabilitar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedCells.Count > 0) // Verifica si hay alguna celda seleccionada
            {
                // Obtiene el índice de la fila de la celda seleccionada
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[rowIndex];

                // Extrae el valor de la celda "Codigo" de la fila seleccionada
                int codigo = Convert.ToInt32(filaSeleccionada.Cells["Codigo"].Value);

                // Intenta deshabilitar el artículo usando el servicio
                if (articuloService.DeshabilitarArticulo(codigo))
                {
                    MessageBox.Show("Artículo deshabilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarArticulos(); // Recargar artículos para reflejar cambios
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se encontró el artículo para deshabilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una celda en la fila del artículo para deshabilitar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnHabilitar_Click(object sender, EventArgs e)
        {


            if (dataGridViewInactivos.SelectedCells.Count > 0)
            {
                int rowIndex = dataGridViewInactivos.SelectedCells[0].RowIndex;
                DataGridViewRow filaSeleccionada = dataGridViewInactivos.Rows[rowIndex];
                int codigo = Convert.ToInt32(filaSeleccionada.Cells["Codigo"].Value);

                if (articuloService.HabilitarArticulo(codigo))
                {
                    MessageBox.Show("Artículo habilitado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarArticulos();
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("No se encontró el artículo para habilitar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Seleccione una celda en la fila del artículo para habilitar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }




        private void btnArticulosDeshabilitados_Click(object sender, EventArgs e)
        {
            // Mostrar los artículos deshabilitados en el DataGridView
            dataGridView1.DataSource = articuloService.CargarArticulos(false);
            btnDeshabilitar.Visible = false;
            btnHabilitar.Visible = true;
        }

        private void btnArticulosActivos_Click(object sender, EventArgs e)
        {
            // Mostrar los artículos activos en el DataGridView
            dataGridView1.DataSource = articuloService.CargarArticulos(true);
            btnDeshabilitar.Visible = true;
            btnHabilitar.Visible = false;
        }






        //private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        //{
        //    // Obtener la fila y la columna editada
        //    var fila = dataGridView1.Rows[e.RowIndex];
        //    string nombreColumna = dataGridView1.Columns[e.ColumnIndex].Name;

        //    // Si se intenta modificar el "Codigo", mostrar mensaje y cancelar edición
        //    if (nombreColumna == "Codigo")
        //    {
        //        MessageBox.Show("No se puede modificar el código del artículo.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        dataGridView1.CancelEdit();
        //        return;
        //    }

        //    // Obtener los valores de otras celdas (con comprobaciones de nulabilidad)
        //    int codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
        //    string? nombre = fila.Cells["Nombre"].Value?.ToString()?.Trim();
        //    string? marca = fila.Cells["Marca"].Value?.ToString()?.Trim();
        //    string? rubro = fila.Cells["Rubro"].Value?.ToString()?.Trim();

        //    // Validar Precio y Stock para evitar valores nulos
        //    if (!double.TryParse(fila.Cells["Precio_Unitario"].Value?.ToString(), out double precio) ||
        //        !int.TryParse(fila.Cells["Stock"].Value?.ToString(), out int stock))
        //    {
        //        MessageBox.Show("Error en los datos de Precio o Stock. Verifica la información ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        return;
        //    }

        //    // Verificar si los valores se han modificado
        //    if (fila.Tag is DataRow filaOriginal)
        //    {
        //        bool seModifico =
        //            nombre != filaOriginal["Nombre"].ToString().Trim() ||
        //            marca != filaOriginal["Marca"].ToString().Trim() ||
        //            rubro != filaOriginal["Rubro"].ToString().Trim() ||
        //            precio != Convert.ToDouble(filaOriginal["Precio_Unitario"]) ||
        //            stock != Convert.ToInt32(filaOriginal["Stock"]);

        //        if (!seModifico)
        //        {
        //            return; // No hacer nada si no se modificó ningún valor
        //        }
        //    }

        //    // Actualizar el artículo si los demás valores cambiaron
        //    if (articuloService.ActualizarArticulo(codigo, nombre, marca, rubro, precio, stock))
        //    {
        //        MessageBox.Show("Artículo actualizado correctamente desde la grilla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error al actualizar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        /////
        /// 
        private void ConfigurarDataGridView()
        {
            // Configurar el DataGridView
            dataGridView1.Columns["Codigo"].ReadOnly = true; // Hacer que la columna "Codigo" sea de solo lectura
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Obtener la columna editada
            string nombreColumna = dataGridView1.Columns[e.ColumnIndex].Name;

            // Si la columna editada es "Codigo", mostrar un mensaje de error y cancelar la edición
            if (nombreColumna == "Codigo")
            {
                MessageBox.Show("No se puede modificar el código del artículo. Este campo es de solo lectura.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dataGridView1.CancelEdit();
                CargarArticulos(); // Recargar los datos originales
                return;
            }

            // Continuar con la lógica de actualización normal para las demás columnas
            var fila = dataGridView1.Rows[e.RowIndex];
            int codigo = Convert.ToInt32(fila.Cells["Codigo"].Value);
            string? nombre = fila.Cells["Nombre"].Value?.ToString()?.Trim();
            string? marca = fila.Cells["Marca"].Value?.ToString()?.Trim();
            string? rubro = fila.Cells["Rubro"].Value?.ToString()?.Trim();

            // Validar Precio y Stock para evitar valores nulos
            if (!double.TryParse(fila.Cells["Precio_Unitario"].Value?.ToString(), out double precio) ||
                !int.TryParse(fila.Cells["Stock"].Value?.ToString(), out int stock))
            {
                MessageBox.Show("Error en los datos de Precio o Stock. Verifica la información ingresada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Llamar a la lógica de negocio para actualizar los datos
            if (articuloService.ActualizarArticulo(codigo, nombre, marca, rubro, precio, stock))
            {
                MessageBox.Show("Artículo actualizado correctamente desde la grilla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error al actualizar el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}



