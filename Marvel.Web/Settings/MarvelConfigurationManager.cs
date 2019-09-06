using System.Configuration;

namespace Marvel.Web.Settings
{
    public class MarvelConfigurationManager : IMarvelConfigurationManager
    {
        public string MarvelPublicKey => ConfigurationManager.AppSettings["MarvelPublicKey"];
        public string MarvelPrivateKey => ConfigurationManager.AppSettings["MarvelPrivateKey"];
        public string MarvelBaseUrl => ConfigurationManager.AppSettings["MarvelBaseUrl"];
    }
}