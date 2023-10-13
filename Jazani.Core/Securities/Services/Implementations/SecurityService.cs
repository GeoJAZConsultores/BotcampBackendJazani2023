using Microsoft.AspNetCore.Identity;

namespace Jazani.Core.Securities.Services.Implementations
{
    public class SecurityService : ISecurityService
    {
        public string HashPassword(string userName, string hashedPassword)
        {
            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

            return passwordHasher.HashPassword(userName, hashedPassword);
        }

        public bool VerifyHashedPassword(string userName, string hashedPassword, string providedPassword)
        {

            PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(userName, hashedPassword, providedPassword);

            if (result == PasswordVerificationResult.Success) return true;

            return false;
        }
    }
}

