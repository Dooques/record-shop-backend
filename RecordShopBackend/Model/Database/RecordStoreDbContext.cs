using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using RecordShopBackend.Model.Models;
using SharpCompress.Common;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RecordShopBackend.Model.Database
{
    public class RecordStoreDBContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public RecordStoreDBContext(DbContextOptions<RecordStoreDBContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") is "Development")
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Album>().HasData(
                    new Album(1, "Breakup Song", "Deerhoof", 2012, "Indie Rock"),
                    new Album(2, "Stereo Type A", "Cibo Matto", 1999, "Trip hop"),
                    new Album(3, "Blue Rev", "Alvvays", 2022, "Alternative / Shoegaze"),
                    new Album(4, "Souvlaki Space Station", "Slowdive", 1993, "Shoegaze / Ambient"),
                    new Album(5, "Loveless", "My Bloody Valentine", 1991, "Shoegaze")
                );
            }
        }
    }
}
