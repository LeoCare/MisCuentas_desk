using Dapper;
using Microsoft.SqlServer.Server;
using MisCuentas_desk.Entities;
using MySqlConnector;
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
        private readonly string _cadenaConexion;

        public TiposDAO(string cadenaConexion)
        {
            _cadenaConexion = cadenaConexion;
        }

        public virtual TipoPerfil ObtenerByTipo(string tipo)
        {
            using (IDbConnection conexion = new MySqlConnection(_cadenaConexion))
            {
                var sql = $"SELECT * FROM TIPO_PERFIL WHERE tipo = {tipo}";
                return conexion.QuerySingleOrDefault<TipoPerfil>(sql, tipo);
            }
        }

        public virtual IEnumerable<TipoPerfil> ObtenerTodos()
        {
            using (IDbConnection conexion = new MySqlConnection(_cadenaConexion))
            {
                var sql = "SELECT * FROM TIPO_PERFIL";
                return conexion.Query<TipoPerfil>(sql);
            }
        }
    }
}
