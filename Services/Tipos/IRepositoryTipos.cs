using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Tipos
{
    public interface IRepositoryTipos<T>
    {
        T ObtenerByTipo(string tipo);
        IEnumerable<T> ObtenerTodos();
       
    }
}
