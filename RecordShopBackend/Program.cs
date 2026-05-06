using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RecordShopBackend.Model.Database;
using RecordShopBackend.Model.Repository;
using RecordShopBackend.Model.Service;

namespace RecordShopBackend
{
    public class Program
    {
        private static string? connectionString = System.Configuration.ConfigurationManager.AppSettings["CONNECTION_STRING"];
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IAlbumModel, AlbumModel>();

            
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") is "Development")
            {
                var connection = new SqliteConnection(connectionString);
                connection.Open();

                builder.Services.AddDbContext<RecordStoreDBContext>(options =>
                {
                    options.UseSqlite(connection);
                });
            } else
            {
                var connection = new SqlConnection(connectionString);
                connection.Open();
                builder.Services.AddDbContext<RecordStoreDBContext>(options =>
                {
                    options.UseSqlServer(connection);
                });

            }

            var app = builder.Build();

            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<RecordStoreDBContext>();
                    db.Database.EnsureCreated();
                }
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
