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

namespace MisCuentas_desk.Services.Gastos
{
    public class GastoDAO : IRepositoryGasto<Gasto>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ErrorManager _errorManager = new ErrorManager();

        public GastoDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public virtual bool Crear(Gasto gasto)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"INSERT INTO GASTOS (tipo, concepto, importe, fecha_gasto, id_participante)
                            VALUES (@Tipo, @Concepto, @Importe, @Fecha_Gasto, @Id_Participante)";
                    conexion.Execute(sql, gasto);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al crear el gasto. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al crear el gasto.");
                throw;
            }
        }

        public virtual Gasto ObtenerPorId(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM GASTOS WHERE id_gasto = @Id_Gasto";
                    return conexion.QuerySingleOrDefault<Gasto>(sql, new { Id_Gasto = id });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener el gasto. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener el gasto.");
                throw;
            }
        }

        public virtual IEnumerable<Gasto> ObtenerPorIdParticipante(int idParticipante)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM GASTOS WHERE id_participante = @Id_Participante";
                    return conexion.Query<Gasto>(sql, new { Id_Participante = idParticipante });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener los gastos del participante. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener los gastos del participante.");
                throw;
            }
        }

        public virtual bool Actualizar(Gasto gasto)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"UPDATE GASTOS
                            SET tipo = @Tipo, concepto = @Concepto, importe = @Importe, fecha_gasto = @Fecha_Gasto, id_participante = @Id_Participante
                            WHERE id_gasto = @Id_Gasto";
                    conexion.Execute(sql, gasto);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al actualizar el gasto. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al actualizar el gasto.");
                throw;
            }
        }

        public virtual bool Eliminar(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"DELETE FROM GASTOS WHERE id_gasto = @Id_Gasto";
                    conexion.Execute(sql, new { Id_Gasto = id });
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al eliminar el gasto. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al eliminar el gasto.");
                throw;
            }
        }
    }
}
