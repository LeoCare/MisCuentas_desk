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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Utils
{
    public class UpdateDataUsuario
    {
        #region ATRIBUTOS
        private MisCuentasConnect _conn = new MisCuentasConnect();
        private UsuarioServices _usuarioServices;
        private PersonalDataServices _personalDataServices;
        private HojaServices _hojaServices;
        private PagoServices _pagoServices;
        private ParticipanteServices _participanteServices;
        private GastoServices _gastoServices;
        private BalanceServices _balanceServices;
        #endregion

        #region CONSTRUCTOR
        public UpdateDataUsuario()
        {
            string cadenaConexion = _conn.Conexion();
            _personalDataServices = new PersonalDataServices(cadenaConexion);
            _hojaServices = new HojaServices(cadenaConexion);
            _pagoServices = new PagoServices(cadenaConexion);
            _participanteServices = new ParticipanteServices(cadenaConexion);
            _gastoServices = new GastoServices(cadenaConexion);
            _balanceServices = new BalanceServices(cadenaConexion);
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo que obtiene, o instancia si aun no estan creados, los datos personales.
        /// </summary>
        /// <param name="idUsuario">Id del usuario creado</param>    
        public Personal_Data ObtenerDatosPersonales(int idUsuario)
        {
            //Obtener Personal_Data
            Personal_Data datos = _personalDataServices.ObtenerPorId(idUsuario);

            if (datos == null)
            {
                datos = new Personal_Data(idUsuario, null, null, null, null, null);
                //Insert Personal_Data
                _personalDataServices.Crear(datos);       
            }
            return datos;
        }


        /// <summary>
        /// Metodo que carga las hojas del usuario
        /// </summary>
        /// <returns>Lista de hojas</returns>
        public List<Hoja> ObtenerHojas(int id_usuario)
        {

            return (List<Hoja>)_hojaServices.ObtenerPorIdUsuario(id_usuario);

        }


        /// <summary>
        /// Metodo que carga los participantes de cada hoja
        /// </summary>
        public List<Hoja> CargarHojaConPart(List<Hoja> listHojas)
        {
            List<Participante> listParticipantes = new List<Participante>();

            //Cargar participantes por Hoja:
            listHojas.ForEach(hoja =>
            {
                listParticipantes = ((List<Participante>)_participanteServices.ObtenerParticipantesPorHoja(hoja.Id_Hoja));

                if (listParticipantes != null && listParticipantes.Count > 0)
                {
                    hoja.Participantes = listParticipantes;                  
                }
            });
            return listHojas;
        }


        /// <summary>
        /// Metodo que carga los gastos solo donde el usuario logeado participe
        /// </summary>
        public List<Gasto> CargarGastos(List<Hoja> listHojas, int idUsuario)
        {
            List<Gasto> listGastos = new List<Gasto>();

            //Buscarme como participante:
            listHojas.ForEach(hoja =>
            {
                hoja.Participantes.ForEach(participante =>
                {
                    if (participante.Id_Usuario.Equals(idUsuario))
                    {
                        //Cargar mis gastos:
                        listGastos.AddRange((List<Gasto>)_gastoServices.ObtenerPorIdParticipante(participante.Id_Participante));
                    }
                });
            });
            return listGastos;
        }


        /// <summary>
        /// Metodo que carga los balances del usuario
        /// </summary>
        public List<Hoja> CargarBalances(List<Hoja> listHojas)
        {
            List<Balance> listBalances = new List<Balance>();

            //Buscarme como participante:
            listHojas.ForEach(hoja =>
            {
                hoja.Participantes.ForEach(participante =>
                {                 
                    //Cargar mis balances:
                    listBalances = ((List<Balance>)_balanceServices.ObtenerPorIdParticipante(participante.Id_Participante));

                    if (listBalances != null && listBalances.Count > 0)
                    {
                        participante.Balances = listBalances;
                    }                  
                });
            });
            return listHojas;
        }

        /// <summary>
        /// Metodo que carga los pagos del usuario logeado 
        /// </summary>
        public List<Pago> CargarPagos(List<Hoja> listHojas, int idUsuario)
        {
            List<Pago> misPagos = new List<Pago>();

            //Buscarme como participante:
            listHojas.ForEach(hoja =>
            {
                hoja.Participantes.ForEach(participante =>
                {
                    if (participante.Id_Usuario.Equals(idUsuario))
                    {
                        participante.Balances.ForEach(balance =>
                        {
                            misPagos.AddRange((List<Pago>)_pagoServices.ObtenerPorIdBalance(balance.Id_Balance));
                           
                        });
                    }
                });
            });
            return misPagos;
        }
        #endregion
    }
}
