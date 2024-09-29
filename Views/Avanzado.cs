using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.PersonalData;
using MisCuentas_desk.Services.Usuarios;
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
    public partial class Avanzado : Form
    {
        #region ATRIBUTOS
        private Usuario usuario;
        private MisCuentasConnect conn = new MisCuentasConnect();
        private UsuarioServices usuarioServices;
        private FormMisCuentas formMisCuentas;
        #endregion

        #region CONSTRUCTOR
        public Avanzado(Usuario usuario, FormMisCuentas formMisCuentas)
        {
            InitializeComponent();
            string cadenaConexion = conn.Conexion();
            usuarioServices = new UsuarioServices(cadenaConexion);          
            this.formMisCuentas = formMisCuentas;
            this.usuario = usuario;
        }
        #endregion


    }
}
