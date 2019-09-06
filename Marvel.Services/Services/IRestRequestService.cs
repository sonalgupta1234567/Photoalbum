using RestSharp;

namespace Marvel.Services
{
    public interface IRestRequestService
    {
        RestRequest CreateRequest(string resource, Method method, string privateKey, string publicKey);
    }
}