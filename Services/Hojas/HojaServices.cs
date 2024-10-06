using MisCuentas_desk.Entities;
using System;


namespace MisCuentas_desk.Services.Hojas
{
    public class HojaServices : HojaDAO
    {
        public HojaServices(string cadenaConexion) : base(cadenaConexion) { }

        public override int Crear(Hoja hoja)
        {
            try
            {               
                return base.Crear(hoja);
            }
            catch (Exception ex)
            {   
                return 0;
            }
        }

        public override bool Actualizar(Hoja hoja)
        {
            try
            {
                return base.Actualizar(hoja);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public override bool Eliminar(int idHoja)
        {
            try
            {
                return base.Eliminar(idHoja);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
