using System.Text.Json;
using RecordShopBackend.Model.Database;
using RecordShopBackend.Model.Models;

namespace RecordShopBackend.Model.Repository
{
    public interface IAlbumModel
    {
        Album FetchAlbum(int id);
        List<Album> FetchAllAlbums();
        Album InsertAlbum(Album album);
        Album PatchAlbum(AlbumDTO album);
        Album RemoveAlbum(int id);
    }
    public class AlbumModel : IAlbumModel
    {
        private readonly RecordStoreDBContext _db;
        public AlbumModel(RecordStoreDBContext db)
        {
            _db = db;
        }

        public Album FetchAlbum(int id)
        {
            var albums = _db.Albums.ToList();
            return albums.First(a => a.Id == id);
        }

        public List<Album> FetchAllAlbums()
        {
            var albums = _db.Albums.ToList();
            return albums;
        }

        public Album InsertAlbum(Album album)
        {
            _db.Albums.Add(album);
            _db.SaveChanges();
            return album;
        }

        public Album PatchAlbum(AlbumDTO album)
        {
            var albumToUpdate = _db.Albums.First(a => a.Id == album.Id);

            if (
                albumToUpdate.Title == album.Title &&
                albumToUpdate.Artist == album.Artist &&
                albumToUpdate.Genre == album.Genre &&
                albumToUpdate.ReleaseYear == album.ReleaseYear
                ) throw new Exception("The album is the same as the one in the database, no changes to be made.");

            if (albumToUpdate.Title != album.Title) { albumToUpdate.Title = album.Title ?? albumToUpdate.Title; }
            if (albumToUpdate.Artist != album.Artist) { albumToUpdate.Artist = album.Artist ?? albumToUpdate.Artist; }
            if (albumToUpdate.ReleaseYear != album.ReleaseYear) { albumToUpdate.ReleaseYear = album.ReleaseYear ?? 0; }
            if (albumToUpdate.Genre != album.Genre) { albumToUpdate.Genre = album.Genre ?? albumToUpdate.Genre; }

            _db.SaveChanges();
            return albumToUpdate;
        }

        public Album RemoveAlbum(int id)
        {
            var albumToDelete = _db.Albums.First(a => a.Id == id);
            _db.Albums.Remove(albumToDelete);
            _db.SaveChanges();
            return albumToDelete;
        }
    }
}
