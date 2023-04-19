using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFLawRepository : ILawRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFLawRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<Law>>> GetLaws()
		{
			return await _context.Laws.ToListAsync();
		}

		public async Task<ActionResult<Law>> GetLaw(int id)
		{
			var law = await _context.Laws.FindAsync(id);
			return law;
		}

		public async Task<ActionResult<Law>> PostLaw(Law entity)
		{
			var la = new Law
			{
				LawName = entity.LawName,
				CreatedAt = DateTime.Today
			};
			_context.Laws.Add(la);
			await _context.SaveChangesAsync();
			return la;
		}

		public async Task<ActionResult<Law>> PutLaw(int id, Law entity)
		{
			var la = await _context.Laws.FindAsync(id);
			la.LawName = entity.LawName;
			la.UpdatedAt = DateTime.Today;
			_context.Laws.Update(la);
			await _context.SaveChangesAsync();
			return la;
		}

		public async void DeleteLaw(int id)
		{
			var law = await _context.Laws.FindAsync(id);
			_context.Laws.Remove(law);
			await _context.SaveChangesAsync();
		}
	}
}
