using Microsoft.EntityFrameworkCore;
using RecordShopBackend.Model.Models;

namespace RecordShopBackend.Model.Database
{
    public class RecordStoreDBContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public RecordStoreDBContext(DbContextOptions<RecordStoreDBContext> options) : base(options) {  }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=RecordStoreDB;Trusted_Connection=True;");
        }
    }
}
