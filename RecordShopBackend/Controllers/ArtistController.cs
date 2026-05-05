using Microsoft.AspNetCore.Mvc;
using RecordShopBackend.Model.Service;

namespace RecordShopBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController(IArtistService artistService) : ControllerBase
    {
        IArtistService _artistService = artistService;
    }
}
