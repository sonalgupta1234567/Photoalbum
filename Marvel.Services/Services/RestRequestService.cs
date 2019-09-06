using Marvel.Services.Utility;
using RestSharp;

namespace Marvel.Services
{
    public class RestRequestService : IRestRequestService
    {
        private readonly ITimeStamp _timestamp;
        private readonly IHash _hash;
        public RestRequestService()
        {
            _timestamp = new TimeStamp();
            _hash = new Hash();
        }

        internal RestRequestService(ITimeStamp timeStamp, IHash hash)
        {
            _timestamp = timeStamp;
            _hash = hash;
        }

        public  RestRequest CreateRequest(string resource, Method method, string privateKey, string publicKey)
        {
            var timestamp = _timestamp.GetTimestamp();
            var hash = _hash.GetHash(timestamp, privateKey, publicKey);
            var request = new RestRequest(resource, method);
            request.AddHeader("Accept", "application/json");
            request.AddParameter("ts", timestamp, ParameterType.QueryString);
            request.AddParameter("apikey", publicKey, ParameterType.QueryString);
            request.AddParameter("hash", hash, ParameterType.QueryString);
            return request;
        }
    }
}
