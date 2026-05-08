using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordShopBackend.Controllers;
using RecordShopBackend.Model.Models;
using RecordShopBackend.Model.Service;
using Shouldly;

namespace TestSuite.ControllerTests
{
    [TestFixture]
    internal class AlbumControllerTests
    {
        private Mock<IAlbumService> _albumService;
        private AlbumsController _albumController;

        [SetUp]
        public void SetUp()
        {
            _albumService = new Mock<IAlbumService>();
            _albumController = new AlbumsController(_albumService.Object);
        }

        [Test]
        public void GetAlbums()
        {
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumService.Setup(service => service.GetAllAlbums()).Returns(new List<Album> { expected });

            var result = _albumController.GetAllAlbums() as OkObjectResult;
            result.StatusCode.ShouldBe(StatusCodes.Status200OK);
            (result.Value as IEnumerable<Album>).ShouldNotBeEmpty();
            (result.Value as IEnumerable<Album>).ToList().First().ShouldBe(expected);
        }
        
        [Test]
        public void GetAlbums_NoData_ReturnsEmptyList()
        {
            _albumService.Setup(service => service.GetAllAlbums()).Returns(new List<Album> { });

            var result = _albumController.GetAllAlbums() as OkObjectResult;

            result.Value.ShouldBeOfType(typeof(List<Album>));
            (result.Value as IEnumerable<Album>).ShouldBeEmpty();
        }

        [Test]
        public void GetAlbumById_ValidId()
        {
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumService.Setup(service => service.GetAlbumById(1)).Returns(expected);

            var result = _albumController.GetAlbum(1) as OkObjectResult;
            result.StatusCode.ShouldBe(StatusCodes.Status200OK);
        }

        [Test]
        public void GetAlbumById_InvalidId()
        {
            _albumService.Setup(service => service.GetAlbumById(999));

            var result = _albumController.GetAlbum(999) as OkObjectResult;
            result.StatusCode.ShouldBe(StatusCodes.Status200OK);
        }

        [Test]
        public void PostAlbum()
        {
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumService.Setup(service => service.PostAlbum(expected)).Returns(expected);

            var result = _albumController.PostAlbum(expected) as ObjectResult;
            result.StatusCode.ShouldBe(StatusCodes.Status201Created);
            result.Value.ShouldBe(expected);
        }

        [Test]
        public void PatchAlbum()
        {
            var input = new AlbumDTO(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumService.Setup(service => service.UpdateAlbum(input)).Returns(expected);

            var result = _albumController.UpdateAlbum(input) as ObjectResult;
            result.StatusCode.ShouldBe(StatusCodes.Status200OK);
            result.Value.ShouldBe(expected);
        }
        
        [Test]
        public void DeleteAlbum()
        {
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumService.Setup(service => service.DeleteAlbum(1)).Returns(expected);

            var result = _albumController.DeleteAlbum(1) as ObjectResult;
            result.StatusCode.ShouldBe(StatusCodes.Status204NoContent);
            result.Value.ShouldBe(expected);
        }

    }
}
