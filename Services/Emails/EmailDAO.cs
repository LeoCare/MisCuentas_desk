using Dapper;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Utils;
using MySqlConnector;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Emails
{
    class EmailDAO : IRepositoryEmail<EmailRequest>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ErrorManager _errorManager = new ErrorManager();


        public EmailDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }


        public virtual IEnumerable<EmailRequest> ObtenerTodosByHojaTipo(int idHoja, string tipo)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT el.id_email, p.nombre, h.titulo, h.fecha_creacion, b.monto, p.correo,  te.asunto, te.contenido 
                                FROM PARTICIPANTES p, TIPO_EMAIL te, BALANCES b, HOJAS h, EMAIL_LOG el
                                WHERE h.id_hoja = @IdHoja
                                and h.id_hoja = p.id_hoja
                                and h.id_hoja = b.id_hoja
                                and p.id_participante = b.id_participante
                                AND p.id_hoja = b.id_hoja
                                AND el.id_balance = b.id_balance
                                AND el.tipo = te.tipo
                                AND b.tipo = @Tipo
                                AND p.correo IS NOT NULL;";
                    return conexion.Query<EmailRequest>(sql, new { IdHoja = idHoja, Tipo = tipo});
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                _logger.Error(ex, "Error de MySQL al obtener todos deudores. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener todos los deudores.");
                throw;
            }
        }
    }
}
