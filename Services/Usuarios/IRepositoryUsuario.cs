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
        bool Crear(T entidad);
        T ObtenerPorId(int id);
        IEnumerable<T> ObtenerTodos();
        void Actualizar(T entidad);
        void Eliminar(int id);
    }
}
