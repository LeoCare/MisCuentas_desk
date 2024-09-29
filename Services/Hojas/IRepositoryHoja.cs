using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Hojas
{
    public interface IRepositoryHoja<T>
    {
        bool Crear(T entidad);
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerPorIdUsuario(int idUsuario);
        bool Actualizar(T entidad);
        bool Eliminar(int id);
    }

}
