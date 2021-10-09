using System;
using System.Security.Cryptography;

namespace ChatApp.Common
{
    public static class SecurityHelper
    {
        public static (string Salt, string Password) GeneratePassword(string password)
        {
            RNGCryptoServiceProvider randomServiceProvider = new RNGCryptoServiceProvider();

            byte[] salt = new byte[8];

            randomServiceProvider.GetBytes(salt);

            Rfc2898DeriveBytes hashAlgorithm = new Rfc2898DeriveBytes(password, salt);

            return (Convert.ToBase64String(salt), Convert.ToBase64String(hashAlgorithm.GetBytes(24)));
        }

        public static bool ConfirmPassword(string hashedPassword, string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            Rfc2898DeriveBytes hashAlgorithm = new Rfc2898DeriveBytes(password, saltBytes, 1000);

            byte[] saltedHashedPassword = hashAlgorithm.GetBytes(24);

            return Convert.ToBase64String(saltedHashedPassword) == hashedPassword;
        }
    }
}
