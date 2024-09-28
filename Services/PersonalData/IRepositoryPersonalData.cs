using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.PersonalData
{
    public interface IRepositoryPersonalData<T>
    {
        bool Crear(T entidad);
        T ObtenerPorId(int id);
        bool Actualizar(T entidad);
        bool Eliminar(int id);
    }
}
