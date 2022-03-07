using Authorization.Model;
using Microsoft.EntityFrameworkCore;

namespace Authorization.DAL
{
    public class AuthorizationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public AuthorizationContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }
    }
}
