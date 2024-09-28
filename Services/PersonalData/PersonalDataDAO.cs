using Dapper;
using MisCuentas_desk.Entities;
using MySqlConnector;
using NLog;
using System;


namespace MisCuentas_desk.Services.PersonalData
{
    public class PersonalDataDAO : IRepositoryPersonalData<Personal_Data>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public PersonalDataDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        /// <summary>
        /// Metodo para crear los datos del usuario.
        /// </summary>
        /// <param name="datos">Datos del usuario a crear</param>
        /// <returns>true o false segun insercion exitosa o no</returns>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual bool Crear(Personal_Data datos)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"INSERT INTO PERSONAL_DATA (id_usuario, nombre, apellidos, direccion, pais, telefono)
                            VALUES (@Id_Usuario, @Nombre, @Apellidos, @Direccion, @Pais, @Telefono)";
                    conexion.Execute(sql, datos);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al crear datos. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                   
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al crear datos en la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {
                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al crear datos.");

                // Re-lanzar la excepción si es necesario
                throw;
            }

        }


        /// <summary>
        /// Metodo para obtener los datos personal por id de usuario
        /// </summary>
        /// <param name="id">id del usuario logeado</param>
        /// <returns>Instancia de Personal_Data o null</returns>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual Personal_Data ObtenerPorId(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"SELECT * FROM PERSONAL_DATA WHERE id_usuario = @Id_Usuario";
                    return conexion.QuerySingleOrDefault<Personal_Data>(sql, new { Id_Usuario = id });
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al obtener datos personales. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al obtener datos personales de la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {
                
                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al obtener datos personales.");

                // Re-lanzar la excepción si es necesario
                throw;
            }
        }


        /// <summary>
        /// Metodo para actualizar los datos del usuario.
        /// </summary>
        /// <param name="personalData">Datos del usuario a actualizar</param>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual bool Actualizar(Personal_Data personalData)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"UPDATE PERSONAL_DATA
                            SET nombre = @Nombre, apellidos = @Apellidos, direccion = @Direccion, pais = @Pais, telefono = @Telefono
                            WHERE id_usuario = @Id_Usuario";
                    conexion.Execute(sql, personalData);
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al actualizar datos personales. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al actualizar datos personales de la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {

                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al actualizar datos personales.");

                // Re-lanzar la excepción si es necesario
                throw;
            }
        }


        /// <summary>
        /// Metodo para eliminar los datos personales.
        /// </summary>
        /// <param name="id">id del usuario logeado</param>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual bool Eliminar(int id)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"DELETE FROM PERSONAL_DATA WHERE id_usuario = @Id_Usuario";
                    conexion.Execute(sql, new { Id_Usuario = id });
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                logger.Error(ex, "Error de MySQL al eliminar datos personales. Código de error: {0}", ex.Number);

                // Puedes manejar diferentes códigos de error de MySQL
                switch (ex.Number)
                {
                    case 1149: // Código de error para sintaxis incorrecta
                        throw new Exception("Sintaxis incorrecta de sql.", ex);
                    case 1045: // Código de error para acceso denegado
                        throw new Exception("Acceso denegado a la base de datos.", ex);
                    default:
                        throw new Exception("Ocurrió un error al eliminar datos personales de la base de datos.", ex);
                }
            }
            catch (Exception ex)
            {

                // Manejo general para otras excepciones
                logger.Error(ex, "Error general al eliminar datos personales.");

                // Re-lanzar la excepción si es necesario
                throw;
            }
        }
    }
}
