using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisCuentas_desk.Views
{
    public partial class Informes : Form
    {
        public Informes()
        {
            InitializeComponent();
        }


        private void btnVerMisHojas_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.OliveDrab;
        }

        private void btnVerMisGastos_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.DeepSkyBlue;
        }

        private void btnVerMisPagos_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.MediumVioletRed;
        }

        private void btnVerMisBalances_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.Goldenrod;
        }

     
    }
}
