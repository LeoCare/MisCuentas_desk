using MisCuentas_desk.Entities;
using System;
using System.Collections.Generic;


namespace MisCuentas_desk.Services.Participantes
{
    public class ParticipanteServices : ParticipanteDAO
    {
        public ParticipanteServices(string cadenaConexion) : base(cadenaConexion) { }

        public override bool Crear(Participante participante)
        {
            try
            {
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
                return base.Actualizar(participante);
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        public override bool Eliminar(int idParticipante)
        {
            try
            {
                return base.Eliminar(idParticipante);
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
