using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.Usuarios;
using MisCuentas_desk.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisCuentas_desk
{
    public partial class Login : Form
    {
        #region ATRIBUTOS
        private MisCuentasConnect conn = new MisCuentasConnect();
        private UsuarioServices usuarioServices;
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string correo = tbxUsuario.Text;
            string contrasenna = tbxPass.Text;
            if (String.IsNullOrEmpty(correo) || String.IsNullOrEmpty(contrasenna))
            {

                MessageBox.Show("Faltan datos para poder Entrar!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                ObtenerUsuarioLogin(correo, contrasenna);
            }
        }

        private void ObtenerUsuarioLogin(string correo, String contrasenna)
        {
            Usuario usuario = usuarioServices.ObtenerUsuarioPorCorreo(correo, contrasenna);
            if(usuario != null)
            {
                Usuario.ObtenerInstancia(usuario);
                UsuarioLogeadoOK();
            }
            else MessageBox.Show("Correo o contraseña incorrectos!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    InstanciaUsuario(usuarioACrear);
;                   UsuarioLogeadoOK();
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

            if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(correo) || String.IsNullOrEmpty(contrasenna))
            {

                MessageBox.Show("Faltan datos para completar el registro!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Usuario usuario = new Usuario(nombre, correo, contrasenna, perfil);
                return usuario;
            }
            return null;
        }   
        #endregion

        /// <summary>
        /// Metodo para instanciar el usuario creado como Singleton
        /// </summary>
        private void InstanciaUsuario(Usuario usuario)
        {
            Usuario usu = usuarioServices.ObtenerPorCorreo(usuario.Correo);
            Usuario.ObtenerInstancia(usu);
        }

        private void UsuarioLogeadoOK(Usuario usuario)
        {
            this.Close();
            formMisCuentas.pbxUsuarioLoginOK.Visible = true;
            formMisCuentas.pbxUsuarioLoginNOK.Visible = false;
            formMisCuentas.MostrarMensaje($"Bienvenido {usuario.Nombre}");
            nav.AbrirFormEnPanel(new MisDatos());
        }

    }
}
