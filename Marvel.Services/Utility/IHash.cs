namespace Marvel.Services.Utility
{
    public interface IHash
    {
        string GetHash(string timestamp, string privateKey, string publicKey);
    }
}