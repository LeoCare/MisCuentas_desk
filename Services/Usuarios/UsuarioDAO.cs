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


        /// <summary>
        /// Metodo para crear un Usuario.
        /// </summary>
        /// <param name="usuario">Nuevo usuario a crear</param>
        /// <returns>true o false segun insercion exitosa o no</returns>
        /// <exception cref="Exception">Excepciones de control</exception>
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
                    case 1149: // Código de error para sintaxis incorrecta
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
        /// Metodo para obtener el usuario por id.
        /// </summary>
        /// <param name="id">id del usuario a obtener</param>
        /// <returns>Usuario obtenido o null</returns>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual Usuario ObtenerPorId(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM USUARIOS WHERE id_usuario = @Id_Usuario";
                    return conexion.QuerySingleOrDefault<Usuario>(sql, new { Id_Usuario = id });
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al obtener el usuario. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al obtener el usuario en la base de datos.", ex);
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
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al obtener el usuario en la base de datos.", ex);
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


        /// <summary>
        /// Metodo para obtener todos los usuarios.
        /// </summary>
        /// <returns>Usuario IEnumerable de usuarios o null</returns>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual IEnumerable<Usuario> ObtenerTodos()
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM USUARIOS";
                    return conexion.Query<Usuario>(sql);
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al obtener todos los usuarios. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al obtener todos los usuarios en la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {
                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al obtener todos los usuarios.");

                // Re-lanzar la excepción si es necesario
                throw;
            }
        }



        /// <summary>
        /// Metodo para actualizar el usuarios.
        /// </summary>
        /// <param name="usuario">Usuario a actualizar</param>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual bool Actualizar(Usuario usuario)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"UPDATE USUARIOS
                            SET nombre = @Nombre, correo = @Correo, contrasenna = @Contrasenna, perfil = @Perfil
                            WHERE id_usuario = @Id_Usuario";
                    conexion.Execute(sql, usuario);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al actualizar el usuario. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al actualizar el usuario en la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {
                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al actualizar el usuario.");

                // Re-lanzar la excepción si es necesario
                throw;
            }
        }


        /// <summary>
        /// Metodo para eliminar el usuarios.
        /// </summary>
        /// <param name="id">id del usuario a eliminar</param>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual bool Eliminar(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"DELETE FROM USUARIOS WHERE id_usuario = @Id_Usuario";
                    conexion.Execute(sql, new { Id_Usuario = id });
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al eliminar el usuario. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al eliminar el usuario en la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {
                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al eliminar el usuario.");

                // Re-lanzar la excepción si es necesario
                throw;
            }
        }

    }
}

