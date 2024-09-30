using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class Participante
    {
        public int Id_Participante { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int Id_Usuario { get; set; }
        public int Id_Hoja { get; set; }
        public List<Gasto> Gastos { get; set; }

        public Participante() { }

        public Participante(int id_Participante, string nombre, string correo, int id_Usuario, int id_Hoja)
        {
            Id_Participante = id_Participante;
            Nombre = nombre;
            Correo = correo;
            Id_Usuario = id_Usuario;
            Id_Hoja = id_Hoja;
        }

    }
}
