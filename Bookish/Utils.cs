using System.Security.Cryptography;
using System.Text;

namespace Bookish
{
    public static class Utils
    {
        public static string ComputeSha256(string plaintext)
        {
            using var sha256Hash = SHA256.Create();
            // ComputeHash - returns byte array  
            var bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plaintext));

            // Convert byte array to a string   
            var builder = new StringBuilder();
            foreach(var t in bytes) builder.Append(t.ToString("x2"));
            return builder.ToString();
        }
    }
}