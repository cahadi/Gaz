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
		List<Score> scores;
		[Authorize]
		[HttpGet(nameof(GetScores))]
        public async Task<ActionResult<IEnumerable<Score>>> GetScores()
		{
			scores = await _context.Scores
				.Include("User").ToListAsync();
			return scores;
		}

		[HttpGet(nameof(GetScoreByMY))]
		public async Task<List<Score>> GetScoreByMY(int month, int year)
        {
            return scores.Where(p => p.Month == month &&
                p.Year == year).ToList();
        }

		[HttpGet(nameof(GetScoresByUser))]
		public async Task<List<Score>> GetScoresByUser(int userId)
        {
            return await _context.Scores
                .Include("User").Where(z=>z.UserId == userId)
				.ToListAsync();
        }

		[HttpGet(nameof(GetScoreByDetail))]
		public async Task<Score> GetScoreByDetail(int userId, int month, int year)
		{
			Score score = await _context.Scores.Include("User")
				.FirstOrDefaultAsync(z => z.UserId == userId
				&& z.Month == month
				&& z.Year == year);
			return score;
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
					.Include("Type").FirstOrDefaultAsync(u=>u.Id==score.UserId),
					MonthScore = score.MonthScore,
					FinalScore = score.FinalScore,
					Month = score.Month,
					Year = score.Year,
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
					.Include("Type").FirstOrDefaultAsync(u=>u.Id==score.UserId);
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
