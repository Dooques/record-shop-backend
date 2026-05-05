using System.Reflection;

namespace RecordShopBackend.Model.Models
{
    public record Album
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Artist { get; set; }
        public required int ReleaseYear { get; set; }
        public required string Genre { get; set; }
    }
}
