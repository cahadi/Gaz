using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFExplanationRepository : IExplanationRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFExplanationRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<Explanation>>> GetExplanations()
		{
			return await _context.Explanations
				.Include("User").ToListAsync();
		}

		public async Task<ActionResult<Explanation>> GetExplanation(int id)
		{
			var explanation = await _context.Explanations
					.Include("User").FirstOrDefaultAsync(e => e.Id == id);
			return explanation;
		}

		public async Task<ActionResult<Explanation>> PostExplanation(Explanation entity)
		{
			DateTime now = DateTime.Now;
			int month = now.Month;
			int year = now.Year;
			var ex = new Explanation
			{
				Explanation1 = entity.Explanation1,
				UserId = entity.UserId,
				User = await _context.Users
				.Include("Onetype").FirstOrDefaultAsync(u => u.Id == entity.UserId),
				Month = month,
				Year = year,
				CreatedAt = DateTime.Today
			};
			_context.Explanations.Add(entity);
			await _context.SaveChangesAsync();
			return ex;
		}

		public async Task<ActionResult<Explanation>> PutExplanation(int id, Explanation entity)
		{
			DateTime now = DateTime.Now;
			int month = now.Month;
			int year = now.Year;
			var ex = await _context.Explanations
				.Include("User").FirstOrDefaultAsync(e => e.Id == id);
			ex.Explanation1 = entity.Explanation1;
			ex.UserId = entity.UserId;
			ex.User = await _context.Users
				.Include("Onetype").FirstOrDefaultAsync(u => u.Id == entity.UserId);
			ex.Month = month;
			ex.Year = year;
			ex.UpdatedAt = DateTime.Today;
			await _context.SaveChangesAsync();
			return ex;
		}

		public async void DeleteExplanation(int id)
		{
			var explanation = await _context.Explanations
				.Include("User").FirstOrDefaultAsync(e => e.Id == id);
			_context.Explanations.Remove(explanation);
			await _context.SaveChangesAsync();
		}
	}
}
