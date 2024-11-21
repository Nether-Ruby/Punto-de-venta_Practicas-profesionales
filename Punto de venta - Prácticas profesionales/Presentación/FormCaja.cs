


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
        //  private CajaLogica cajaLogica = new CajaLogica();


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
            ActualizarTextBoxMovimiento();
            ReiniciarGrillaTransacciones();
            // RegistrarCierreDeCaja();
        }


     

        public void RegistrarCierreDeCaja()
        {
            try
            {
                if (dataGridViewTransacciones.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para registrar el cierre de caja.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var fila = dataGridViewTransacciones.Rows[0];
                string fechaHoraCierre = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                double efectivo = Convert.ToDouble(fila.Cells["Efectivo"].Value ?? 0);
                double tarjeta = Convert.ToDouble(fila.Cells["Tarjeta"].Value ?? 0);
                double ingresos = Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
                double egresos = Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
                double total = Convert.ToDouble(fila.Cells["Total"].Value ?? 0);

                int idCaja = CajaLogica.ObtenerIdCajaActual();
                if (idCaja == -1)
                {
                    MessageBox.Show("No hay caja activa para cerrar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar el cierre en la base de datos
                CajaLogica.GuardarCierreDeCaja(DateTime.Now, efectivo, tarjeta, ingresos, egresos, total);

                // Reiniciar la interfaz
                ReiniciarCaja();
                CargarMovimientos();
                CargarVentas();
                CargarTransacciones();

                MessageBox.Show("Cierre de caja realizado correctamente.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el cierre de caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ReiniciarGrillaMovimientos()
        {
            // Reiniciar la grilla de movimientos dejando un estado inicial vacío
            dataGridViewMovimientos.Rows.Clear();
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
      

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            //RegistrarMovimiento("Ingreso", Convert.ToDouble(txtMonto.Texts));
            if (!double.TryParse(txtMonto.Texts, out double monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Registrar el ingreso en la grilla de movimientos
            RegistrarMovimientoEnGrilla("Ingreso", monto);

            // Actualizar la grilla de transacciones y los totales
            CargarTransacciones();
        }
    

        private void CargarMovimientos()
        {
            try
            {
                double totalIngresos = 0;
                double totalEgresos = 0;

                foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
                {
                    totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
                    totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
                }

                // Actualizar cuadros de texto
                txtTotalIngresos.Texts = totalIngresos.ToString("F2");
                txtTotalEgresos.Texts = totalEgresos.ToString("F2");

                // Actualizar transacciones
                CargarTransacciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar movimientos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEgreso_Click(object sender, EventArgs e)
        {
            // RegistrarMovimiento("Egreso", Convert.ToDouble(txtMonto.Texts));
            if (!double.TryParse(txtMonto.Texts, out double monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido mayor a cero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Registrar el egreso en la grilla de movimientos
            RegistrarMovimientoEnGrilla("Egreso", monto);

            // Actualizar la grilla de transacciones y los totales
            CargarTransacciones();
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

                // Obtener el ID de la caja actual
                int idCaja = CajaLogica.ObtenerIdCajaActual();
                if (idCaja == -1)
                {
                    MessageBox.Show("No hay caja activa para cargar ventas.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calcular totales desde las transacciones posteriores al último cierre
                var (totalEfectivo, totalTarjeta) = CajaLogica.FiltrarVentasPorUltimoCierre(idCaja);

                // Obtener las transacciones específicas para mostrarlas en la grilla
                var transacciones = VentasLogica.ObtenerTransaccionesPosterioresAlUltimoCierre(idCaja);

                // Llenar la grilla con los datos filtrados
                foreach (var transaccion in transacciones)
                {
                    string metodoPago = transaccion.MetodoPago?.ToLower().Trim();
                    double efectivo = metodoPago == "efectivo" ? transaccion.Total : 0;
                    double tarjeta = (metodoPago == "tarjeta de crédito" || metodoPago == "tarjeta de débito") ? transaccion.Total : 0;

                    dataGridViewVentas.Rows.Add(
                        transaccion.FechaHora.ToString("yyyy-MM-dd HH:mm:ss"),
                        efectivo,
                        tarjeta,
                        totalEfectivo,
                        totalTarjeta
                    );
                }

                // Actualizar los cuadros de texto con los totales
                txtEfectivo.Texts = totalEfectivo.ToString("F2");
                txtTarjeta.Texts = totalTarjeta.ToString("F2");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar ventas: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void ActualizarTextBoxMovimiento()
        {
            double totalIngresos = 0;
            double totalEgresos = 0;

            foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
            {
                totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
                totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
            }

            txtTotalIngresos.Texts = totalIngresos.ToString("F2");
            txtTotalEgresos.Texts = totalEgresos.ToString("F2");
        }
      

        public void RegistrarMovimiento(string tipo, double monto)
        {
            try
            {
                if (monto <= 0)
                {
                    MessageBox.Show("El monto debe ser mayor a 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Determinar si es ingreso o egreso
                string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                double ingreso = tipo == "Ingreso" ? monto : 0;
                double egreso = tipo == "Egreso" ? monto : 0;

                // Calcular totales acumulados
                double totalIngresos = 0;
                double totalEgresos = 0;

                foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
                {
                    totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
                    totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
                }

                totalIngresos += ingreso;
                totalEgresos += egreso;

                // Calcular el total global
                double totalGlobal = totalIngresos - totalEgresos;

                // Agregar a la grilla de movimientos
                dataGridViewMovimientos.Rows.Add(fechaHora, ingreso, egreso, totalIngresos, totalEgresos, totalGlobal);

                // Actualizar los cuadros de texto
                txtTotalIngresos.Texts = totalIngresos.ToString("F2");
                txtTotalEgresos.Texts = totalEgresos.ToString("F2");

                // Actualizar transacciones
                CargarTransacciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el movimiento: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    
        private void CargarTransacciones()
        {
            try
            {
                // Limpiar la grilla de transacciones antes de cargar
                dataGridViewTransacciones.Rows.Clear();

                // Obtener los valores de los cuadros de texto
                double totalEfectivo = ConvertirSeguro(txtEfectivo.Texts);
                double totalTarjeta = ConvertirSeguro(txtTarjeta.Texts);
                double totalIngresos = ConvertirSeguro(txtTotalIngresos.Texts);
                double totalEgresos = ConvertirSeguro(txtTotalEgresos.Texts);

                // Calcular el total global
                double totalGlobal = totalEfectivo + totalTarjeta + totalIngresos - totalEgresos;

                // Cargar los valores en la grilla
                string fecha = DateTime.Now.ToString("yyyy-MM-dd");
                dataGridViewTransacciones.Rows.Add(fecha, totalEfectivo, totalTarjeta, totalIngresos, totalEgresos, totalGlobal);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar transacciones: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private double ConvertirSeguro(object valor)
        {
            if (valor == null || valor == DBNull.Value || string.IsNullOrWhiteSpace(valor.ToString()))
                return 0.0;

            if (double.TryParse(valor.ToString(), out double resultado))
                return resultado;

            throw new FormatException($"El valor '{valor}' no tiene un formato numérico válido.");
        }


       

        private void RegistrarMovimientoEnGrilla(string tipo, double monto)
        {
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            double ingreso = tipo == "Ingreso" ? monto : 0;
            double egreso = tipo == "Egreso" ? monto : 0;

            double totalIngresos = ConvertirSeguro(txtTotalIngresos.Texts) + ingreso;
            double totalEgresos = ConvertirSeguro(txtTotalEgresos.Texts) + egreso;

            double totalGlobal = totalIngresos - totalEgresos;

            dataGridViewMovimientos.Rows.Add(fechaHora, ingreso, egreso, totalIngresos, totalEgresos, totalGlobal);

            txtTotalIngresos.Texts = totalIngresos.ToString("F2");
            txtTotalEgresos.Texts = totalEgresos.ToString("F2");

            CargarTransacciones();
        }


     
        private void ReiniciarCaja()
        {
            // Limpiar las grillas relacionadas
            dataGridViewTransacciones.Rows.Clear();
            dataGridViewMovimientos.Rows.Clear();
            dataGridViewVentas.Rows.Clear();

            // Reiniciar cuadros de texto a 0
            txtEfectivo.Texts = "0.00";
            txtTarjeta.Texts = "0.00";
            txtTotalIngresos.Texts = "0.00";
            txtTotalEgresos.Texts = "0.00";

            // Llamar al método que elimina los totales acumulados en la base de datos
            DatosCaja.ReiniciarTotales();

            // Forzar una fila vacía en la grilla de transacciones
            ReiniciarGrillaTransacciones();
            ReiniciarGrillaMovimientos();
        }

        private void ReiniciarGrillaTransacciones()
        {
            // Agregar una fila inicial con todos los valores en 0
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridViewTransacciones.Rows.Add(fecha, 0.0, 0.0, 0.0, 0.0, 0.0);
        }




        private void btnCierreDeCaja_Click(object sender, EventArgs e)
        {
            }

        private void btnCierreDeCaja_Click_1(object sender, EventArgs e)
        {

            try
            {
                if (dataGridViewTransacciones.Rows.Count == 0)
                {
                    MessageBox.Show("No hay datos para cerrar la caja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener datos de la primera fila de la grilla de transacciones
                DataGridViewRow fila = dataGridViewTransacciones.Rows[0];

                string fechaHora = fila.Cells["Fecha"].Value.ToString();
                double efectivo = Convert.ToDouble(fila.Cells["Efectivo"].Value ?? 0);
                double tarjeta = Convert.ToDouble(fila.Cells["Tarjeta"].Value ?? 0);
                double ingresos = Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
                double egresos = Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
                double total = Convert.ToDouble(fila.Cells["Total"].Value ?? 0);

                // Registrar el cierre en la base de datos
                int idCaja = CajaLogica.ObtenerIdCajaActual();
                DatosCaja.GuardarCierreDeCaja(DateTime.Now, efectivo, tarjeta, ingresos, egresos, total);

                // Limpiar todas las grillas y cuadros de texto
                ReiniciarCaja();

                MessageBox.Show("Cierre de caja realizado correctamente.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar la caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                int idCaja = CajaLogica.ObtenerIdCajaActual();

                CajaLogica.RegistrarCierreDeCaja(idCaja);

                ReiniciarCaja();
                MessageBox.Show("Cierre de caja realizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cerrar la caja: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

