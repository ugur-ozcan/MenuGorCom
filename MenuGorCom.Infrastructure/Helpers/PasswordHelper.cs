// File: MenuGorCom.Infrastructure/Helpers/PasswordHelper.cs
using Microsoft.AspNetCore.Identity;

namespace MenuGorCom.Infrastructure.Helpers
{
    public static class PasswordHelper
    {
        private static readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

        // Şifre Hashleme
        public static string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        // Şifre Doğrulama
        public static bool VerifyPassword(string hashedPassword, string plainPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, plainPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
