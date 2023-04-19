using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Data;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFRoleRepository : IRoleRepository
	{
		private readonly freedb_testdbgazContext _context;

		public EFRoleRepository(freedb_testdbgazContext context)=>
			_context = context;

		public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
		{
			return await _context.Roles
				.Include("Indicator")
				.Include("Time").ToListAsync();
		}

		public async Task<ActionResult<Role>> GetRole(int id)
		{
			var role = await _context.Roles
					.Include("Indicator")
					.Include("Time").FirstOrDefaultAsync(r => r.Id == id);
			return role;
		}

		public async Task<ActionResult<Role>> PostRole(Role entity)
		{
			var ro = new Role
			{
				RoleName = entity.RoleName,
				TimeId = entity.TimeId,
				Time = await _context.EditTimes.FindAsync(entity.TimeId),
				IndicatorId = entity.IndicatorId,
				Indicator = await _context.Indicators.FindAsync(entity.IndicatorId),
				CreatedAt = DateTime.Today
			};
			_context.Roles.Add(ro);
			await _context.SaveChangesAsync();
			return ro;
		}

		public async Task<ActionResult<Role>> PutRole(int id, Role entity)
		{
			var ro = await _context.Roles
				.Include("Indicator")
				.Include("Time").FirstOrDefaultAsync(r => r.Id == id);
			ro.RoleName = entity.RoleName;
			ro.TimeId = entity.TimeId;
			ro.Time = await _context.EditTimes.FindAsync(entity.TimeId);
			ro.IndicatorId = entity.IndicatorId;
			ro.Indicator = await _context.Indicators.FindAsync(entity.IndicatorId);
			ro.UpdatedAt = DateTime.Today;
			_context.Roles.Update(ro);
			await _context.SaveChangesAsync();
			return ro;
		}

		public async void DeleteRole(int id)
		{
			var role = await _context.Roles
				.Include("Indicator")
				.Include("Time").FirstOrDefaultAsync(r => r.Id == id);
			_context.Roles.Remove(role);
			await _context.SaveChangesAsync();
		}
	}
}
