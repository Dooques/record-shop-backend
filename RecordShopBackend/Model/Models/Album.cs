using System.Reflection;

namespace RecordShopBackend.Model.Models
{
    public class Album(int id, string title, string artist, int releaseYear, string genre)
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Artist { get; set; } = artist;
        public int ReleaseYear { get; set; } = releaseYear;
        public string Genre { get; set; } = genre;
    }

    public class AlbumDTO(int id, string? title, string? artist, int? releaseYear, string? genre)
    {
        public int Id { get; set; } = id;
        public string? Title { get; set; } = title;
        public string? Artist { get; set; } = artist;
        public int? ReleaseYear { get; set; } = releaseYear;
        public string? Genre { get; set; } = genre;
    }
}
