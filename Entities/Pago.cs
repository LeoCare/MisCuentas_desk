using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MisCuentas_desk.Entities
{
    public class Pago
    {
        public int Id_Pago { get; set; }
        public int Id_Balance { get; set; }
        public int Id_Balance_Pagado { get; set; }
        public Double Monto { get; set; }
        public DateTime Fecha_Pago { get; set; }
        public DateTime Fecha_Confirmacion { get; set; }


        public Pago() { }

        public Pago(int id_Pago, int id_Balance, int id_Balance_Pagado, Double monto, DateTime fecha_Pago, DateTime fecha_Confirmacion)
        {
            Id_Pago = id_Pago;
            Id_Balance = id_Balance;
            Id_Balance_Pagado = id_Balance_Pagado;
            Monto = monto;
            Fecha_Pago = fecha_Pago;
            Fecha_Confirmacion = fecha_Confirmacion;
        }
    }
}
