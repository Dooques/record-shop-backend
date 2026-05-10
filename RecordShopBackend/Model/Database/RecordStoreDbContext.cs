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

        public RecordStoreDBContext(DbContextOptions<RecordStoreDBContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") is "Development")
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Entity<Album>().HasData(
                    new Album(1, "Breakup Song", "Deerhoof", 2012, "Indie Rock", 5, 
                    "https://upload.wikimedia.org/wikipedia/en/c/cf/Breakup_Song.jpg"),
                    new Album(2, "Stereo Type A", "Cibo Matto", 1999, "Trip hop", 3, 
                    "https://upload.wikimedia.org/wikipedia/en/0/02/Stereo_Type_A.jpg"),
                    new Album(3, "Blue Rev", "Alvvays", 2022, "Alternative / Shoegaze", 6, 
                    "https://upload.wikimedia.org/wikipedia/en/7/7f/Blue_Rev_Alvvays.jpg"),
                    new Album(4, "Souvlaki", "Slowdive", 1993, "Shoegaze / Ambient", 0, 
                    "https://upload.wikimedia.org/wikipedia/en/a/a6/Souvlaki_%28album%29_cover.jpg"),
                    new Album(5, "Loveless", "My Bloody Valentine", 1991, "Shoegaze", 10, 
                    "https://upload.wikimedia.org/wikipedia/en/4/4b/My_Bloody_Valentine_-_Loveless.png"));
            }
        }
    }
}
