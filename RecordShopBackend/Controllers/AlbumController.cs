using Microsoft.AspNetCore.Mvc;
using RecordShopBackend.Model.Service;

namespace RecordShopBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController(IAlbumService albumService) : ControllerBase
    {
        IAlbumService _albumService = albumService;

    }
}
