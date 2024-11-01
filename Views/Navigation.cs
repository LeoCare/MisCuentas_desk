﻿using MisCuentas_desk.Entities;
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
                case FormsMisDatos _:
                    formMisCuentas.btnMisDatos.BackColor = Color.DarkGray;                   
                    formMisCuentas.btnInformes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnSolicitudes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnAvanzado.BackColor = Color.MediumTurquoise;
                    break;
                case FormsInformes _:
                    formMisCuentas.btnMisDatos.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnInformes.BackColor = Color.DarkGray;
                    formMisCuentas.btnSolicitudes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnAvanzado.BackColor = Color.MediumTurquoise;
                    break;
                case
                    FormsSolicitudes _:
                    formMisCuentas.btnMisDatos.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnInformes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnSolicitudes.BackColor = Color.DarkGray;
                    formMisCuentas.btnAvanzado.BackColor = Color.MediumTurquoise;
                    break;
                case
                    FormsAvanzado _:
                    formMisCuentas.btnMisDatos.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnInformes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnSolicitudes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnAvanzado.BackColor = Color.DarkGray;
                    break;
                default:
                    formMisCuentas.btnMisDatos.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnInformes.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnAvanzado.BackColor = Color.MediumTurquoise;
                    formMisCuentas.btnSolicitudes.BackColor = Color.MediumTurquoise;
                    break;
            }
        }
    }
}
