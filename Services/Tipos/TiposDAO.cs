using Dapper;
using Microsoft.SqlServer.Server;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Utils;
using MySqlConnector;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Tipos
{
    public class TiposDAO : IRepositoryTipos<TipoPerfil>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ErrorManager _errorManager = new ErrorManager();

        public TiposDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public virtual TipoPerfil ObtenerByTipo(string tipo)
        {
            try
            {
                using (IDbConnection conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = $"SELECT * FROM TIPO_PERFIL WHERE tipo = {tipo}";
                    return conexion.QuerySingleOrDefault<TipoPerfil>(sql, tipo);
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener un tipo perfil. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener un tipo perfil.");
                throw;
            }
        }

        public virtual IEnumerable<TipoPerfil> ObtenerTodos()
        {
            try
            {
                using (IDbConnection conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = "SELECT * FROM TIPO_PERFIL";
                    return conexion.Query<TipoPerfil>(sql);
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener todos los perfiles. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener todos los perfiles.");
                throw;
            }
        }
    }
}
