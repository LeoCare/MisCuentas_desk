﻿using Dapper;
using MisCuentas_desk.Entities;
using MisCuentas_desk.Utils;
using MySqlConnector;
using NLog;
using System;
using System.Collections.Generic;

namespace MisCuentas_desk.Services.Usuarios
{
    class UsuarioDAO : IRepositoryUsuario<Usuario>
    {
        protected readonly string _cadenaConexion;
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        private ErrorManager _errorManager = new ErrorManager();

        public UsuarioDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }


        /// <summary>
        /// Metodo para crear un Usuario.
        /// </summary>
        /// <param name="usuario">Nuevo usuario a crear</param>
        /// <returns>id del usuario recien creado</returns>
        /// <exception cref="Exception">Excepciones de control</exception>
        public virtual int Crear(Usuario usuario)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                    var sql = @"INSERT INTO USUARIOS (nombre, correo, contrasenna, perfil)
                                VALUES (@Nombre, @Correo, @Contrasenna, @Perfil);
                                SELECT LAST_INSERT_ID();";

                    return conexion.QuerySingle<int>(sql, usuario); // Devuelve el ID
                }
            }
            catch (MySqlException ex)
            {
                // Manejo específico para errores de MySQL
                _logger.Error(ex, "Error de MySQL al crear el usuario. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {                
                _logger.Error(ex, "Error general al crear el usuario.");
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
                _logger.Error(ex, "Error de MySQL al obtener el usuario. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener el usuario.");
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
                _logger.Error(ex, "Error de MySQL al obtener el usuario. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener el usuario.");
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
                _logger.Error(ex, "Error de MySQL al obtener todos los usuarios. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al obtener todos los usuarios.");
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
                _logger.Error(ex, "Error de MySQL al actualizar el usuario. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al actualizar el usuario.");
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
                _logger.Error(ex, "Error de MySQL al eliminar el usuario. Código de error: {0}", ex.Number);
                throw _errorManager.ManejarExcepcionMySql(ex);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error general al eliminar el usuario.");
                throw;
            }
        }
    }
}

