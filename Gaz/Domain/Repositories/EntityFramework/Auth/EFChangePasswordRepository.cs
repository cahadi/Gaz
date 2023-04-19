using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Gaz.Domain.Repositories.EntityFramework.Auth
{
    public class EFChangePasswordRepository : IChangePasswordRepository
	{
		private readonly freedb_testdbgazContext _context;

		public EFChangePasswordRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<User>> Change(string oldpass, string newpass)
		{
			oldpass = EncryptPassword(oldpass);
			newpass = EncryptPassword(newpass);
			User user = await _context.Users.FirstOrDefaultAsync(u => u.Password == oldpass);
			user.Password = newpass;
			user.UpdatedAt = DateTime.Today;
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
			return user;
		}

		public static string EncryptPassword(string password)
		{
			byte[] data = Encoding.UTF8.GetBytes(password);
			data = new SHA256Managed().ComputeHash(data);
			return Encoding.ASCII.GetString(data);
		}
	}
}
