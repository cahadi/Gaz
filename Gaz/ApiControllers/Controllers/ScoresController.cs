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
    public class ScoresController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public ScoresController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetScores))]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
		{
			try
			{
                return await _context.Scores
                    .Include("User").ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetScore/{id}")]
        public async Task<ActionResult<Score>> GetScore(int id)
		{
			try
			{
				var score = await _context.Scores
			.Include("User").FirstOrDefaultAsync(sc=>sc.Id == id);
            if (score == null)
            {
				return NotFound();
            }
			return score;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostScore))]
		public async Task<ActionResult<Score>> PostScore(Score score)
		{
			try
			{
				var sc = new Score
				{
					UserId = score.UserId,
					User = await _context.Users
					.Include("Onetype").FirstOrDefaultAsync(u=>u.Id==score.UserId),
					MonthScore = score.MonthScore,
					FinalScore = score.FinalScore,
					CreatedAt = DateTime.Today
				};
				_context.Scores.Add(sc); 
				await _context.SaveChangesAsync();
				return CreatedAtAction("GetScore", new { id = sc.Id }, sc);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutScore/{id}")]
        public async Task<IActionResult> PutScore(int id, Score score)
		{
			try
			{
				if (id != score.Id)
				{
					return BadRequest();
				}
				var sc = await _context.Scores
					.Include("User").FirstOrDefaultAsync(s=>s.Id==id);
				sc.UserId = score.UserId;
				sc.User = await _context.Users
					.Include("Oneytype").FirstOrDefaultAsync(u=>u.Id==score.UserId);
				sc.MonthScore = score.MonthScore;
				sc.FinalScore = score.FinalScore;
				sc.UpdatedAt = DateTime.Today;
				_context.Scores.Update(sc);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteScore/{id}")]
        public async Task<IActionResult> DeleteScore(int id)
		{
			try
			{
				var score = await _context.Scores
					.Include("User").FirstOrDefaultAsync(s=>s.Id==id);
				if (score == null)
				{
					return NotFound();
				}
				_context.Scores.Remove(score);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool ScoreExists(int id)
        {
            return (_context.Scores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
