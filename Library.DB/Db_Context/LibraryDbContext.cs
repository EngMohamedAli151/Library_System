using Library.DB.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Library.DB.Db_Context
{
    public class LibraryDbContext:DbContext

    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext>options):base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User>Users { get; set; }
        public DbSet<Order>Orders { get; set; }
    }
}
