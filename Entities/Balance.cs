using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class Balance
    {
        public int Id_Balance { get; set; }
        public int Id_Hoja { get; set; }
        public int Id_Participante { get; set; }
        public string Tipo { get; set; }
        public Double Monto { get; set; }
        

        public Balance() { }

        public Balance(int id_Balance, int id_Hoja, int id_Participante, string tipo, Double monto)
        {
            Id_Balance = id_Balance;
            Id_Hoja = id_Hoja;
            Id_Participante = id_Participante;
            Tipo = tipo;
            Monto = monto;
        }
    }
}
