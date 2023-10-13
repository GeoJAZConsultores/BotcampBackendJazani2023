using Jazani.Core.Securities.Etities;

namespace Jazani.Core.Securities.Services
{
    public interface ISecurityService
	{
		string HashPassword(string userName, string hashedPassword);
		bool VerifyHashedPassword(string userName, string hashedPassword, string providerPassword);

		SecurityEntity JwtSecurity(string jwtSecrectKey);
    }
}

