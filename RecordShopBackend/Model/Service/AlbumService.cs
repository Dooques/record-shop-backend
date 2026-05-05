using RecordShopBackend.Model.Repository;

namespace RecordShopBackend.Model.Service
{
    public interface IAlbumService
    {

    }
    public class AlbumService(IAlbumModel albumModel) : IAlbumService
    {
        IAlbumModel _albumModel = albumModel;
    }
}
