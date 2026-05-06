using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RecordShopBackend.Model.Models;
using RecordShopBackend.Model.Repository;
using RecordShopBackend.Model.Service;
using Shouldly;

namespace TestSuite.AlbumServiceTests
{
    [TestFixture]
    internal class AlbumServiceTests
    {
        private Mock<IAlbumModel> _albumModel;
        private IAlbumService _albumService;

        [SetUp]
        public void SetUp()
        {
            _albumModel = new Mock<IAlbumModel>();
            _albumService = new AlbumService(_albumModel.Object);
        }

        [Test]
        public void FetchAllAlbums()
        {
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumModel.Setup(model =>model.FetchAllAlbums()).Returns(new List<Album> { expected });

            var result = _albumService.GetAllAlbums();
            result.ShouldNotBeEmpty();
            result.First().ShouldBe(expected);
        }

        [Test]
        public void FetchAlbums_NoData_ReturnsEmptyList()
        {
            _albumModel.Setup(service => service.FetchAllAlbums()).Returns(new List<Album>());

            var result = _albumService.GetAllAlbums();
            result.ShouldBeOfType(typeof(List<Album>));
            result.ShouldBeEmpty();
        }
        
        [Test]
        public void PostAlbum()
        {
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumModel.Setup(service => service.InsertAlbum(expected)).Returns(expected);

            var result = _albumService.PostAlbum(expected);
            result.ShouldBe(expected);
        }

        [Test]
        public void UpdateAlbum()
        {
            var input = new AlbumDTO(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumModel.Setup(service => service.PatchAlbum(input)).Returns(expected);

            var result = _albumService.UpdateAlbum(input);
            result.ShouldBe(expected);
        }

        [Test]
        public void DeleteAlbum()
        {
            var expected = new Album(1, "Stereo Type A", "Cibo Matto", 1999, "Trip hop");

            _albumModel.Setup(service => service.RemoveAlbum(1)).Returns(expected);

            var result = _albumService.DeleteAlbum(1);
            result.ShouldBe(expected);
        }
    }
}
