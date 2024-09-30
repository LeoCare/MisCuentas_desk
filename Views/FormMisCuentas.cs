using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.Usuarios;
using MisCuentas_desk.Views;
using NLog.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisCuentas_desk
{
    public partial class FormMisCuentas : Form
    {
        private MisCuentasConnect conn = new MisCuentasConnect();
        private UsuarioServices _usuarioService;
        private Navigation _nav;
        private Usuario _usuario;

        public FormMisCuentas()
        {
            InitializeComponent();
            _nav = new Navigation(this);
            _nav.AbrirFormEnPanel(new Inicio());
            string cadenaConexion = conn.Conexion();
            _usuarioService = new UsuarioServices(cadenaConexion);
            ConexionEstablecida();
            
        }


        private void ConexionEstablecida()
        {
            if (conn.PruebaConexion()) {
                pbxConectaOK.Visible = true;
                pbxConectaNOK.Visible = false;
            }
            else
            {
                pbxConectaOK.Visible = false;
                pbxConectaNOK.Visible = true;
            }
        }

        public void InstanciaUsuario(Usuario usuario)
        {
            _usuario = Usuario.ObtenerInstancia(usuario);
        }


        /// <summary>
        /// Metodo navegar al inicio.
        /// Boton superior izquierdo.
        /// </summary>
        private void pbxHome_Click(object sender, EventArgs e)
        {
            _nav.AbrirFormEnPanel(new Inicio());
        }

        /// <summary>
        /// Hora actual
        /// </summary>
        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// Metodo para el inicio de sesion
        /// Boton superior derecho.
        /// </summary>
        private void pbxUsuarioLoginNOK_Click(object sender, EventArgs e)
        {
            _nav.AbrirFormEnPanel(new Login(this));
        }

        /// <summary>
        /// Metodo para el cierre de sesion.
        /// Boton superior derecho.
        /// </summary>
        private void pbxUsuarioLoginOK_Click(object sender, EventArgs e)
        {
            RetornoLogin();
            _nav.AbrirFormEnPanel(new Login(this));
        }

        /// <summary>
        /// Metodo para el cierre de sesion o eliminacion de cuenta.
        /// </summary>
        public void RetornoLogin()
        { 
            _usuario = null;
            Usuario.CerrarSesion();
            lblInformacion.Text = "Inicia sesion";
            pbxUsuarioLoginNOK.Visible = true;
            pbxUsuarioLoginOK.Visible = false;    
        }

        /// <summary>
        /// Metodo para navegar al formulario MisDatos.
        /// Boton panel lateral izquierdo.
        /// </summary>
        private void btnMisDatos_Click(object sender, EventArgs e)
        {
            if (_usuario != null) _nav.AbrirFormEnPanel(new MisDatos(_usuario, this));
        }

        /// <summary>
        /// Metodo para navegar al formulario Informes.
        /// Boton panel lateral izquierdo.
        /// </summary>
        private void btnInformes_Click(object sender, EventArgs e)
        {
            if (_usuario != null) _nav.AbrirFormEnPanel(new Informes(_usuario, this));
        }

        /// <summary>
        /// Metodo para navegar al formulario Avanzado.
        /// Boton panel lateral izquierdo.
        /// </summary>
        private void btnAvanzado_Click(object sender, EventArgs e)
        {
            if (_usuario != null) _nav.AbrirFormEnPanel(new Avanzado(_usuario, this));
        }

        /// <summary>
        /// Metodo para cerrar la aplicacion.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        /// <summary>
        /// Metodo que cambia el color al pasar con el raton por encima del boton.
        /// </summary>
        private void MouseMove_Home(object sender, MouseEventArgs e)
        {
            pbxHome.BackColor = Color.DarkGray;
        }

        /// <summary>
        /// Metodo que cambia el color al dejar de pasar con el raton por encima del boton.
        /// </summary>
        private void MouseLeave_Home(object sender, EventArgs e)
        {
            pbxHome.BackColor = Color.Silver;
        }

        /// <summary>
        /// Metodo que cambia el color al dejar de pasar con el raton por encima del boton.
        /// </summary>
        private void MouseLeave_User(object sender, EventArgs e)
        {
            pbxUsuarioLoginOK.BackColor = Color.Silver;
            pbxUsuarioLoginNOK.BackColor = Color.Silver;
        }

        /// <summary>
        /// Metodo que cambia el color al pasar con el raton por encima del boton.
        /// </summary>
        private void MouseMove_User(object sender, MouseEventArgs e)
        {
            pbxUsuarioLoginOK.BackColor = Color.DarkGray;
            pbxUsuarioLoginNOK.BackColor = Color.DarkGray;
        }
       
        /// <summary>
        /// Metodo que modifica el texto del panel informativo superior.
        /// </summary>
        public void MostrarMensaje(string mensaje)
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = mensaje;
        }
    }
}
