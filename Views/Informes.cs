using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.Balances;
using MisCuentas_desk.Services.Gastos;
using MisCuentas_desk.Services.Hojas;
using MisCuentas_desk.Services.Pagos;
using MisCuentas_desk.Services.PersonalData;
using MisCuentas_desk.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MisCuentas_desk.Views
{
    public partial class Informes : Form
    {

        private Usuario _usuario;
        private List<Hoja> _listHojas;
        private MisCuentasConnect _conn = new MisCuentasConnect();
        private UsuarioServices _usuarioServices; 
        private HojaServices _hojaServices;
        private PagoServices _pagoServices;
        private GastoServices _gastoServices;
        private BalanceServices _balanceServices;
        private FormMisCuentas _formMisCuentas;

        public Informes(Usuario usuario, FormMisCuentas formMisCuentas)
        {
            InitializeComponent();
            string cadenaConexion = _conn.Conexion();
            _usuarioServices = new UsuarioServices(cadenaConexion);
            _hojaServices = new HojaServices(cadenaConexion);
            _pagoServices = new PagoServices(cadenaConexion);
            _gastoServices = new GastoServices(cadenaConexion);
            _balanceServices = new BalanceServices(cadenaConexion);
            _formMisCuentas = formMisCuentas;
            _usuario = usuario;
            _listHojas = new List<Hoja>();

            CargarHojas();

        }

        #region CARGAR DATOS POR ID_USUARIO
        private void CargarHojas()
        {

            _listHojas = (List<Hoja>)_hojaServices.ObtenerPorIdUsuario(_usuario.Id_Usuario);

            CargarTotalesHoja(_listHojas);
            
        }

        private void CargarTotalesHoja(List<Hoja> listHojas)
        {
            lblTotalHojas.Text = listHojas.Count.ToString();
            lblTotalCursoHojas.Text = listHojas.Where(hoja => hoja.Status.Equals("C")).ToList().Count.ToString();  
        }


        //private void CargarPagos()
        //{
        //    List<Pago> listPagos = new List<Pago>();
        //    listPagos = (List<Pago>)_pagoServices.ObtenerPorIdBalance();

        //    if (listPagos.Count > 0)
        //    {
        //        dgInformes.DataSource = null;
        //        dgInformes.Rows.Clear();
        //        dgInformes.Columns.Clear();
        //        dgInformes.DataSource = listPagos;
        //    }
        //}



        #endregion


        private void btnVerMisHojas_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.OliveDrab;

            if (_listHojas.Count > 0)
            {
                dgInformes.DataSource = null;
                dgInformes.Rows.Clear();
                dgInformes.Columns.Clear();
                dgInformes.DataSource = _listHojas;

                dgInformes.Columns["Id_Usuario"].Visible = false; //Inecesaria esta info
            }
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
