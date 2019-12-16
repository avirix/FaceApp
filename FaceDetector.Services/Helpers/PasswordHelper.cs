using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FaceDetector.Services.Helpers
{
    public static class PasswordHelper
    {
        public static string CreatePasswordHash(string password, string passwordSalt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                    password: password,
                    salt: Encoding.UTF8.GetBytes(passwordSalt),
                    prf: KeyDerivationPrf.HMACSHA512,
                    iterationCount: 10000,
                    numBytesRequested: 256 / 8);
            return Convert.ToBase64String(valueBytes);
        }

        public static bool VerifyPasswordHash(string password, string storedHash, string storedSalt) =>
            CreatePasswordHash(password, storedSalt).Equals(storedHash, StringComparison.InvariantCulture);

        public static string CreateSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var generator = RandomNumberGenerator.Create())
            {
                generator.GetBytes(randomBytes);
                return Convert.ToBase64String(randomBytes);
            }
        }

        public static string SaltToString(byte[] salt) => Convert.ToBase64String(salt);

        public static byte[] SaltToBytes(string salt) => Encoding.UTF8.GetBytes(salt);
    }
}
