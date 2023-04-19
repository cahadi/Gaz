using SerGaz.Controllers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using DocumentFormat.OpenXml.Office2010.Excel;
using Gaz.Data;
using Gaz.Models;
using Gaz.Domain.Entities;
using SerGaz.ApiControllers.Auth;

namespace Gaz.ApiControllers.Auth.Controllers
{
    [ApiController]
    public class AuthenticateController : BaseController
    {
        private readonly freedb_testdbgazContext _dbContext;
        public AuthenticateController
            (freedb_testdbgazContext dbContext) =>
            _dbContext = dbContext;

        private string GenerateJSONWebToken(LoginModel user)
        {
            var identity = GetIdentity(user.Email, user.Password);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOptions.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            var token = new JwtSecurityToken(
                    issuer: AuthOptions.Issuer,
                    audience: AuthOptions.Audience,
                    expires: DateTime.Now.AddMinutes(120),
                    claims: identity.Claims,
                    signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost(nameof(Login)), AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            IActionResult response = Unauthorized();
            if (login != null)
            {
                var tokenString = GenerateJSONWebToken(login);
                response = Ok(tokenString);
            }
            return response;
        }

        [HttpGet(nameof(Get)), Authorize]
        public async Task<IEnumerable<string>> Get()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            return new string[] { accessToken };
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

            User user = _dbContext.Users.FirstOrDefault(x => x.Email == email && x.Password == pass);
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

        private bool UserExists(int id)
        {
            return _dbContext.Users.Any(e => e.Id == id);
        }
    }
}
