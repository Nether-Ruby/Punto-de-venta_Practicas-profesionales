
//using System;
//using System.Data;
//using System.Windows.Forms;
//using Punto_de_venta___Prácticas_profesionales.Logica;
//using Punto_de_venta___Prácticas_profesionales.Datos;
//using System.Data.SQLite;

//namespace Punto_de_venta___Prácticas_profesionales.Presentación
//{


//    ///
//    public partial class FormCaja : Form
//    {
//        private CajaLogica cajaLogica = new CajaLogica();


//        //public FormCaja()
//        //{
//        //    //InitializeComponent();
//        //    //DatosCaja.InitializeDatabase();
//        //    //ConfigurarDataGridView();
//        //    //ConfigurarGrillaMovimientos();
//        //    //ConfigurarGrillaVentas();
//        //    //CargarMovimientos();
//        //    //CargarVentas();
//        //    //CargarTransacciones();
//        //    //ActualizarTextBox();
//        //    //ReiniciarGrillaTransacciones();


//        //    //diseño 

//        //    InitializeComponent();
//        //    DatosCaja.InitializeDatabase();
//        //    ConfigurarDataGridView();
//        //    ConfigurarGrillaMovimientos();
//        //    ConfigurarGrillaVentas();
//        //    CargarMovimientos();
//        //    CargarVentas();
//        //    CargarTransacciones();
//        //    ActualizarTextBox();
//        //   ReiniciarGrillaTransacciones();

//        //    // Configurar diseño y comportamiento de las grillas
//        //    InicializarEventos();

//        //    CargarMovimientos();
//        //    CargarVentas(); // IMPORTANTE: Asegúrate de que esta llamada esté aquí
//        //    CargarTransacciones();
//        //    ActualizarTextBox();

//        //    dataGridViewMovimientos.Visible = false;
//        //    dataGridViewVentas.Visible = false;
//        //}
//        public FormCaja()
//        {
//            InitializeComponent();

//            // Inicializar base de datos y configurar grillas
//            DatosCaja.InitializeDatabase();
//            ConfigurarDataGridView();
//            ConfigurarGrillaMovimientos();
//            ConfigurarGrillaVentas();

//            // Cargar datos en las grillas y cuadros de texto
//            CargarMovimientos();
//            CargarVentas(); // Llama a CargarVentas ANTES de cambiar la visibilidad
//            CargarTransacciones();
//            ActualizarTextBox();
//            ReiniciarGrillaTransacciones();

//            //// Configurar eventos de los botones
//            //InicializarEventos();

//            //// Ocultar las grillas después de cargarlas
//            //dataGridViewMovimientos.Visible = false;
//            //dataGridViewVentas.Visible = false;
//        }


//        //public void RegistrarCierreDeCaja(DataGridViewRow filaTransacciones)
//        //{
//        //    string fechaHora = filaTransacciones.Cells["Fecha"].Value.ToString();
//        //    double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"].Value ?? 0);
//        //    double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"].Value ?? 0);
//        //    double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"].Value ?? 0);
//        //    double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"].Value ?? 0);
//        //    double total = Convert.ToDouble(filaTransacciones.Cells["Total"].Value ?? 0);

//        //    // Registrar los datos del cierre de caja en la base de datos
//        //    DatosCaja.RegistrarCierreDeCaja(fechaHora, efectivo, tarjeta, ingresos, egresos, total);

//        //    // Reiniciar ingresos y egresos del día
//        //    DatosCaja.ReiniciarIngresosYEgresosDelDia();

//        //    // Recargar la grilla de transacciones para reflejar los cambios
//        //    CargarTransacciones();
//        //}

//        public void RegistrarCierreDeCaja(DataGridViewRow filaTransacciones)
//        {
//            string fechaHora = filaTransacciones.Cells["Fecha"]?.Value?.ToString() ?? DateTime.Now.ToString();
//            double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"]?.Value ?? 0);
//            double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"]?.Value ?? 0);
//            double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"]?.Value ?? 0);
//            double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"]?.Value ?? 0);
//            double total = Convert.ToDouble(filaTransacciones.Cells["Total"]?.Value ?? 0);

//            // Registrar los datos del cierre de caja en la base de datos
//            DatosCaja.RegistrarCierreDeCaja(fechaHora, efectivo, tarjeta, ingresos, egresos, total);

//            // Reiniciar ingresos y egresos del día
//            DatosCaja.ReiniciarIngresosYEgresosDelDia();

//            // Recargar la grilla de transacciones para reflejar los cambios
//            CargarTransacciones();
//        }
//        // Método para convertir de forma segura y evitar valores nulos
//        private double ConvertirSeguro(object valor)
//        {
//            return valor != null && double.TryParse(valor.ToString(), out double resultado) ? resultado : 0;
//        }

//        private void ConfigurarDataGridView()
//        {
//            dataGridViewTransacciones.Columns.Clear();
//            dataGridViewTransacciones.Columns.Add("Fecha", "Fecha");
//            dataGridViewTransacciones.Columns.Add("Efectivo", "Efectivo");
//            dataGridViewTransacciones.Columns.Add("Tarjeta", "Tarjeta");
//            dataGridViewTransacciones.Columns.Add("Ingresos", "Ingresos");
//            dataGridViewTransacciones.Columns.Add("Egresos", "Egresos");
//            dataGridViewTransacciones.Columns.Add("Total", "Total");

//            dataGridViewTransacciones.ReadOnly = true;
//        }

//        private void ConfigurarGrillaMovimientos()
//        {
//            dataGridViewMovimientos.Columns.Clear();
//            dataGridViewMovimientos.Columns.Add("Fecha_Hora", "Fecha y Hora");
//            dataGridViewMovimientos.Columns.Add("Ingresos", "Ingresos");
//            dataGridViewMovimientos.Columns.Add("Egresos", "Egresos");
//            dataGridViewMovimientos.Columns.Add("TotalIngresos", "Total Ingresos");
//            dataGridViewMovimientos.Columns.Add("TotalEgresos", "Total Egresos");
//            dataGridViewMovimientos.Columns.Add("Total", "Total");

//            dataGridViewMovimientos.ReadOnly = true;
//        }

//        private void ConfigurarGrillaVentas()
//        {
//            dataGridViewVentas.Columns.Clear();
//            dataGridViewVentas.Columns.Add("Fecha_Hora", "Fecha y Hora");
//            dataGridViewVentas.Columns.Add("Efectivo", "Efectivo");
//            dataGridViewVentas.Columns.Add("Tarjeta", "Tarjeta");
//            dataGridViewVentas.Columns.Add("TotalEfectivo", "Total Efectivo");
//            dataGridViewVentas.Columns.Add("TotalTarjeta", "Total Tarjeta");

//            //// Configuración opcional
//            //dataGridViewVentas.Columns["Fecha_Hora"].Width = 150;
//            //dataGridViewVentas.Columns["Efectivo"].Width = 100;
//            //dataGridViewVentas.Columns["Tarjeta"].Width = 100;
//            //dataGridViewVentas.Columns["TotalEfectivo"].Width = 120;
//            //dataGridViewVentas.Columns["TotalTarjeta"].Width = 120;

//            // Evitar edición directa por el usuario
//            dataGridViewVentas.ReadOnly = true;
//        }
//        private void CargarMovimientos()
//        {
//            dataGridViewMovimientos.Rows.Clear();

//            // Obtener movimientos desde la lógica
//            var movimientos = cajaLogica.ObtenerMovimientosDelDia();

//            foreach (var movimiento in movimientos)
//            {
//                dataGridViewMovimientos.Rows.Add(
//                    movimiento["FechaHora"],
//                    movimiento["Ingreso"],
//                    movimiento["Egreso"],
//                    movimiento["TotalIngresos"],
//                    movimiento["TotalEgresos"],
//                    movimiento["Total"]
//                );
//            }
//        }

//        private void btnIngreso_Click(object sender, EventArgs e)
//        {
//            RegistrarMovimiento("Ingreso", Convert.ToDouble(txtMonto.Texts));
//        }

//        private void btnEgreso_Click(object sender, EventArgs e)
//        {
//            RegistrarMovimiento("Egreso", Convert.ToDouble(txtMonto.Texts));
//        }

//        private (double, double) CalcularTotalesMovimientos()
//        {
//            double totalIngresos = 0;
//            double totalEgresos = 0;

//            foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
//            {
//                totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
//                totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
//            }

//            return (totalIngresos, totalEgresos);
//        }


//        //este
//        //private void ActualizarTotalesVentas(DataTable ventas)
//        //{
//        //    double totalEfectivo = 0;
//        //    double totalTarjeta = 0;

//        //    foreach (DataRow row in ventas.Rows)
//        //    {
//        //        totalEfectivo += Convert.ToDouble(row["Efectivo"]);
//        //        totalTarjeta += Convert.ToDouble(row["Tarjeta"]);
//        //    }

//        //    // Actualizar cuadros de texto (opcional, por redundancia)
//        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
//        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");

//        //    // Actualizar la grilla de transacciones
//        //    if (dataGridViewTransacciones.Rows.Count > 0)
//        //    {
//        //        var fila = dataGridViewTransacciones.Rows[0];
//        //        fila.Cells["Efectivo"].Value = totalEfectivo;
//        //        fila.Cells["Tarjeta"].Value = totalTarjeta;
//        //    }
//        //}
//        //estos

//        //private void CargarVentas()
//        //{
//        //    dataGridViewVentas.Rows.Clear();

//        //    // Obtener ventas ficticias desde la capa de datos
//        //    DataTable ventas = DatosCaja.ObtenerVentasFicticias();

//        //    double totalEfectivo = 0;
//        //    double totalTarjeta = 0;

//        //    foreach (DataRow row in ventas.Rows)
//        //    {
//        //        double efectivo = Convert.ToDouble(row["Efectivo"]);
//        //        double tarjeta = Convert.ToDouble(row["Tarjeta"]);

//        //        // Sumar los totales para la grilla
//        //        totalEfectivo += efectivo;
//        //        totalTarjeta += tarjeta;

//        //        // Agregar la fila a la grilla de ventas
//        //        dataGridViewVentas.Rows.Add(
//        //            row["Fecha_Hora"],
//        //            efectivo,
//        //            tarjeta,
//        //            totalEfectivo,
//        //            totalTarjeta
//        //        );
//        //    }

//        //    // Actualizar los cuadros de texto
//        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
//        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");
//        //}

//        //private void ActualizarTotalesVentas()
//        //{
//        //    double totalEfectivo = 0;
//        //    double totalTarjeta = 0;

//        //    foreach (DataGridViewRow fila in dataGridViewVentas.Rows)
//        //    {
//        //        totalEfectivo += Convert.ToDouble(fila.Cells["Efectivo"].Value ?? 0);
//        //        totalTarjeta += Convert.ToDouble(fila.Cells["Tarjeta"].Value ?? 0);
//        //    }

//        //    // Actualizar los cuadros de texto
//        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
//        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");

//        //    // Actualizar la grilla de transacciones
//        //    if (dataGridViewTransacciones.Rows.Count > 0)
//        //    {
//        //        var fila = dataGridViewTransacciones.Rows[0];
//        //        fila.Cells["Efectivo"].Value = totalEfectivo;
//        //        fila.Cells["Tarjeta"].Value = totalTarjeta;
//        //    }
//        //}
//        //07
//        public void ActualizarTotalesVentas(DataTable ventas)
//        {
//            double totalEfectivo = 0;
//            double totalTarjeta = 0;

//            // Calcular totales de efectivo y tarjeta
//            foreach (DataRow row in ventas.Rows)
//            {
//                totalEfectivo += Convert.ToDouble(row["Efectivo"]);
//                totalTarjeta += Convert.ToDouble(row["Tarjeta"]);
//            }

//            // Actualizar los cuadros de texto
//            txtEfectivo.Texts = totalEfectivo.ToString("F2");
//            txtTarjeta.Texts = totalTarjeta.ToString("F2");

//            // Asegurar que la tabla de transacciones se actualice correctamente
//            if (dataGridViewTransacciones.Rows.Count > 0)
//            {
//                var fila = dataGridViewTransacciones.Rows[0];
//                fila.Cells["Efectivo"].Value = totalEfectivo;
//                fila.Cells["Tarjeta"].Value = totalTarjeta;
//            }
//        }
//        //public void ActualizarTotalesVentas(DataTable ventas)
//        //{
//        //    double totalEfectivo = 0;
//        //    double totalTarjeta = 0;

//        //    // Calcular totales de efectivo y tarjeta
//        //    foreach (DataRow row in ventas.Rows)
//        //    {
//        //        totalEfectivo += Convert.ToDouble(row["Efectivo"]);
//        //        totalTarjeta += Convert.ToDouble(row["Tarjeta"]);
//        //    }

//        //    // Actualizar los cuadros de texto
//        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
//        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");

//        //    // Asegurar que la tabla de transacciones se actualice correctamente
//        //    if (dataGridViewTransacciones.Rows.Count > 0)
//        //    {
//        //        var fila = dataGridViewTransacciones.Rows[0];
//        //        fila.Cells["Efectivo"].Value = totalEfectivo;
//        //        fila.Cells["Tarjeta"].Value = totalTarjeta;
//        //    }
//        //}
//        //public void ActualizarTotalesVentas(DataTable ventas)
//        //{
//        //    double totalEfectivo = 0;
//        //    double totalTarjeta = 0;

//        //    foreach (DataRow row in ventas.Rows)
//        //    {
//        //        totalEfectivo += Convert.ToDouble(row["Efectivo"]);
//        //        totalTarjeta += Convert.ToDouble(row["Tarjeta"]);
//        //    }

//        //    // Actualizar los cuadros de texto
//        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
//        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");

//        //    // Asegurar que los totales estén reflejados en la tabla de transacciones
//        //    if (dataGridViewTransacciones.Rows.Count > 0)
//        //    {
//        //        var fila = dataGridViewTransacciones.Rows[0];
//        //        fila.Cells["Efectivo"].Value = totalEfectivo;
//        //        fila.Cells["Tarjeta"].Value = totalTarjeta;
//        //    }
//        //}

//        //07
//        public void CargarVentas()
//        {
//            dataGridViewVentas.Rows.Clear();
//            DataTable ventas = DatosCaja.ObtenerVentasFicticias();

//            double totalEfectivo = 0;
//            double totalTarjeta = 0;

//            foreach (DataRow row in ventas.Rows)
//            {
//                double efectivo = Convert.ToDouble(row["Efectivo"]);
//                double tarjeta = Convert.ToDouble(row["Tarjeta"]);

//                // Sumar los totales
//                totalEfectivo += efectivo;
//                totalTarjeta += tarjeta;

//                // Agregar la fila a la grilla de ventas
//                dataGridViewVentas.Rows.Add(row["Fecha_Hora"], efectivo, tarjeta, totalEfectivo, totalTarjeta);
//            }

//            // Actualizar totales en los cuadros de texto y transacciones
//            ActualizarTotalesVentas(ventas);

//        }

//        //ESTE ESSSSSS PARA Q SE VEAN BIEN CONN EL DISEÑO TMB 
//        //public void CargarVentas()
//        //{
//        //    Console.WriteLine("Cargando ventas..."); // Mensaje de depuración
//        //    dataGridViewVentas.Rows.Clear();
//        //    DataTable ventas = DatosCaja.ObtenerVentasFicticias();

//        //    if (ventas == null || ventas.Rows.Count == 0)
//        //    {
//        //        Console.WriteLine("No se encontraron datos de ventas."); // Mensaje de depuración
//        //        return;
//        //    }

//        //    double totalEfectivo = 0;
//        //    double totalTarjeta = 0;

//        //    foreach (DataRow row in ventas.Rows)
//        //    {
//        //        double efectivo = Convert.ToDouble(row["Efectivo"]);
//        //        double tarjeta = Convert.ToDouble(row["Tarjeta"]);

//        //        // Sumar los totales
//        //        totalEfectivo += efectivo;
//        //        totalTarjeta += tarjeta;

//        //        // Agregar la fila a la grilla de ventas
//        //        dataGridViewVentas.Rows.Add(row["Fecha_Hora"], efectivo, tarjeta, totalEfectivo, totalTarjeta);
//        //    }

//        //    Console.WriteLine("Ventas cargadas correctamente."); // Mensaje de depuración
//        //    ActualizarTotalesVentas(ventas);
//        //}


//        //private void ActualizarTextBox()
//        //{

//        //    var (totalIngresos, totalEgresos) = CalcularTotalesMovimientos();


//        //    if (dataGridViewTransacciones.Rows.Count > 0)
//        //    {
//        //        var fila = dataGridViewTransacciones.Rows[0];
//        //        txtEfectivo.Texts = fila.Cells["Efectivo"].Value.ToString();
//        //        txtTarjeta.Texts = fila.Cells["Tarjeta"].Value.ToString();
//        //    }

//        //    txtTotalIngresos.Texts = totalIngresos.ToString("F2");
//        //    txtTotalEgresos.Texts = totalEgresos.ToString("F2");
//        //    }

//        private void ActualizarTextBox()
//        {
//            // Calcular totales de ingresos y egresos desde la grilla de movimientos
//            var (totalIngresos, totalEgresos) = CalcularTotalesMovimientos();

//            // Obtener datos de efectivo y tarjeta desde la grilla de ventas
//            double totalEfectivo = 0;
//            double totalTarjeta = 0;
//            foreach (DataGridViewRow fila in dataGridViewVentas.Rows)
//            {
//                totalEfectivo += Convert.ToDouble(fila.Cells["Efectivo"].Value ?? 0);
//                totalTarjeta += Convert.ToDouble(fila.Cells["Tarjeta"].Value ?? 0);
//            }

//            // Actualizar los cuadros de texto
//            txtEfectivo.Texts = totalEfectivo.ToString("F2");
//            txtTarjeta.Texts = totalTarjeta.ToString("F2");
//            txtTotalIngresos.Texts = totalIngresos.ToString("F2");
//            txtTotalEgresos.Texts = totalEgresos.ToString("F2");
//        }




//        //07
//        private void RegistrarMovimientoEnGrilla(string tipo, double monto)
//        {
//            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

//            // Determinar si es un ingreso o un egreso
//            double ingreso = tipo == "Ingreso" ? monto : 0;
//            double egreso = tipo == "Egreso" ? monto : 0;

//            // Calcular totales acumulados en la grilla Movimientos
//            double totalIngresos = 0;
//            double totalEgresos = 0;

//            foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
//            {
//                totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
//                totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
//            }

//            totalIngresos += ingreso;
//            totalEgresos += egreso;

//            // Calcular el total final
//            double total = totalIngresos - totalEgresos;

//            // Agregar el nuevo movimiento a la grilla
//            dataGridViewMovimientos.Rows.Add(fechaHora, ingreso, egreso, totalIngresos, totalEgresos, total);

//            // Actualizar las vistas
//            ActualizarTextBox();
//            CargarTransacciones();
//        }



//        //tmb
//        //private void RegistrarMovimientoEnGrilla(string tipo, double monto)
//        //{
//        //    string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

//        //    // Determinar si es un ingreso o un egreso
//        //    double ingreso = tipo == "Ingreso" ? monto : 0;
//        //    double egreso = tipo == "Egreso" ? monto : 0;

//        //    // Calcular totales acumulados en la grilla Movimientos
//        //    double totalIngresos = 0;
//        //    double totalEgresos = 0;

//        //    foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
//        //    {
//        //        totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
//        //        totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
//        //    }

//        //    totalIngresos += ingreso;
//        //    totalEgresos += egreso;

//        //    // Calcular el total final
//        //    double total = totalIngresos - totalEgresos;

//        //    // Agregar el nuevo movimiento a la grilla
//        //    dataGridViewMovimientos.Rows.Add(fechaHora, ingreso, egreso, totalIngresos, totalEgresos, total);

//        //    // Actualizar las vistas
//        //    ActualizarTextBox();
//        //    CargarTransacciones();
//        //}




//        //public void RegistrarMovimiento(string tipo, double monto)
//        //{
//        //    // Registrar el movimiento en la base de datos
//        //    cajaLogica.RegistrarMovimiento(tipo, monto);

//        //    // Agregar el movimiento a la grilla de movimientos
//        //    RegistrarMovimientoEnGrilla(tipo, monto);

//        //    // Actualizar todas las vistas
//        //    CargarVentas();        // Actualiza la grilla de ventas
//        //    CargarTransacciones(); // Actualiza la grilla de transacciones
//        //    ActualizarTextBox();   // Actualiza los cuadros de texto
//        //                           //}
//        //}

//        //public void RegistrarMovimiento(string tipo, double monto)
//        //{
//        //    // Registrar el movimiento en la base de datos
//        //    cajaLogica.RegistrarMovimiento(tipo, monto);

//        //    // Agregar el movimiento a la grilla de movimientos
//        //    RegistrarMovimientoEnGrilla(tipo, monto);

//        //    // Recargar la grilla de transacciones para reflejar los nuevos totales
//        //    CargarTransacciones();

//        //    // Actualizar los cuadros de texto (ingresos/egresos totales)
//        //    ActualizarTextBox();
//        //}
//        public void RegistrarMovimiento(string tipo, double monto)
//        {
//            // Registrar el movimiento en la base de datos
//            cajaLogica.RegistrarMovimiento(tipo, monto);

//            // Actualizar la grilla de movimientos con el nuevo registro
//            RegistrarMovimientoEnGrilla(tipo, monto);

//            // Recargar la grilla de transacciones para reflejar los cambios
//            CargarTransacciones();

//            // Actualizar los cuadros de texto
//            ActualizarTextBox();
//        }



//        // 07
//        //public void CargarTransacciones()
//        //{
//        //    // Limpiar la tabla de transacciones
//        //    dataGridViewTransacciones.Rows.Clear();

//        //    // Obtener el resumen del día
//        //    var resumen = DatosCaja.ObtenerResumenDelDia();
//        //    if (resumen != null)
//        //    {
//        //        string fecha = DateTime.Now.ToString("yyyy-MM-dd");

//        //        // Convertir valores de forma segura para evitar excepciones
//        //        double efectivo = ConvertirSeguro(resumen["Efectivo"]);
//        //        double tarjeta = ConvertirSeguro(resumen["Tarjeta"]);
//        //        double ingresos = ConvertirSeguro(resumen["Ingresos"]);
//        //        double egresos = ConvertirSeguro(resumen["Egresos"]);
//        //        double total = ConvertirSeguro(resumen["Total"]);

//        //        // Agregar la fila actualizada a la tabla de transacciones
//        //        dataGridViewTransacciones.Rows.Add(fecha, efectivo, tarjeta, ingresos, egresos, total);
//        //    }
//        //}
//        //09
//        public void CargarTransacciones()
//        {
//            // Limpiar la grilla de transacciones
//            dataGridViewTransacciones.Rows.Clear();

//            // Obtener el resumen del día actual
//            var resumen = DatosCaja.ObtenerResumenDelDia();
//            if (resumen != null)
//            {
//                string fecha = DateTime.Now.ToString("yyyy-MM-dd");
//                double efectivo = ConvertirSeguro(resumen["Efectivo"]);
//                double tarjeta = ConvertirSeguro(resumen["Tarjeta"]);
//                double ingresos = ConvertirSeguro(resumen["Ingresos"]);
//                double egresos = ConvertirSeguro(resumen["Egresos"]);
//                double total = ConvertirSeguro(resumen["Total"]);

//                // Agregar el resumen del día actual a la grilla de transacciones
//                dataGridViewTransacciones.Rows.Add(fecha, efectivo, tarjeta, ingresos, egresos, total);
//            }
//        }

//        //0
//        //public void CargarTransacciones()
//        //{
//        //    // Limpiar la grilla de transacciones
//        //    dataGridViewTransacciones.Rows.Clear();

//        //    // Obtener el resumen del día actual
//        //    var resumen = DatosCaja.ObtenerResumenDelDia();
//        //    if (resumen != null)
//        //    {
//        //        string fecha = DateTime.Now.ToString("yyyy-MM-dd");
//        //        double efectivo = ConvertirSeguro(resumen["Efectivo"]);
//        //        double tarjeta = ConvertirSeguro(resumen["Tarjeta"]);
//        //        double ingresos = ConvertirSeguro(resumen["Ingresos"]);
//        //        double egresos = ConvertirSeguro(resumen["Egresos"]);
//        //        double total = ConvertirSeguro(resumen["Total"]);

//        //        // Agregar el resumen del día actual a la grilla de transacciones
//        //        dataGridViewTransacciones.Rows.Add(fecha, efectivo, tarjeta, ingresos, egresos, total);
//        //    }
//        //}


//        //tmb
//        //public void CargarTransacciones()
//        //{
//        //    // Limpiar la tabla de transacciones
//        //    dataGridViewTransacciones.Rows.Clear();

//        //    // Obtener el resumen del día
//        //    var resumen = DatosCaja.ObtenerResumenDelDia();
//        //    if (resumen != null)
//        //    {
//        //        string fecha = DateTime.Now.ToString("yyyy-MM-dd");

//        //        // Convertir valores de forma segura para evitar excepciones
//        //        double efectivo = ConvertirSeguro(resumen["Efectivo"]);
//        //        double tarjeta = ConvertirSeguro(resumen["Tarjeta"]);
//        //        double ingresos = ConvertirSeguro(resumen["Ingresos"]);
//        //        double egresos = ConvertirSeguro(resumen["Egresos"]);
//        //        double total = ConvertirSeguro(resumen["Total"]);

//        //        // Agregar la fila actualizada a la tabla de transacciones
//        //        dataGridViewTransacciones.Rows.Add(fecha, efectivo, tarjeta, ingresos, egresos, total);
//        //    }
//        //}




//        // Método de conversión segura
//        //private double ConvertirSeguro(object valor)
//        //{
//        //    return valor != DBNull.Value && double.TryParse(valor.ToString(), out double resultado) ? resultado : 0;
//        //}


//        // Método de conversión segura


//        private void ReiniciarGrillaTransacciones()
//        {
//            dataGridViewTransacciones.Rows.Clear();
//            // Agregar una fila vacía con valores en 0 para iniciar nuevamente
//            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
//            dataGridViewTransacciones.Rows.Add(fecha, 0.0, 0.0, 0.0, 0.0, 0.0);
//        }
//        private void FormCaja_Load(object sender, EventArgs e)
//        {

//        }

//        //07
//        private void ReiniciarCaja()
//        {
//            // Reiniciar la grilla de transacciones
//            dataGridViewTransacciones.Rows.Clear();
//            dataGridViewTransacciones.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd"), 0, 0, 0, 0, 0);

//            // Reiniciar la grilla de movimientos
//            dataGridViewMovimientos.Rows.Clear();

//            // Reiniciar la grilla de ventas
//            dataGridViewVentas.Rows.Clear();

//            // Reiniciar los cuadros de texto
//            txtEfectivo.Texts = "0";
//            txtTarjeta.Texts = "0";
//            txtTotalIngresos.Texts = "0";
//            txtTotalEgresos.Texts = "0";

//            // Reiniciar los totales en la base de datos
//            DatosCaja.ReiniciarTotales();
//        }
//        //dise
//        //private void ReiniciarCaja()
//        //{
//        //    // Reiniciar las grillas de transacciones y movimientos
//        //    dataGridViewTransacciones.Rows.Clear();
//        //    dataGridViewMovimientos.Rows.Clear();

//        //    // Crear una nueva fila inicial en la grilla de transacciones
//        //    string fecha = DateTime.Now.ToString("yyyy-MM-dd");
//        //    dataGridViewTransacciones.Rows.Add(fecha, 0.0, 0.0, 0.0, 0.0, 0.0);

//        //    // Reiniciar los cuadros de texto
//        //    txtEfectivo.Texts = "0";
//        //    txtTarjeta.Texts = "0";
//        //    txtTotalIngresos.Texts = "0";
//        //    txtTotalEgresos.Texts = "0";

//        //    // Reiniciar los totales de ingresos y egresos en la base de datos (solo el día actual)
//        //    DatosCaja.ReiniciarIngresosYEgresosDelDia();

//        //    // La grilla de ventas NO se reinicia porque debe conservarse
//        //    // AÑADIR: Reiniciar también la grilla de ventas
//        //    dataGridViewVentas.Rows.Clear();
//        //    // Si es necesario, puedes agregar una fila inicial vacía
//        //    //dataGridViewVentas.Rows.Add(fecha, 0.0, 0.0, 0.0, 0.0);

//        //}

//        //tmb
//        //private void ReiniciarCaja()
//        //{
//        //    // Reiniciar la grilla de movimientos
//        //    dataGridViewMovimientos.Rows.Clear();

//        //    // Reiniciar la grilla de ventas
//        //    dataGridViewVentas.Rows.Clear();

//        //    // Reiniciar la grilla de transacciones
//        //    dataGridViewTransacciones.Rows.Clear();

//        //    // Reiniciar los cuadros de texto
//        //    txtEfectivo.Texts = "0";
//        //    txtTarjeta.Texts = "0";
//        //    txtTotalIngresos.Texts = "0";
//        //    txtTotalEgresos.Texts = "0";

//        //    // Reiniciar los totales en la base de datos
//        //    DatosCaja.ReiniciarTotales();

//        //    // Volver a cargar la grilla de transacciones con valores iniciales
//        //    CargarTransacciones();
//        //}





//        private void btnCierreDeCaja_Click(object sender, EventArgs e)
//        {
//            // Verificar si hay datos en la grilla de transacciones
//            if (dataGridViewTransacciones.Rows.Count == 0 || dataGridViewTransacciones.Rows[0].Cells["Total"].Value == null)
//            {
//                MessageBox.Show("No hay datos para realizar el cierre de caja.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // Registrar los datos de la grilla de transacciones en la base de datos
//            var filaTransacciones = dataGridViewTransacciones.Rows[0];
//            string fechaHora = filaTransacciones.Cells["Fecha"].Value.ToString();
//            double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"].Value ?? 0);
//            double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"].Value ?? 0);
//            double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"].Value ?? 0);
//            double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"].Value ?? 0);
//            double total = Convert.ToDouble(filaTransacciones.Cells["Total"].Value ?? 0);

//            DatosCaja.GuardarCierreDeCaja(DateTime.Now, efectivo, tarjeta, ingresos, egresos, total);

//            // Reiniciar la caja
//            ReiniciarCaja();

//            MessageBox.Show("Cierre de caja realizado correctamente.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnCierreDeCaja_Click_1(object sender, EventArgs e)
//        {
//            if (dataGridViewTransacciones.Rows.Count == 0 || dataGridViewTransacciones.Rows[0].Cells["Total"].Value == null)
//            {
//                MessageBox.Show("No hay datos para realizar el cierre de caja.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // Registrar los datos de la grilla de transacciones en la base de datos
//            var filaTransacciones = dataGridViewTransacciones.Rows[0];
//            string fechaHora = filaTransacciones.Cells["Fecha"].Value.ToString();
//            double efectivo = Convert.ToDouble(filaTransacciones.Cells["Efectivo"].Value ?? 0);
//            double tarjeta = Convert.ToDouble(filaTransacciones.Cells["Tarjeta"].Value ?? 0);
//            double ingresos = Convert.ToDouble(filaTransacciones.Cells["Ingresos"].Value ?? 0);
//            double egresos = Convert.ToDouble(filaTransacciones.Cells["Egresos"].Value ?? 0);
//            double total = Convert.ToDouble(filaTransacciones.Cells["Total"].Value ?? 0);

//            DatosCaja.GuardarCierreDeCaja(DateTime.Now, efectivo, tarjeta, ingresos, egresos, total);

//            // Reiniciar la caja
//            ReiniciarCaja();
//            CargarVentas();

//            MessageBox.Show("Cierre de caja realizado correctamente.", "Cierre de Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);

//        }

//        private void panel1_Paint(object sender, PaintEventArgs e)
//        {

//        }
//        //diseño 


//        // Método para inicializar los eventos de los botones
//        //private void InicializarEventos()
//        //{
//        //    // Asegúrate de que los nombres btnMovimientos y btnVentas
//        //    // sean los mismos que configuraste en el diseñador
//        //    // btnMovimientos.Click += BtnMovimientos_Click;
//        //    // btnVentas.Click += BtnVentas_Click;

//        //    // Ocultar las grillas al inicio
//        //    dataGridViewMovimientos.Visible = false;
//        //    dataGridViewVentas.Visible = false;
//        //    dataGridViewTransacciones.Visible = false;
//        //}

//        private void btnMovimientos_Click(object sender, EventArgs e)
//        {
//            //dataGridViewMovimientos.Visible = true;
//            //dataGridViewVentas.Visible = false;
//            //dataGridViewMovimientos.Dock = DockStyle.Fill; // Asegurar que se expanda

//        }

//        private void btnVentas_Click(object sender, EventArgs e)
//        {

//            //dataGridViewVentas.Visible = true;
//            //dataGridViewMovimientos.Visible = false;
//            //dataGridViewVentas.Dock = DockStyle.Fill; // Asegurar que se expanda

//        }

//        private void classBtnPersonalizado1_Click(object sender, EventArgs e)
//        {
//        //    dataGridViewTransacciones.Visible = true;
//        //    dataGridViewTransacciones.Dock = DockStyle.Fill;
//        }

//        // Evento para mostrar la grilla de movimientos


//    }


//}


///////////////////////////////////////////////////////////////////////////////////
///porfa san expedito /
///
using System;
using System.Data;
using System.Windows.Forms;
using Punto_de_venta___Prácticas_profesionales.Logica;
using Punto_de_venta___Prácticas_profesionales.Datos;
using System.Data.SQLite;
using Punto_de_venta___Prácticas_profesionales.Lógica;

namespace Punto_de_venta___Prácticas_profesionales.Presentación
{


    ///
    public partial class FormCaja : Form
    {
        private CajaLogica cajaLogica = new CajaLogica();


        //public FormCaja()
        //{
        //    InitializeComponent();
        //    DatosCaja.InitializeDatabase();
        //    ConfigurarDataGridView();
        //    ConfigurarGrillaMovimientos();
        //    CargarMovimientos();
        //    CargarTransacciones();
        //    ActualizarTextBox();
        //}
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



        //

  

        //07
        public void ActualizarTotalesVentas(DataTable ventas)
        {
            double totalEfectivo = 0;
            double totalTarjeta = 0;

            // Calcular totales de efectivo y tarjeta
            foreach (DataRow row in ventas.Rows)
            {
                totalEfectivo += Convert.ToDouble(row["Efectivo"]);
                totalTarjeta += Convert.ToDouble(row["Tarjeta"]);
            }

            // Actualizar los cuadros de texto
            txtEfectivo.Texts = totalEfectivo.ToString("F2");
            txtTarjeta.Texts = totalTarjeta.ToString("F2");

            // Asegurar que la tabla de transacciones se actualice correctamente
            if (dataGridViewTransacciones.Rows.Count > 0)
            {
                var fila = dataGridViewTransacciones.Rows[0];
                fila.Cells["Efectivo"].Value = totalEfectivo;
                fila.Cells["Tarjeta"].Value = totalTarjeta;
            }
        }
        //public void ActualizarTotalesVentas(DataTable ventas)
        //{
        //    double totalEfectivo = 0;
        //    double totalTarjeta = 0;

        //    // Calcular totales de efectivo y tarjeta
        //    foreach (DataRow row in ventas.Rows)
        //    {
        //        totalEfectivo += Convert.ToDouble(row["Efectivo"]);
        //        totalTarjeta += Convert.ToDouble(row["Tarjeta"]);
        //    }

        //    // Actualizar los cuadros de texto
        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");

        //    // Asegurar que la tabla de transacciones se actualice correctamente
        //    if (dataGridViewTransacciones.Rows.Count > 0)
        //    {
        //        var fila = dataGridViewTransacciones.Rows[0];
        //        fila.Cells["Efectivo"].Value = totalEfectivo;
        //        fila.Cells["Tarjeta"].Value = totalTarjeta;
        //    }
        //}


        //07
        //public void CargarVentas()
        //{
        //    dataGridViewVentas.Rows.Clear();
        //    DataTable ventas = DatosCaja.ObtenerVentasFicticias();

        //    double totalEfectivo = 0;
        //    double totalTarjeta = 0;

        //    foreach (DataRow row in ventas.Rows)
        //    {
        //        double efectivo = Convert.ToDouble(row["Efectivo"]);
        //        double tarjeta = Convert.ToDouble(row["Tarjeta"]);

        //        // Sumar los totales
        //        totalEfectivo += efectivo;
        //        totalTarjeta += tarjeta;

        //        // Agregar la fila a la grilla de ventas
        //        dataGridViewVentas.Rows.Add(row["Fecha_Hora"], efectivo, tarjeta, totalEfectivo, totalTarjeta);
        //    }

        //    // Actualizar totales en los cuadros de texto y transacciones
        //    ActualizarTotalesVentas(ventas);
        //}
        //prueba ventas reales 
        //public void CargarVentas()
        //{
        //    // Limpiar la grilla de ventas
        //    dataGridViewVentas.Rows.Clear();

        //    // Obtener los totales de ventas reales
        //    var (totalEfectivo, totalTarjeta) = DatosCaja.ObtenerTotalesVentasReales();

        //    // Sumar los totales al mostrar en la grilla
        //    dataGridViewVentas.Rows.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), totalEfectivo, totalTarjeta, totalEfectivo, totalTarjeta);

        //    // Actualizar los cuadros de texto
        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");
        //}


        //public void CargarVentas()
        //{
        //    // Limpiar la grilla
        //    dataGridViewVentas.Rows.Clear();

        //    // Obtener los totales de ventas
        //    var (totalEfectivo, totalTarjeta) = DatosCaja.ObtenerTotalesVentasReales();

        //    // Agregar los totales a la grilla
        //    dataGridViewVentas.Rows.Add(
        //        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Fecha
        //        totalEfectivo,                                // Efectivo
        //        totalTarjeta,                                // Tarjeta
        //        totalEfectivo,                                // Acumulado Efectivo
        //        totalTarjeta                                 // Acumulado Tarjeta
        //    );

        //    // Actualizar los cuadros de texto
        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");
        //}
        //private void CargarVentas()
        //{
        //    // Limpiar la grilla de ventas
        //    dataGridViewVentas.Rows.Clear();

        //    // Obtener las ventas del día
        //    var ventas = VentasLogica.ObtenerTransaccionesDelDia();

        //    // Calcular los totales de efectivo y tarjeta
        //    var totales = CajaLogica.CalcularTotalesDesdeVentas(ventas);

        //    double totalEfectivo = totales.totalEfectivo;
        //    double totalTarjeta = totales.totalTarjeta;

        //    // Agregar los totales a la grilla de ventas
        //    dataGridViewVentas.Rows.Add(
        //        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
        //        totalEfectivo,
        //        totalTarjeta,
        //        totalEfectivo,
        //        totalTarjeta
        //    );

        //    // Actualizar los cuadros de texto
        //    txtEfectivo.Texts = totalEfectivo.ToString("F2");
        //    txtTarjeta.Texts = totalTarjeta.ToString("F2");
        //}
        private void CargarVentas()
        {
            // Limpiar la grilla de ventas
            dataGridViewVentas.Rows.Clear();

            // Obtener los totales de ventas reales desde la base de datos
            var (totalEfectivo, totalTarjeta) = DatosCaja.ObtenerTotalesVentasReales();

            // Calcular los acumulados para efectivo y tarjeta
            double acumuladoEfectivo = totalEfectivo;
            double acumuladoTarjeta = totalTarjeta;

            // Insertar una fila en la grilla de ventas
            dataGridViewVentas.Rows.Add(
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), // Fecha actual
                totalEfectivo,                                // Efectivo del día
                totalTarjeta,                                // Tarjeta del día
                acumuladoEfectivo,                           // Total acumulado en efectivo
                acumuladoTarjeta                             // Total acumulado en tarjeta
            );

            // Actualizar los cuadros de texto
            txtEfectivo.Texts = acumuladoEfectivo.ToString("F2");
            txtTarjeta.Texts = acumuladoTarjeta.ToString("F2");
        }



        private void ActualizarTextBox()
        {
            // Calcular totales de ingresos y egresos desde la grilla de movimientos
            var (totalIngresos, totalEgresos) = CalcularTotalesMovimientos();

            // Obtener datos de efectivo y tarjeta desde la grilla de ventas
            double totalEfectivo = 0;
            double totalTarjeta = 0;
            foreach (DataGridViewRow fila in dataGridViewVentas.Rows)
            {
                totalEfectivo += Convert.ToDouble(fila.Cells["Efectivo"].Value ?? 0);
                totalTarjeta += Convert.ToDouble(fila.Cells["Tarjeta"].Value ?? 0);
            }

            // Actualizar los cuadros de texto
            txtEfectivo.Texts = totalEfectivo.ToString("F2");
            txtTarjeta.Texts = totalTarjeta.ToString("F2");
            txtTotalIngresos.Texts = totalIngresos.ToString("F2");
            txtTotalEgresos.Texts = totalEgresos.ToString("F2");
        }




        //07
        private void RegistrarMovimientoEnGrilla(string tipo, double monto)
        {
            string fechaHora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // Determinar si es un ingreso o un egreso
            double ingreso = tipo == "Ingreso" ? monto : 0;
            double egreso = tipo == "Egreso" ? monto : 0;

            // Calcular totales acumulados en la grilla Movimientos
            double totalIngresos = 0;
            double totalEgresos = 0;

            foreach (DataGridViewRow fila in dataGridViewMovimientos.Rows)
            {
                totalIngresos += Convert.ToDouble(fila.Cells["Ingresos"].Value ?? 0);
                totalEgresos += Convert.ToDouble(fila.Cells["Egresos"].Value ?? 0);
            }

            totalIngresos += ingreso;
            totalEgresos += egreso;

            // Calcular el total final
            double total = totalIngresos - totalEgresos;

            // Agregar el nuevo movimiento a la grilla
            dataGridViewMovimientos.Rows.Add(fechaHora, ingreso, egreso, totalIngresos, totalEgresos, total);

            // Actualizar las vistas
            ActualizarTextBox();
            CargarTransacciones();
        }



       
        




 
        public void RegistrarMovimiento(string tipo, double monto)
        {
            // Registrar el movimiento en la base de datos
            cajaLogica.RegistrarMovimiento(tipo, monto);

            // Actualizar la grilla de movimientos con el nuevo registro
            RegistrarMovimientoEnGrilla(tipo, monto);

            // Recargar la grilla de transacciones para reflejar los cambios
            CargarTransacciones();

            // Actualizar los cuadros de texto
            ActualizarTextBox();
        }


        //07
        //public void CargarTransacciones()
        //{
        //    // Limpiar la grilla de transacciones
        //    dataGridViewTransacciones.Rows.Clear();

        //    // Obtener el resumen del día actual
        //    var resumen = DatosCaja.ObtenerResumenDelDia();
        //    if (resumen != null)
        //    {
        //        string fecha = DateTime.Now.ToString("yyyy-MM-dd");
        //        double efectivo = ConvertirSeguro(resumen["Efectivo"]);
        //        double tarjeta = ConvertirSeguro(resumen["Tarjeta"]);
        //        double ingresos = ConvertirSeguro(resumen["Ingresos"]);
        //        double egresos = ConvertirSeguro(resumen["Egresos"]);
        //        double total = ConvertirSeguro(resumen["Total"]);

        //        // Agregar el resumen del día actual a la grilla de transacciones
        //        dataGridViewTransacciones.Rows.Add(fecha, efectivo, tarjeta, ingresos, egresos, total);
        //    }
        //}

        //prueba ventas totales 
        //public void CargarTransacciones()
        //{
        //    // Limpiar la grilla de transacciones
        //    dataGridViewTransacciones.Rows.Clear();

        //    // Obtener el resumen del día
        //    var resumen = DatosCaja.ObtenerResumenDelDia();

        //    if (resumen != null)
        //    {
        //        string fecha = DateTime.Now.ToString("yyyy-MM-dd");
        //        double efectivo = ConvertirSeguro(resumen["Efectivo"]);
        //        double tarjeta = ConvertirSeguro(resumen["Tarjeta"]);
        //        double ingresos = ConvertirSeguro(resumen["Ingresos"]);
        //        double egresos = ConvertirSeguro(resumen["Egresos"]);
        //        double total = ConvertirSeguro(resumen["Total"]);

        //        // Reflejar los datos reales en la grilla
        //        dataGridViewTransacciones.Rows.Add(fecha, efectivo, tarjeta, ingresos, egresos, total);
        //    }
        //}
        //esta grilla conecta perfectamnete con la grilla de ventas y los texbox, por primera vez
        private void CargarTransacciones()
        {
            // Limpiar la grilla de transacciones
            dataGridViewTransacciones.Rows.Clear();

            // Obtener las ventas del día desde VentasLogica
            var ventas = VentasLogica.ObtenerTransaccionesDelDia();

            // Calcular los totales de efectivo y tarjeta desde las ventas
            var (totalEfectivo, totalTarjeta) = CajaLogica.CalcularTotalesDesdeVentas(ventas);

            // Obtener los totales de movimientos (ingresos y egresos) desde la grilla de movimientos
            var (totalIngresos, totalEgresos) = CalcularTotalesMovimientos();

            // Calcular el total global
            double totalGlobal = totalEfectivo + totalTarjeta + totalIngresos - totalEgresos;

            // Agregar los datos calculados a la grilla de transacciones
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridViewTransacciones.Rows.Add(
                fecha,            // Fecha
                totalEfectivo,    // Total efectivo
                totalTarjeta,     // Total tarjeta
                totalIngresos,    // Total ingresos
                totalEgresos,     // Total egresos
                totalGlobal       // Total global
            );

            // Actualizar los cuadros de texto (si los tienes en tu formulario)
            txtEfectivo.Texts = totalEfectivo.ToString("F2");
            txtTarjeta.Texts = totalTarjeta.ToString("F2");
            txtTotalIngresos.Texts = totalIngresos.ToString("F2");
            txtTotalEgresos.Texts = totalEgresos.ToString("F2");
        }

        //public void CargarTransacciones()
        //{
        //    // Limpiar la grilla de transacciones
        //    dataGridViewTransacciones.Rows.Clear();

        //    // Obtener los totales desde las ventas
        //    var ventas = VentasLogica.ObtenerTransaccionesDelDia(); // Función del lado de ventas
        //    var (totalEfectivo, totalTarjeta) = DatosCaja.CalcularTotalesDesdeVentas(ventas);

        //    // Obtener los ingresos y egresos
        //    var (totalIngresos, totalEgresos) = CalcularTotalesMovimientos();

        //    // Agregar los datos a la grilla de transacciones
        //    string fecha = DateTime.Now.ToString("yyyy-MM-dd");
        //    dataGridViewTransacciones.Rows.Add(
        //        fecha,
        //        totalEfectivo,
        //        totalTarjeta,
        //        totalIngresos,
        //        totalEgresos,
        //        totalEfectivo + totalTarjeta - totalEgresos
        //    );
        //}





        // Método de conversión segura
        private double ConvertirSeguro(object valor)
        {
            return valor != DBNull.Value && double.TryParse(valor.ToString(), out double resultado) ? resultado : 0;
        }


        // Método de conversión segura


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
            // Reiniciar las grillas de transacciones y movimientos
            dataGridViewTransacciones.Rows.Clear();
            dataGridViewMovimientos.Rows.Clear();

            // Crear una nueva fila inicial en la grilla de transacciones
            string fecha = DateTime.Now.ToString("yyyy-MM-dd");
            dataGridViewTransacciones.Rows.Add(fecha, 0.0, 0.0, 0.0, 0.0, 0.0);

            // Reiniciar los cuadros de texto
            txtEfectivo.Texts = "0";
            txtTarjeta.Texts = "0";
            txtTotalIngresos.Texts = "0";
            txtTotalEgresos.Texts = "0";

            // Reiniciar los totales de ingresos y egresos en la base de datos (solo el día actual)
            DatosCaja.ReiniciarIngresosYEgresosDelDia();

            // La grilla de ventas NO se reinicia porque debe conservarse
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
            var diagnostico = DatosCaja.DiagnosticoVentas();
            MessageBox.Show(string.Join("\n", diagnostico), "Diagnóstico de Ventas");
            //var ventas = DatosCaja.DiagnosticoVentas();
            //if (ventas.Count == 0)
            //{
            //    MessageBox.Show("No se encontraron ventas registradas.", "Diagnóstico", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else
            //{
            //    MessageBox.Show(string.Join("\n", ventas), "Ventas Registradas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

    }
}











/*
 *        //sof

        internal static List<Transaccion> ObtenerTransaccionesDelDia()
        {
            var todasLasTransacciones = new List<Transaccion>
    {
        new Transaccion
        {
            FechaHora = DateTime.Now,
            MetodoPago = "Efectivo",
            Total = 150.00
        },
        new Transaccion
        {
            FechaHora = DateTime.Now,
            MetodoPago = "Tarjeta de Crédito",
            Total = 200.00
        }
    };

            // Filtrar por fecha actual
            return todasLasTransacciones
                .Where(t => t.FechaHora.Date == DateTime.Now.Date)
                .ToList();
        }

 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 */
