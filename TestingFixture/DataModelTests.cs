using RecordShopBackend.Model.Models;
using Shouldly;

namespace TestSuite.DataModels
{
    public class DataModelTests
    {
        [Test]
        public void AlbumTest_ValidData()
        {

            var result = new Album
            {
                Id = 1,
                Title = "Test Album",
                Artist = "Test Artist",
                ReleaseYear = 2020,
                Genre = "Rock"
            };

            result.Artist.ShouldBe("Test Artist");
            result.Title.ShouldBe("Test Album");
            result.ReleaseYear.ShouldBe(2020);
            result.Genre.ShouldBe("Rock");
        }    
    }
}