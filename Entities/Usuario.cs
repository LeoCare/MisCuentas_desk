using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class Usuario
    {
        private static Usuario instancia = null;

        public int Id_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasenna { get; set; }
        public string Perfil { get; set; }
        public Personal_Data Personal_Data { get; set; } = new Personal_Data();
        public List<Hoja> Hojas { get; set; } = new List<Hoja>(); 
        public List<Gasto> Gastos { get; set; } = new List<Gasto>();
        public List<Pago> Pagos { get; set; } = new List<Pago>();

        // Constructor sin parámetros
        public Usuario() { }

        // Constructor con parámetros
        public Usuario(string nombre, string correo, string contrasenna, string perfil ) 
        { 
            Nombre = nombre;
            Correo = correo;
            Contrasenna = contrasenna;
            Perfil = perfil;
        }

        // Método estático para obtener la instancia
        public static Usuario ObtenerInstancia(Usuario usuario)
        {
            if (instancia == null)
            {
                instancia = usuario;
            }
            return instancia;
        }

        // Método estático para cerrar sesión (resetear la instancia)
        public static void CerrarSesion()
        {
            instancia = null;
        }
    }


}
