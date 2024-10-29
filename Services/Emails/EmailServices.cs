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
        /// Metodo para obtener los posibles mensajes de envio deudores por hoja.
        /// </summary>
        /// <param name="idUsuario">identificador del usuario</param>
        /// <returns>Instancia de EmailRequest a enviar en el Socket</returns>
        public override IEnumerable<EmailRequest> ObtenerTodosDeudorByHoja(int idUsuario)
        {
            try
            {
                return base.ObtenerTodosDeudorByHoja(idUsuario);
            }
            catch (Exception e)
            {
                return null;
            }
        }


        /// <summary>
        /// Metodo para obtener lso posibles mensajes de envio acreedores por hoja.
        /// </summary>
        /// <param name="idUsuario">identificador del usuario</param>
        /// <returns>Instancia de EmailRequest a enviar en el Socket</returns>
        public override IEnumerable<EmailRequest> ObtenerTodosAcreedorByHoja(int idUsuario)
        {
            try
            {
                return base.ObtenerTodosAcreedorByHoja(idUsuario);
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
