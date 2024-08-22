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
        public FormMisCuentas()
        {
            InitializeComponent();
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
            AbrirFormEnPanel(new Login());
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
           
        }   
    }
}
