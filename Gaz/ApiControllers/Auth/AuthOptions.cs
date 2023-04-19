using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SerGaz.ApiControllers.Auth
{
	public class AuthOptions
	{
		public const string? Issuer = "https://localhost:7099";
		public const string? Key = "Jbgfrewbjk389ufso329irkjs";
		public const string? Audience = "AuthClient";
		
		public static SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
		}
	}
}
