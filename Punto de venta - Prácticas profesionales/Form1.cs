using FontAwesome.Sharp;
using Punto_de_venta___Prácticas_profesionales.Lógica;
using System.Data;
using System.Globalization;
using System.ComponentModel;



namespace Punto_de_venta___Prácticas_profesionales
{
    public partial class Form1 : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        /////////
        private readonly reportesLogica reportesLogica = new reportesLogica();


        public Form1()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);

            //saca los bordes del formulario
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            ////////////////caja reportes////////////////////////
            ConfigurarComboboxes();
            CargarDatos(); // Mostrar todos los datos al cargar el formulario
            pnCaja.Visible = false;
            /// EstilizarDataGridView(); // Estilizar el DataGridView de cajas
            // CentrarDataGridViewCajas();   // Centrar el DataGridView de cajas dentro del panel
            // Estilizar los DataGridView
            EstilizarDataGridView(dgvCajas);
            EstilizarDataGridView(dgvDetalleVenta);
            EstilizarDataGridView(dgvVentas);
            EstilizarDataGridView(dgvArticulos);

            // Centrar los DataGridView en sus respectivos paneles
            CentrarDataGridView(dgvCajas, pnCaja);
            CentrarDataGridView(dgvDetalleVenta, pnDetallesVentas);
            CentrarDataGridView(dgvVentas, pnVentas);
            CentrarDataGridView(dgvArticulos, pnArticulos);
            /////////////////ventas reporte///////////////////////
            ConfigurarFiltrosVentas();
            CargarDatosVentas();
            pnVentas.Visible = false;
            pnDetallesVentas.Visible = false;
            //////////////////articulo reportes////////////////
            pnArticulos.Visible = false;
            CargarArticulos();
            ConfigurarCbx();
        }
        private struct RGBcolors
        {
            //opcional
            public static Color color1 = Color.Orange;
            //public static Color color2 = Color.Orange;
            //public static Color color3 = Color.FromArgb(15, 8, 196);
            //public static Color color4 = Color.FromArgb(172, 126, 241);
            //public static Color color5 = Color.FromArgb(172, 126, 241);
            //public static Color color6 = Color.FromArgb(172, 126, 241);

        }
        //metodo
        private void ActivateButton(object senderBtn, Color color)
        {
            DisableButton();
            if (senderBtn != null)
            {
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                // currentBtn.IconColor = Color.Orange; //esto es para q al dar click cambe el color del icono pero no mg

                iconoActual.IconChar = currentBtn.IconChar;
                iconoActual.IconColor = color;

            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(21, 9, 49);
                currentBtn.ForeColor = Color.White;

            }
        }

        private void openChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }

            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelEscritorio.Controls.Add(childForm);
            panelEscritorio.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            // esta condicion la podes usar en el caso que quieras que reportes solo se muestre en caja 
            //(o en cualquier formuario q necesites git add "Punto de venta - Prácticas profesionales/controlesPersonalizados/Botones.Designer.cs")
            //if (childForm is Presentación.FormCaja)
            //{
            //    menuStrip2.Visible = true;  // Mostrar el MenuStrip si es FormCaja
            //}
            //else
            //{
            //    menuStrip2.Visible = false; // Ocultar el MenuStrip para otros formularios
            //}

            // labelEtiqueta.Text = childForm.Text;
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {

            ActivateButton(sender, RGBcolors.color1);

            openChildForm(new AriculosForm());


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            //currentChildForm.Close();
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            Reset();

        }
        private void Reset()
        {

            DisableButton();
            leftBorderBtn.Visible = false;

            iconoActual.IconChar = IconChar.HomeLg;
            iconoActual.IconColor = Color.FromArgb(172, 126, 241);
            labelEtiqueta.Text = "Home";


        }



        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormVentas());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormCaja());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormProveedores());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormClientes());
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormCompras());
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new Presentación.FormEmpleados());
        }

        private void classBtnPersonalizado1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBcolors.color1);
            openChildForm(new controlesPersonalizados.Botones());
        }

        private void panelEscritorio_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton8_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton10_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
        }

        private void iconButton11_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        ////////////////////////////////////////////////////////////caja reporte///////////////////////////////////////////////////////////////
        private void ConfigurarComboboxes()
        {
            // Agregar opciones al ComboBox de filtro
            cmbFiltro.Items.AddRange(new string[]
            {
                "Ver todo",
                "Últimos 7 días",
                "Últimos 30 días",
                "Seleccionar mes específico"
            });

            // Agregar meses al ComboBox de meses
            cmbMes.Items.AddRange(System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[..12]);

            // Deshabilitar ComboBox de meses por defecto
            cmbMes.Enabled = false;

            // Asignar eventos
            cmbFiltro.SelectedIndexChanged += CmbFiltro_SelectedIndexChanged;
            cmbMes.SelectedIndexChanged += CmbMes_SelectedIndexChanged;

            // Seleccionar por defecto "Ver todo"
            cmbFiltro.SelectedIndex = 0;
        }

        private void CargarDatos(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            DataTable datosCaja;

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                datosCaja = reportesLogica.ObtenerDatosCajaPorRango(fechaInicio.Value, fechaFin.Value);
            }
            else
            {
                datosCaja = reportesLogica.ObtenerTodosLosDatosCaja();
            }

            dgvCajas.DataSource = datosCaja;
        }

        private void CmbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string filtroSeleccionado = cmbFiltro.SelectedItem.ToString();

            //// Al seleccionar "Ver todo", no aplicamos filtros de fechas
            //if (filtroSeleccionado == "Ver todo")
            //{
            //    cmbMes.Enabled = false;  // Deshabilitar el ComboBox de meses
            //    CargarDatos();  // Cargar todos los datos
            //}
            //// Al seleccionar "Últimos 7 días", mostramos solo esos registros
            //else if (filtroSeleccionado == "Últimos 7 días")
            //{
            //    cmbMes.Enabled = false;  // Deshabilitar el ComboBox de meses
            //    CargarDatos(DateTime.Now.AddDays(-7), DateTime.Now);  // Cargar los datos de los últimos 7 días
            //}
            //// Al seleccionar "Últimos 30 días", mostramos solo esos registros
            //else if (filtroSeleccionado == "Últimos 30 días")
            //{
            //    cmbMes.Enabled = false;  // Deshabilitar el ComboBox de meses
            //    CargarDatos(DateTime.Now.AddDays(-30), DateTime.Now);  // Cargar los datos de los últimos 30 días
            //}
            //// Si selecciona "Seleccionar mes específico", habilitamos el ComboBox de meses
            //else if (filtroSeleccionado == "Seleccionar mes específico")
            //{
            //    cmbMes.Enabled = true;  // Habilitar el ComboBox de meses
            //                            // También debemos actualizar los datos para reflejar el cambio
            //    CargarDatos();  // Cargar todos los datos por defecto cuando seleccionan "mes específico"
            //}
        }

        private void CmbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Solo se actualiza si hay una selección válida en el ComboBox de meses
            if (cmbMes.SelectedIndex >= 0)
            {
                string filtroSeleccionado = cmbFiltro.SelectedItem?.ToString();  // Obtenemos el filtro actual

                // Si el filtro está en "Seleccionar mes específico", cargamos los datos de ese mes
                if (filtroSeleccionado == "Seleccionar mes específico")
                {
                    int mesSeleccionado = cmbMes.SelectedIndex + 1;
                    DateTime fechaInicio = new DateTime(DateTime.Now.Year, mesSeleccionado, 1);
                    DateTime fechaFin = fechaInicio.AddMonths(1).AddDays(-1);

                    // Actualizamos la grilla con los datos del mes seleccionado
                    CargarDatos(fechaInicio, fechaFin);
                }
            }
        }

         private void cajaToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            // Mostrar el panel de caja
            pnArticulos.Visible = false;
            pnVentas.Visible = false;
            pnCaja.Visible = true;
              
           
            CargarDatos();

            // Opcional: Restablecer los filtros para mostrar todo al abrir
            cmbFiltro.SelectedIndex = 0;  // Reseteamos la selección a "Ver todo"
            cmbMes.SelectedIndex = -1;  // Reseteamos el ComboBox de meses
            cmbMes.Enabled = false;  // Deshabilitamos el ComboBox de meses
        }   
              
            
        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarArticulos();
            pnCaja.Visible = false;
            pnDetalleCaja.Visible = false; 
            pnVentas.Visible = false;
            pnArticulos.Visible = true;
        }
           
        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnArticulos.Visible = false;
            pnCaja.Visible = true;

            pnVentas.Visible = true;
        }

        private void btnCerrarCajas_Click(object sender, EventArgs e)
        {
            pnCaja.Visible = false;

        }
        private void EstilizarDataGridView(DataGridView dgv)
        {
            //// Estilo de la grilla
            dgv.BackgroundColor = Color.FromArgb(32, 32, 32); // Fondo oscuro
            //dgv.ForeColor = Color.White; // Texto blanco
            dgv.BorderStyle = BorderStyle.None; // Sin borde
                                                //dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40); // Fondo alterno de filas
                                                //dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.White; // Texto de filas alternas
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(32, 32, 32); // Fondo seleccionado igual que el fondo general
            //dgv.DefaultCellStyle.SelectionForeColor = Color.White; // Texto seleccionado blanco
            //dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Alineación al centro
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50); // Fondo de encabezados
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Texto de encabezados
            //dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Encabezados al centro
            //dgv.EnableHeadersVisualStyles = false; // Deshabilitar estilos predeterminados de encabezados
            //dgv.RowTemplate.Height = 30; // Altura de las filas

            //// Ajustar columnas al contenido
            //dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // Ajustar las columnas al contenido
            //dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // Ajustar las filas al contenido

            //// Ajustar el anclaje de la grilla para que se ajuste al tamaño del contenedor
            //dgv.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Anclaje a todos los bordes

            //// Deshabilitar la selección y clic en la grilla
            //dgv.MultiSelect = false; // No permitir selección múltiple
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Solo se puede seleccionar toda la fila
            dgv.AllowUserToAddRows = false; // Deshabilitar la posibilidad de agregar filas
            dgv.AllowUserToDeleteRows = false; // Deshabilitar la posibilidad de borrar filas
            dgv.ReadOnly = true; // Hacer la grilla solo de lectura (no editable)
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }


        private void CentrarDataGridView(DataGridView dgv, Panel panel)
        {
            // Calcular la posición para centrar el DataGridView en el panel correspondiente
            int x = (panel.Width - dgv.Width) / 2; // Centrado horizontal
            int y = (panel.Height - dgv.Height - 60); // Ajuste de margen inferior para espacio adicional

            dgv.Location = new Point(x, y); // Asignar la nueva posición
        }



        private void CentrarDataGridViewCajas()
        {
            // Calcular la posición para centrar el DataGridView en el panel de caja
            int x = (pnCaja.Width - dgvCajas.Width) / 2; // Centrado horizontal
            int y = pnCaja.Height - dgvCajas.Height - 60; // Ajuste de margen inferior para dejar espacio al botón

            dgvCajas.Location = new Point(x, y); // Asignar la nueva posición
        }

        private void btCerrarArticulos_Click(object sender, EventArgs e)
        {

        }

        private void pnCaja_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnDetalleCaja_Click(object sender, EventArgs e)
        {

        }

        private void classBtnPersonalizado1_Click_1(object sender, EventArgs e)
        {
            pnDetalleCaja.Visible = true;
        }

        ////////////////////////////////////////////////////////////ventas reporte///////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////
        // Configuración de filtros y carga de datos
        ////////////////////////////////////////////////////////////

        private void ConfigurarFiltrosVentas()
        {
            // Configurar ComboBox de Filtros
            comboBoxFecha.Items.AddRange(new string[]
            {
                "Ver todo",
                "Últimos 7 días",
                "Últimos 30 días",
                "Mes"
            });
            comboBoxFecha.SelectedIndex = 0;

            // Configurar ComboBox de Meses
            comboBoxMes.Items.AddRange(CultureInfo.CurrentCulture.DateTimeFormat.MonthNames[..12]);
            comboBoxMes.Enabled = false;

            // Eventos de ComboBox
            comboBoxFecha.SelectedIndexChanged += ComboBoxFecha_SelectedIndexChanged;
            btnFiltrar.Click += BtnFiltrar_Click;
            btnVerDetalle.Click += BtnVerDetalle_Click;
        }

        private void CargarDatosVentas(DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            DataTable datosVentas;

            if (fechaInicio.HasValue && fechaFin.HasValue)
            {
                datosVentas = reportesLogica.ObtenerVentasPorRango(fechaInicio.Value, fechaFin.Value);
            }
            else
            {
                datosVentas = reportesLogica.ObtenerTodasLasVentas();
            }

            dgvVentas.DataSource = datosVentas;
        }

        ////////////////////////////////////////////////////////////
        // Eventos de Filtros
        ////////////////////////////////////////////////////////////

        private void ComboBoxFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboBoxFecha.SelectedItem.ToString();
            if (filtro == "Mes")
            {
                comboBoxMes.Enabled = true;
            }
            else
            {
                comboBoxMes.Enabled = false;
                comboBoxMes.SelectedIndex = -1;
            }
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = comboBoxFecha.SelectedItem.ToString();
            if (filtro == "Últimos 7 días")
            {
                CargarDatosVentas(DateTime.Now.AddDays(-7), DateTime.Now);
            }
            else if (filtro == "Últimos 30 días")
            {
                CargarDatosVentas(DateTime.Now.AddDays(-30), DateTime.Now);
            }
            else if (filtro == "Mes" && comboBoxMes.SelectedIndex >= 0)
            {
                int mesSeleccionado = comboBoxMes.SelectedIndex + 1;
                DateTime fechaInicio = new DateTime(DateTime.Now.Year, mesSeleccionado, 1);
                DateTime fechaFin = fechaInicio.AddMonths(1).AddDays(-1);
                CargarDatosVentas(fechaInicio, fechaFin);
            }
            else
            {
                CargarDatosVentas(); // Ver todo
            }
        }

        ////////////////////////////////////////////////////////////
        // Visualización de Detalles de Venta
        ////////////////////////////////////////////////////////////

        private void BtnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvVentas.SelectedRows.Count > 0)
            {
                int idVentaSeleccionada = Convert.ToInt32(dgvVentas.SelectedRows[0].Cells["id_venta"].Value);
                DataTable detallesVenta = reportesLogica.ObtenerDetallesVenta(idVentaSeleccionada);

                dgvDetalleVenta.DataSource = detallesVenta;
                pnDetallesVentas.Visible = true;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una venta para ver los detalles.",
                                "Detalle de Venta",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btnCerrarVentas_Click(object sender, EventArgs e)
        {
            pnCaja.Visible = false;
            pnVentas.Visible = false;

        }

        private void btnCerrarDetallesV_Click(object sender, EventArgs e)
        {
            pnDetallesVentas.Visible = false;
        }

        private void dgvDetalleVenta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCajas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVerDetalle_Click_1(object sender, EventArgs e)
        {

        }

        private void btnBuscarCaja_Click(object sender, EventArgs e)
        {
            string filtroSeleccionado = cmbFiltro.SelectedItem.ToString();

            // Al seleccionar "Ver todo", no aplicamos filtros de fechas
            if (filtroSeleccionado == "Ver todo")
            {
                cmbMes.Enabled = false;  // Deshabilitar el ComboBox de meses
                CargarDatos();  // Cargar todos los datos
            }
            // Al seleccionar "Últimos 7 días", mostramos solo esos registros
            else if (filtroSeleccionado == "Últimos 7 días")
            {
                cmbMes.Enabled = false;  // Deshabilitar el ComboBox de meses
                CargarDatos(DateTime.Now.AddDays(-7), DateTime.Now);  // Cargar los datos de los últimos 7 días
            }
            // Al seleccionar "Últimos 30 días", mostramos solo esos registros
            else if (filtroSeleccionado == "Últimos 30 días")
            {
                cmbMes.Enabled = false;  // Deshabilitar el ComboBox de meses
                CargarDatos(DateTime.Now.AddDays(-30), DateTime.Now);  // Cargar los datos de los últimos 30 días
            }
            // Si selecciona "Seleccionar mes específico", habilitamos el ComboBox de meses
            else if (filtroSeleccionado == "Seleccionar mes específico")
            {
                cmbMes.Enabled = true;  // Habilitar el ComboBox de meses
                                        // También debemos actualizar los datos para reflejar el cambio
                CargarDatos();  // Cargar todos los datos por defecto cuando seleccionan "mes específico"
            }
        }
        /////////articulos reportes///////////////////

        private void CargarArticulos()
        {
            // Obtener los datos de la capa de lógica
            var tablaArticulos = reportesLogica.ObtenerArticulosVendidos();

            // Asignar la tabla al DataGridView
            dgvArticulos.DataSource = tablaArticulos;
        }
        private void ConfigurarCbx()
        {
            // Agregar opciones al ComboBox de filtro
            cbxFiltro.Items.AddRange(new string[]
            {
                "Más vendidos",
                "Menos vendidos"
            });

            // Opcionalmente, puedes establecer un valor predeterminado
            cbxFiltro.SelectedIndex = 0; // Esto selecciona "Más vendidos" por defecto
        }

        //private void cbxFiltro_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //// Filtrar según el valor seleccionado en el ComboBox
        //    //string filtro = cbxFiltro.SelectedItem.ToString();
        //    //if (filtro == "Más vendidos")
        //    //{
        //    //    dgvArticulos.Sort(dgvArticulos.Columns["cantidad_vendida"], ListSortDirection.Descending);
        //    //}
        //    //else if (filtro == "Menos vendidos")
        //    //{
        //    //    dgvArticulos.Sort(dgvArticulos.Columns["cantidad_vendida"], ListSortDirection.Ascending);
        //    //}
        //}

        private void btnArticulos_Click(object sender, EventArgs e)
        {
            // Filtrar según el valor seleccionado en el ComboBox
            string filtro = cbxFiltro.SelectedItem.ToString();
            if (filtro == "Más vendidos")
            {
                dgvArticulos.Sort(dgvArticulos.Columns["cantidad_vendida"], ListSortDirection.Descending);
            }
            else if (filtro == "Menos vendidos")
            {
                dgvArticulos.Sort(dgvArticulos.Columns["cantidad_vendida"], ListSortDirection.Ascending);
            }
        }

        private void btnCerrarArticulos_Click(object sender, EventArgs e)
        {
            pnArticulos.Visible = false;
        }

         
    }
}
