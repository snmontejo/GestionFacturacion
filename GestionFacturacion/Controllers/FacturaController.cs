using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuyaPrueba.Context;
using TuyaPrueba.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GestionFacturacion.Controllers
{
    
    
    public class FacturaController : Controller
    {
        private readonly AppDbContext context;
        public FacturaController(AppDbContext context)
        {
            this.context = context;
        }
       
        [HttpGet]
        [Route("ListarFacturas")]
        public IEnumerable<Factura> Get()
        {
            return context.Factura.ToList();
        }

        // GET api/<FacturaController>/5
        [HttpGet("{id}")]
        public Factura Get(int id)
        {
            var factura = context.Factura.FirstOrDefault(p => p.id == id);
            return factura;
        }

        // POST api/<FacturaController>
        [HttpPost]
        [Route("Facturar")]
        public ActionResult Post([FromBody] Factura factura)
        {
            try
            {
                var TotalFactura = context.DetallePedido.Where(p => p.idPedido == factura.idPedido).ToList().Sum(t=> t.precioUnitario*t.cantidad);
                factura.totalFactura = TotalFactura;
                factura.fecha = DateTime.Now;
                context.Factura.Add(factura);
                context.SaveChanges();
                return Ok("Factura Nro "+ factura .id+ " Registrada Con Exito");
            }catch
            {
                return BadRequest();
            }
        }

        // PUT api/<FacturaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FacturaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
