using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Services.Participantes
{
    public class ParticipanteServices : ParticipanteDAO
    {
        public ParticipanteServices(string cadenaConexion) : base(cadenaConexion) { }

        public override bool Crear(Participante participante)
        {
            try
            {
                // Aquí puedes agregar validaciones adicionales antes de crear el participante
                return base.Crear(participante);
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

        public override bool Actualizar(Participante participante)
        {
            try
            {
                // Lógica adicional antes de actualizar (si es necesario)
                return base.Actualizar(participante);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public IEnumerable<Participante> ObtenerParticipantesPorHoja(int idHoja)
        {
            try
            {
                return ObtenerPorIdHoja(idHoja);
            }
            catch (Exception ex)
            {   
                return null;
            }
        }
    }

}
