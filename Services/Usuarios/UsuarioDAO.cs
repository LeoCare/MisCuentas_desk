using Dapper;
using MisCuentas_desk.Entities;
using MySqlConnector;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Usuarios
{
    class UsuarioDAO : IRepositoryUsuario<Usuario>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public UsuarioDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public virtual bool Crear(Usuario usuario)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"INSERT INTO USUARIOS (nombre, correo, contrasenna, perfil)
                            VALUES (@Nombre, @Correo, @Contrasenna, @Perfil)";
                    conexion.Execute(sql, usuario);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al crear el usuario. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1062: // Código de error para entrada duplicada
                        throw new Exception("El correo electrónico ya está registrado.", ex);
                    case 1149: // Código de error para entrada duplicada
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al crear el usuario en la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {
                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al crear el usuario.");

                // Re-lanzar la excepción si es necesario
                throw;
            }

        }

        public virtual Usuario ObtenerPorId(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM USUARIOS WHERE id_usuario = @IdUsuario";
                    return conexion.QuerySingleOrDefault<Usuario>(sql, new { IdUsuario = id });
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al crear el usuario. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para entrada duplicada
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al crear el usuario en la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {
                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al crear el usuario.");

                // Re-lanzar la excepción si es necesario
                throw;
            }
        }

        /// <summary>
        /// Metodo para obtener usuario por el correo.
        /// </summary>
        /// <param name="correo">Correo usado en el registro</param>
        /// <returns>Usuario obtenido o null</returns>
        /// <exception cref="Exception">Excepciones al obtener usuario</exception>
        public virtual Usuario ObtenerPorCorreo(string correo)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM USUARIOS WHERE correo = @Correo";
                    return conexion.QuerySingleOrDefault<Usuario>(sql, new { Correo = correo });
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al obtener el usuario. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para entrada duplicada
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al crear el usuario en la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {
                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al obtener el usuario.");

                // Re-lanzar la excepción si es necesario
                throw;
            }
        }

        public virtual IEnumerable<Usuario> ObtenerTodos()
        {
            using (var conexion = new MySqlConnection(_cadenaConexion))
            {
                var sql = @"SELECT * FROM USUARIOS";
                return conexion.Query<Usuario>(sql);
            }
        }

        public virtual void Actualizar(Usuario usuario)
        {
            using (var conexion = new MySqlConnection(_cadenaConexion))
            {
                var sql = @"UPDATE USUARIOS
                        SET nombre = @Nombre, correo = @Correo, contrasenna = @Contrasenna, perfil = @Perfil
                        WHERE id_usuario = @IdUsuario";
                conexion.Execute(sql, usuario);
            }
        }

        public virtual void Eliminar(int id)
        {
            using (var conexion = new MySqlConnection(_cadenaConexion))
            {
                var sql = @"DELETE FROM USUARIOS WHERE id_usuario = @IdUsuario";
                conexion.Execute(sql, new { IdUsuario = id });
            }
        }

    }
}

