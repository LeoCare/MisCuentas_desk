using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.Gastos;
using MisCuentas_desk.Services.Hojas;
using MisCuentas_desk.Services.Pagos;
using MisCuentas_desk.Services.Participantes;
using MisCuentas_desk.Services.PersonalData;
using MisCuentas_desk.Services.Usuarios;
using MisCuentas_desk.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection;
using System.Windows.Forms.VisualStyles;

namespace MisCuentas_desk.Views
{
    public partial class FormsAvanzado : Form
    {
        #region ATRIBUTOS
        private Usuario _usuario;
        private MisCuentasConnect _conn = new MisCuentasConnect();
        private UsuarioServices _usuarioServices;
        private HojaServices _hojaServices;
        private ParticipanteServices _participanteServices;
        private UpdateDataUsuario _updateUsuario;
        private Timer _timerAviso;
        private string _entidadElejida = "";
        private string _accionElejida = "";
        private List<Hoja> _hojasFiltradas  = new List<Hoja>();
        private List<Participante> _participantesFiltrados = new List<Participante>();
        private Color _color = new Color();
        #endregion

        #region CONSTRUCTOR
        public FormsAvanzado(Usuario usuario, FormMisCuentas formMisCuentas)
        {
            InitializeComponent();
            InstanciaTimer();
            string cadenaConexion = _conn.Conexion();
            _hojaServices = new HojaServices(cadenaConexion);
            _usuarioServices = new UsuarioServices(cadenaConexion);
            _participanteServices = new ParticipanteServices(cadenaConexion);
            _usuario = usuario;
            _updateUsuario = new UpdateDataUsuario();
            EntidadInicial();
        }
        #endregion


        #region ELECCION ENTIDAD
        /// <summary>
        /// Metodo que inicial el formulario con la entidad Hojas seleccionada.
        /// </summary>
        private void EntidadInicial()
        {
            PintarBtnElegido(0);
            PintarBtnAccion(3);
            _entidadElejida = "Hojas";
            _color = Color.Orange;
        }

        /// <summary>
        /// Metodo que prepara el formulario para trabajar con Hojas.
        /// </summary>
        private void btnAvanzadoHojas_Click(object sender, EventArgs e)
        {
            PintarBtnElegido(0);
            PintarBtnAccion(3);
            _entidadElejida = "Hojas";
            _color = Color.Orange;
        }

        /// <summary>
        /// Metodo que prepara el formulario para trabajar con Participantes.
        /// </summary>
        private void btnAvanzadoParticipantes_Click(object sender, EventArgs e)
        {
            PintarBtnElegido(1);
            PintarBtnAccion(3);
            _entidadElejida = "Participantes";
            _color = Color.DarkSeaGreen;
        }


        /// <summary>
        /// Metodo que pinta los botones del objeto elegido
        /// </summary>
        /// <param name="elegido">id del objeto elegido</param>
        private void PintarBtnElegido(int elegido)
        {
            panelAvanzadoHojas.Visible = false;
            panelAvanzadoParticipantes.Visible = false;
            switch (elegido)
            {
                case 0: //btnHojas
                    btnAvanzadoHojas.BackColor = Color.Orange;
                    btnAvanzadoParticipantes.BackColor = Color.LightGray;
                    break; 
                case 1: //btnParticipantes
                    btnAvanzadoHojas.BackColor = Color.LightGray;
                    btnAvanzadoParticipantes.BackColor = Color.DarkSeaGreen;

                    break;
                default: //ninguno Clickado
                    btnAvanzadoHojas.BackColor = Color.LightGray;
                    btnAvanzadoParticipantes.BackColor = Color.LightGray;
                    break;
            }
        }
        #endregion


        #region ELECCION ACCION
        /// <summary>
        /// Metodo que identifica la eleccionde Agregar.
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _accionElejida = "Agregar";
            PintarBtnAccion(0);
            ActivarPanelFiltro(false);
            HabilitaSoloBtnAccion(false);
        }


        /// <summary>
        /// Metodo que identifica la eleccionde Modificar.
        /// </summary>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            _accionElejida = "Modificar";
            PintarBtnAccion(1);
            ActivarPanelFiltro(true);
            HabilitaSoloBtnAccion(false);
        }

        /// <summary>
        /// Metodo que identifica la eleccionde Eliminar.
        /// </summary>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _accionElejida = "Eliminar";
            PintarBtnAccion(2);
            ActivarPanelFiltro(true);
            HabilitaSoloBtnAccion(true);
        }


        /// <summary>
        /// Metodo que pinta el formulario segun el boton de accion seleccionado
        /// </summary>
        /// <param name="elegido">id del boton elegido</param>
        private void PintarBtnAccion(int elegido)
        {
            LimpiarPanelAccion();
            LimpiarPanelFiltros();
            switch (elegido)
            {
                case 0: //btnAgregar
                    btnAgregar.BackColor = _color;
                    btnModificar.BackColor = Color.WhiteSmoke;
                    btnEliminar.BackColor = Color.WhiteSmoke;
                    btnAvanzadoAccion.BackColor = _color;
                    btnAccionParticipantes.BackColor = _color;
                    btnAvanzadoAccion.Text = "Agregar";
                    break;
                case 1: //btnModificar
                    btnAgregar.BackColor = Color.WhiteSmoke;
                    btnModificar.BackColor = _color;
                    btnEliminar.BackColor = Color.WhiteSmoke;
                    btnAvanzadoAccion.BackColor = _color;
                    btnAccionParticipantes.BackColor = _color;
                    btnAvanzadoAccion.Text = "Modificar";
                    break;
                case 2: //btnEliminar
                    btnAgregar.BackColor = Color.WhiteSmoke;
                    btnModificar.BackColor = Color.WhiteSmoke;
                    btnEliminar.BackColor = _color;
                    btnAvanzadoAccion.Text = "Eliminar";
                    btnAvanzadoAccion.BackColor = _color;
                    btnAccionParticipantes.BackColor = _color;
                    break;               
                default: //ninguno Clickado
                    btnAgregar.BackColor = Color.WhiteSmoke;
                    btnModificar.BackColor = Color.WhiteSmoke;
                    btnEliminar.BackColor = Color.WhiteSmoke;
                    btnAvanzadoAccion.BackColor = Color.WhiteSmoke;
                    btnAccionParticipantes.BackColor = Color.WhiteSmoke;
                    btnAvanzadoAccion.Text = "Listo!";
                    break;
               
            }
        }

        /// <summary>
        /// Metodo que activa/desactiva los paneles segun la eleccion.
        /// </summary>
        /// <param name="isAgregar">True si la accion elegida es AGREGAR, false cualquier otra eleccion.</param>
        private void ActivarPanelFiltro(bool busqueda)
        {
            List<string> filtros = new List<string>();
            panelAvanzadoFiltro.Enabled = busqueda;
            PropertyInfo[] propiedadesEntidad = null;

            switch (_entidadElejida)
            {
                case "Hojas":
                    PanelAgregarHoja(!busqueda);
                    panelAvanzadoHojas.Visible = true;
                    panelAvanzadoParticipantes.Visible = false;
                    propiedadesEntidad = typeof(Hoja).GetProperties();
                    break;
                case "Participantes":
                    PanelAgregarParticipantes(!busqueda);
                    panelAvanzadoParticipantes.Visible = true;
                    panelAvanzadoHojas.Visible = false;
                    propiedadesEntidad = typeof(Participante).GetProperties();
                    break;
                
            }
            if (panelAvanzadoFiltro.Enabled) CargarFiltros(propiedadesEntidad); 
        }


        /// <summary>
        /// Metodo que activa los elementos necesarios segun la accion.
        /// </summary>
        /// <param name="creacion">True si la accion es AGREGAR, false en cualquier otro caso</param>
        private void PanelAgregarHoja(bool creacion)
        {
            panelAvanzadoHojas.Enabled = creacion;
            tbxFechaCreacionHoja.Visible = !creacion;
            tbxStatusHoja.Visible = !creacion;
            lblFechaCreacionHoja.Visible = !creacion;
            lblStatusHoja.Visible = !creacion;
            tbxFechaLimiteHoja.Visible = !creacion;
            lblParticipanesCount.Visible = !creacion;
            lblParticipantesHoja.Visible = !creacion;
            btnParticipantesHoja.Visible = !creacion;
        }

        /// <summary>
        /// Metodo que activa los elementos necesarios segun la accion.
        /// </summary>
        /// <param name="creacion">True si la accion es AGREGAR, false en cualquier otro caso</param>
        private void PanelAgregarParticipantes(bool creacion)
        {
            panelAvanzadoParticipantes.Enabled = creacion;
            tbxIdUsuarioParti.Visible = !creacion;
            lblIdUsuarioParti.Visible = !creacion;
        }
        #endregion


        #region BLOQUE FILTROS
        /// <summary>
        /// Metodo que carga las propiedades de la entidad en la lista de posibles filtros.
        /// </summary>
        /// <param name="propiedadesEntidad"></param>
        private void CargarFiltros(PropertyInfo[] propiedadesEntidad)
        {
            cbxFiltros.Items.Clear();
            foreach (PropertyInfo propiedad in propiedadesEntidad)
            {
                switch (_entidadElejida)
                {
                    case "Hojas":
                        if(!propiedad.Name.Equals("Participantes")) cbxFiltros.Items.Add(propiedad.Name);
                        break;
                    case "Participantes":
                        if (!propiedad.Name.Equals("Gastos") && !propiedad.Name.Equals("Balances")) cbxFiltros.Items.Add(propiedad.Name);
                        break;
                }              
            }
            if (cbxFiltros.Items.Count > 0)
            {
                cbxFiltros.SelectedIndex = 0;
            }

        }

        /// <summary>
        /// Metodo que inicia el filtrado segun la entidad elegida
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(tbxFiltroTexto.Text))
            {
                MessageBox.Show("Tienes que indicar un valor para iniciar la busqueda!", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (_accionElejida.Equals("Eliminar")) HabilitaSoloBtnAccion(true);

            switch (_entidadElejida)
            {
                case "Hojas":
                    panelAvanzadoHojas.Enabled = true;
                    BuscarHojaPor(cbxFiltros.Text, tbxFiltroTexto.Text.Trim());
                    break;
                case "Participantes":
                    panelAvanzadoParticipantes.Enabled = true;
                    BuscarParticipanesPor(cbxFiltros.Text, tbxFiltroTexto.Text.Trim());
                    break;
            }
        }


        /// <summary>
        /// Metodo que inicia el filtro de hojas.
        /// </summary>
        /// <param name="atributo">Atributo de la hoja por el cual filtrar</param>
        /// <param name="valor">valor del filtro</param>
        private void BuscarHojaPor(string atributo, string valor)
        {
            // Obtener la información de la propiedad especificada
            Type tipoHoja = typeof(Hoja);
            PropertyInfo propiedad = tipoHoja.GetProperty(atributo);
            _hojasFiltradas.Clear();

            if (propiedad == null)
            {
                // La propiedad no existe
                MessageBox.Show("El filtro seleccionado no es válido.");
                return;
            }

            // Filtrar las hojas
            _hojasFiltradas = _usuario.Hojas.Where(hoja =>
            {
                // Obtener el valor de la propiedad en la instancia actual
                var valorPropiedad = propiedad.GetValue(hoja);

                // Convertir ambos valores a cadenas y comparar
                return valorPropiedad != null && valorPropiedad.ToString().Equals(valor, StringComparison.OrdinalIgnoreCase);
            }).ToList();

            if (_hojasFiltradas != null) MostrarFiltroHojas();

        }


        /// <summary>
        /// Metodo que llena el dataGridView con los elementos filtrados.
        /// </summary>
        private void MostrarFiltroHojas()
        {
            dgListaFiltrada.DataSource = null;
            dgListaFiltrada.Rows.Clear();
            dgListaFiltrada.Columns.Clear();

            dgListaFiltrada.DataSource = _hojasFiltradas;

            // Mostrar solo la columna 'Titulo'
            foreach (DataGridViewColumn column in dgListaFiltrada.Columns)
            {
                if (column.Name != "Titulo")
                {
                    column.Visible = false;
                }
            }

            // Configurar la selección de filas completas
            dgListaFiltrada.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgListaFiltrada.MultiSelect = false;

        }

        /// <summary>
        /// Metodo de seleccion de elemento de la lista de filtrados.
        /// </summary>
        private void dgListaFiltrada_SelectionChanged(object sender, EventArgs e)
        {
            if (dgListaFiltrada.SelectedRows.Count > 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow filaSeleccionada = dgListaFiltrada.SelectedRows[0];

                switch (_entidadElejida)
                {
                    case "Hojas":
                        // Obtener el objeto 'Hoja' asociado a la fila
                        Hoja hojaSeleccionada = filaSeleccionada.DataBoundItem as Hoja;
                        if (hojaSeleccionada != null) MostrarDatosHoja(hojaSeleccionada);
                        break;
                    case "Participantes":
                        Participante partiSeleccionado = filaSeleccionada.DataBoundItem as Participante;
                        if (partiSeleccionado != null) MostrarDatosParticipante(partiSeleccionado);
                        break;
                }
            }
        }

        /// <summary>
        /// Metodo que pinta los datos en el panel de acciones
        /// </summary>
        /// <param name="hojaSeleccionada">Hoja elegida del dataGridView</param>
        private void MostrarDatosHoja(Hoja hojaSeleccionada)
        {
            lblIdHoja.Text = hojaSeleccionada.Id_Hoja.ToString();
            tbxTituloHoja.Text = hojaSeleccionada.Titulo;
            tbxStatusHoja.Text = hojaSeleccionada.Status;
            tbxFechaCreacionHoja.Text = hojaSeleccionada.Fecha_Creacion.ToString("dd/MM/yyyy");
            tbxFechaLimiteHoja.Text = hojaSeleccionada.Fecha_Cierre?.ToString("dd/MM/yyyy");
            tbxLimiteGastosHoja.Text = hojaSeleccionada.Limite_Gastos.ToString();
            lblParticipanesCount.Text = hojaSeleccionada.Participantes.Count.ToString();
        }

        
    
        /// <summary>
        /// Metodo que inicia el filtro de participantes.
        /// </summary>
        /// <param name="atributo">Atributo del participante por el cual filtrar</param>
        /// <param name="valor">valor del filtro</param>
        private void BuscarParticipanesPor(string atributo, string valor)
        {
            // Obtener la información de la propiedad especificada
            Type tipoParticipante = typeof(Participante);
            PropertyInfo propiedad = tipoParticipante.GetProperty(atributo);
            _participantesFiltrados.Clear();
            if (propiedad == null)
            {
                // La propiedad no existe
                MessageBox.Show("El filtro seleccionado no es válido.");
                return;
            }

            // Filtrar los participantes
            _usuario.Hojas.ForEach(hoja =>
            {
                _participantesFiltrados.AddRange(hoja.Participantes.Where(p =>
                {
                    // Obtener el valor de la propiedad en la instancia actual
                    var valorPropiedad = propiedad.GetValue(p);

                    // Convertir ambos valores a cadenas y comparar
                    return valorPropiedad != null && valorPropiedad.ToString().Equals(valor, StringComparison.OrdinalIgnoreCase);
                }));

            });

            if (_participantesFiltrados != null) MostrarFiltroParticipantes();

        }


        /// <summary>
        /// Metodo que llena el dataGridView con los elementos filtrados.
        /// </summary>
        private void MostrarFiltroParticipantes()
        {
            dgListaFiltrada.DataSource = null;
            dgListaFiltrada.Rows.Clear();
            dgListaFiltrada.Columns.Clear();

            dgListaFiltrada.DataSource = _participantesFiltrados;

            // Mostrar solo la columna 'Titulo'
            foreach (DataGridViewColumn column in dgListaFiltrada.Columns)
            {
                if (column.Name == "Id_Participante" || column.Name == "Nombre" || column.Name == "Id_Hoja")
                {
                    column.Visible = true;
                }
                else column.Visible = false;
            }

            // Configurar la selección de filas completas
            dgListaFiltrada.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgListaFiltrada.MultiSelect = false;

        }

        /// <summary>
        /// Metodo que pinta los datos en el panel de acciones
        /// </summary>
        /// <param name="participanteSeleccionado">Participante elegido del dataGridView</param>
        private void MostrarDatosParticipante(Participante participanteSeleccionado)
        {
            lblIdParticipante.Text = participanteSeleccionado.Id_Participante.ToString();
            tbxNombreParti.Text = participanteSeleccionado.Nombre;
            tbxIdUsuarioParti.Text = participanteSeleccionado.Id_Usuario.HasValue ? participanteSeleccionado.Id_Usuario.Value.ToString() : "";
            tbxCorreoParti.Text = participanteSeleccionado.Correo;
            tbxIdHojaParti.Text = participanteSeleccionado.Id_Hoja.ToString();
        }
        #endregion


        #region PANEL ACCIONES
        /// <summary>
        /// Boton que ejecuta la accion elegida para la entidad Hojas.
        /// </summary>
        private void btnAccion_Click(object sender, EventArgs e)
        {
            switch (_accionElejida)
            {
                case "Agregar":
                    AgregarEntidad();
                    break;
                case "Modificar":
                    ModificarEntidad();
                    break;
                case "Eliminar":
                    EliminarEntidad();
                    break;
            }
        }     

        /// <summary>
        /// Metodo para Agregar la entidad elegida.
        /// </summary>
        private void AgregarEntidad()
        {
            switch (_entidadElejida)
            {
                case "Hojas":
                    AgregarHoja();
                    break;
                case "Participantes":
                    AgregarParticipante();
                    break;
            }
        }

        /// <summary>
        /// Metodo para Agregar la entidad elegida.
        /// </summary>
        private void ModificarEntidad()
        {
            switch (_entidadElejida)
            {
                case "Hojas":
                    ModificarHoja();
                    break;
                case "Participantes":
                    ModificarParticipante();
                    break;
            }
        }

        /// <summary>
        /// Metodo para eliminar la entidad elegida.
        /// </summary>
        private void EliminarEntidad()
        {
            switch (_entidadElejida)
            {
                case "Hojas":
                    EliminarHoja();
                    break;
                case "Participantes":
                    EliminarParticipante();
                    break;
            }
        }

        /// <summary>
        /// Metodo que inserta una nueva hoja.
        /// /// Comprueba los valores dados por el usuario segun logica.
        /// </summary>
        private void AgregarHoja()
        {
            //TITULO:
            string titulo = tbxTituloHoja.Text; ;
            if (String.IsNullOrEmpty(titulo))
            {
                MessageBox.Show("Debe contener un titulo obligatoriamente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //FECHA LIMITE:
            DateTime? fechaLimite = null;
            if (!cbxSinFechaLimite.Checked)
            {
                DateTime fecha = new DateTime();
                if( DateTime.TryParse(dtFechaLimite.Text, out fecha)) fechaLimite = fecha;              
                else
                {
                    MessageBox.Show("Formato de fecha incorrecto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }  
            //LIMITE GASTOS:
            Double? limiteGastos = null;
            if (!cbxSinLimiteGastos.Checked && !String.IsNullOrEmpty(tbxLimiteGastosHoja.Text))
            {
                bool isNumber = Validaciones.EsNumeroConDosDecimales(tbxLimiteGastosHoja.Text);
                if (isNumber) limiteGastos = Double.Parse(tbxLimiteGastosHoja.Text);
                else
                {
                    MessageBox.Show("El importe limite no es correcto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            //INSERTS:
            InsertHoja(titulo, fechaLimite, limiteGastos);         
        }

        /// <summary>
        /// Metodo que inserta los valores dados por el usuario en la accion AGREGAR (Hoja).
        /// </summary>
        /// <param name="titulo">titulo de la hoja</param>
        /// <param name="fechaLimite">fecha limite de la hoja</param>
        /// <param name="limiteGastos">limite de gastos de la hoja</param>
        private void InsertHoja(string titulo, DateTime? fechaLimite, Double? limiteGastos)
        {
            bool exito = false;
            int idHoja = _hojaServices.Crear(new Hoja(0, titulo, DateTime.Now, fechaLimite, limiteGastos, "C", _usuario.Id_Usuario));
            if (idHoja > 0)
            {
                exito = _participanteServices.Crear(new Participante(0, _usuario.Nombre, _usuario.Correo, _usuario.Id_Usuario, idHoja));
            }
            AvisoAccion(exito, lblAvisoAccion);
        }


        /// <summary>
        /// Metodo que inserta un nuevo Participante.
        /// Comprueba los valores dados por el usuario segun logica.
        /// </summary>
        private void AgregarParticipante()
        {
            //NOMBRE:
            string idHoja = tbxIdHojaParti.Text.Trim();
            string nombre = tbxNombreParti.Text.Trim();           
            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(idHoja))
            {
                MessageBox.Show("Faltan datos obligatorios!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //CORREO:
            string correo = tbxCorreoParti.Text.Trim(); ;
            if (!String.IsNullOrEmpty(correo))
            {
                bool correoValido = Validaciones.ValidaEmail(correo);
                if (!correoValido)
                {
                    MessageBox.Show("El correo no es valido, revíselo.!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else correo = null;
            //ID_HOJA
            bool idHojaAceptado = false;
            bool hojaEncontrada = false;
            int id_hoja;
            int.TryParse(idHoja, out id_hoja);

            foreach (var hoja in _usuario.Hojas)
            {
                if (hoja.Id_Hoja.Equals(id_hoja))
                {
                    hojaEncontrada = true;
                    if (!hoja.Status.Equals("C"))
                    {
                        MessageBox.Show("Imposible asignarle esa Hoja, no esta actualmente en Curso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else idHojaAceptado = true;
                   
                    break; // Rompe el bucle al encontrar la coincidencia             
                }
                
            }
            if (!hojaEncontrada)
            {
                MessageBox.Show("Ese ID_HOJA no pertenece a una hoja creada actualmente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //ID_USUARIO
            int? idUsuario = null;
            if (!String.IsNullOrEmpty(tbxIdUsuarioParti.Text))
            {
                idUsuario = int.Parse(tbxIdUsuarioParti.Text);
            }

            //INSERTS:
            if (!idHojaAceptado) return;
            else InsertParticipante( nombre, correo, idUsuario, id_hoja);  
        }

        /// <summary>
        /// Metodo que inserta el participante desde el boton AGREGAR (Participantes).
        /// </summary>
        /// <param name="nombre">nombre del participante</param>
        /// <param name="correo">correo del participante</param>
        /// <param name="idUsuario">identificador del participante</param>
        /// <param name="idHoja">identificador de la hoja</param>
        private void InsertParticipante(string nombre, string correo, int? idUsuario, int idHoja)
        {
            bool exito = false;
            exito = _participanteServices.Crear(new Participante(0, nombre, correo, idUsuario, idHoja));

            AvisoAccion(exito, lblAvisoParticipante);
        }


        /// <summary>
        /// Metodo que modifica la hoja seleccionada.
        /// </summary>
        private void ModificarHoja()
        {
            bool exito = false;
            int idHoja;
            if (int.TryParse(lblIdHoja.Text, out idHoja))
            {
                Hoja hojaAModificar = _hojasFiltradas.FirstOrDefault(hoja => hoja.Id_Hoja.Equals(idHoja));

                //TITULO:
                if (String.IsNullOrEmpty(tbxTituloHoja.Text))
                {
                    MessageBox.Show("El importe limite no es correcto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else hojaAModificar.Titulo = tbxTituloHoja.Text;

                //FECHA LIMITE:
                if (String.IsNullOrEmpty(tbxFechaLimiteHoja.Text) || cbxSinFechaLimite.Checked) hojaAModificar.Fecha_Cierre = null;
                else
                {
                    DateTime fecha = new DateTime();
                    if(DateTime.TryParse(tbxFechaLimiteHoja.Text, out fecha))
                    {
                        hojaAModificar.Fecha_Cierre = fecha;
                    }
                    else
                    {
                        MessageBox.Show("Formato de fecha incorrecto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //LIMITE GASTOS:
                if (String.IsNullOrEmpty(tbxLimiteGastosHoja.Text) || cbxSinLimiteGastos.Checked) hojaAModificar.Limite_Gastos = null;
                else hojaAModificar.Limite_Gastos = Double.Parse(tbxLimiteGastosHoja.Text);

                exito = _hojaServices.Actualizar(hojaAModificar);

                AvisoAccion(exito, lblAvisoAccion);
            }
            else
            {
                MessageBox.Show("No se encontró una hoja con el ID especificado.");
                return;
            }     
        }


        /// <summary>
        /// Metodo para modificar al participante seleccionado
        /// </summary>
        private void ModificarParticipante()
        {
            bool exito = false;
            int? idUsuarioByCorreo = null;

            //NOMBRE:
            string idHoja = tbxIdHojaParti.Text.Trim();
            string nombre = tbxNombreParti.Text.Trim();
            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(idHoja))
            {
                MessageBox.Show("Faltan datos obligatorios!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //CORREO:
            string correo = tbxCorreoParti.Text.Trim(); ;
            if (!String.IsNullOrEmpty(correo))
            {
                bool correoValido = Validaciones.ValidaEmail(correo); 
                if (!correoValido)
                {
                    MessageBox.Show("El correo no es valido, revíselo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else //correo valido
                {
                    Usuario usuarioConCorreo = _usuarioServices.ObtenerPorCorreo(correo); //Usuario de ese correo
                    if (usuarioConCorreo != null)
                    { 
                        idUsuarioByCorreo = usuarioConCorreo.Id_Usuario;
                    }   
                }
            }
            else correo = null;
            //ID_HOJA
            bool idHojaAceptado = false;
            bool hojaEncontrada = false;
            int id_hoja;
            int.TryParse(idHoja, out id_hoja);

            foreach (var hoja in _usuario.Hojas)
            {
                if (hoja.Id_Hoja.Equals(id_hoja))
                {
                    hojaEncontrada = true;
                    if (!hoja.Status.Equals("C"))
                    {
                        MessageBox.Show("Imposible modificarlo, esa Hoja ya no esta actualmente en Curso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else idHojaAceptado = true;

                    break; // Rompe el bucle al encontrar la coincidencia             
                }

            }
            if (!hojaEncontrada)
            {
                MessageBox.Show("Ese ID_HOJA no pertenece a una hoja creada actualmente!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //ID_USUARIO
            int? idUsuario = null;
            if (idUsuarioByCorreo == null) //El correo no tiene idUsuario registrado
            { 
                if (!String.IsNullOrEmpty(tbxIdUsuarioParti.Text)) //ya tiene idUsuario
                {
                    idUsuario = int.Parse(tbxIdUsuarioParti.Text);
                }
            }
            else idUsuario = idUsuarioByCorreo.Value; //El idUsuario es el del correo registrado.

            if (idUsuario != null && idUsuario.Equals(_usuario.Id_Usuario)) //El participante es el usuario logeado.
            {
                MessageBox.Show("Para realiar un cambio al usuario principal vaya a la pestaña MIS DATOS.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //INSERTS:
            if (!idHojaAceptado) return;
            exito = _participanteServices.Actualizar(new Participante(int.Parse(lblIdParticipante.Text), nombre, correo, idUsuario, id_hoja));

            AvisoAccion(exito, lblAvisoParticipante);

        }



        /// <summary>
        /// Metodo que elimina la hoja elegida.
        /// </summary>
        private void EliminarHoja()
        {
            bool exito = false;
            int idHoja;
            if (int.TryParse(lblIdHoja.Text, out idHoja))
            {
                Hoja hojaAEliminar = _hojasFiltradas.FirstOrDefault(hoja => hoja.Id_Hoja.Equals(idHoja));

                if(hojaAEliminar != null)
                {
                    hojaAEliminar.Participantes.ForEach(p =>
                    {
                        if (p != null)
                        {
                            _participanteServices.Eliminar(p.Id_Participante);
                        }
                    }); 
                    exito = _hojaServices.Eliminar(idHoja);

                    AvisoAccion(exito, lblAvisoAccion);
                }
                else
                {
                    MessageBox.Show("No se encontró una hoja con el ID especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Ese id no pertenece a ninguna hoja!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        /// <summary>
        /// Metodo que elimina al participante elegido.
        /// </summary>
        private void EliminarParticipante()
        {
            bool exito = false;
            bool hojaFinOBal = false;
            int idParticipante;
            if (int.TryParse(lblIdParticipante.Text, out idParticipante))
            {
                //Buscar participante:
                Participante participanteAEliminar = _participantesFiltrados.FirstOrDefault(p => p.Id_Participante.Equals(idParticipante));

                if (participanteAEliminar != null)
                {
                    //Buscar hojas Finalizadas o Balanceadas donde participe:
                    foreach (var hoja in _usuario.Hojas)
                    {
                        foreach (var participante in hoja.Participantes)
                        {
                            if (participante.Equals(participanteAEliminar) && !hoja.Status.Equals("C"))
                            {
                                hojaFinOBal = true; //Encontrada hoja donde participa y no esta en curso.
                                break;
                            }
                        }
                    }
                    if (hojaFinOBal)
                    {
                        MessageBox.Show("No se puede eliminar, es el participante de una hoja que ya no esta en Curso!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        exito = _participanteServices.Eliminar(idParticipante);
                        AvisoAccion(exito, lblAvisoParticipante);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró al participante en ninguna hoja.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Ese id no pertenece a ningun participante de la BBDD!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }


        /// <summary>
        /// Metodo que muestra el aviso de exito o fallo en la accion.
        /// </summary>
        /// <param name="exito">resultado del a accion elegida</param>
        private void AvisoAccion(bool exito, Label label)
        {
            if(exito)
            {
                label.Visible = true;
                label.Text = "Exito!";
                label.ForeColor = Color.GreenYellow;
                UpdateInfoUsuario();
            }
            else
            {
                label.Visible = true;
                label.Text = "Fallido!";
                label.ForeColor = Color.Crimson;
            }

            dgListaFiltrada.DataSource = null;
            dgListaFiltrada.Rows.Clear();
            dgListaFiltrada.Columns.Clear();
            LimpiarPanelAccion();
            _timerAviso.Start();
        }

        /// <summary>
        /// Metodo que lanza el formularo con la lista de participantes de la hoja filtrada.
        /// </summary>
        private void btnParticipantesHoja_Click(object sender, EventArgs e)
        {
            int idHoja;
            if (int.TryParse(lblIdHoja.Text, out idHoja))
            {
                Hoja hojaActual = _hojasFiltradas.FirstOrDefault(hoja => hoja.Id_Hoja.Equals(idHoja));

                if (hojaActual != null && hojaActual.Participantes != null && hojaActual.Participantes.Count > 0)
                {
                    // Crear una instancia del formulario de participantes y pasarle la lista
                    FormsParticipantes participantesForm = new FormsParticipantes(hojaActual.Participantes);
                    participantesForm.Show(); // O ShowDialog() si prefieres que sea modal
                }
                else
                {
                    MessageBox.Show("No hay participantes para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Ese id no pertenece a ninguna hoja!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } 
        }
        #endregion


        #region METODOS
        /// <summary>
        /// Metodo que recarga la info actualizada del usuario.
        /// </summary>
        private void UpdateInfoUsuario()
        {
            List<Hoja> listHojas = _updateUsuario.ObtenerHojas(_usuario.Id_Usuario);
            if (listHojas != null || listHojas.Count > 0)
            {
                _usuario.Hojas = _updateUsuario.CargarHojaConPart(listHojas);
                _usuario.Gastos = _updateUsuario.CargarGastos(listHojas, _usuario.Id_Usuario);
                _usuario.Hojas = _updateUsuario.CargarBalances(listHojas);
                _usuario.Pagos = _updateUsuario.CargarPagos(listHojas, _usuario.Id_Usuario);
            }
        }

        /// <summary>
        /// Metodo para limpiar los texbox de panel de accion
        /// </summary>
        private void LimpiarPanelAccion()
        {
            switch (_entidadElejida)
            {
                case "Hojas":
                    lblIdHoja.Text = "0";
                    lblParticipanesCount.Text = "0";
                    tbxLimiteGastosHoja.Clear();
                    tbxTituloHoja.Clear();
                    tbxFechaLimiteHoja.Clear();
                    tbxStatusHoja.Clear();
                    tbxFechaCreacionHoja.Clear();
                    cbxSinLimiteGastos.Checked = false;
                    cbxSinFechaLimite.Checked = false;
                    break;
                case "Participantes":
                    lblIdParticipante.Text = "0";
                    tbxNombreParti.Clear();
                    tbxIdUsuarioParti.Clear();
                    tbxCorreoParti.Clear();
                    tbxIdHojaParti.Clear();
                    break;
            }
           
        }

        /// <summary>
        /// Metodo para limpiar el panel de filtros
        /// </summary>
        private void LimpiarPanelFiltros()
        {
            cbxFiltros.Items.Clear();
            cbxFiltros.Text = string.Empty;
            tbxFiltroTexto.Clear();
            dgListaFiltrada.DataSource = null;
            dgListaFiltrada.Rows.Clear();
            dgListaFiltrada.Columns.Clear();
        }

        /// <summary>
        /// Metodo que prepara el panel para la accion elegida
        /// </summary>
        /// <param name="habilita">true si se elige la accion de eliminacion</param>
        private void HabilitaSoloBtnAccion(bool habilita)
        {
            switch (_entidadElejida)
            {
                case "Hojas":
                    tbxLimiteGastosHoja.Enabled = !habilita;
                    tbxTituloHoja.Enabled = !habilita;
                    tbxFechaLimiteHoja.Enabled = !habilita;
                    cbxSinLimiteGastos.Enabled = !habilita;
                    cbxSinFechaLimite.Enabled = !habilita;
                    lblParticipanesCount.Enabled = !habilita;
                    lblParticipantesHoja.Enabled = !habilita;
                    btnParticipantesHoja.Enabled = !habilita;
                    break;
                case "Participantes":
                    tbxNombreParti.Enabled = !habilita;                   
                    tbxCorreoParti.Enabled = !habilita;
                    tbxIdHojaParti.Enabled = !habilita;
                    break;
            }
        }

        /// <summary>
        /// Creacion de un Timer para el aviso de la accion.
        /// </summary>
        private void InstanciaTimer()
        {
            _timerAviso = new System.Windows.Forms.Timer();
            _timerAviso.Interval = 3000; // 3 segundos
            _timerAviso.Tick += TimerAviso_Tick;
        }


        /// <summary>
        /// Metodo que se llama una vez termina el Timer
        /// </summary>
        private void TimerAviso_Tick(object sender, EventArgs e)
        { 
            _timerAviso.Stop();
            switch (_entidadElejida)
            {
                case "Hojas":
                    lblAvisoAccion.Visible = false;
                    break;
                case "Participantes":
                    lblAvisoParticipante.Visible = false;
                    break;
            }    
        }


        /// <summary>
        /// Metodo que control el valor nulo de la fecha limite
        /// </summary>
        private void cbxSinFechaLimite_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSinFechaLimite.Checked)
            {
                dtFechaLimite.Enabled = false;
                tbxFechaLimiteHoja.Enabled = false;
            }
            else
            {
                dtFechaLimite.Enabled = true;
                tbxFechaLimiteHoja.Enabled = true;
            }
        }

        /// <summary>
        /// Metodo que control el valor nulo del limite de gastos
        /// </summary>
        private void cbxSinLimiteGastos_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxSinLimiteGastos.Checked)
            {
                tbxLimiteGastosHoja.Enabled = false;
            }
            else tbxLimiteGastosHoja.Enabled = true;
            
        }
        #endregion
  
    }
}
