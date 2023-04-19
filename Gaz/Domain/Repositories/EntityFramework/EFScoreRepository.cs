using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Formats.Asn1.AsnWriter;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFScoreRepository : IScoreRepository
	{
		private readonly freedb_testdbgazContext _context;

		public EFScoreRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<Score>>> GetScores()
		{
			return await _context.Scores
				.Include("User").ToListAsync();
		}

		public async Task<ActionResult<Score>> GetScore(int id)
		{
			var score = await _context.Scores
				.Include("User").FirstOrDefaultAsync(sc => sc.Id == id);
			return score;
		}

		public async Task<ActionResult<Score>> PostScore(Score entity)
		{
			var sc = new Score
			{
				UserId = entity.UserId,
				User = await _context.Users
				.Include("Onetype").FirstOrDefaultAsync(u => u.Id == entity.UserId),
				MonthScore = entity.MonthScore,
				FinalScore = entity.FinalScore,
				CreatedAt = DateTime.Today
			};
			_context.Scores.Add(sc);
			await _context.SaveChangesAsync();
			return sc;
		}

		public async Task<ActionResult<Score>> PutScore(int id, Score entity)
		{
			var sc = await _context.Scores
					.Include("User").FirstOrDefaultAsync(s => s.Id == id);
			sc.UserId = entity.UserId;
			sc.User = await _context.Users
				.Include("Oneytype").FirstOrDefaultAsync(u => u.Id == entity.UserId);
			sc.MonthScore = entity.MonthScore;
			sc.FinalScore = entity.FinalScore;
			sc.UpdatedAt = DateTime.Today;
			_context.Scores.Update(sc);
			await _context.SaveChangesAsync();
			return sc;
		}

		public async void DeleteScore(int id)
		{
			var score = await _context.Scores
					.Include("User").FirstOrDefaultAsync(s => s.Id == id);
			_context.Scores.Remove(score);
			await _context.SaveChangesAsync();
		}
	}
}
