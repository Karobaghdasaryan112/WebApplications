using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace S.P.WithCleanArchitecture.Infrastructure.Utils.PasswordHelper
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create()) 
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password); 
                byte[] hashBytes = sha256.ComputeHash(passwordBytes); 
                return Convert.ToBase64String(hashBytes);
            }
        }
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword); 
            return enteredHash == storedHash; 
        }
    }
}
