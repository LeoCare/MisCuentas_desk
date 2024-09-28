using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
 
    public class TipoPerfil
    {
        public string Tipo { get; set; }
        public string Descripcion { get; set; }

        
        private TipoPerfil(string tipo, string descripcion)
        {
            Tipo = tipo;
            Descripcion = descripcion;
        }

        public static readonly TipoPerfil Admin = new TipoPerfil("ADMIN", "Administrador");
        public static readonly TipoPerfil Usuario = new TipoPerfil("USER", "Usuario");

    }

}
