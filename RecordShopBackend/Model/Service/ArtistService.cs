using RecordShopBackend.Model.Repository;

namespace RecordShopBackend.Model.Service
{
    public interface IArtistService
    {
        
    }
    public class ArtistService(IArtistModel artistModel) : IArtistModel
    {
        IArtistModel _artistModel = artistModel;
    }
}
