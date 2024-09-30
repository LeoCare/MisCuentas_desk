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
        /// <returns>id del usuario recien creado</returns>
        public override int Crear(Usuario usuario)
        {
            try
            {           
                // Hashear la contraseña antes de guardarla
                usuario.Contrasenna = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenna);

                return base.Crear(usuario);
               
            }
            catch (Exception e)
            {
                return 0;
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
        /// Metodo para obtener el usuario por id
        /// </summary>
        /// <param name="id_usuario">Correo del usuario registrado</param>
        /// <returns>Instancia de un Usuario o null</returns>
        public Usuario ObtenerUsuarioPorId(int id_usuario)
        {
            try
            {
                return base.ObtenerPorId(id_usuario);
            }
            catch (Exception e)
            {
                return null;
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
