using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Model;
using MisCuentas_desk.Services.PersonalData;
using MisCuentas_desk.Services.Usuarios;
using MisCuentas_desk.Utils;
using MisCuentas_desk.Views;
using System;
using System.Windows.Forms;

namespace MisCuentas_desk
{
    public partial class Login : Form
    {
        #region ATRIBUTOS
        private MisCuentasConnect conn = new MisCuentasConnect();
        private UsuarioServices usuarioServices;
        private PersonalDataServices personalDataServices;
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
                //Obtener Personal_Data
                Personal_Data datos = personalDataServices.ObtenerPorId(usuario.Id_Usuario);

                if (datos == null)
                {
                    datos = new Personal_Data(usuario.Id_Usuario, null, null, null, null, null);
                    //Insert Personal_Data
                    bool actualizado = personalDataServices.Crear(datos);
                }
                InstanciaUsuario(usuario, datos);
            }
            else MessageBox.Show("Correo o contraseña incorrectos!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            bool creado = false;
            Usuario usuarioACrear = UsuarioACrear();
            if (usuarioACrear != null)
            {
                existe = usuarioServices.CorreoExiste(usuarioACrear.Correo);

                if (existe) MessageBox.Show("Ese correo ya esta registrado!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    creado = usuarioServices.Crear(usuarioACrear);
                }
                if (creado)
                {
                    Usuario usu = usuarioServices.ObtenerPorCorreo(usuarioACrear.Correo);
                    Personal_Data datos = PersonalDataACrear(usu);
                    if(personalDataServices.Crear(datos)) InstanciaUsuario(usu, datos); 
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
            usuario.Personal_Data = datos;
            Usuario.ObtenerInstancia(usuario);
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
