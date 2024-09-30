using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Gastos
{
    public interface IRepositoryGasto<T>
    {
        bool Crear(T entidad);
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerPorIdParticipante(int idParticipante);
        bool Actualizar(T entidad);
        bool Eliminar(int id);
    }

}
