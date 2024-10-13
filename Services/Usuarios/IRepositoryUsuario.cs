using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Usuarios
{
    public interface IRepositoryUsuario<T>
    {
        int Crear(T entidad);
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerTodos();
        bool Actualizar(T entidad);
        bool Eliminar(int id);
    }

}
