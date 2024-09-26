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
        private UsuarioServices usuarioService;
        private Navigation nav;
        private Usuario usuario;

        public FormMisCuentas()
        {
            InitializeComponent();
            this.nav = new Navigation(this);
            nav.AbrirFormEnPanel(new Inicio());
            string cadenaConexion = conn.Conexion();
            this.usuarioService = new UsuarioServices(cadenaConexion);
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

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            nav.AbrirFormEnPanel(new MisDatos());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
           
        }

        private void pbxHome_Click(object sender, EventArgs e)
        {
            nav.AbrirFormEnPanel(new Inicio());
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void pbxLogin_Click(object sender, EventArgs e)
        {
            nav.AbrirFormEnPanel(new Login(this));
        }

        private void pbxUsuarioLoginNOK_Click(object sender, EventArgs e)
        {
            nav.AbrirFormEnPanel(new Login(this));
        }

        private void pbxUsuarioLoginOK_Click(object sender, EventArgs e)
        {
            //cerrar sesion
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            nav.AbrirFormEnPanel(new Informes());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nav.AbrirFormEnPanel(new Avanzado());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void MouseMove_Home(object sender, MouseEventArgs e)
        {
            pbxHome.BackColor = Color.DarkGray;
        }

        private void MouseLeave_Home(object sender, EventArgs e)
        {
            pbxHome.BackColor = Color.Silver;
        }

        private void MouseLeave_User(object sender, EventArgs e)
        {
            pbxUsuarioLoginOK.BackColor = Color.Silver;
            pbxUsuarioLoginNOK.BackColor = Color.Silver;
        }

        private void MouseMove_User(object sender, MouseEventArgs e)
        {
            pbxUsuarioLoginOK.BackColor = Color.DarkGray;
            pbxUsuarioLoginNOK.BackColor = Color.DarkGray;
        }

        // Método público para mostrar un mensaje en el Label
        public void MostrarMensaje(string mensaje)
        {
            lblInformacion.Visible = true;
            lblInformacion.Text = mensaje;
        }
    }
}
