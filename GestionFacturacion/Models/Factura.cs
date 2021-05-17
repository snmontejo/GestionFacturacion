using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuyaPrueba.Models
{
    public class Factura
    {
        public int id { get; set; }
        public int idPedido { get; set; }

        public Decimal totalFactura { get; set; }
        public DateTime fecha { get; set; }
    }
}
