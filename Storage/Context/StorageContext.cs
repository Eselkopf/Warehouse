using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace Storage.Context
{
    public class StorageContext : DbContext
    {
        public DbSet<StorageLevel> StorageLevels { get; set; } = null!;
        public DbSet<StorageLevelTreeObject> StorageLevelTreeObjects { get; set; } = null!;
        public DbSet<Item> StoringItems { get; set; } = null!;
        public StorageContext()
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
