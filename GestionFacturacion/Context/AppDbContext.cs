using GestionFacturacion.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TuyaPrueba.Models;

namespace TuyaPrueba.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Factura>Factura{get;set;}
        public DbSet<CabPedido> CabPedido { get; set; }
        public DbSet<DetallePedido> DetallePedido { get; set; }
        public DbSet<Despacho> Despachos { get; set; }
    }
}
