using Dapper;
using MisCuentas_desk.Entities;
using MySqlConnector;
using System;

namespace MisCuentas_desk.Services.Usuarios
{
    class UsuarioServices : UsuarioDAO 
    {
        public UsuarioServices(string cadenaConexion) : base(cadenaConexion)
        {
        }


        /// <summary>
        /// Metodo para crear un Usuario.
        /// </summary>
        /// <param name="usuario">Nuevo usuario a crear</param>
        /// <returns>true o false segun insercion exitosa o no</returns>
        public override bool Crear(Usuario usuario)
        {
            try
            {           
                // Hashear la contraseña antes de guardarla
                usuario.Contrasenna = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenna);

                // Llamar al método base para crear el usuario
                base.Crear(usuario);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Metodo para comprobar el correo el usuario.
        /// </summary>
        /// <param name="correo">Correo del usuario registrado</param>
        /// <returns>true o false segun corresponda</returns>
        public bool CorreoExiste(string correo)
        {
            try
            {
                using (var conexion = new MySqlConnection(_cadenaConexion))
                {
                var sql = @"SELECT COUNT(1) FROM USUARIOS WHERE correo = @Correo";
                return conexion.ExecuteScalar<int>(sql, new { Correo = correo }) > 0;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Metodo para obtener el usuario segun el correo
        /// </summary>
        /// <param name="correo">Correo del usuario registrado</param>
        /// <returns>Instancia de un Usuario o null</returns>
        public Usuario ObtenerUsuarioPorCorreo(string correo, string contrasenna)
        {
            try
            {
                bool verificado = VerificarCredenciales(correo, contrasenna);
                if (verificado)
                {
                    return base.ObtenerPorCorreo(correo);
                }
                else return null;
                
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo para obtener el usuario de inicio de sesion
        /// </summary>
        /// <param name="correo">correo del usuario con el que se registro</param>
        /// <param name="contrasenna">contraseña personal</param>
        /// <returns></returns>
        private bool VerificarCredenciales(string correo, string contrasenna)
        {
            try
            {
                var usuario = ObtenerPorCorreo(correo);
                if (usuario == null) return false;

                return BCrypt.Net.BCrypt.Verify(contrasenna, usuario.Contrasenna);
            }catch (Exception e)
            {
                return false;
            }
        }


        /// <summary>
        /// Metodo para crear un Usuario.
        /// </summary>
        /// <param name="usuario">Nuevo usuario a crear</param>
        /// <returns>true o false segun insercion exitosa o no</returns>
        public override bool Actualizar(Usuario usuario)
        {
            try
            {
                // Hashear la contraseña antes de guardarla
                usuario.Contrasenna = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenna);

                // Llamar al método base para crear el usuario
                base.Actualizar(usuario);
                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
    
}
