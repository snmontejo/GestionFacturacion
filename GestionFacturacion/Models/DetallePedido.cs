using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionFacturacion.Models
{
    public class DetallePedido
    {
        public int id { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public int cantidad { get; set; }
        public Decimal precioUnitario { get; set; }
        public Decimal descuento { get; set; }
    }
}
