using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Gastos
{
    public class GastoServices : GastoDAO
    {
        public GastoServices(string cadenaConexion) : base(cadenaConexion) { }

        public override bool Crear(Gasto gasto)
        {
            try
            {
                return base.Crear(gasto);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public override IEnumerable<Gasto> ObtenerPorIdParticipante(int idParticipante)
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

        public override bool Actualizar(Gasto gasto)
        {
            try
            {
                return base.Actualizar(gasto);
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }
    }

}
