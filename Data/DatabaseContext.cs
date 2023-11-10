using DatosPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace DatosPruebaTecnica.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options) { }

        public DbSet<DetalleFactura> DetalleFacturas { get; set; }

        public DbSet<Factura> Facturas { get; set; }

        public DbSet<FamiliadeProducto> FamiliadeProductos { get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Login> Logins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<FamiliadeProducto>()
                .HasMany(e => e.Productos)
                .WithOne(e => e.FamiliadeProducto)
                .HasForeignKey(e => e.IdProducto)
                .IsRequired();

            modelBuilder
                .Entity<Producto>()
                .HasOne(e => e.FamiliadeProducto)
                .WithMany(e => e.Productos)
                .HasForeignKey(e => e.IdFamilia)
                .IsRequired();
        }
    }
}
