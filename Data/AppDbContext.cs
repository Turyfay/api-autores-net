using autores_api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace autores_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros {get;set;}
        
        

    }
}