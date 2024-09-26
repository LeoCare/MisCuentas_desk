using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Tipos
{
    class TiposServices : TiposDAO
    {
        public TiposServices(string cadenaConexion) : base(cadenaConexion)
        {
        }
    }
}
