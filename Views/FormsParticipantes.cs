using MisCuentas_desk.Entities;
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
    public partial class FormsParticipantes : Form
    {
        #region ATRIBUTOS
        private List<Participante> participantes;
        #endregion

        #region CONSTRUCTOR
        public FormsParticipantes(List<Participante> participantes)
        {
            InitializeComponent();
            this.participantes = participantes;
            CargarParticipantes();
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo para cargar los participantes en el listBox del formulario.
        /// </summary>
        private void CargarParticipantes()
        {
            // Asumiendo que tienes un ListBox llamado listBoxParticipantes
            foreach (var participante in participantes)
            {
                lbxParticipantes.Items.Add(participante.Nombre);
            }
        }

        /// <summary>
        /// Metodo que cierra el formulario.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
