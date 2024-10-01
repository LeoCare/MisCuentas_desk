using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Balances
{
    public class BalanceServices : BalanceDAO
    {
        public BalanceServices(string cadenaConexion) : base(cadenaConexion) { }

        public override bool Crear(Balance balance)
        {
            try
            {
                return base.Crear(balance);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public override IEnumerable<Balance> ObtenerPorIdParticipante(int idParticipante)
        {
            try
            {

                return base.ObtenerPorIdParticipante(idParticipante);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public override bool Actualizar(Balance balance)
        {
            try
            {
                
                return base.Actualizar(balance);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}
