using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.Balances;
using MisCuentas_desk.Services.Gastos;
using MisCuentas_desk.Services.Hojas;
using MisCuentas_desk.Services.Pagos;
using MisCuentas_desk.Services.Participantes;
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
        private ParticipanteServices _participanteServices;
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
            _participanteServices = new ParticipanteServices(cadenaConexion);
            _gastoServices = new GastoServices(cadenaConexion);
            _balanceServices = new BalanceServices(cadenaConexion);
            _formMisCuentas = formMisCuentas;
            _usuario = usuario; 

            CargarTotalesHoja();
            CargarTotalesGastos();
            CargarTotalesPagos();
        }


        #region CARGAR TOTALES
        /// <summary>
        /// Metodo que pinta los totales (Hojas) en el formulario.
        /// </summary>
        /// <param name="listHojas">Lista de hojas del usuario logeado</param>
        private void CargarTotalesHoja()
        {
            lblTotalHojas.Text = _usuario.Hojas.Count.ToString();
            lblTotalCursoHojas.Text = _usuario.Hojas.Where(hoja => hoja.Status.Equals("C")).ToList().Count.ToString();  
        }


        /// <summary>
        /// Metodo que pinta los totales (Gastos) en el formulario.
        /// </summary>
        /// <param name="listHojas">Lista de hojas del usuario logeado</param>
        private void CargarTotalesGastos()
        {
            //Total:
            Double totalGastos = 0.0;
            _usuario.Gastos.ForEach(gasto =>
            {
                totalGastos += gasto.Importe;
            });
            lblTotalGastos.Text = totalGastos.ToString();

            //Total este mes:
            Double totalGastosMes = 0.0;
            int mesActual = DateTime.Now.Month;
            int añoActual = DateTime.Now.Year;
            _usuario.Gastos.ForEach(gasto =>
            {
                if (gasto.Fecha_Gasto.Month == mesActual && gasto.Fecha_Gasto.Year == añoActual)
                {
                    totalGastosMes += gasto.Importe;
                }
            });
            lblTotalGastosMes.Text = totalGastosMes.ToString();
        }

        /// <summary>
        /// Metodo que pinta los totales (Pagos) en el formulario.
        /// </summary>
        /// <param name="listHojas">Lista de hojas del usuario logeado</param>
        private void CargarTotalesPagos()
        {
            //Total:
            Double totalPagos = 0.0;
            _usuario.Pagos.ForEach(pago =>
            {
                totalPagos += pago.Monto;
            });
            lblTotalPagos.Text = totalPagos.ToString();

            //Total este mes:
            Double totalPagosMes = 0.0;
            int mesActual = DateTime.Now.Month;
            int añoActual = DateTime.Now.Year;
            _usuario.Pagos.ForEach(pago =>
            {
                if (pago.Fecha_Pago.Month == mesActual && pago.Fecha_Pago.Year == añoActual)
                {
                    totalPagosMes += pago.Monto;
                }
            });
            lblTotalPagosMes.Text = totalPagosMes.ToString();
        }
        #endregion


        private void btnVerMisHojas_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.OliveDrab;

            if (_usuario.Hojas.Count > 0)
            {
                dgInformes.DataSource = null;
                dgInformes.Rows.Clear();
                dgInformes.Columns.Clear();
                dgInformes.DataSource = _usuario.Hojas;

                dgInformes.Columns["Id_Usuario"].Visible = false; //Inecesaria esta info
            }
        }

        private void btnVerMisGastos_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.DeepSkyBlue;

            if (_usuario.Gastos.Count > 0)
            {
                dgInformes.DataSource = null;
                dgInformes.Rows.Clear();
                dgInformes.Columns.Clear();
                dgInformes.DataSource = _usuario.Gastos;

                dgInformes.Columns["Id_Participante"].Visible = false; //Inecesaria esta info
            }
        }

        private void btnVerMisPagos_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.MediumVioletRed;

            if (_usuario.Pagos.Count > 0)
            {
                dgInformes.DataSource = null;
                dgInformes.Rows.Clear();
                dgInformes.Columns.Clear();
                dgInformes.DataSource = _usuario.Pagos;
 
            }
        }

        private void btnVerMisBalances_Click(object sender, EventArgs e)
        {
            panelInformeResultColor.BackColor = Color.Goldenrod;

            List<Balance> misBalances = new List<Balance>();

            if (_usuario.Hojas.Count > 0)
            {
                _usuario.Hojas.ForEach(h =>
                {
                    if (h.Participantes.Count > 0)
                    {
                        h.Participantes.ForEach(p =>
                        {
                            if (p.Id_Usuario.Equals(_usuario.Id_Usuario) && p.Balances.Count > 0)
                            {                              
                                misBalances.AddRange(p.Balances);  
                            }
                        });
                    }
                });
            }

            dgInformes.DataSource = null;
            dgInformes.Rows.Clear();
            dgInformes.Columns.Clear();
            dgInformes.DataSource = misBalances;

        }
    }
}
