using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionFacturacion.Models
{
    public class CabPedido
    {

        public int id { get; set; }
        public DateTime fechaPedido { get; set; }
        public int IdCliente { get; set; }
        public Int64 NumPedido { get; set; }
        public string Observacion { get; set; }

    }
}
