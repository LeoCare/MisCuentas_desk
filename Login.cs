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
        public Login()
        {
            InitializeComponent();
        }

        private bool controlTimer = false;
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
                if(panelContenedorLogin.Left == 240)
                {
                    timer1.Stop ();
                    controlTimer = false;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

       
    }
}
