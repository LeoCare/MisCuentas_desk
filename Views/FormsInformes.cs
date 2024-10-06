using MisCuentas_desk.Configurations;
using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MisCuentas_desk.Views
{
    public partial class FormsInformes : Form
    {
        #region ATRIBUTOS
        private Usuario _usuario;
        private MisCuentasConnect _conn = new MisCuentasConnect();
        #endregion

        #region CONSTRUCTOR
        public FormsInformes(Usuario usuario, FormMisCuentas formMisCuentas)
        {
            InitializeComponent();
            string cadenaConexion = _conn.Conexion();
            _usuario = usuario; 

            CargarTotalesHoja();
            CargarTotalesGastos();
            CargarTotalesPagos();
            CargarTotalesBalances();
        }
        #endregion

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


        /// <summary>
        /// Metodo que pinta los totales (Balances) en el formulario.
        /// </summary>
        private void CargarTotalesBalances()
        {
            //Total:
            int totalBalances = 0;
            
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
            lblTotalBalances.Text = misBalances.Count.ToString();

            //Total este mes:
            Double totalBalancesMes = 0.0;

            if(misBalances != null && misBalances.Count > 0)
            {
                misBalances.ForEach(balance =>
                {
                    if(balance.Tipo.Equals("A")) totalBalancesMes += Double.Parse(balance.Monto.ToString());
                });
                lblTotalBalancesFavor.Text = totalBalancesMes.ToString();
            }   
        }
        #endregion

        #region BOTONES ACCION
        /// <summary>
        /// Metodo para ver las hojas del usuario logeado.
        /// </summary>
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

        /// <summary>
        /// Metodo para ver los gastos del usuario logeado.
        /// </summary>
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

        /// <summary>
        /// Metodo para ver los pagos del usuario logeado.
        /// </summary>
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

        /// <summary>
        /// Metodo para ver los balances del usuario logeado.
        /// </summary>
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
        #endregion
    }
}
