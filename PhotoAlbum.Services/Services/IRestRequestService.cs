using RestSharp;

namespace PhotoAlbum.Services
{
    public interface IRestRequestService
    {
        RestRequest CreateRequest(string resource, Method method);
    }
}