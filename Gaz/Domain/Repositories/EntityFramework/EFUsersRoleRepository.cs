using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFUsersRoleRepository : IUsersRoleRepository
	{
		private readonly freedb_testdbgazContext _context;

		public EFUsersRoleRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<UsersRole>>> GetUsersRoles()
		{
			return await _context.UsersRoles
				.Include("User")
				.Include("Role").ToListAsync();
		}

		public async Task<ActionResult<UsersRole>> GetUsersRole(int id)
		{
			var usersRole = await _context.UsersRoles
				.Include("User")
				.Include("Role").FirstOrDefaultAsync(ur => ur.Id == id);
			return usersRole;
		}

		public async Task<ActionResult<UsersRole>> PostUsersRole(UsersRole entity)
		{
			var ur = new UsersRole
			{
				UserId = entity.UserId,
				User = await _context.Users
				.Include("Type")
				.FirstOrDefaultAsync(u => u.Id == entity.UserId),
				RoleId = entity.RoleId,
				Role = await _context.Roles
				.Include("Indicator")
				.Include("Time")
				.FirstOrDefaultAsync(r => r.Id == entity.RoleId),
				CreatedAt = DateTime.Today
			};
			_context.UsersRoles.Add(ur);
			await _context.SaveChangesAsync();
			return ur;
		}

		public async Task<ActionResult<UsersRole>> PutUsersRole(int id, UsersRole entity)
		{
			var ur = await _context.UsersRoles
				.Include("User")
				.Include("Role").FirstOrDefaultAsync(uR => uR.Id == id);
			ur.UserId = entity.UserId;
			ur.User = await _context.Users
				.Include("Type")
				.FirstOrDefaultAsync(u => u.Id == entity.UserId);
			ur.RoleId = entity.RoleId;
			ur.Role = await _context.Roles
				.Include("Indicator")
				.Include("Time").FirstOrDefaultAsync(r => r.Id == entity.RoleId);
			ur.UpdatedAt = DateTime.Today;
			_context.UsersRoles.Update(ur);
			await _context.SaveChangesAsync();
			return ur;
		}

		public async void DeleteUsersRole(int id)
		{
			var usersRole = await _context.UsersRoles
				.Include("User")
				.Include("Role").FirstOrDefaultAsync(uR => uR.Id == id);
			_context.UsersRoles.Remove(usersRole);
			await _context.SaveChangesAsync();
		}
	}
}
