using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFPollRepository : IPollRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFPollRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<Poll>>> GetPolls()
		{
			return await _context.Polls
			.Include("EstimationsMarks")
			.Include("User").ToListAsync();
		}

		public async Task<ActionResult<Poll>> GetPoll(int id)
		{
			var poll = await _context.Polls
				.Include("EstimationsMarks")
				.Include("User").FirstOrDefaultAsync(p => p.Id == id);
			return poll;
		}

		public async Task<ActionResult<Poll>> PostPoll(Poll entity)
		{

			DateTime now = DateTime.Now;
			int month = now.Month;
			int year = now.Year;
			var po = new Poll
			{
				UserId = entity.UserId,
				User = await _context.Users
				.Include("Onetype").FirstOrDefaultAsync(u => u.Id == entity.UserId),
				EstimationsMarksId = entity.EstimationsMarksId,
				EstimationsMarks = await _context.EstimationsMarks
				.Include("Estimation")
				.Include("Mark")
				.FirstOrDefaultAsync(em => em.Id == entity.EstimationsMarksId),
				Month = month,
				Year = year,
				CreatedAt = DateTime.Today
			};
			_context.Polls.Add(po);
			await _context.SaveChangesAsync();
			return po;
		}

		public async Task<ActionResult<Poll>> PutPoll(int id, Poll entity)
		{
			var po = await _context.Polls
				.Include("EstimationsMarks")
				.Include("User").FirstOrDefaultAsync(p => p.Id == id);
			po.UserId = entity.UserId;
			po.User = await _context.Users
				.Include("Onetype").FirstOrDefaultAsync(u => u.Id == entity.UserId);
			po.EstimationsMarksId = entity.EstimationsMarksId;
			po.EstimationsMarks = await _context.EstimationsMarks
				.Include("Estimation")
				.Include("Mark")
				.FirstOrDefaultAsync(em => em.Id == entity.EstimationsMarksId);
			po.UpdatedAt = DateTime.Today;
			_context.Polls.Update(po);
			await _context.SaveChangesAsync();
			return po;
		}

		public async void DeletePoll(int id)
		{
			var poll = await _context.Polls
					.Include("EstimationsMarks")
					.Include("User").FirstOrDefaultAsync(p => p.Id == id);
			_context.Polls.Remove(poll);
			await _context.SaveChangesAsync();
		}
	}
}
