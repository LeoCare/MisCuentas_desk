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

namespace MisCuentas_desk.Services.Pagos
{
    public class PagoDAO : IRepositoryPago<Pago>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ErrorManager _errorManager = new ErrorManager();

        public PagoDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public virtual bool Crear(Pago pago)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"INSERT INTO PAGO (id_balance, id_balance_pagado, monto, fecha_pago, fecha_confirmacion)
                            VALUES (@Id_Balance, @Id_Balance_Pagado, @Monto, @Fecha_Pago, @Fecha_Confirmacion)";
                    conexion.Execute(sql, pago);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al crear el pago. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al crear el pago.");
                throw;
            }
        }

        public virtual Pago ObtenerPorId(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM PAGO WHERE id_pago = @Id_Pago";
                    return conexion.QuerySingleOrDefault<Pago>(sql, new { Id_Pago = id });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener el pago. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener el pago.");
                throw;
            }
        }

        public virtual IEnumerable<Pago> ObtenerPorIdBalance(int idBalance)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM PAGO WHERE id_balance = @Id_Balance";
                    return conexion.Query<Pago>(sql, new { Id_Balance = idBalance });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener todos los pagos. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener todos los pagos.");
                throw;
            }
        }

        public virtual bool Actualizar(Pago pago)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"UPDATE PAGO
                            SET id_balance = @Id_Balance, id_balance_pagado = @Id_Balance_Pagado, monto = @Monto, fecha_pago = @Fecha_Pago, fecha_confirmacion = @Fecha_Confirmacion
                            WHERE id_pago = @Id_Pago";
                    conexion.Execute(sql, pago);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al actualizar el pago. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al actualizar el pago.");
                throw;
            }
        }

        public virtual bool Eliminar(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"DELETE FROM PAGO WHERE id_pago = @Id_Pago";
                    conexion.Execute(sql, new { Id_Pago = id });
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al eliminar el pago. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al eliminar el pago.");
                throw;
            }
        }
    }
}
