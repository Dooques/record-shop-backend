using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RecordShopBackend.Model.Database;

namespace RecordShopBackend
{
    public class Program
    {
        private static string? connectionString = System.Configuration.ConfigurationManager.AppSettings["CONNECTION_STRING"];
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<RecordStoreDBContext>(options =>
            {
                var connection = new SqliteConnection(connectionString);
                connection.Open();
                options.UseSqlServer(connection);
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
