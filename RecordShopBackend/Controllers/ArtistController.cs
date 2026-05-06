using Microsoft.AspNetCore.Mvc;
using RecordShopBackend.Model.Service;

namespace RecordShopBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController(IArtistService artistService) : ControllerBase
    {
        IArtistService _artistService = artistService;

        [HttpGet]
        public IActionResult GetAllArtists()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetArtist(int id)
        {
            return Ok();
        }
    }
}
