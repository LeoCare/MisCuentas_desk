using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class Hoja
    {
        public int Id_Hoja { get; set; }
        public string Titulo { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public DateTime? Fecha_Cierre { get; set; }
        public Double? Limite_Gastos { get; set; }
        public string Status { get; set; }
        public int Id_Usuario { get; set; }
        public List<Participante> Participantes { get; set; }

        public Hoja() { }

        public Hoja(int id_Hoja, string titulo, DateTime fecha_Creacion, DateTime? fecha_Cierre, Double? limite_Gastos, string status, int id_Usuario)
        {
            Id_Hoja = id_Hoja;
            Titulo = titulo;
            Fecha_Creacion = fecha_Creacion;
            Fecha_Cierre = fecha_Cierre;
            Limite_Gastos = limite_Gastos;
            Status = status;
            Id_Usuario = id_Usuario;
        }

        public override string ToString()
        {
            return this.Titulo.ToString();
        }
    }
}
