using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Pagos
{
    public interface IRepositoryPago<T>
    {
        bool Crear(T entidad);
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerPorIdBalance(int idBalance);
        bool Actualizar(T entidad);
        bool Eliminar(int id);
    }
}
