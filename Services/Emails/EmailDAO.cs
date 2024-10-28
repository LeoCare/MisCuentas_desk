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


        public virtual IEnumerable<EmailRequest> ObtenerTodosAcreedorByHoja(int idHoja)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sqlAcreedor = "SELECT el.id_email, h.titulo, h.fecha_creacion, pg.monto, p.correo, p.nombre, te.asunto, te.contenido " +
                                           "FROM PARTICIPANTES p, TIPO_EMAIL te, BALANCES b, HOJAS h, EMAIL_LOG el, PAGOS pg " +
                                           "WHERE el.status = 'P' " +
                                           "AND el.fecha_envio IS NULL " +
                                           "AND el.id_balance = b.id_balance " +
                                           "AND el.tipo = te.tipo " +
                                           "AND b.id_participante = p.id_participante " +
                                          "AND b.id_hoja = p.id_hoja " +
                                           "AND b.id_balance = pg.id_balance_pagado " +
                                           "AND h.id_hoja = p.id_hoja " +
                                           "AND te.tipo = 'S' " +
                                           "AND p.correo IS NOT NULL ";                  

                    return conexion.Query<EmailRequest>(sqlAcreedor, new { IdHoja = idHoja});
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


        public virtual IEnumerable<EmailRequest> ObtenerTodosDeudorByHoja(int idHoja)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sqlDeudor = "SELECT el.id_email, h.titulo, h.fecha_creacion, b.monto, p.correo, p.nombre, te.asunto, te.contenido " +
                                           "FROM PARTICIPANTES p, TIPO_EMAIL te, BALANCES b, HOJAS h, EMAIL_LOG el, PAGOS pg " +
                                            "WHERE el.status = 'P' " +
                                            "AND el.fecha_envio IS NULL " +
                                            "AND el.id_balance = b.id_balance " +
                                            "AND el.tipo = te.tipo " +
                                            "AND b.id_participante = p.id_participante " +
                                            "AND b.id_hoja = p.id_hoja " +
                                            "AND h.id_hoja = p.id_hoja " +
                                            "AND te.tipo = 'E' " +
                                            "AND p.correo IS NOT NULL;";

                    return conexion.Query<EmailRequest>(sqlDeudor, new { IdHoja = idHoja });
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
