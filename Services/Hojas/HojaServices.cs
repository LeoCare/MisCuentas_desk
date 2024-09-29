using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Hojas
{
    public class HojaServices : HojaDAO
    {
        public HojaServices(string cadenaConexion) : base(cadenaConexion) { }

        public override bool Crear(Hoja hoja)
        {
            try
            {               
                return base.Crear(hoja);
            }
            catch (Exception ex)
            {   
                return false;
            }
        }

        public override bool Actualizar(Hoja hoja)
        {
            try
            {
                return base.Actualizar(hoja);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
