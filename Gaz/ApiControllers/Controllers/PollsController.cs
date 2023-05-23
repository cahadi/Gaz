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
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Drawing;

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

		List<Poll> polls;

		[HttpGet(nameof(GetPolls))]
        public async Task<List<Poll>> GetPolls()
		{
			polls = await _context.Polls
				.Include("EstimationsMarks")
				.Include("User")
				.Include("EstimationsMarks.Mark")
				.Include("EstimationsMarks.Estimation")
				.ToListAsync();
			return polls;
        }

        [HttpGet(nameof(GetPollsByMY))]
		public async Task<List<Poll>> GetPollsByMY(int month, int year)
		{
			return polls.Where(p => p.Month == month &&
                p.Year == year).ToList();
        }
		[HttpGet(nameof(GetPollsByUser))]
		public async Task<List<Poll>> GetPollsByUser(int userId)
        {
            return await _context.Polls
            .Include("EstimationsMarks")
            .Include("User").Where(z=>z.UserId == userId)
			.ToListAsync();
        }

		List<Poll> pollsList;

		[HttpGet(nameof(GetPollsByDetail))]
		public async Task<List<Poll>> GetPollsByDetail(int userId, int month, 
			int year)
		{
			var polls = await _context.Polls
				.Include("User")
				.Include("EstimationsMarks")
				.Include("EstimationsMarks.Mark")
				.Include("EstimationsMarks.Estimation")
				.Where(z => z.UserId == userId && z.Month == month && z.Year == year)
				.ToListAsync();
			pollsList = polls;
			return pollsList;
		}
		[HttpGet(nameof(GetPollByUY))]
		public async Task<List<Poll>> GetPollByUY(int userId, int year)
        {
            var polls = await _context.Polls
                .Include("User")
                .Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark")
				.Include("EstimationsMarks.Estimation")
                .Where(z => z.UserId == userId && z.Year == year)
                .ToListAsync();
            pollsList = polls;
            return pollsList;
        }
		List<Poll> pollsExcel1;
        List<Poll> pollsExcel2;
        List<Poll> pollsExcel3;
        List<Poll> pollsExcel4;

        [HttpGet(nameof(GetPollsForExcel1))]
		public async Task<List<Poll>> GetPollsForExcel1(int year)
		{
            pollsExcel1 = polls.Where(z => z.Year == year &&
				z.Month >= 1 && z.Month <= 3).ToList();
			return pollsExcel1;
        }

        [HttpGet(nameof(GetPollsForExcel2))]
        public async Task<List<Poll>> GetPollsForExcel2(int year)
        {
            pollsExcel2 = polls.Where(z => z.Year == year &&
                z.Month >= 4 && z.Month <= 6).ToList();
            return pollsExcel2;
        }

        [HttpGet(nameof(GetPollsForExcel3))]
        public async Task<List<Poll>> GetPollsForExcel3(int year)
        {
            pollsExcel3 = polls.Where(z => z.Year == year &&
                z.Month >= 7 && z.Month <= 9).ToList();
            return pollsExcel3;
        }

        [HttpGet(nameof(GetPollsForExcel4))]
        public async Task<List<Poll>> GetPollsForExcel4(int year)
        {
            pollsExcel4 = polls.Where(z => z.Year == year &&
                z.Month >= 10 && z.Month <= 12).ToList();
            return pollsExcel4;
        }

		List<Poll> pollsL;

		[HttpGet(nameof(GetPollForExcel))]
		public async Task<List<Poll>> GetPollForExcel(int quarter, int userId, int estiId)
		{
			var polls = new List<Poll>();
			if (quarter == 1)
			{
				if(pollsExcel1 != null)
					polls = pollsExcel1;
			}
			else if (quarter == 2)
			{
				if(pollsExcel2 != null)
					polls = pollsExcel2;
			}
            else if (quarter == 3)
			{
				if(pollsExcel3 != null)
                polls = pollsExcel3;
			}
            else if (quarter == 4)
			{
				if(pollsExcel4 != null)
					polls = pollsExcel4;
			}

			if(polls != null)
				pollsL = polls.Where(z => z.UserId == userId
					&& z.EstimationsMarks.EstimationId == estiId).ToList();
			return pollsL;
        }

		[HttpGet(nameof(GetPollForExcelFirst))]
		public async Task<Poll> GetPollForExcelFirst(int quarter)
		{
			var poll = new Poll();
			if (quarter == 1)
			{
				if(pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 1);
			}
            if (quarter == 2)
			{
				if(pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 4);
			}
            if (quarter == 3)
			{
				if(pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 7);
			}
            if (quarter == 4)
			{
				if(pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 10);
			}
			return poll;
        }

        [HttpGet(nameof(GetPollForExcelSecond))]
        public async Task<Poll> GetPollForExcelSecond(int quarter)
        {
            var poll = new Poll();
            if (quarter == 1)
			{
				if(pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 2);
			}
            if (quarter == 2)
			{
				if(pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 5);
			}
            if (quarter == 3)
			{
				if(pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 8);
			}
            if (quarter == 4)
			{
				if(pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 11);
			}
            return poll;
        }

        [HttpGet(nameof(GetPollForExcelThird))]
        public async Task<Poll> GetPollForExcelThird(int quarter)
        {
            var poll = new Poll();
            if (quarter == 1)
			{
				if (pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 3);
			}
            if (quarter == 2)
			{
				if (pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 6);
			}
            if (quarter == 3)
			{
				if (pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 9);
			}
            if (quarter == 4)
			{
				if (pollsL != null)
					poll = pollsL.FirstOrDefault(z => z.Month == 12);
			}
            return poll;
        }



        [HttpGet(nameof(GetPollByMoreDetail))]
		public async Task<Poll> GetPollByMoreDetail(int estiId)
		{
			var poll = pollsList
                .FirstOrDefault(p =>  p.EstimationsMarks.EstimationId == estiId);
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
