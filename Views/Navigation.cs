using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisCuentas_desk.Views
{
    public class Navigation
    {
        private FormMisCuentas formMisCuentas;
       

        public Navigation(FormMisCuentas formMisCuentas) 
        {
            this.formMisCuentas = formMisCuentas;   
        }

        private Form formActivo = null;
        public void AbrirFormEnPanel(Form formHija)
        {
            if (formActivo != null) formActivo.Close();
            formActivo = formHija;
            formHija.TopLevel = false;
            formHija.FormBorderStyle = FormBorderStyle.None;
            formHija.Dock = DockStyle.Fill;
            formMisCuentas.panelContenedor.Controls.Add(formHija);
            formMisCuentas.panelContenedor.Tag = formHija;
            formHija.BringToFront();
            formHija.Show();
            PintarBotonFormulario(formHija);
        }

        /// <summary>
        /// Mantiene pintado el boton seleccionado
        /// </summary>
        /// <param name="formHija"></param>
        private void PintarBotonFormulario(Form formHija)
        {
            switch (formHija)
            {
                case MisDatos _:
                    formMisCuentas.btnMisDatos.BackColor = Color.DarkGray;
                    formMisCuentas.btnMisDatos.FlatStyle = FlatStyle.Flat;
                    formMisCuentas.btnInformes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnAvanzado.BackColor = Color.MediumTurquoise;
                    break;
                case Informes _:
                    formMisCuentas.btnMisDatos.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnInformes.BackColor = Color.DarkGray;
                    formMisCuentas.btnAvanzado.BackColor = Color.MediumTurquoise;
                    break;
                case
                    Avanzado _:
                    formMisCuentas.btnMisDatos.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnInformes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnAvanzado.BackColor = Color.DarkGray;
                    break;
                default:
                    formMisCuentas.btnMisDatos.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnInformes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnAvanzado.BackColor = Color.MediumTurquoise;
                    break;
            }
        }
    }
}
