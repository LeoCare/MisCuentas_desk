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

namespace MisCuentas_desk.Services.Participantes
{
    public class ParticipanteDAO : IRepositoryParticipante<Participante>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ErrorManager _errorManager = new ErrorManager();


        public ParticipanteDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public virtual bool Crear(Participante participante)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"INSERT INTO PARTICIPANTES (nombre, correo, id_usuario, id_hoja)
                            VALUES (@Nombre, @Correo, @Id_Usuario, @Id_Hoja)";
                    conexion.Execute(sql, participante);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al crear el participante. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al  crear el participante.");
                throw;
            }
        
        }

        public virtual Participante ObtenerPorId(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM PARTICIPANTES WHERE id_participante = @Id_Participante";
                    return conexion.QuerySingleOrDefault<Participante>(sql, new { Id_Participante = id });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener el participante. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener el participante.");
                throw;
            }
        }

        public virtual IEnumerable<Participante> ObtenerTodos()
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM PARTICIPANTES";
                    return conexion.Query<Participante>(sql);
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener todos los participantes. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener todos los participantes.");
                throw;
            }
        }

        public virtual IEnumerable<Participante> ObtenerPorIdHoja(int idHoja)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM PARTICIPANTES WHERE id_hoja = @Id_Hoja";
                    return conexion.Query<Participante>(sql, new { Id_Hoja = idHoja });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener los participantes por Id de hoja. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener los participantes por Id de hoja.");
                throw;
            }
        }

        public virtual bool Actualizar(Participante participante)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"UPDATE PARTICIPANTES
                            SET nombre = @Nombre, correo = @Correo, id_usuario = @Id_Usuario, id_hoja = @Id_Hoja
                            WHERE id_participante = @Id_Participante";
                    conexion.Execute(sql, participante);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al actualizar el participante. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al actualizar el participante.");
                throw;
            }
        }

        public virtual bool Eliminar(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"DELETE FROM PARTICIPANTES WHERE id_participante = @Id_Participante";
                    conexion.Execute(sql, new { Id_Participante = id });
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al eliminar el participante. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al eliminar el participante.");
                throw;
            }
        }

    }
}
