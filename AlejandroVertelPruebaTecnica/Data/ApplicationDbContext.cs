using AlejandroVertelPruebaReImagine.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlejandroVertelPruebaReImagine.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<DetalleDeVenta> DetallesDeVenta { get; set; }
        public DbSet<Producto> Productos { get; set; }


    }
}
