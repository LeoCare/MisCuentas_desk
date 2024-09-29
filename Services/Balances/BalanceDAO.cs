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

namespace MisCuentas_desk.Services.Balances
{
    public class BalanceDAO : IRepositoryBalance<Balance>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ErrorManager _errorManager = new ErrorManager();

        public BalanceDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public virtual bool Crear(Balance balance)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"INSERT INTO BALANCE (id_hoja, id_participante, tipo, monto)
                            VALUES (@Id_Hoja, @Id_Participante, @Tipo, @Monto)";
                    conexion.Execute(sql, balance);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al crear el balance. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al crear el balance.");
                throw;
            }
        }

        public virtual Balance ObtenerPorId(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM BALANCE WHERE id_balance = @Id_Balance";
                    return conexion.QuerySingleOrDefault<Balance>(sql, new { Id_Balance = id });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener el balance. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener el balance.");
                throw;
            }
        }

        public virtual IEnumerable<Balance> ObtenerTodos()
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM BALANCE";
                    return conexion.Query<Balance>(sql);
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener todos los balances. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener todos los balances.");
                throw;
            }
        }

        public virtual bool Actualizar(Balance balance)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"UPDATE BALANCE
                            SET id_hoja = @Id_Hoja, id_participante = @Id_Participante, tipo = @Tipo, monto = @Monto
                            WHERE id_balance = @Id_Balance";
                    conexion.Execute(sql, balance);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al actualizar el balance. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al actualizar el balance.");
                throw;
            }
        }

        public virtual bool Eliminar(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"DELETE FROM BALANCE WHERE id_balance = @Id_Balance";
                    conexion.Execute(sql, new { Id_Balance = id });
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al eliminar el balance. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al eliminar el balance.");
                throw;
            }
        }
    }
}
