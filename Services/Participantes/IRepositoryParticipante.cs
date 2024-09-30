using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Participantes
{
    public interface IRepositoryParticipante<T>
    {
        bool Crear(T entidad);
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerTodos();
        bool Actualizar(T entidad);
        bool Eliminar(int id);
        IEnumerable<T> ObtenerPorIdHoja(int idHoja);
    }

}
