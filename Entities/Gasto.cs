using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class Gasto
    {
        public int Id_Gasto { get; set; }
        public string Tipo { get; set; }
        public string Concepto { get; set; }
        public long Importe { get; set; }
        public string Fecha_Gasto { get; set; }
        public int Id_Participante { get; set; }
        

        public Gasto() { }

        public Gasto(int id_Gasto, string tipo, string concepto, long importe, string fecha_Gasto, int id_Participante)
        {
            Id_Gasto = id_Gasto;
            Tipo = tipo;
            Concepto = concepto;
            Importe = importe;
            Fecha_Gasto = fecha_Gasto;
            Id_Participante = id_Participante;
        }
    }
}
