namespace Marvel.Web.Settings
{
    public interface IMarvelConfigurationManager
    {
        string MarvelPrivateKey { get; }
        string MarvelPublicKey { get; }
        string MarvelBaseUrl { get; }
    }
}