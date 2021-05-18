using GestionFacturacion.Models;
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
    public class PedidoController : Controller
    {

        private readonly AppDbContext context;
        public PedidoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [Route("ListarPedidos")]
        public IEnumerable<CabPedido> Get()
        {
            return context.CabPedido.ToList();
        }
        // POST: PedidoController/Create
        [HttpPost]
        [Route("cabPedido")]
        public ActionResult Post([FromBody] CabPedido cabPedido)
        {
            try
            {
                if (cabPedido == null)
                {
                    throw new Exception("Todos los Campos son Obligatorios.Valide que cuente con el Formato correcto");
                }
                if(!EsFecha(cabPedido.fechaPedido.ToString()))
                {
                    throw new Exception("Formato Fecha Invalida,(yyyy-mm-dd)");
                }
                context.CabPedido.Add(cabPedido);
                context.SaveChanges();
               
                return Ok("Pedido Nro " + cabPedido.NumPedido.ToString() + " Registrado Con Exito");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public static Boolean EsFecha(String fecha)
        {
            try
            {
                DateTime.Parse(fecha);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // POST: PedidoController/Create
        [HttpPost]
        [Route("detallePedido")]
        public ActionResult Post([FromBody] DetallePedido detallePedido)
        {
            try
            {
                if(detallePedido== null)
                {
                    throw new Exception("Todos los Campos son Obligatorios");
                }
                if(EsValorValido(detallePedido.precioUnitario.ToString())==false)
                {
                    throw new Exception("Precio Unitario, formato incorrecto");
                }
                context.DetallePedido.Add(detallePedido);
                context.SaveChanges();
                return Ok("Item  Registrado Con Exito");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public static Boolean EsValorValido(string valor)
        {
            decimal number3 = 0;
            bool canConvert  = decimal.TryParse(valor, out number3);
            if (canConvert == true)
                return true;
            else
                return false;

        }

        // GET: PedidoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PedidoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PedidoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PedidoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
