using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace MinimalAPIAuthentication.Services
{
    public class HashService : IHashService
    {
        public string GetHash(string key)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: key!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
        }
    }
}
