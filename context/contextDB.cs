using Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Api.context
{
    public class contextDB : DbContext
    {
        public contextDB(DbContextOptions options) : base(options)
        { }

        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<productos> productos { get; set; }
        public DbSet<favoritos> favoritos { get; set; }
        public DbSet<carrito> carrito { get; set; }
        public DbSet<carrito_detalle> carrito_detalle { get; set; }
        public DbSet<metodos_pago> metodos_pago { get; set; }
        public DbSet<pedidos> pedidos { get; set; }
        public DbSet<pedido_detalle> pedido_detalle { get; set; }
        public DbSet<pagos> pagos { get; set; }
        public DbSet<reportes> reportes { get; set; }
    }
}