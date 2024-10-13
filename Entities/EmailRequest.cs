using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class EmailRequest
    {
        public int Id_Email { get; set; }
        public string Nombre { get; set; }
        public string Titulo { get; set; }
        public DateTime? Fecha_Creacion { get; set; }
        public double? Monto { get; set; }
        public string Correo { get; set; }
        public string Asunto { get; set; }
        public string Contenido { get; set; }


        public EmailRequest() { }


        public EmailRequest(int id_email, string titulo, DateTime? fecha_Creacion, double? monto, string correo, string nombre, string asunto, string contenido)
        {
            Id_Email = id_email;
            Titulo = titulo;
            Fecha_Creacion = fecha_Creacion;
            Monto = monto;
            Correo = correo;
            Nombre = nombre;
            Asunto = asunto;
            Contenido = contenido;
        }
    } 
}
