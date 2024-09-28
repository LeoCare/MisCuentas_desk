using MisCuentas_desk.Entities;
using MisCuentas_desk.Services.Usuarios;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.PersonalData
{
    class PersonalDataServices : PersonalDataDAO
    {
        public PersonalDataServices(string cadenaConexion) : base(cadenaConexion)
        {
        }


        public override bool Crear(Personal_Data datosUsuario)
        {
            try
            {
                base.Crear(datosUsuario);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public override Personal_Data ObtenerPorId(int id)
        {
            try
            {
                return base.ObtenerPorId(id); 
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public override bool Actualizar(Personal_Data datosUsuario)
        {
            try
            {
                base.Actualizar(datosUsuario);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
