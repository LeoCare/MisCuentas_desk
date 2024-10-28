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
    public partial class FormsLogin : Form
    {
        #region ATRIBUTOS
        private Usuario _usuario;
        private MisCuentasConnect _conn = new MisCuentasConnect();
        private UsuarioServices _usuarioServices;
        private FormMisCuentas _formMisCuentas;
        private Navigation _nav;
        private bool _controlTimer = false;
        private UpdateDataUsuario _updateUsuario;
        #endregion

        #region CONSTRUCTOR
        public FormsLogin(FormMisCuentas formMisCuentas)
        {
            InitializeComponent();
            string cadenaConexion = _conn.Conexion();
            _usuarioServices = new UsuarioServices(cadenaConexion);
            _usuario = new Usuario();
            _updateUsuario = new UpdateDataUsuario();
            _formMisCuentas = formMisCuentas;
            _nav = new Navigation(formMisCuentas);
        }
        #endregion

        #region EVENTOS
        /// <summary>
        /// Metodo que controla el desplazamiento de la ventana de LOGIN
        /// </summary>
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!_controlTimer)
            {
                panelContenedorLogin.Left += 10;
                panelRegistrar.BringToFront();
                panelRegistrar.Show();
                if(panelContenedorLogin.Left == 720)
                {
                    timer1.Stop();
                    _controlTimer = true;
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
                    _controlTimer = false;
                }
            }
        }
        #endregion

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
            Usuario usuario =  _usuarioServices.ObtenerUsuarioVerificadoPorCorreo(correo, contrasenna);
            if(usuario != null)
            {
                //Instanciar usuario y sus datos
                _usuario = Usuario.ObtenerInstancia(usuario);
                CargarInfoUsuario();
            }
            else MessageBox.Show("Correo o contraseña incorrectos!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }


        /// <summary>
        /// Metodo que se encarga de cargar las Hojas, gastos, pagos y demas
        /// </summary>
        private void CargarInfoUsuario()
        {
            _usuario.Personal_Data = _updateUsuario.ObtenerDatosPersonales(_usuario.Id_Usuario);
            List<Hoja> listHojas = _updateUsuario.ObtenerHojas(_usuario.Id_Usuario);
            if (listHojas != null || listHojas.Count > 0)
            {
                _usuario.Hojas = _updateUsuario.CargarHojaConPart(listHojas);
                _usuario.Gastos = _updateUsuario.CargarGastos(listHojas, _usuario.Id_Usuario);
                _usuario.Hojas = _updateUsuario.CargarBalances(listHojas);
                _usuario.Pagos = _updateUsuario.CargarPagos(listHojas, _usuario.Id_Usuario);
            }

            UsuarioLogeadoOK(_usuario);
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
                existe = _usuarioServices.CorreoExiste(usuarioACrear.Correo);

                if (existe) MessageBox.Show("Ese correo ya esta registrado!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    idUsuario = _usuarioServices.Crear(usuarioACrear);
                }
                if (idUsuario != 0)
                {
                    Usuario usuario = _usuarioServices.ObtenerUsuarioPorId(idUsuario);
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
            _formMisCuentas.pbxUsuarioLoginOK.Visible = true;
            _formMisCuentas.pbxUsuarioLoginNOK.Visible = false;
            _formMisCuentas.MostrarMensaje($"Bienvenido/a    {usuario.Nombre}");
            _formMisCuentas.InstanciaUsuario(usuario);
            _nav.AbrirFormEnPanel(new FormsMisDatos(usuario, _formMisCuentas));
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
