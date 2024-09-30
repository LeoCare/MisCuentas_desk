using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Model;
using MisCuentas_desk.Services.Balances;
using MisCuentas_desk.Services.Gastos;
using MisCuentas_desk.Services.Hojas;
using MisCuentas_desk.Services.Pagos;
using MisCuentas_desk.Services.Participantes;
using MisCuentas_desk.Services.PersonalData;
using MisCuentas_desk.Services.Usuarios;
using MisCuentas_desk.Utils;
using MisCuentas_desk.Views;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MisCuentas_desk
{
    public partial class Login : Form
    {
        #region ATRIBUTOS
        private Usuario _usuario;
        private MisCuentasConnect conn = new MisCuentasConnect();
        private UsuarioServices usuarioServices;
        private PersonalDataServices personalDataServices;
        private HojaServices _hojaServices;
        private PagoServices _pagoServices;
        private ParticipanteServices _participanteServices;
        private GastoServices _gastoServices;
        private BalanceServices _balanceServices;
        private FormMisCuentas formMisCuentas;
        private Navigation nav;
        private bool controlTimer = false;
        #endregion

        #region CONSTRUCTOR
        public Login(FormMisCuentas formMisCuentas)
        {
            InitializeComponent();
            string cadenaConexion = conn.Conexion();
            usuarioServices = new UsuarioServices(cadenaConexion);
            personalDataServices = new PersonalDataServices(cadenaConexion);
            _hojaServices = new HojaServices(cadenaConexion);
            _pagoServices = new PagoServices(cadenaConexion);
            _participanteServices = new ParticipanteServices(cadenaConexion);
            _gastoServices = new GastoServices(cadenaConexion);
            _balanceServices = new BalanceServices(cadenaConexion);
            _usuario = new Usuario();
            this.formMisCuentas = formMisCuentas;
            this.nav = new Navigation(formMisCuentas);
        }
        #endregion

       
        /// <summary>
        /// Metodo que controla el desplazamiento de la ventana de LOGIN
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!controlTimer)
            {
                panelContenedorLogin.Left += 10;
                panelRegistrar.BringToFront();
                panelRegistrar.Show();
                if(panelContenedorLogin.Left == 720)
                {
                    timer1.Stop();
                    controlTimer = true;
                }
            }
            else
            {
                panelContenedorLogin.Left -= 10;
                panelEntrar.BringToFront();
                panelEntrar.Show();
                if(panelContenedorLogin.Left == 310)
                {
                    timer1.Stop ();
                    controlTimer = false;
                }
            }
        }

        #region LOGEO
        /// <summary>
        /// Metodo que nos dirige al formulario de Login
        /// </summary>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }


        /// <summary>
        /// Metodo que verifica el acceso y no dirige a MisDatos
        /// </summary>
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string correo = tbxUsuario.Text;
            string contrasenna = tbxPass.Text;

            if (!ValidarDatosLogin()) MessageBox.Show("Faltan datos para poder Entrar!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else ObtenerUsuarioLogin(correo, contrasenna);
            
        }

        /// <summary>
        /// Metodo para obtener el usuario de la BBDD.
        /// </summary>
        /// <param name="correo">Correo del logeado</param>
        /// <param name="contrasenna">Contraseña del logeado</param>
        private void ObtenerUsuarioLogin(string correo, String contrasenna)
        {
            Usuario usuario = usuarioServices.ObtenerUsuarioPorCorreo(correo, contrasenna);
            if(usuario != null)
            {
                //Instanciar usuario y sus datos
                _usuario = Usuario.ObtenerInstancia(usuario);
                CargarInfoUsuario();
                UsuarioLogeadoOK(_usuario);
            }
            else MessageBox.Show("Correo o contraseña incorrectos!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        /// <summary>
        /// Metodo que se encarga de cargar las Hojas, gastos, pagos y demas
        /// </summary>
        private void CargarInfoUsuario()
        {
            ObtenerDatosPersonales(_usuario.Id_Usuario);

            //Cargar hojas, gastos, pagos y balances
            List<Hoja> listHojas = ObtenerHojas(_usuario.Id_Usuario);
            if (listHojas != null || listHojas.Count > 0)
            {
                ObtenerYCargarHojaPart(listHojas);
                CargarGastos(listHojas);
            }

            UsuarioLogeadoOK(_usuario);
        }


        /// <summary>
        /// Metodo que obtiene, o instancia si aun no estan creados, los datos personales.
        /// </summary>
        /// <param name="idUsuario">Id del usuario creado</param>    
        private void ObtenerDatosPersonales(int idUsuario)
        {
            //Obtener Personal_Data
            Personal_Data datos = personalDataServices.ObtenerPorId(idUsuario);

            if (datos == null)
            {
                datos = new Personal_Data(idUsuario, null, null, null, null, null);
                //Insert Personal_Data
                bool actualizado = personalDataServices.Crear(datos);
                if (actualizado) _usuario.Personal_Data = datos;
            }
            else _usuario.Personal_Data = datos;
        }


        /// <summary>
        /// Metodo que carga las hojas del usuario
        /// </summary>
        /// <returns>Lista de hojas</returns>
        private List<Hoja> ObtenerHojas(int id_usuario)
        {

            return (List<Hoja>)_hojaServices.ObtenerPorIdUsuario(id_usuario);

        }


        /// <summary>
        /// Metodo que carga los participantes de cada hoja
        /// </summary>
        private void ObtenerYCargarHojaPart(List<Hoja> listHojas)
        {
            List<Participante> listParticipantes = new List<Participante>();

            //Cargar participantes por Hoja:
            listHojas.ForEach(hoja =>
            {
                listParticipantes = ((List<Participante>)_participanteServices.ObtenerParticipantesPorHoja(hoja.Id_Hoja));

                if (listParticipantes != null && listParticipantes.Count > 0)
                {
                    hoja.Participantes = listParticipantes;
                    _usuario.Hojas.Add(hoja);
                }
            });

        }


        /// <summary>
        /// Metodo que carga los gastos solo donde el usuario logeado participe
        /// </summary>
        private void CargarGastos(List<Hoja> listHojas)
        {
            List<Gasto> listGastos = new List<Gasto>();

            //Buscarme como participante:
            listHojas.ForEach(hoja =>
            {
                hoja.Participantes.ForEach(participante =>
                {
                    if (participante.Id_Usuario.Equals(_usuario.Id_Usuario))
                    {
                        //Cargar mis gastos:
                        listGastos = ((List<Gasto>)_gastoServices.ObtenerPorIdParticipante(participante.Id_Participante));

                        if (listGastos != null && listGastos.Count > 0)
                        {
                            _usuario.Gastos.AddRange(listGastos);
                        }
                    }
                });
            });
        }



        /// <summary>
        /// Metodo para validar la sintaxis de los datos introducidos
        /// </summary>
        /// <returns>true o false segun corresponda</returns>
        private bool ValidarDatosLogin()
        {
            bool valido = true;

            while (valido)
            {
                if (String.IsNullOrEmpty(tbxUsuario.Text) || String.IsNullOrEmpty(tbxPass.Text)) return false;
                if (!Validaciones.ValidaPass(tbxPass.Text)) return false;
                valido = false;
            }

            return true;
        }
        #endregion



        #region REGISTRO
        /// <summary>
        /// Metodo que nos dirige al formulario de Registro
        /// </summary>
        private void btnRegistro_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        /// <summary>
        /// Metodo que inicia el registro:
        /// UsuarioCrear para instanciar el usuario.
        /// CorreoExiste para comprobar correo en la BBDD.
        /// Crear para realizar el insert en la BBDD
        /// </summary>
        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            bool existe = false;
            int idUsuario = 0;

            Usuario usuarioACrear = UsuarioACrear();
            if (usuarioACrear != null)
            {
                existe = usuarioServices.CorreoExiste(usuarioACrear.Correo);

                if (existe) MessageBox.Show("Ese correo ya esta registrado!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    idUsuario = usuarioServices.Crear(usuarioACrear);
                }
                if (idUsuario != 0)
                {
                    Usuario usuario = usuarioServices.ObtenerUsuarioPorId(idUsuario);
                    if (usuario != null)
                    {
                        //Instanciar usuario y sus datos
                        _usuario = Usuario.ObtenerInstancia(usuario);
                        CargarInfoUsuario();
                        UsuarioLogeadoOK(_usuario);
                    }
                }
            }
        }

      
        /// <summary>
        /// Metodo que verifica los datos e instancia el usuario.
        /// </summary>
        /// <returns></returns>
        private Usuario UsuarioACrear()
        {
            string nombre = tbxNombreRegistro.Text;
            string correo = tbxCorreoRegistro.Text;
            string contrasenna = tbxPassRegistro.Text;
            string perfil = "ADMIN";

            if (!ValidarDatosRegistro()) MessageBox.Show("Faltan datos para completar el registro!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            else
            { 
                Usuario usuario = new Usuario(nombre, correo, contrasenna, perfil);
                return usuario;
            }
            return null;
        }

        /// <summary>
        /// Metodo que verifica los datos e instancia el usuario.
        /// </summary>
        /// <returns></returns>
        private Personal_Data PersonalDataACrear(Usuario usuarioCreado)
        {
            return new Personal_Data(
                usuarioCreado.Id_Usuario, 
                null,
                null,
                null, 
                null,
                null);
        }


        /// <summary>
        /// Metodo para validar sintaxis de los datos introducidos.
        /// </summary>
        /// <returns>true o false segun corresponda</returns>
        private bool ValidarDatosRegistro()
        {
            bool valido = true;
            string nombre = tbxNombreRegistro.Text;
            string correo = tbxCorreoRegistro.Text;
            string contrasenna = tbxPassRegistro.Text;

            while (valido)
            {
                if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(correo) || String.IsNullOrEmpty(contrasenna)) return false;
                if (!Validaciones.ValidaPass(tbxPassRegistro.Text)) return false;
                if (!Validaciones.ValidaEmail(tbxCorreoRegistro.Text)) return false;
                valido = false;
            }

            return true;
        }
        #endregion




        #region METODOS 
        /// <summary>
        /// Metodo para instanciar el usuario creado como Singleton
        /// </summary>
        private void InstanciaUsuario(Usuario usuario, Personal_Data datos)
        {         
            UsuarioLogeadoOK(usuario);
        }

        /// <summary>
        /// Metodo que navega a Mis datos si todo esta OK
        /// </summary>
        /// <param name="usuario">Instancia de Usuario para pasar al formulario MisDatos</param>
        private void UsuarioLogeadoOK(Usuario usuario)
        {
            this.Close();
            formMisCuentas.pbxUsuarioLoginOK.Visible = true;
            formMisCuentas.pbxUsuarioLoginNOK.Visible = false;
            formMisCuentas.MostrarMensaje($"Bienvenido/a {usuario.Nombre}");
            formMisCuentas.InstanciaUsuario(usuario);
            nav.AbrirFormEnPanel(new MisDatos(usuario, formMisCuentas));
        }

        /// <summary>
        /// Metodo que muestra la contraseña introducida
        /// </summary>
        private void btnVerPassLogin_Click(object sender, EventArgs e)
        {
            if (tbxPass.PasswordChar == '*')
            {
                tbxPass.PasswordChar = '\0'; // Muestra la contraseña
                btnNoVerPassLogin.Visible = true;
                btnVerPassLogin.Visible = false;
            }
            else
            {
                tbxPass.PasswordChar = '*'; // Oculta la contraseña
                btnNoVerPassLogin.Visible = false;
                btnVerPassLogin.Visible = true;
            }

        }

        /// <summary>
        /// Metodo que oculta la contraseña introducida
        /// </summary>
        private void btnVerPassRegistro_Click(object sender, EventArgs e)
        {
            if (tbxPassRegistro.PasswordChar == '*')
            {
                tbxPassRegistro.PasswordChar = '\0'; // Muestra la contraseña
                btnNoVerPassRegistro.Visible = true;
                btnVerPassRegistro.Visible = false;
            }
            else
            {
                tbxPassRegistro.PasswordChar = '*'; // Oculta la contraseña
                btnNoVerPassRegistro.Visible = false;
                btnVerPassRegistro.Visible = true;
            }
        }
        #endregion
    }
}
