


using System;
using System.Data;
using System.Windows.Forms;
using Punto_de_venta___Prácticas_profesionales.Logica;
using Punto_de_venta___Prácticas_profesionales.Datos;
using System.Data.SQLite;
using Punto_de_venta___Prácticas_profesionales.Lógica;

namespace Punto_de_venta___Prácticas_profesionales.Presentación
{


    
    public partial class FormCaja : Form
    {
        private CajaLogica cajaLogica = new CajaLogica();


     
        public FormCaja()
        {
            InitializeComponent();
            DatosCaja.InitializeDatabase();
            ConfigurarDataGridView();
            ConfigurarGrillaMovimientos();
            ConfigurarGrillaVentas();
            CargarMovimientos();
            CargarVentas();
            CargarTransacciones();
            ActualizarTextBox();
            ReiniciarGrillaTransacciones();
            // RegistrarCierreDeCaja();
        }



        public void RegistrarCierreDeCaja(DataGridViewRow filaTransacciones)
        {
            string fechaHora = filaTransacciones.Cells["Fecha"].Value.ToString();
            double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"].Value ?? 0);
            double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"].Value ?? 0);
            double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"].Value ?? 0);
            double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"].Value ?? 0);
            double total = Convert.ToDouble(filaTransacciones.Cells["Total"].Value ?? 0);

            // Registrar los datos del cierre de caja en la base de datos
            DatosCaja.RegistrarCierreDeCaja(fechaHora, efectivo, tarjeta, ingresos, egresos, total);

            // Reiniciar ingresos y egresos del día
            DatosCaja.ReiniciarIngresosYEgresosDelDia();

            // Recargar la grilla de transacciones para reflejar los cambios
            CargarTransacciones();
        }


        private void ConfigurarDataGridView()
        {
            dataGridViewTransacciones.Columns.Clear();
            dataGridViewTransacciones.Columns.Add("Fecha", "Fecha");
            dataGridViewTransacciones.Columns.Add("Efectivo", "Efectivo");
            dataGridViewTransacciones.Columns.Add("Tarjeta", "Tarjeta");
            dataGridViewTransacciones.Columns.Add("Ingresos", "Ingresos");
            dataGridViewTransacciones.Columns.Add("Egresos", "Egresos");
            dataGridViewTransacciones.Columns.Add("Total", "Total");

            dataGridViewTransacciones.ReadOnly = true;
        }

        private void ConfigurarGrillaMovimientos()
        {
            dataGridViewMovimientos.Columns.Clear();
            dataGridViewMovimientos.Columns.Add("Fecha_Hora", "Fecha y Hora");
            dataGridViewMovimientos.Columns.Add("Ingresos", "Ingresos");
            dataGridViewMovimientos.Columns.Add("Egresos", "Egresos");
            dataGridViewMovimientos.Columns.Add("TotalIngresos", "Total Ingresos");
            dataGridViewMovimientos.Columns.Add("TotalEgresos", "Total Egresos");
            dataGridViewMovimientos.Columns.Add("Total", "Total");

            dataGridViewMovimientos.ReadOnly = true;
        }

        private void ConfigurarGrillaVentas()
        {
            dataGridViewVentas.Columns.Clear();
            dataGridViewVentas.Columns.Add("Fecha_Hora", "Fecha y Hora");
            dataGridViewVentas.Columns.Add("Efectivo", "Efectivo");
            dataGridViewVentas.Columns.Add("Tarjeta", "Tarjeta");
            dataGridViewVentas.Columns.Add("TotalEfectivo", "Total Efectivo");
            dataGridViewVentas.Columns.Add("TotalTarjeta", "Total Tarjeta");

            // Configuración opcional
            dataGridViewVentas.Columns["Fecha_Hora"].Width = 150;
            dataGridViewVentas.Columns["Efectivo"].Width = 100;
            dataGridViewVentas.Columns["Tarjeta"].Width = 100;
            dataGridViewVentas.Columns["TotalEfectivo"].Width = 120;
            dataGridViewVentas.Columns["TotalTarjeta"].Width = 120;

            // Evitar edición directa por el usuario
            dataGridViewVentas.ReadOnly = true;
        }
        private void CargarMovimientos()
        {
            dataGridViewMovimientos.Rows.Clear();

            // Obtener movimientos desde la lógica
            var movimientos = cajaLogica.ObtenerMovimientosDelDia();

            foreach (var movimiento in movimientos)
            {
                dataGridViewMovimientos.Rows.Add(
                    movimiento["FechaHora"],
                    movimiento["Ingreso"],
                    movimiento["Egreso"],
                    movimiento["TotalIngresos"],
                    movimiento["TotalEgresos"],
                    movimiento["Total"]
                );
            }
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            RegistrarMovimiento("Ingreso", Convert.ToDouble(txtMonto.Texts));
        }

        private void btnEgreso_Click(object sender, EventArgs e)
        {
            RegistrarMovimiento("Egreso", Convert.ToDouble(txtMonto.Texts));
        }

        private (double, double) CalcularTotalesMovimientos()
        {
            double totalIngresos = 0;
            double totalEgresos = 0;

            foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
            {
                totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
                totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
            }

            return (totalIngresos, totalEgresos);
        }

        
        public void ActualizarTotalesVentas(DataTable ventas)
        {
            double totalEfectivo = 0;
            double totalTarjeta = 0;

            
            foreach (DataRow row in ventas.Rows)
            {
                totalEfectivo += Convert.ToDouble(row["Efectivo"]);
                totalTarjeta += Convert.ToDouble(row["Tarjeta"]);
            }

     
            txtEfectivo.Texts = totalEfectivo.ToString("F2");
            txtTarjeta.Texts = totalTarjeta.ToString("F2");

         
            if (dataGridViewTransacciones.Rows.Count > 0)
            {
                var fila = dataGridViewTransacciones.Rows[0];
                fila.Cells["Efectivo"].Value = totalEfectivo;
                fila.Cells["Tarjeta"].Value = totalTarjeta;
            }
        }
        
        private void CargarVentas()
        {
            try
            {
               
                dataGridViewVentas.Rows.Clear();

                var transacciones = VentasLogica.ObtenerTransaccionesDelDia();

                double totalEfectivo = 0;
                double totalTarjeta = 0;

             
                foreach (var transaccion in transacciones)
                {
    
                    string metodoPago = transaccion.MetodoPago?.ToLower().Trim();

                    double efectivo = metodoPago == "efectivo" ? transaccion.Total : 0;
                    double tarjeta = (metodoPago == "tarjeta de crédito" || metodoPago == "tarjeta de débito") ? transaccion.Total : 0;

                    totalEfectivo += efectivo;
                    totalTarjeta += tarjeta;

                    dataGridViewVentas.Rows.Add(
                        transaccion.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"), // Fecha y Hora
                        efectivo,                                             // Efectivo
                        tarjeta,                                              // Tarjeta
                        totalEfectivo,                                        // Total acumulado de efectivo
                        totalTarjeta                                          // Total acumulado de tarjeta
                    );
                }

                txtEfectivo.Texts = totalEfectivo.ToString("F2");
                txtTarjeta.Texts = totalTarjeta.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   
        private void ActualizarTextBox()
        {
            try
            {
                double totalEfectivo = 0;
                double totalTarjeta = 0;

                // Recorre las filas de la grilla de ventas
                foreach (DataGridViewRow fila in dataGridViewVentas.Rows)
                {
                    totalEfectivo += ConvertirSeguro(fila.Cells["Efectivo"].Value);
                    totalTarjeta += ConvertirSeguro(fila.Cells["Tarjeta"].Value);
                }

                // Actualizar los cuadros de texto con los totales
                txtEfectivo.Texts = totalEfectivo.ToString("F2");
                txtTarjeta.Texts = totalTarjeta.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar los cuadros de texto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double ConvertirSeguro(object valor)
        {
            return valor != DBNull.Value && double.TryParse(valor?.ToString(), out double resultado) ? resultado : 0;
        }
      
        private void RegistrarMovimientoEnGrilla(string tipo, double monto)
        {
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            double ingreso = tipo == "Ingreso" ? monto : 0;
            double egreso = tipo == "Egreso" ? monto : 0;

            double totalIngresos = 0;
            double totalEgresos = 0;

            foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
            {
                totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
                totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
            }

            totalIngresos += ingreso;
            totalEgresos += egreso;

           
            double total = totalIngresos - totalEgresos;

           
            dataGridViewMovimientos.Rows.Add(fechaHora, ingreso, egreso, totalIngresos, totalEgresos, total);

           
            ActualizarTextBox();
            CargarTransacciones();
        }
        public void RegistrarMovimiento(string tipo, double monto)
        {
        
            cajaLogica.RegistrarMovimiento(tipo, monto);

            
            RegistrarMovimientoEnGrilla(tipo, monto);

            CargarTransacciones();

        
            ActualizarTextBox();
        }


    
        private void CargarTransacciones()
        {
         
            dataGridViewTransacciones.Rows.Clear();

          
            var ventas = VentasLogica.ObtenerTransaccionesDelDia();

            var (totalEfectivo, totalTarjeta) = CajaLogica.CalcularTotalesDesdeVentas(ventas);

            var (totalIngresos, totalEgresos) = CalcularTotalesMovimientos();

          
            double totalGlobal = totalEfectivo + totalTarjeta + totalIngresos - totalEgresos;

            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridViewTransacciones.Rows.Add(
                fecha,            // Fecha
                totalEfectivo,    // Total efectivo
                totalTarjeta,     // Total tarjeta
                totalIngresos,    // Total ingresos
                totalEgresos,     // Total egresos
                totalGlobal       // Total global
            );

          
            txtEfectivo.Texts = totalEfectivo.ToString("F2");
            txtTarjeta.Texts = totalTarjeta.ToString("F2");
            txtTotalIngresos.Texts = totalIngresos.ToString("F2");
            txtTotalEgresos.Texts = totalEgresos.ToString("F2");
        }

   
        private void ReiniciarGrillaTransacciones()
        {
            dataGridViewTransacciones.Rows.Clear();
            // Agregar una fila vacía con valores en 0 para iniciar nuevamente
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridViewTransacciones.Rows.Add(fecha, 0.0, 0.0, 0.0, 0.0, 0.0);
        }
        private void FormCaja_Load(object sender, EventArgs e)
        {

        }
        private void ReiniciarCaja()
        {
            
            dataGridViewTransacciones.Rows.Clear();
            dataGridViewMovimientos.Rows.Clear();

            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridViewTransacciones.Rows.Add(fecha, 0.0, 0.0, 0.0, 0.0, 0.0);

            // Reiniciar los cuadros de texto
            txtEfectivo.Texts = "0";
            txtTarjeta.Texts = "0";
            txtTotalIngresos.Texts = "0";
            txtTotalEgresos.Texts = "0";

            
            DatosCaja.ReiniciarIngresosYEgresosDelDia();

         
        }


        private void btnCierreDeCaja_Click(object sender, EventArgs e)
        {
            // Verificar si hay datos en la grilla de transacciones
            if (dataGridViewTransacciones.Rows.Count == 0 || dataGridViewTransacciones.Rows[0].Cells["Total"].Value == null)
            {
                MessageBox.Show("No hay datos para realizar el cierre de caja.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Registrar los datos de la grilla de transacciones en la base de datos
            var filaTransacciones = dataGridViewTransacciones.Rows[0];
            string fechaHora = filaTransacciones.Cells["Fecha"].Value.ToString();
            double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"].Value ?? 0);
            double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"].Value ?? 0);
            double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"].Value ?? 0);
            double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"].Value ?? 0);
            double total = Convert.ToDouble(filaTransacciones.Cells["Total"].Value ?? 0);

            DatosCaja.GuardarCierreDeCaja(DateTime.Now, efectivo, tarjeta, ingresos, egresos, total);

            // Reiniciar la caja
            ReiniciarCaja();

            MessageBox.Show("Cierre de caja realizado correctamente.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCierreDeCaja_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewTransacciones.Rows.Count == 0 || dataGridViewTransacciones.Rows[0].Cells["Total"].Value == null)
            {
                MessageBox.Show("No hay datos para realizar el cierre de caja.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Registrar los datos de la grilla de transacciones en la base de datos
            var filaTransacciones = dataGridViewTransacciones.Rows[0];
            string fechaHora = filaTransacciones.Cells["Fecha"].Value.ToString();
            double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"].Value ?? 0);
            double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"].Value ?? 0);
            double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"].Value ?? 0);
            double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"].Value ?? 0);
            double total = Convert.ToDouble(filaTransacciones.Cells["Total"].Value ?? 0);

            DatosCaja.GuardarCierreDeCaja(DateTime.Now, efectivo, tarjeta, ingresos, egresos, total);

            // Reiniciar la caja
            ReiniciarCaja();

            MessageBox.Show("Cierre de caja realizado correctamente.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        private void btnDiagnostico_Click(object sender, EventArgs e)
        {
            //var diagnostico = DatosCaja.DiagnosticoVentas();
            //MessageBox.Show(string.Join("\n", diagnostico), "Diagnóstico de Ventas");
            ////var ventas = DatosCaja.DiagnosticoVentas();
            ////if (ventas.Count == 0)
            ////{
            ////    MessageBox.Show("No se encontraron ventas registradas.", "Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////}
            ////else
            ////{
            ////    MessageBox.Show(string.Join("\n", ventas), "Ventas Registradas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ////}
        }

        private void btnDiagnostico_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Llama al método para obtener las transacciones del día
                var transacciones = VentasLogica.ObtenerTransaccionesDelDia();

                // Muestra cada transacción en un cuadro de mensaje
                foreach (var transaccion in transacciones)
                {
                    MessageBox.Show($"Fecha: {transaccion.FechaHora}, Método: {transaccion.MetodoPago}, Total: {transaccion.Total}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener transacciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

