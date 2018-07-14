using System;
using System.Security.Cryptography;
using System.Text;

namespace RegistrationApi.Crypto
{
    /// <summary>
    /// Encoding class
    /// </summary>
    public static class Crypto
    {
        // encoding function
        public static string Hash(string value)
        {
            return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(value)));
        }
    }
}
