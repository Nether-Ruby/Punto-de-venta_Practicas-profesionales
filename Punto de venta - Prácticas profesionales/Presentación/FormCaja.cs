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
        private cajaLogica cl = new cajaLogica();
        private int idTurnoAbierto = -1;


        public FormCaja(Form1 padre)
        {
            InitializeComponent();
            formpadre = padre;


        }

        public void InicializarEventos()
        {
            ingresostxt.ReadOnly = true;
            egresostxt.ReadOnly = true;

            // Verificar si hay un turno abierto
            idTurnoAbierto = cl.ObtenerIdTurnoAbierto();
            if (idTurnoAbierto != -1)
            {
                // Si hay un turno abierto, habilitar los botones de cierre, ingresos y egresos
                abrirBtn.Enabled = false;
                cerrarBtn.Enabled = true;
                ingresoBtn.Enabled = true;
                egresosBtn.Enabled = true;


                // Mostrar los ingresos y egresos actuales
                ingresostxt.Text = formpadre.Ingreso.ToString("C2");
                egresostxt.Text = formpadre.Egreso.ToString("C2");

                // Cargar las ventas del día y calcular los totales
                dataGridView1.DataSource = cajaLogica.ventasHoy();
                CalcularTotalEfectivo();
                CalcularTotalTarjeta();
                CalcularTotalCaja();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            else
            {
                // Si no hay un turno abierto, deshabilitar los botones de cierre, ingresos y egresos
                cerrarBtn.Enabled = false;
                ingresoBtn.Enabled = false;
                egresosBtn.Enabled = false;
                abrirBtn.Enabled = true;

                // Limpiar los campos de ingresos y egresos
                ingresostxt.Text = "0.00";
                egresostxt.Text = "0.00";
                efectivolbl.Text = "0.00";
                tarjetalbl.Text = "0.00";
                totallbl.Text = "0.00";
            }
        }
        
        private void FormCaja_Resize(object sender, EventArgs e)
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
        private void CalcularTotalEfectivo()
        {
            decimal totalCaja = 0;

            // Recorremos todas las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Comprobamos que la fila no sea una fila nueva (vacía)
                if (!fila.IsNewRow)
                {
                    // Verificamos si el valor de la columna "metodo" es "efectivo"
                    string metodoPago = fila.Cells["metodo"].Value.ToString();

                    if (metodoPago == "Efectivo" || metodoPago == "Transferencia")
                    {
                        // Sumamos el valor de la columna "total"
                        decimal totalVenta = Convert.ToDecimal(fila.Cells["total"].Value);
                        totalCaja += totalVenta;
                    }
                }
            }

            // Asignamos el valor calculado al label
            efectivolbl.Text = totalCaja.ToString("C2"); // El formato "C2" muestra el valor como moneda con 2 decimales
        }

        private void CalcularTotalTarjeta()
        {
            decimal totalCaja = 0;

            // Recorremos todas las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Comprobamos que la fila no sea una fila nueva (vacía)
                if (!fila.IsNewRow)
                {
                    // Verificamos si el valor de la columna "metodo" es "tarjeta"
                    string metodoPago = fila.Cells["metodo"].Value.ToString();

                    if (metodoPago == "Tarjeta de crédito" || metodoPago == "Tarjeta de débito")
                    {
                        // Sumamos el valor de la columna "total"
                        decimal totalVenta = Convert.ToDecimal(fila.Cells["total"].Value);
                        totalCaja += totalVenta;
                    }
                }
            }

            // Asignamos el valor calculado al label
            tarjetalbl.Text = totalCaja.ToString("C2"); // El formato "C2" muestra el valor como moneda con 2 decimales
        }

        private void CalcularTotalCaja()
        {
            double totalEfe = 0; // Total para efectivo y transferencia
            double totalTar = 0; // Total para tarjeta

            // Recorremos todas las filas del DataGridView
            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
                // Comprobamos que la fila no sea una fila nueva (vacía)
                if (!fila.IsNewRow)
                {
                    // Verificamos si la celda "metodo" y "total" no son nulas
                    if (fila.Cells["metodo"].Value != null && fila.Cells["total"].Value != null)
                    {
                        string metodoPago = fila.Cells["metodo"].Value.ToString();
                        if (double.TryParse(fila.Cells["total"].Value.ToString(), out double totalVenta))
                        {
                            // Sumar según el método de pago
                            if (metodoPago == "Efectivo" || metodoPago == "Transferencia")
                            {
                                totalEfe += totalVenta;
                            }
                            else if (metodoPago == "Tarjeta de crédito" || metodoPago == "Tarjeta de débito")
                            {
                                totalTar += totalVenta;
                            }
                        }
                    }
                }
            }

            // Calculamos el total de la caja incluyendo ingresos y egresos
            double ingreso = formpadre.Ingreso;
            double egreso = formpadre.Egreso;

            double totalCaja = totalEfe + totalTar + ingreso - egreso;

            // Actualizamos el Label con el total formateado como moneda
            totallbl.Text = totalCaja.ToString("C2");
        }



        private void abrirBtn_Click(object sender, EventArgs e)
        {
            // Abrir un nuevo turno
            bool exito = cl.AbrirTurno(DateTime.Now);

            if (exito)
            {
                // Actualizar el estado de la caja
                formpadre.IsOpen = true;
                idTurnoAbierto = cl.ObtenerIdTurnoAbierto(); // Obtener el ID del turno abierto

                // Habilitar los botones de cierre, ingresos y egresos
                abrirBtn.Enabled = false;
                cerrarBtn.Enabled = true;
                ingresoBtn.Enabled = true;
                egresosBtn.Enabled = true;

                // Cargar las ventas del día y calcular los totales
                dataGridView1.DataSource = cajaLogica.ventasHoy();
                CalcularTotalEfectivo();
                CalcularTotalTarjeta();
                CalcularTotalCaja();
            }
            else
            {
                MessageBox.Show("Hubo un error al abrir el turno. Intente nuevamente.");
            }
        }
        private void cerrarBtn_Click(object sender, EventArgs e)
        {
            double totalEfectivo = Convert.ToDouble(efectivolbl.Text.Replace("€", "").Replace("$", "").Trim());
            double totalTarjeta = Convert.ToDouble(tarjetalbl.Text.Replace("€", "").Replace("$", "").Trim());
            double totalIngresos = formpadre.Ingreso;
            double totalEgresos = formpadre.Egreso;
            double totalCaja = Convert.ToDouble(totallbl.Text.Replace("€", "").Replace("$", "").Trim());
            DateTime horaCierre = DateTime.Now;

            // Cerrar el turno actual
            bool exito = cl.CerrarTurno(idTurnoAbierto, horaCierre, totalEfectivo, totalTarjeta, totalCaja, totalIngresos, totalEgresos);

            if (exito)
            {
                // Actualizar el estado de la caja
                formpadre.IsOpen = false;
                idTurnoAbierto = -1;

                // Deshabilitar los botones de cierre, ingresos y egresos
                abrirBtn.Enabled = true;
                cerrarBtn.Enabled = false;
                ingresoBtn.Enabled = false;
                egresosBtn.Enabled = false;

                // Limpiar los campos de ingresos y egresos
                formpadre.Ingreso = 0;
                formpadre.Egreso = 0;
                efectivolbl.Text = "0.00";
                tarjetalbl.Text = "0.00";
                totallbl.Text = "0.00";
                ingresostxt.Text = "0.00";
                egresostxt.Text = "0.00";

                // Limpiar el DataGridView
                dataGridView1.DataSource = null;
            }
            else
            {
                MessageBox.Show("Hubo un error al cerrar el turno. Intente nuevamente.");
            }
        }

        private void FormCaja_Load(object sender, EventArgs e)
        {
            ingresostxt.ReadOnly = true;
            egresostxt.ReadOnly = true;
            idTurnoAbierto = cl.ObtenerIdTurnoAbierto();
            if (idTurnoAbierto != -1)
            {
                abrirBtn.Enabled = false;
                cerrarBtn.Enabled = true;
                ingresostxt.Text = formpadre.Ingreso.ToString();
                egresostxt.Text = formpadre.Egreso.ToString();
                dataGridView1.DataSource = cajaLogica.ventasHoy();
                CalcularTotalEfectivo();
                CalcularTotalTarjeta();
                CalcularTotalCaja();
            }
            else
            {
                cerrarBtn.Enabled = false;
                abrirBtn.Enabled = true;
            }
        }

        private void ingresoBtn_Click(object sender, EventArgs e)
        {
            // Creamos y mostramos el formulario FormIngreso
            FormCajaIngresos formIngreso = new FormCajaIngresos();
            if (formIngreso.ShowDialog() == DialogResult.OK)
            {
                // Si se ingresó un monto válido, lo sumamos al total de los ingresos
                formpadre.Ingreso = formpadre.Ingreso + formIngreso.MontoIngresado;
                // Actualizamos el label con el nuevo total
                ingresostxt.Text = formpadre.Ingreso.ToString("C2");
                CalcularTotalCaja();
            }
            else
            {
                // Si el usuario presiona "Volver" o cancela, no hacemos nada
                MessageBox.Show("No se realizó ningún ingreso.");
            }
        }

        private void egresosBtn_Click(object sender, EventArgs e)
        {
            // Creamos y mostramos el formulario FormEgreso
            FormCajaEgresos formEgreso = new FormCajaEgresos();
            if (formEgreso.ShowDialog() == DialogResult.OK)
            {
                // Si se ingresó un monto válido, lo restamos del total de la caja
                formpadre.Egreso = formpadre.Egreso + formEgreso.MontoEgreso;
                // Actualizamos el label con el nuevo total
                egresostxt.Text = formpadre.Egreso.ToString("C2");
                CalcularTotalCaja();
            }
            else
            {
                // Si el usuario presiona "Volver" o cancela, no hacemos nada
                MessageBox.Show("No se realizó ningún egreso.");
            }
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
