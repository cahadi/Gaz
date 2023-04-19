using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFUserRepository : IUserRepository
	{
		private readonly freedb_testdbgazContext _context;

		public EFUserRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			return await _context.Users
				.Include("Type").ToListAsync();
		}

		public async Task<ActionResult<User>> GetUser(int id)
		{
			var user = await _context.Users
				.Include("Type").FirstOrDefaultAsync(u => u.Id == id);
			return user;
		}

		public async Task<ActionResult<User>> GetUserEmail(string email)
		{
			var user = await _context.Users
				.Include("Type").FirstOrDefaultAsync(u => u.Email == email);
			return user;
		}

		public async Task<ActionResult<User>> PutUser(int id, User entity)
		{
			var us = await _context.Users
				.Include("Type").FirstOrDefaultAsync(u => u.Id == id);
			us.Fio = entity.Fio;
			us.ServiceNumber = entity.ServiceNumber;
			us.Division = entity.Division;
			us.Position = entity.Position;
			us.TypeId = entity.TypeId;
			us.Type = await _context.Onetypes.FindAsync(entity.TypeId);
			us.Email = entity.Email;
			us.UpdatedAt = DateTime.Today;
			_context.Users.Update(us);
			await _context.SaveChangesAsync();
			return us;
		}

		public async void DeleteUser(int id)
		{
			var user = await _context.Users
				.Include("Type").FirstOrDefaultAsync(u => u.Id == id);
			_context.Users.Remove(user);
			await _context.SaveChangesAsync();
		}
	}
}
