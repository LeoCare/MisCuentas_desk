using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Pagos
{
    public class PagoServices : PagoDAO
    {
        public PagoServices(string cadenaConexion) : base(cadenaConexion) { }

        public override bool Crear(Pago pago)
        {
            try
            {            
                return base.Crear(pago);
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public override IEnumerable<Pago> ObtenerPorIdBalance(int idBalance)
        {
            try
            {
                return base.ObtenerPorIdBalance(idBalance);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public override bool Actualizar(Pago pago)
        {
            try
            {
                return base.Actualizar(pago);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }
    }
}
