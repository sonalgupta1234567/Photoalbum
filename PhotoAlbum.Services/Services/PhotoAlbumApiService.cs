using System.Collections.Generic;
using PhotoAlbum.Services.Entities;
using PhotoAlbum.Services.Utility;
using RestSharp;

namespace PhotoAlbum.Services
{
    public class PhotoAlbumApiService : IPhotoAlbumApiService
    {      
        private readonly IRestClient _restClient;
        private readonly IRestRequestService _restRequest;
   
        public PhotoAlbumApiService(string baseUrl)
        {           
            _restRequest = new RestRequestService();
            _restClient = new RestClient(baseUrl);
        }

        internal PhotoAlbumApiService(IRestClient restClient, IRestRequestService restRequest)
        {
            _restClient = restClient;
            _restRequest = restRequest;
        }

        public List<Photo> GetPhotos()
        {
            var request = _restRequest.CreateRequest(Constants.PhotoResourceUrl, Method.GET);
            var response = _restClient.Execute<List<Photo>>(request);
            return response?.Data;
        }

        public List<Album> GetAlbums()
        {
            var request = _restRequest.CreateRequest(Constants.AlbumResourceUrl, Method.GET);
            var response = _restClient.Execute<List<Album>>(request);
            return response?.Data;
        }

        public List<Album> GetAlbumsByUserId(int id)
        {
            var requestUrl = string.Format("{0}?userId={1}", Constants.AlbumResourceUrl, id);
            var request = _restRequest.CreateRequest(requestUrl, Method.GET);
            var response = _restClient.Execute<List<Album>>(request);
            return response?.Data;
        }
    }
}