using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TuyaPrueba.Models
{
    public class Despacho
    {
        public int id { get; set; }
        public int idFactura { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public DateTime fechaEnvio { get; set; }
        public string nroGuia { get; set; }
        public int idTransportadora { get; set; }


    }
}
