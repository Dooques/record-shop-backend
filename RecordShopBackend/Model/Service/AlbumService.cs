using RecordShopBackend.Model.Database;
using RecordShopBackend.Model.Models;
using RecordShopBackend.Model.Repository;

namespace RecordShopBackend.Model.Service
{
    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        Album PostAlbum(Album album);
        Album UpdateAlbum(AlbumDTO album);
        Album DeleteAlbum(int id);
    }
    public class AlbumService(IAlbumModel albumModel) : IAlbumService
    {
        IAlbumModel _albumModel = albumModel;
        public Album GetAlbumById(int id)
        {
            return _albumModel.FetchAlbum(id);
        }

        public List<Album> GetAllAlbums()
        {
            return _albumModel.FetchAllAlbums();
        }

        public Album PostAlbum(Album album)
        {
            return _albumModel.InsertAlbum(album);
        }

        public Album UpdateAlbum(AlbumDTO album)
        {
            return _albumModel.PatchAlbum(album);
        }
        public Album DeleteAlbum(int id)
        {
            return _albumModel.RemoveAlbum(id);
        }
    }
}
