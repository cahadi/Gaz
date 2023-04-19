using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFRolesLawRepository : IRolesLawRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFRolesLawRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<RolesLaw>>> GetRolesLaws()
		{
			return await _context.RolesLaws
				.Include("Law")
				.Include("Role").ToListAsync();
		}

		public async Task<ActionResult<RolesLaw>> GetRolesLaw(int id)
		{
			var rolesLaw = await _context.RolesLaws
					.Include("Law")
					.Include("Role").FirstOrDefaultAsync(rl => rl.Id == id);
			return rolesLaw;
		}

		public async Task<ActionResult<RolesLaw>> PostRolesLaw(RolesLaw entity)
		{
			var rl = new RolesLaw
			{
				RoleId = entity.RoleId,
				Role = await _context.Roles
				.Include("Indicator")
				.Include("EditTime").FirstOrDefaultAsync(r => r.Id == entity.RoleId),
				LawId = entity.LawId,
				Law = await _context.Laws.FindAsync(entity.LawId),
				CreatedAt = DateTime.Today
			};
			_context.RolesLaws.Add(rl);
			await _context.SaveChangesAsync();
			return rl;
		}

		public async Task<ActionResult<RolesLaw>> PutRolesLaw(int id, RolesLaw entity)
		{
			var rl = await _context.RolesLaws
				.Include("Law")
				.Include("Role").FirstOrDefaultAsync(rL => rL.Id == id);
			rl.RoleId = entity.RoleId;
			rl.Role = await _context.Roles
				.Include("Indicator")
				.Include("EditTime")
				.FirstOrDefaultAsync(r => r.Id == entity.RoleId);
			rl.LawId = entity.LawId;
			rl.Law = await _context.Laws.FindAsync(entity.LawId);
			rl.UpdatedAt = DateTime.Today;
			_context.RolesLaws.Update(rl);
			await _context.SaveChangesAsync();
			return rl;
		}

		public async void DeleteRolesLaw(int id)
		{
			var rolesLaw = await _context.RolesLaws
					.Include("Law")
					.Include("Role").FirstOrDefaultAsync(rl => rl.Id == id);
			_context.RolesLaws.Remove(rolesLaw);
			await _context.SaveChangesAsync();
		}
	}
}
