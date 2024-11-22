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

        public FormCaja(Form1 padre)
        {

            InitializeComponent();
            formpadre = padre;
            InicializarEventos();
        }
        public void InicializarEventos()
        {
            ingresostxt.ReadOnly = true;
            egresostxt.ReadOnly = true;
            if (formpadre.IsOpen == true)
            {
                abrirBtn.Enabled = false;
                cerrarBtn.Enabled = true;
                ingresoBtn.Enabled = true;
                egresosBtn.Enabled = true;
                ingresostxt.Text = formpadre.Ingreso.ToString("C2");
                egresostxt.Text = formpadre.Egreso.ToString("C2");
                dataGridView1.DataSource = cajaLogica.ventasHoy();
                CalcularTotalEfectivo();
                CalcularTotalTarjeta();
                CalcularTotalCaja();

            }
            else
            {
                cerrarBtn.Enabled = false;
                ingresoBtn.Enabled = false;
                egresosBtn.Enabled = false;
                abrirBtn.Enabled = true;
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
            dataGridView1.DataSource = cajaLogica.ventasHoy();
            formpadre.IsOpen = true;
            InicializarEventos();
        }

        private void cerrarBtn_Click(object sender, EventArgs e)
        {
            double totalEfectivo = Convert.ToDouble(efectivolbl.Text.Replace("€", "").Replace("$", "").Trim());
            double totalTarjeta = Convert.ToDouble(tarjetalbl.Text.Replace("€", "").Replace("$", "").Trim());
            double totalIngresos = formpadre.Ingreso;
            double totalEgresos = formpadre.Egreso;
            double totalCaja = Convert.ToDouble(totallbl.Text.Replace("€", "").Replace("$", "").Trim());
            DateTime horaCierre = DateTime.Now;

            bool exito = cl.CerrarCaja(totalEfectivo, totalTarjeta, totalCaja, totalIngresos, totalEgresos, horaCierre);
            if (exito)
            {
                dataGridView1.DataSource = null;
                formpadre.IsOpen = false;
                InicializarEventos();
                MessageBox.Show("Caja cerrada con éxito y datos guardados.");
                formpadre.Ingreso = 0;
                formpadre.Egreso = 0;
                double totalEfe = 0; // Total para efectivo y transferencia
                double totalTar = 0; // Total para tarjeta
                double totalC = 0;
                efectivolbl.Text= totalEfe.ToString("C2");
                tarjetalbl.Text = totalTar.ToString("C2");
                totallbl.Text = totalC.ToString("C2");
                ingresostxt.Text = formpadre.Ingreso.ToString("C2");
                egresostxt.Text = formpadre.Egreso.ToString("C2");
            }
            else
            {
                MessageBox.Show("Hubo un error al cerrar la caja. Intente nuevamente.");
            }
        }

        private void FormCaja_Load(object sender, EventArgs e)
        {
            ingresostxt.ReadOnly = true;
            egresostxt.ReadOnly = true;
            if (formpadre.IsOpen == true)
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
    }
}
