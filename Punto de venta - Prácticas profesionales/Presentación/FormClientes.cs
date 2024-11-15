using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Punto_de_venta___Prácticas_profesionales.Lógica;
namespace Punto_de_venta___Prácticas_profesionales.Presentación
{
    public partial class FormClientes : Form
    {
        private readonly clientesLogica _clientesLogica = new clientesLogica();

        public FormClientes()
        {
            InitializeComponent();
            _clientesLogica = new clientesLogica();
            panel1.Visible = false; // Panel oculto al inicio
            CargarPersonasEnGrilla();

            // Eventos para manejo de celdas
            dgvClientes.CellEndEdit += dgvClientes_CellEndEdit;
            dgvClientes.KeyDown += dgvClientes_KeyDown;

            dgvClientes.AllowUserToAddRows = false;
            ConfigurarEstiloDataGridView();
            //dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dgvClientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            ConfigurarBotonNuevoCliente();
            ConfigurarPanelCentrado();
            txtCuil.KeyPress += txtCuil_KeyPress;
            txtTelefono.KeyPress += txtTelefono_KeyPress;

        }



        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void btNuevoCliente_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void FormClientes_Load(object sender, EventArgs e)
        {
            CargarPersonasEnGrilla();
        }



        //private void btGuardar_Click(object sender, EventArgs e)
        //{


        //}

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void CargarPersonasEnGrilla()
        {
            DataTable tablaPersonas = _clientesLogica.ObtenerPersonas();
            dgvClientes.DataSource = tablaPersonas;
        }



        private void dvgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvClientes.ReadOnly = false;
        }
        // Método para actualizar datos al terminar de editar una celda
        private void dgvClientes_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvClientes.Rows[e.RowIndex];

                string cuilStr = row.Cells["CUIL"].Value?.ToString();
                string nombre = row.Cells["nombres"].Value?.ToString();
                string apellido = row.Cells["apellido"].Value?.ToString();
                string telefonoStr = row.Cells["telefono"].Value?.ToString();
                string domicilio = row.Cells["domicilio"].Value?.ToString();
                string email = row.Cells["email"].Value?.ToString();

                // Validación de que no estén vacíos los campos obligatorios
                if (string.IsNullOrWhiteSpace(cuilStr) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                    string.IsNullOrWhiteSpace(telefonoStr) || string.IsNullOrWhiteSpace(domicilio) || string.IsNullOrWhiteSpace(email))
                {
                    MessageBox.Show("Por favor, complete todos los campos antes de continuar.");
                    dgvClientes.CancelEdit(); // Cancela la edición y no actualiza
                    return;
                }

                // Validación y actualización
                string mensajeError = _clientesLogica.ValidarYActualizarPersona(cuilStr, nombre, apellido, telefonoStr, domicilio, email, out long cuil, out long telefono);

                if (!string.IsNullOrEmpty(mensajeError))
                {
                    MessageBox.Show(mensajeError);
                    dgvClientes.CancelEdit(); // Cancela la edición si hay error
                }
                else
                {
                    CargarPersonasEnGrilla(); // Recarga para reflejar cambios
                }
            }
        }




        // Maneja el evento de presionar Enter en la grilla
        private void dgvClientes_KeyDown(object sender, KeyEventArgs e)
        {
            // Solo actuamos si se presiona Enter
            if (e.KeyCode == Keys.Enter && dgvClientes.CurrentCell != null)
            {
                // Previene que se cambie la celda antes de guardar
                e.Handled = true;

                // Finaliza la edición de la celda actual y guarda los cambios
                dgvClientes.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // Evento KeyPress para restringir la entrada a solo números
        private void txtCuil_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y el carácter de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancelar la entrada del carácter
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y el carácter de retroceso (Backspace)
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Cancelar la entrada del carácter
            }
        }
        private void btGuardar_Click_1(object sender, EventArgs e)
        {
            string cuilStr = txtCuil.Texts;
            string nombre = txtNombre.Texts;
            string apellido = txtApellido.Texts;
            string telefonoStr = txtTelefono.Texts;
            string domicilio = txtDomicilio.Texts;
            string email = txtEmail.Texts;


            string mensajeError = _clientesLogica.ValidarDatosPersona(cuilStr, nombre, apellido, telefonoStr, domicilio, email, out long cuil, out long telefono);

            if (!string.IsNullOrEmpty(mensajeError))
            {
                MessageBox.Show(mensajeError);

            }
            else
            {
                _clientesLogica.GuardarPersona(cuil, nombre, apellido, telefono, domicilio, email);
                //MessageBox.Show("Cliente registrado correctamente ");
                panel1.Visible = false;
                CargarPersonasEnGrilla();
                txtCuil.Texts = "";
                txtNombre.Texts = "";
                txtApellido.Texts = "";
                txtTelefono.Texts = "";
                txtDomicilio.Texts = "";
                txtEmail.Texts = "";


            }

        }

        private void classBtnPersonalizado2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;

        }



        private void txtCuil__TextChanged(object sender, EventArgs e)
        {

        }
       


        private void ConfigurarEstiloDataGridView()
        {
            // Establecer que la primera columna (CUIL) no sea editable
            dgvClientes.Columns["CUIL"].ReadOnly = true;
            // Fondo oscuro y estilo de las celdas
            dgvClientes.BackgroundColor = Color.FromArgb(45, 45, 48); // Fondo oscuro para la grilla
            dgvClientes.DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30); // Fondo oscuro en cada celda
            dgvClientes.DefaultCellStyle.ForeColor = Color.White; // Texto blanco para contraste
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.FromArgb(70, 70, 70); // Color para la selección
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.White;

            // Encabezado con estilo
            dgvClientes.EnableHeadersVisualStyles = false; // Permite personalizar los encabezados
            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(55, 55, 58);
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            // Ajuste de columnas
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Rellena todo el espacio disponible
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Bordes y márgenes
            dgvClientes.BorderStyle = BorderStyle.None;
            dgvClientes.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvClientes.RowHeadersVisible = false; // Oculta el encabezado de las filas
            dgvClientes.AllowUserToResizeColumns = false; // Evita que se cambie el tamaño de las columnas

            // Ajuste dinámico al tamaño del formulario
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            //dgvClientes.Top = boton.Top + boton.Height + 10; // Desplaza la grilla debajo del botón con margen
            dgvClientes.Left = 10; // Márgenes izquierdo
            dgvClientes.Width = this.ClientSize.Width - 20; // Ancho ajustado con margen
            dgvClientes.Height = this.ClientSize.Height - dgvClientes.Top - 10; // Ajusta la altura disponible

            // Asegurarse de que los textos sean legibles y uniformes
            dgvClientes.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Regular); // Fuente para las celdas
            dgvClientes.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold); // Fuente para el encabezado
            dgvClientes.RowsDefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Regular); // Fuente para las filas
            dgvClientes.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(35, 35, 35); // Color alternativo para filas

            // Ajuste cuando el formulario cambia de tamaño
            this.Resize += (sender, e) =>
            {
                dgvClientes.Width = this.ClientSize.Width - 20;
                dgvClientes.Height = this.ClientSize.Height - dgvClientes.Top - 10;
            };
        }

        private void classBtnPersonalizado1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            txtCuil.Texts = "";
            txtNombre.Texts = "";
            txtApellido.Texts = "";
            txtTelefono.Texts = "";
            txtDomicilio.Texts = "";
            txtEmail.Texts = "";

        }
        private void ConfigurarBotonNuevoCliente()
        {
            // Configurar el botón para que siempre esté en la esquina superior derecha
            btNuevoCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Fija el botón en la parte superior y derecha
            btNuevoCliente.Top = 10; // Márgenes de la parte superior
            btNuevoCliente.Left = this.ClientSize.Width - btNuevoCliente.Width - 10; // Márgenes del lado derecho

            // Ajustar cuando el formulario cambia de tamaño
            this.Resize += (sender, e) => {
                btNuevoCliente.Left = this.ClientSize.Width - btNuevoCliente.Width - 10;
                btNuevoCliente.Top = 10;
            };
        }

        private void ConfigurarPanelCentrado()
        {
            // Anclar el panel para que se mantenga centrado
            panel1.Anchor = AnchorStyles.None;

            // Ajustar la posición del panel cuando el formulario cambie de tamaño
            this.Resize += (sender, e) =>
            {
                // Calcular la posición central
                panel1.Left = (this.ClientSize.Width - panel1.Width) / 2;
                panel1.Top = (this.ClientSize.Height - panel1.Height) / 2;
            };
        }


    }
}
