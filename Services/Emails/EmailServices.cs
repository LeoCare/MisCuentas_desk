using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Emails
{
    class EmailServices : EmailDAO
    {
        public EmailServices(string cadenaConexion): base(cadenaConexion) { }


        /// <summary>
        /// Metodo para obtener lso posibles mensajes de envio, por hoja y tipo
        /// </summary>
        /// <param name="idHoja">identificador de la hoja</param>
        /// <param name="tipo">A -> acreedor o D -> deudor</param>
        /// <returns>Instancia de EmailRequest a enviar en el Socket</returns>
        public override IEnumerable<EmailRequest> ObtenerTodosByHojaTipo(int idHoja, string tipo)
        {
            try
            {
                return base.ObtenerTodosByHojaTipo(idHoja, tipo);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
