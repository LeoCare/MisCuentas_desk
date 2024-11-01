﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;
using Dapper;
using MySqlConnector;
using System.Data;
using System.Windows.Forms;

namespace MisCuentas_desk.Configurations
{
    public class MisCuentasConnect
    {

        #region ATRIBUTOS
        private string _strConn;
        #endregion

        #region METODOS
        /// <summary>
        /// Metodo que entrega la cadena de conexion.
        /// </summary>
        /// <returns>Cadena de conexion a la BBDD</returns>
        public String Conexion()
        {
            return this._strConn = "Server=192.168.7.3;Port=3306;Database=DBMisCuentas;Uid=leo;Pwd=111nonamaEM";
        }


        /// <summary>
        /// Metodo que realiza la conexion con la BBDD.
        /// </summary>
        /// <returns>True si logra conectarse, o mensaje de aviso si falla.</returns>
        public Boolean PruebaConexion()
        {
            try
            {
                using (IDbConnection db = new MySqlConnection(_strConn))
                {
                    db.Open(); // Intentamos abrir la conexión

                    if (db.State == ConnectionState.Open)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("No se pudo establecer la conexión con la base de datos.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
                return false;
            }
        }
        #endregion
    }
}
