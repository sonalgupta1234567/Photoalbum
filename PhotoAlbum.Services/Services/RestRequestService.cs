using RestSharp;

namespace PhotoAlbum.Services
{
    public class RestRequestService : IRestRequestService
    {
        public  RestRequest CreateRequest(string resource, Method method)
        {    
            var request = new RestRequest(resource, method);
            request.AddHeader("Accept", "application/json");         
            return request;
        }
    }
}
