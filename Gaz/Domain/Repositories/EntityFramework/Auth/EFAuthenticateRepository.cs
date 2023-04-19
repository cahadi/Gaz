using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Gaz.Models;
using NuGet.Protocol.Plugins;
using Gaz.Data;

namespace Gaz.Domain.Repositories.EntityFramework.Auth
{
    public class EFAuthenticateRepository : IAuthenticateRepository
	{
		private readonly freedb_testdbgazContext _context;

		public EFAuthenticateRepository(freedb_testdbgazContext context)
			=> _context = context;

		public string Login(LoginModel entity)
        {
			var tokenString = "";
            if (entity != null)
            {
                tokenString = GenerateJSONWebToken(entity);
            }
            return tokenString;
        }

        public string GenerateJSONWebToken(LoginModel user)
        {
            var identity = GetIdentity(user.Email, user.Password);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Jbgfrewbjk389ufso329irkjs"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    //issuer: AuthOptions.Issuer,
                    audience: "AuthClient",
                    expires: DateTime.Now.AddMinutes(120),
                    claims: identity.Claims,
                    signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

		public static string EncryptPassword(string password)
		{
			byte[] data = Encoding.UTF8.GetBytes(password);
			data = new SHA256Managed().ComputeHash(data);
			return Encoding.ASCII.GetString(data);
		}

		private ClaimsIdentity GetIdentity(string email, string password)
		{
			string pass = EncryptPassword(password);

			User user = _context.Users.FirstOrDefault(x => x.Email == email && x.Password == pass);
			if (user == null)
			{
				return null;
			}
			var claims = new List<Claim>
			{
				new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
			};
			ClaimsIdentity claimsIdentity =
				new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
				ClaimsIdentity.DefaultRoleClaimType);
			return claimsIdentity;
		}
	}
}
