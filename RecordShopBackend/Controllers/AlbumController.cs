using Microsoft.AspNetCore.Mvc;
using RecordShopBackend.Model.Database;
using RecordShopBackend.Model.Models;
using RecordShopBackend.Model.Service;

namespace RecordShopBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbumController(IAlbumService albumService) : ControllerBase
    {
        IAlbumService _albumService = albumService;

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            return Ok(_albumService.GetAllAlbums());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAlbum(int id)
        {
            return Ok(_albumService.GetAlbumById(id));
        }

        [HttpPost]
        public IActionResult PostAlbum(Album album)
        {
            _albumService.PostAlbum(album);
            return Created($"/albums/{album.Id}", album);
        }

        [HttpPut]
        public IActionResult UpdateAlbum(AlbumDTO album)
        {
            return Ok(_albumService.UpdateAlbum(album));
        }

        [HttpDelete]
        public IActionResult DeleteAlbum(int id)
        {
            _albumService.DeleteAlbum(id);
            return NoContent();
        }
    }
}
