using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhotoAlbum.Services;
using Rhino.Mocks;
using RestSharp;
using PhotoAlbum.Services.Entities;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;

namespace PhotoAlbumApiClientTests
{
    [TestClass]
    public class PhotoAlbumApiServiceTests
    {
        private IRestClient _restClient;
        private IRestRequestService _restRequest;
        private IPhotoAlbumApiService _apiService;
        private readonly string _photoResourceUrl = "photos";
        private readonly string _albumResourceUrl = "albums";

        [TestInitialize]
        public void TestInit()
        {          
            _restClient  = MockRepository.GenerateMock<IRestClient>();
            _restRequest = MockRepository.GenerateMock<IRestRequestService>();
            _apiService  = new PhotoAlbumApiService(_restClient, _restRequest);
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetPhotosIsCalled_ThenReturnsPhotos()
        {
            //arrange
            var photos = GetPhotos();
            var request = GetRestRequest(_photoResourceUrl, Method.GET);
            _restRequest.Stub(x => x.CreateRequest(_photoResourceUrl, Method.GET)).Return(request);
            _restClient.Stub(c => c.Execute<List<Photo>>(request)).Return(GetPhotoReponse());

            //act
            var result = _apiService.GetPhotos();

            //assert
            result.ShouldAllBeEquivalentTo(photos);
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetAlbumsIsCalled_ThenReturnsAlbums()
        {
            //arrange
            var albums = GetAlbums();
            var request = GetRestRequest(_albumResourceUrl, Method.GET);
            _restRequest.Stub(x => x.CreateRequest(_albumResourceUrl, Method.GET)).Return(request);
            _restClient.Stub(c => c.Execute<List<Album>>(request)).Return(GetAlbumResponse());

            //act
            var result = _apiService.GetAlbums();

            //assert
            result.ShouldAllBeEquivalentTo(albums);
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetAlbumsByUserIdIsCalled_WithUserId_ThenReturnsAlbums()
        {
            //arrange
            var albums = GetAlbums().Where(x => x.UserId == 1).ToList();
            var resposne = new RestResponse<List<Album>>() { Data = albums };
            var request = GetRestRequest(Arg<string>.Is.Anything, Arg<Method>.Is.Anything);
            _restRequest.Stub(x => x.CreateRequest(_albumResourceUrl, Method.GET)).Return(request);
            _restClient.Stub(c => c.Execute<List<Album>>(request)).Return(resposne);

            //act
            var result = _apiService.GetAlbumsByUserId(1);

            //assert
            result.ShouldAllBeEquivalentTo(albums);
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetPhotosIsCalled_ThenRestRequestIsCalled()
        {         
            //act
            var result = _apiService.GetPhotos();

            //assert
            _restRequest.AssertWasCalled(x => x.CreateRequest(_photoResourceUrl, Method.GET));
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetAlbumsIsCalled_ThenRestRequestIsCalled()
        {
            //act
            var result = _apiService.GetAlbums();

            //assert
            _restRequest.AssertWasCalled(x => x.CreateRequest(_albumResourceUrl, Method.GET));
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetAlbumsByUserIdIsCalled_WithUserId_ThenRestRequestIsCalled()
        {
            //arrange
            var requestUrl = string.Format("{0}?userId={1}", _albumResourceUrl, 1);

            //act
            var result = _apiService.GetAlbumsByUserId(1);

            //assert
            _restRequest.AssertWasCalled(x => x.CreateRequest(requestUrl, Method.GET));
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetPhotosIsCalled_ThenRestClientExecuteIsCalled_WithRestRequest()
        {
            //arrange
            var request = GetRestRequest(_photoResourceUrl, Method.GET);
            _restRequest.Stub(x => x.CreateRequest(_photoResourceUrl, Method.GET)).Return(request);

            //act
            var result = _apiService.GetPhotos();

            //assert
            _restClient.AssertWasCalled(x => x.Execute<List<Photo>>(request));
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetAlbumsIsCalled_ThenRestClientExecuteIsCalled_WithRestRequest()
        {
            //arrange
            var request = GetRestRequest(_albumResourceUrl, Method.GET);
            _restRequest.Stub(x => x.CreateRequest(_albumResourceUrl, Method.GET)).Return(request);

            //act
            var result = _apiService.GetAlbums();

            //assert
            _restClient.AssertWasCalled(x => x.Execute<List<Album>>(request));
        }

        [TestMethod]
        public void GivenPhotoAlbumApiService_WhenGetAlbumsByUserIdIsCalled_ThenRestClientExecuteIsCalled_WithRestRequest()
        {
            //arrange
            var requestUrl = string.Format("{0}?userId={1}", _albumResourceUrl, 1);
            var request = GetRestRequest(requestUrl, Method.GET);
            _restRequest.Stub(x => x.CreateRequest(requestUrl, Method.GET)).Return(request);

            //act
            var result = _apiService.GetAlbumsByUserId(1);

            //assert
            _restClient.AssertWasCalled(x => x.Execute<List<Album>>(request));
        }

        private RestRequest GetRestRequest(string resourceUrl, Method method)
        {
            return new RestRequest()
            {
                Resource = resourceUrl,
                Method = method
            };
        }

        private RestResponse<List<Photo>> GetPhotoReponse()
        {
            return new RestResponse<List<Photo>>()
            {
                Data = GetPhotos()
            };
        }

        private RestResponse<List<Album>> GetAlbumResponse()
        {
            return new RestResponse<List<Album>>()
            {
                    Data = GetAlbums()
            };
        }

        private List<Photo> GetPhotos()
        {
            return new List<Photo>()
            {
                new Photo()
                {
                  AlbumId = 1,
                  Id = 2,
                  ThumbnailUrl = "https://via.placeholder.com/150/d32776",
                  Url =  "https://via.placeholder.com/600/f66b97",
                  Title = "test1"
                },
                new Photo()
                {
                  AlbumId = 1,
                  Id = 3,
                  ThumbnailUrl = "https://via.placeholder.com/150/d32776",
                  Url =  "https://via.placeholder.com/600/f66b97",
                  Title = "test2"
                }
            };
        }

        private List<Album> GetAlbums()
        {
            return new List<Album>()
            {
                new Album()
                {
                  UserId = 1,
                  Id = 2,
                  Title = "test1"
                },
                new Album()
                {
                  UserId = 2,
                  Id = 3,
                  Title = "test2"
                }
            };
        }
    }
}