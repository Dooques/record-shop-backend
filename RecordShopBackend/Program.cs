using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using RecordShopBackend.Model.Database;
using RecordShopBackend.Model.Repository;
using RecordShopBackend.Model.Service;

namespace RecordShopBackend
{
    public class Program
    {
            public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IAlbumService, AlbumService>();
            builder.Services.AddScoped<IAlbumModel, AlbumModel>();

            
            builder.Services.AddDbContext<RecordStoreDBContext>(options =>
            {
                var _connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") is "Development")
                {
                    Console.WriteLine($"Connection: ${_connectionString}");
                    var connection = new SqliteConnection(_connectionString);
                    connection.Open();
                    options.UseSqlite(connection);
                }
                else
                {
                    Console.WriteLine($"Connection: ${_connectionString}");                    
                    options.UseSqlServer(_connectionString);
                }
            });


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
