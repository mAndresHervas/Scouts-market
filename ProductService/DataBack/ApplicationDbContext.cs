
// ProductService/Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using ProductService.Models;   // <- donde tengas tus entidades

namespace ProductService.DataBack   // <- AJUSTA si tu raíz del proyecto usa otro namespace
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // DbSet para cada entidad:
        public DbSet<Usuario> Usuarios { get; set; }
        // public DbSet<Producto> Productos { get; set; }
        // ...añade más según necesites
    }
}
