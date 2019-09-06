using System;
using System.Security.Cryptography;
using System.Text;

namespace Marvel.Services.Utility
{
    public class Hash : IHash
    {
        public string GetHash(string timestamp, string privateKey, string publicKey)
        {
            var combined = timestamp + privateKey + publicKey;
            var bytes = Encoding.UTF8.GetBytes(combined);
            var hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes);
            var converted = BitConverter.ToString(hash);
            return converted.Replace("-", string.Empty).ToLower();
        }
    }
}
