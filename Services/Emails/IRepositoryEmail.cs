﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Emails
{
    public interface IRepositoryEmail<T>
    {
        IEnumerable<T> ObtenerTodosAcreedorByHoja(int idUsuario);
        IEnumerable<T> ObtenerTodosDeudorByHoja(int idUsuario);
    }
}
