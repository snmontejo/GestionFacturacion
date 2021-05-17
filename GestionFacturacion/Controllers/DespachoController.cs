using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuyaPrueba.Context;
using TuyaPrueba.Models;

namespace GestionFacturacion.Controllers
{
    public class DespachoController : Controller
    {

        private readonly AppDbContext context;
        public DespachoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        [Route("CrearDespacho")]
        public ActionResult Post([FromBody] Despacho despacho)
        {
            try
            {
                context.Despachos.Add(despacho);
                context.SaveChanges();
                return Ok("Despacho  Registrado Con Exito");
            }
            catch
            {
                return BadRequest();
            }
        }
        
    }
}
