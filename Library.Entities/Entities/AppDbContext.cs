using Microsoft.EntityFrameworkCore;

namespace Library.Entities.Entities
{
    public class AppDbContext: DbContext
    {

        public DbSet<Editorial> Editorials { get; set; }
        public DbSet<Autor> Autors { get; set; }
        public DbSet<Libro> Libros { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


    }

}
