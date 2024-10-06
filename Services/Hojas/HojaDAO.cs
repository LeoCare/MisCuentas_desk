using Dapper;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Utils;
using MySqlConnector;
using NLog;
using System;
using System.Collections.Generic;


namespace MisCuentas_desk.Services.Hojas
{
    public class HojaDAO : IRepositoryHoja<Hoja>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ErrorManager _errorManager = new ErrorManager();

        public HojaDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public virtual int Crear(Hoja hoja)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"INSERT INTO HOJAS (titulo, fecha_creacion, fecha_cierre, limite_gastos, status, id_usuario)
                            VALUES (@Titulo, @Fecha_Creacion, @Fecha_Cierre, @Limite_Gastos, @Status, @Id_Usuario);
                                SELECT LAST_INSERT_ID();";
                    return conexion.QuerySingle<int>(sql, hoja); // Devuelve el ID
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al crear la hoja. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al crear la hoja.");
                throw;
            }
        }

        public virtual Hoja ObtenerPorId(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM HOJAS WHERE id_hoja = @Id_Hoja";
                    return conexion.QuerySingleOrDefault<Hoja>(sql, new { Id_Hoja = id });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener la hoja. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener la hoja.");
                throw;
            }
        }

        public virtual IEnumerable<Hoja> ObtenerPorIdUsuario(int idUsuario)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM HOJAS WHERE id_usuario = @Id_Usuario";
                    return conexion.Query<Hoja>(sql, new { Id_Usuario = idUsuario });
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al obtener todas las hojas. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener todas las hojas.");
                throw;
            }
        }

        public virtual bool Actualizar(Hoja hoja)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"UPDATE HOJAS
                            SET titulo = @Titulo, fecha_creacion = @Fecha_Creacion, fecha_cierre = @Fecha_Cierre, limite_gastos = @Limite_Gastos, status = @Status, id_usuario = @Id_Usuario
                            WHERE id_hoja = @Id_Hoja";
                    conexion.Execute(sql, hoja);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al actualizar la hoja. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al actualizar la hoja.");
                throw;
            }
        }

        public virtual bool Eliminar(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"DELETE FROM HOJAS WHERE id_hoja = @Id_Hoja";
                    conexion.Execute(sql, new { Id_Hoja = id });
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                _logger.Error(ex, "Error al eliminar la hoja. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al eliminar la hoja.");
                throw;
            }
        }
    }
}
