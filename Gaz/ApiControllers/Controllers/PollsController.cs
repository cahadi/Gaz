using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Gaz.Data;
using Gaz.Domain.Entities;

namespace SerGaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollsController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public PollsController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetPolls))]
        public async Task<ActionResult<IEnumerable<Poll>>> GetPolls()
		{
			try
			{
				return await _context.Polls
				.Include("EstimationsMarks")
				.Include("User").ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet(nameof(GetPollsByUser))]
		public async Task<List<Poll>> GetPollsByUser(int userId)
        {
            return await _context.Polls
            .Include("EstimationsMarks")
            .Include("User").Where(z=>z.UserId == userId)
			.ToListAsync();
        }

		[HttpGet(nameof(GetPollsByDetail))]
		public async Task<List<Poll>> GetPollsByDetail(int userId, int month, int year)
		{
			var polls = await _context.Polls
				.Include("User")
				.Include("EstimationsMarks")
				.Include("EstimationsMarks.Mark")
				.Include("EstimationsMarks.Estimation")
				.Where(z => z.UserId == userId && z.Month == month && z.Year == year)
				.ToListAsync();
			return polls;
		}

		[HttpGet(nameof(GetPollByMoreDetail))]
		public async Task<Poll> GetPollByMoreDetail(int userId, 
			int month, int year, int estiId)
		{
			var poll = await _context.Polls
				.Include("User")
				.Include("EstimationsMarks")
				.Include("EstimationsMarks.Mark")
				.Include("EstimationsMarks.Estimation")
				.FirstOrDefaultAsync(p => p.UserId == userId
				&& p.Month == month && p.Year == year
				&& p.EstimationsMarks.EstimationId == estiId);
			return poll;

        }

		[HttpGet(nameof(GetPollByOtherDetail))]
		public async Task<Poll> GetPollByOtherDetail(int userId,
            int month, int year, int emId)
        {
            var poll = await _context.Polls
                .Include("User")
                .Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark")
                .Include("EstimationsMarks.Estimation")
                .FirstOrDefaultAsync(p => p.UserId == userId
                && p.Month == month && p.Year == year
                && p.EstimationsMarksId == emId);
            return poll;
        }


		[Authorize]
		[HttpGet("GetPoll/{id}")]
        public async Task<ActionResult<Poll>> GetPoll(int id)
		{
			try
			{
				var poll = await _context.Polls
					.Include("EstimationsMarks")
					.Include("User").FirstOrDefaultAsync(p=>p.Id == id);
				if (poll == null)
				{
					return NotFound();
				}
				return poll;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostPoll))]
		public async Task<ActionResult<Poll>> PostPoll(Poll poll)
		{
			DateTime now = DateTime.Now;
			int month = now.Month;
			int year = now.Year;
			var po = new Poll
			{
				UserId = poll.UserId,
				User = await _context.Users
				.FirstOrDefaultAsync(u=>u.Id==poll.UserId),
				EstimationsMarksId = poll.EstimationsMarksId,
				EstimationsMarks = await _context.EstimationsMarks
                .Include("Mark").Include("Estimation")
                .FirstOrDefaultAsync(em=>em.Id==poll.EstimationsMarksId),
				Month = month,
				Year = year,
				CreatedAt = DateTime.Today
			};
			_context.Polls.Add(po);
			await _context.SaveChangesAsync();
			return CreatedAtAction("GetPoll", new { id = po.Id }, po);
		}


		[Authorize]
		[HttpPut("PutPoll/{id}")]
        public async Task<IActionResult> PutPoll(int id, Poll poll)
		{
			try
			{
				if (id != poll.Id)
				{
					return BadRequest();
				}
				var po = await _context.Polls
					.Include("EstimationsMarks")
					.Include("User").FirstOrDefaultAsync(p=>p.Id==id);
				po.UserId = poll.UserId;
				po.User = await _context.Users
					.Include("Onetype").FirstOrDefaultAsync(u => u.Id == poll.UserId);
				po.EstimationsMarksId = poll.EstimationsMarksId;
				po.EstimationsMarks = await _context.EstimationsMarks
					.Include("Estimation")
					.Include("Mark")
					.FirstOrDefaultAsync(em => em.Id == poll.EstimationsMarksId);
				po.UpdatedAt = DateTime.Today;
				_context.Polls.Update(po);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeletePoll/{id}")]
        public async Task<IActionResult> DeletePoll(int id)
		{
			try
			{
				var poll = await _context.Polls
					.Include("EstimationsMarks")
					.Include("User").FirstOrDefaultAsync(p => p.Id == id);
				if (poll == null)
				{
					return NotFound();
				}
				_context.Polls.Remove(poll);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool PollExists(int id)
        {
            return (_context.Polls?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
