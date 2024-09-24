using MisCuentas_desk.Configurations;
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

        public FormMisCuentas()
        {
            InitializeComponent();
            AbrirFormEnPanel(new Views.Inicio());
            conn.Conecta();
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

        private Form formActivo = null;
        private void AbrirFormEnPanel(Form formhija)
        {
            if (formActivo != null) formActivo.Close();
            formActivo = formhija;
            formhija.TopLevel = false;
            formhija.FormBorderStyle = FormBorderStyle.None;
            formhija.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(formhija);
            panelContenedor.Tag = formhija;
            formhija.BringToFront();
            formhija.Show();

        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Views.MisDatos());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
           
        }

        private void pbxHome_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Views.Inicio());
        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void pbxLogin_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Login());
        }

        private void btnInformes_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Views.Informes());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Views.Avanzado());
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
    }
}
