using Punto_de_venta___Prácticas_profesionales.Datos;
using Punto_de_venta___Prácticas_profesionales.Lógica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Punto_de_venta___Prácticas_profesionales.Lógica.VentasLogica;

namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    public partial class FormVentas : Form
    {
        private DataTable dt;
        private VentasLogica ventaslogica = new VentasLogica();

        List<string> opcionesDePago = new List<string>
    {
        "Efectivo",
        "Tarjeta de crédito",
        "Tarjeta de débito",
        "Transferencia"
    };

        private bool isUpdating = false;
        private bool isUpdatingV = false;
        private bool isUpdatingC = false;
        private double subtotal = 0;
        private double total = 0;
        private double tasaImpuesto = 21;
        private double tasaDescuento = 0;

        public FormVentas()
        {
            InitializeComponent();
            InicializarEventos();

            texboxs3.Texts = tasaImpuesto.ToString();
            texboxs4.Texts = tasaDescuento.ToString();

            dt = new DataTable();
            dt.Columns.Add("Codigo");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Marca");
            dt.Columns.Add("Rubro");
            dt.Columns.Add("Precio Unitario");
            dt.Columns.Add("Cantidad");
            dt.Columns.Add("Precio Total");

            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


        }
        private void InicializarEventos()
        {
            var nrofact = ventaslogica.ObtenerNroFact();
            // Vincular evento TextChanged del ComboBox
            comboBox1.TextChanged += comboBox1_TextChanged;
            //comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.TextChanged += comboBox2_TextChanged;
            comboBox4.TextChanged += comboBox4_TextChanged;
            // Cargar opciones en el ComboBox
            comboBox3.DataSource = opcionesDePago;
            textBox1.Text = nrofact.ToString();
            textBox1.ReadOnly = true;
            label5.Text = subtotal.ToString("C2");
            label9.Text = total.ToString("C2");
            dataGridView1.ReadOnly = true;
        }
        private void FormVentas_Resize(object sender, EventArgs e)
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


        private void classBtnPersonalizado1_Click(object sender, EventArgs e)
        {

            string nombreArticulo = comboBox1.Text;
            int cantidad;

            if (!int.TryParse(texboxs5.Texts, out cantidad) || cantidad <= 0)

            {
                MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string mensaje;
            bool exito = ventaslogica.VerificarYRegistrarVenta(nombreArticulo, cantidad, out mensaje);

            MessageBox.Show(mensaje, exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);

            if (exito)
            {
                if (comboBox3.SelectedItem == null || comboBox2.SelectedItem == null || comboBox4.SelectedItem == null || texboxs3.Texts == "" || texboxs4.Texts == "")
                {
                    MessageBox.Show("Por favor, completa todos los campos.");
                    return;
                }
                var resultado = ventaslogica.consulta_dgv(comboBox1.Text);
                DataRow row = dt.NewRow();

                row["Codigo"] = resultado.Item1; // Consulta SQL
                row["Nombre"] = comboBox1.Text;
                row["Marca"] = resultado.Item2; // Consulta SQL
                row["Rubro"] = resultado.Item3; // Consulta SQL
                row["Precio Unitario"] = resultado.Item4; // Consulta SQL
                row["Cantidad"] = texboxs5.Texts;
                row["Precio Total"] = Int32.Parse(texboxs5.Texts) * double.Parse(resultado.Item4);

                dt.Rows.Add(row);

                double auxImp = double.Parse(texboxs3.Texts) / 100;
                double auxDesc = double.Parse(texboxs4.Texts) / 100;
                subtotal = subtotal + (Int32.Parse(texboxs5.Texts) * double.Parse(resultado.Item4));
                total = subtotal + (subtotal * auxImp) - (subtotal * auxDesc);

                label5.Text = subtotal.ToString("C2");
                label9.Text = total.ToString("C2");
            }
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // Si ya se está actualizando, salir del evento
            if (isUpdating)
                return;

            try
            {
                isUpdating = true; // Indica que estás actualizando

                // Texto ingresado por el usuario
                string textoBusqueda = comboBox1.Text;

                // Obtener los artículos filtrados
                var articulos = ventaslogica.FiltrarArticulos(textoBusqueda);

                // Actualizar el ComboBox sin modificar el texto actual
                ActualizarComboBox(articulos, textoBusqueda);
            }
            finally
            {
                isUpdating = false; // Finaliza la actualización
            }
        }

        private void ActualizarComboBox(System.Collections.Generic.List<string> articulos, string textoBusqueda)
        {
            // Guardar el estado actual de la lista desplegable
            bool wasDroppedDown = comboBox1.DroppedDown;

            // Limpiar los elementos existentes
            comboBox1.Items.Clear();

            if (articulos.Count > 0)
            {
                // Llenar con los nuevos resultados
                comboBox1.Items.AddRange(articulos.ToArray());
                comboBox1.DroppedDown = true; // Mostrar la lista desplegable
            }
            else
            {
                // Mostrar un mensaje si no hay resultados
                comboBox1.Items.Add("No hay resultados");
                comboBox1.DroppedDown = wasDroppedDown; // Mantener el estado anterior
            }

            // Mantener el texto actual sin modificarlo directamente
            comboBox1.Text = textoBusqueda;
            comboBox1.SelectionStart = textoBusqueda.Length;
            comboBox1.SelectionLength = 0;
        }

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "No hay resultados")
        //    {
        //        string articuloSeleccionado = comboBox1.SelectedItem.ToString();
        //        MessageBox.Show($"Has seleccionado: {articuloSeleccionado}");
        //    }
        //}
        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            // Si ya se está actualizando, salir del evento
            if (isUpdatingV)
                return;

            try
            {
                isUpdatingV = true; // Indica que estás actualizando

                // Texto ingresado por el usuario
                string textoBusqueda = comboBox2.Text;

                // Obtener los artículos filtrados
                var vendedores = ventaslogica.FiltrarVendedores(textoBusqueda);

                // Actualizar el ComboBox sin modificar el texto actual
                ActualizarComboBoxVentas(vendedores, textoBusqueda);
            }
            finally
            {
                isUpdatingV = false; // Finaliza la actualización
            }
        }
        private void ActualizarComboBoxVentas(System.Collections.Generic.List<string> vendedores, string textoBusqueda)
        {
            // Guardar el estado actual de la lista desplegable
            bool wasDroppedDown = comboBox2.DroppedDown;

            // Limpiar los elementos existentes
            comboBox2.Items.Clear();

            if (vendedores.Count > 0)
            {
                // Llenar con los nuevos resultados
                comboBox2.Items.AddRange(vendedores.ToArray());
                comboBox2.DroppedDown = true; // Mostrar la lista desplegable
            }
            else
            {
                // Mostrar un mensaje si no hay resultados
                comboBox2.Items.Add("No hay resultados");
                comboBox2.DroppedDown = wasDroppedDown; // Mantener el estado anterior
            }

            // Mantener el texto actual sin modificarlo directamente
            comboBox2.Text = textoBusqueda;
            comboBox2.SelectionStart = textoBusqueda.Length;
            comboBox2.SelectionLength = 0;
        }

        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            // Si ya se está actualizando, salir del evento
            if (isUpdatingC)
                return;

            try
            {
                isUpdatingC = true; // Indica que estás actualizando

                // Texto ingresado por el usuario
                string textoBusqueda = comboBox4.Text;

                // Obtener los artículos filtrados
                var clientes = ventaslogica.FiltrarClientes(textoBusqueda);

                // Actualizar el ComboBox sin modificar el texto actual
                ActualizarComboBoxClientes(clientes, textoBusqueda);
            }
            finally
            {
                isUpdatingC = false; // Finaliza la actualización
            }
        }

        private void ActualizarComboBoxClientes(System.Collections.Generic.List<string> clientes, string textoBusqueda)
        {
            // Guardar el estado actual de la lista desplegable
            bool wasDroppedDown = comboBox4.DroppedDown;

            // Limpiar los elementos existentes
            comboBox4.Items.Clear();

            if (clientes.Count > 0)
            {
                // Llenar con los nuevos resultados
                comboBox4.Items.AddRange(clientes.ToArray());
                comboBox4.DroppedDown = true; // Mostrar la lista desplegable
            }
            else
            {
                // Mostrar un mensaje si no hay resultados
                comboBox4.Items.Add("No hay resultados");
                comboBox4.DroppedDown = wasDroppedDown; // Mantener el estado anterior
            }

            // Mantener el texto actual sin modificarlo directamente
            comboBox4.Text = textoBusqueda;
            comboBox4.SelectionStart = textoBusqueda.Length;
            comboBox4.SelectionLength = 0;
        }

        private void classBtnPersonalizado3_Click(object sender, EventArgs e)
        {
            string totalT = label9.Text.Replace("€", "").Replace("$", "").Trim(); // Limpiar símbolos monetarios
                                                                                  // Validar y capturar datos
            if (!double.TryParse(totalT, out double total))
            {
                MessageBox.Show("Por favor, ingresa un total válido.");
                return;
            }

            if (comboBox3.SelectedItem == null || comboBox4.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }
            if (dataGridView1.Rows.Count < 2)
            {
                MessageBox.Show("No hay artículos en la lista de venta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear la transacción
            Transaccion transaccion = new Transaccion
            {
                FechaHora = DateTime.Now,
                Vendedor = comboBox2.SelectedItem.ToString(),
                Cliente = comboBox4.SelectedItem.ToString(),
                MetodoPago = comboBox3.SelectedItem.ToString(),
                Total = total
            };

            List<detallesVenta> list_detalles = new List<detallesVenta>();

            foreach (DataRow row in dt.Rows)
            {
                detallesVenta detalles_venta = new detallesVenta();

                detalles_venta.nroFact = textBox1.Text.ToString();
                detalles_venta.codigo = row["Codigo"].ToString();
                detalles_venta.cantidad = row["Cantidad"].ToString();

                list_detalles.Add(detalles_venta);
            }

            List<Tuple<string, string, string>> detalles_imp = new List<Tuple<string, string, string>>();

            foreach (DataRow row in dt.Rows)
            {
                // Obtener los valores de cada fila
                string nroFact = textBox1.Text.ToString();
                string nombre = row["Nombre"].ToString();
                string cantidad = row["Cantidad"].ToString();

                // Crear una nueva tupla y agregarla a la lista
                detalles_imp.Add(new Tuple<string, string, string>(nroFact, nombre, cantidad));
            }

            // Llamar a la capa de datos
            try
            {
                VentasDatos datos = new VentasDatos();
                datos.RegistrarTransaccion(transaccion);
                ventaslogica.RegistrarDetallesVenta(list_detalles);
                textBox1.Text = ventaslogica.ObtenerNroFact().ToString();

                // Imprimir el ticket
                try
                {
                    ImprimirTicket(transaccion.Cliente, transaccion.Vendedor, transaccion.MetodoPago, transaccion.Total, detalles_imp);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al imprimir el ticket: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                MessageBox.Show("Transacción registrada exitosamente.");
                total = 0.00;
                subtotal = 0.00;
                ((DataTable)dataGridView1.DataSource).Rows.Clear();
                label5.Text = subtotal.ToString("C2");
                label9.Text = total.ToString("C2");
                texboxs5.Clear();
                comboBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la transacción: {ex.Message}");
            }
        }


        private void classBtnPersonalizado2_Click(object sender, EventArgs e)
        {
            total = 0.00;
            subtotal = 0.00;
            ((DataTable)dataGridView1.DataSource).Rows.Clear();
            label5.Text = subtotal.ToString("C2");
            label9.Text = total.ToString("C2");
        }

        private void texboxs5_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, tecla de retroceso y teclas de control (e.g., Ctrl+C)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Rechazar el carácter
            }
        }

        private void texboxs3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, tecla de retroceso y teclas de control (e.g., Ctrl+C)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Rechazar el carácter
            }
        }

        private void texboxs4_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, tecla de retroceso y teclas de control (e.g., Ctrl+C)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Rechazar el carácter
            }
        }

        private void ImprimirTicket(string cliente, string vendedor, string metodoPago, double total, List<Tuple<string, string, string>> detalles_imp)
        {
            // Crear el documento de impresión
            TicketPrintDocument printDocument = new TicketPrintDocument(cliente, vendedor, metodoPago, total, detalles_imp);

            // Mostrar el diálogo de impresión
            PrintDialog printDialog = new PrintDialog();
            printDialog.Document = printDocument;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print(); // Imprimir el ticket
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
