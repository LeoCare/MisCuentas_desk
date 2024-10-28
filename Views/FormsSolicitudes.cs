using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.Emails;
using MisCuentas_desk.Socket;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MisCuentas_desk.Views
{
    public partial class FormsSolicitudes : Form
    {
        #region ATRIBUTOS
        private Usuario _usuario;
        private MisCuentasConnect _conn = new MisCuentasConnect();
        private EmailServices _emailServices;
        List<EmailRequest> _enviosDeudores;
        List<EmailRequest> _enviosAcreedores;
        SocketConnect sck = new SocketConnect();
        private Timer _timerMostrarImagen;
        private Timer _timerOcultarImagen;
        private bool _exitoEnvioEmail = false;
        private int opacidadActual = 0;
        #endregion

        #region CONSTRUCTOR
        public FormsSolicitudes(Usuario usuario, FormMisCuentas formMisCuentas)
        {
            InitializeComponent();
            string cadenaConexion = _conn.Conexion();
            _emailServices = new EmailServices(cadenaConexion);
            _usuario = usuario;
            _enviosDeudores = new List<EmailRequest>();
            _enviosAcreedores = new List<EmailRequest>();

            // Configurar el Timer para mostrar la imagen
            _timerMostrarImagen = new Timer();
            _timerMostrarImagen.Interval = 50; // Cada 50 ms actualiza la opacidad
            _timerMostrarImagen.Tick += timerMostrarImagen_Tick;

            // Configurar el Timer para ocultar la imagen
            _timerOcultarImagen = new Timer();
            _timerOcultarImagen.Interval = 2000; // Mostrar la imagen por 2 segundos
            _timerOcultarImagen.Tick += timerOcultarImagen_Tick;

            ObtenerSolicitudes();
            TotalesDeudores();
            TotalesAcreedores();
            LimpiarDatos();      
            CargarDatos();
            ConfigurarDataGridView();
        }
        #endregion


        #region
        /// <summary>
        /// Metodo que obtiene los datos desde la BBDD.
        /// </summary>
        public void ObtenerSolicitudes()
        {
            _enviosDeudores.Clear();
            _enviosAcreedores.Clear();

            if (_usuario.Hojas.Count > 0)
            {
                _usuario.Hojas.ForEach(h =>
                {
                    _enviosDeudores.AddRange(_emailServices.ObtenerTodosDeudorByHoja(h.Id_Hoja));
                    _enviosAcreedores.AddRange(_emailServices.ObtenerTodosAcreedorByHoja(h.Id_Hoja));
                });
            }
        }

        public void TotalesDeudores()
        {
            Double total = 0.0;
            if (_enviosDeudores.Count > 0 && _enviosDeudores != null)
            {  
                foreach (var deuda in _enviosDeudores)
                {
                    total += Double.Parse(deuda.Monto.ToString());
                }
            }

            lblTotalMeDeben.Text = total.ToString();
            lblTotalPartiMeDeben.Text = _enviosDeudores.Count.ToString();
        }

        public void TotalesAcreedores()
        {
            Double total = 0.0;
            if (_enviosAcreedores.Count > 0 && _enviosAcreedores != null)
            {
                foreach (var deuda in _enviosAcreedores)
                {
                    total += Double.Parse(deuda.Monto.ToString());
                }
            }

            lblTotalDebo.Text = total.ToString();
            lblTotalPartiDebo.Text = _enviosAcreedores.Count.ToString();
        }
        #endregion


        #region METODOS DATAGRID
        /// <summary>
        /// Metodo que modifica el datagridview segun necesidad del formulario.
        /// </summary>
        private void ConfigurarDataGridView()
        {
            // Crear una nueva columna de botones
            DataGridViewButtonColumn botonEnviarAcreedores = new DataGridViewButtonColumn();
            botonEnviarAcreedores.Name = "Enviar";
            botonEnviarAcreedores.HeaderText = "Enviar";
            botonEnviarAcreedores.Text = "Enviar";
            botonEnviarAcreedores.UseColumnTextForButtonValue = true;

            // Crear una nueva columna de botones
            DataGridViewButtonColumn botonEnviarDeudores = new DataGridViewButtonColumn();
            botonEnviarDeudores.Name = "Enviar";
            botonEnviarDeudores.HeaderText = "Enviar";
            botonEnviarDeudores.Text = "Enviar";         
            botonEnviarDeudores.UseColumnTextForButtonValue = true;            

            // Añadir la columna de botón al DataGridView
            dgAcreedores.Columns.Add(botonEnviarAcreedores);
            dgDeudores.Columns.Add(botonEnviarDeudores);

            botonEnviarAcreedores.Width = 40; 
            botonEnviarDeudores.Width = 40;
            dgAcreedores.Columns["Monto"].Width = 40;
            dgDeudores.Columns["Monto"].Width = 40;

            // Quitar columnas innecesarias
            dgAcreedores.Columns["Id_Email"].Visible = false;
            dgAcreedores.Columns["Contenido"].Visible = false;
            dgAcreedores.Columns["Asunto"].Visible = false;
            dgDeudores.Columns["Id_Email"].Visible = false;
            dgDeudores.Columns["Contenido"].Visible = false;
            dgDeudores.Columns["Asunto"].Visible = false;

            // Configurar otras propiedades del DataGridView si es necesario
            dgAcreedores.AutoGenerateColumns = false;
            dgDeudores.AutoGenerateColumns = false;
            // Evitar que el usuario agregue nuevas filas manualmente
            dgAcreedores.AllowUserToAddRows = false;
            dgDeudores.AllowUserToAddRows = false;
        }

        /// <summary>
        /// Metodo que limpia los datos del datagrid.
        /// </summary>
        private void LimpiarDatos()
        {
            dgDeudores.DataSource = null;
            dgDeudores.Rows.Clear();
            dgDeudores.Columns.Clear();
            dgAcreedores.DataSource = null;
            dgAcreedores.Rows.Clear();
            dgAcreedores.Columns.Clear();

            
        }

        /// <summary>
        /// Metodo que carga el DataSource del datagrid.
        /// </summary>
        private void CargarDatos()
        {
            dgDeudores.DataSource = _enviosDeudores;
            dgAcreedores.DataSource = _enviosAcreedores;
        }
        #endregion


        #region ENVIO EMAIL
        /// <summary>
        /// Metodo que recoge los datos de la celda clickada del datagrid para su posterior envio con el boton de Enviar.
        /// </summary>
        private void dgDeudores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgDeudores.Columns["Enviar"].Index && e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgDeudores.Rows[e.RowIndex];

                // Extraer los valores de cada columna
                string titulo = filaSeleccionada.Cells["Titulo"].Value?.ToString();
                DateTime? fecha_Creacion = null;
                if (filaSeleccionada.Cells["Fecha_Creacion"].Value != null)
                {
                    fecha_Creacion = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_Creacion"].Value);
                }
                double? monto = null;
                if (filaSeleccionada.Cells["Monto"].Value != null)
                {
                    monto = Convert.ToDouble(filaSeleccionada.Cells["Monto"].Value);
                }
                string correo = filaSeleccionada.Cells["Correo"].Value?.ToString();
                string nombre = filaSeleccionada.Cells["Nombre"].Value?.ToString();
                string asunto = filaSeleccionada.Cells["Asunto"].Value?.ToString();
                string contenido = filaSeleccionada.Cells["Contenido"].Value?.ToString();

                // Llamar al método para enviar el correo
                _exitoEnvioEmail = sck.EnviarCorreoDesdeCliente(titulo, fecha_Creacion, monto, correo, nombre, asunto, contenido);
                MostrarImagenConEfecto();
            }
        }

        /// <summary>
        /// Metodo que recoge los datos de la celda clickada del datagrid para su posterior envio con el boton de Enviar.
        /// </summary>
        private void dgAcreedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgAcreedores.Columns["Enviar"].Index && e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgAcreedores.Rows[e.RowIndex];

                // Extraer los valores de cada columna
                string titulo = filaSeleccionada.Cells["Titulo"].Value?.ToString();
                DateTime? fecha_Creacion = null;
                if (filaSeleccionada.Cells["Fecha_Creacion"].Value != null)
                {
                    fecha_Creacion = Convert.ToDateTime(filaSeleccionada.Cells["Fecha_Creacion"].Value);
                }
                double? monto = null;
                if (filaSeleccionada.Cells["Monto"].Value != null)
                {
                    monto = Convert.ToDouble(filaSeleccionada.Cells["Monto"].Value);
                }
                string correo = filaSeleccionada.Cells["Correo"].Value?.ToString();
                string nombre = filaSeleccionada.Cells["Nombre"].Value?.ToString();
                string asunto = filaSeleccionada.Cells["Asunto"].Value?.ToString();
                string contenido = filaSeleccionada.Cells["Contenido"].Value?.ToString();

                // Llamar al método para enviar el correo
                _exitoEnvioEmail = sck.EnviarCorreoDesdeCliente(titulo, fecha_Creacion, monto, correo, nombre, asunto, contenido);
                MostrarImagenConEfecto();
            }
        }

        /// <summary>
        /// Método para mostrar la imagen con efecto
        /// </summary>
        /// <param name="exito">imagen segun el exito del envio</param>
        private void MostrarImagenConEfecto()
        {
            opacidadActual = 0;

            // Hacer visible el PictureBox segun el resultado del envio
            if (_exitoEnvioEmail)
            {
                pbxOK.Visible = true;
                pbxOK.Size = new Size(10, 10);
            }
            else
            {
                pbxNOK.Visible = true;
                pbxNOK.Size = new Size(10, 10);
            }

            // Iniciar el Timer para mostrar la imagen con efecto gradual
            _timerMostrarImagen.Start();
        }

        /// <summary>
        /// Evento del Timer para manejar la aparición gradual
        /// </summary>
        private void timerMostrarImagen_Tick(object sender, EventArgs e)
        {
            opacidadActual += 10;

            // Simular la opacidad cambiando el tamaño de la imagen
            if (opacidadActual <= 100)
            {
                float escala = opacidadActual / 100f;
                if (_exitoEnvioEmail)
                {
                    pbxOK.Width = (int)(100 * escala); // Ajusta el tamaño según el valor de escala
                    pbxOK.Height = (int)(100 * escala); // Ajusta el tamaño según el valor de escala
                    pbxOK.Refresh();
                }
                else
                {
                    pbxNOK.Width = (int)(100 * escala); // Ajusta el tamaño según el valor de escala
                    pbxNOK.Height = (int)(100 * escala); // Ajusta el tamaño según el valor de escala
                    pbxNOK.Refresh();
                }
                    
            }
            else
            {
                // Detener
                _timerMostrarImagen.Stop();
                // Iniciar
                _timerOcultarImagen.Start();
            }
        }

        /// <summary>
        /// Evento del Timer para ocultar la imagen después de mostrarla por un tiempo
        /// </summary>
        private void timerOcultarImagen_Tick(object sender, EventArgs e)
        {
            _timerOcultarImagen.Stop();
            pbxOK.Visible = false;
            pbxNOK.Visible = false;
        }
        #endregion
 
    }
}
