using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Shouldly.Configuration;

namespace RecordShopBackend.Model.Data
{
    public class InMemoryAlbumRepository
    {
        private string? connectionString = System.Configuration.ConfigurationManager.AppSettings["CONNECTION_STRING"];

        public void CreateTable() 
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var createTableCommand = connection.CreateCommand();
                
                createTableCommand.CommandText =
                    """
                    CREATE TABLE albums
                    VALUES (
                        id INTEGER PRIMARY KEY AUTOINCREMENT,
                        title TEXT NOT NULL,
                        artist TEXT NOT NULL,
                        release_year INTEGER NOT NULL,
                        genre TEXT NOT NULL
                    );
                    """;
                createTableCommand.ExecuteNonQuery();
            }
        }
    }
}
