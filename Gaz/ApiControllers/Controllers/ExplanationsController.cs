using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;
using Gaz.Data;
using Gaz.Domain.Entities;

namespace SerGaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExplanationsController : BaseController
    {
        private readonly freedb_testdbgazContext _context;

        public ExplanationsController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		List<Explanation> exs;

		[Authorize]
		[HttpGet(nameof(GetExplanations))]
        public async Task<List<Explanation>> GetExplanations()
		{
            exs = await _context.Explanations
				.Include("User").ToListAsync();
            return exs;
        }

        [HttpGet(nameof(GetExplanationsByMY))]
        public async Task<List<Explanation>> GetExplanationsByMY(int month, int year)
        {
            return exs.Where(e => e.Month == month &&
                e.Year == year).ToList();
        }


		[HttpGet(nameof(GetExByUser))]
		public async Task<List<Explanation>> GetExByUser(int userId)
		{
			return await _context.Explanations
				.Include("User").Where(z => z.UserId == userId).ToListAsync();
		}

		[Authorize]
		[HttpGet("GetExplanation/{id}")]
        public async Task<ActionResult<Explanation>> GetExplanation(int id)
		{
			try
			{
                var explanation = await _context.Explanations
					.Include("User").FirstOrDefaultAsync(e => e.Id == id);
				if (explanation == null)
                {
                    return NotFound();
                }
                return explanation;
            }
			catch (Exception ex)
			{
				throw;
			}
		}

        [HttpGet("GetExByDetail")]
        public async Task<Explanation> GetExByDetail(int userId, 
			int month, int year)
        {
            try
            {
                var explanation = await _context.Explanations
                    .Include("User").FirstOrDefaultAsync(e => e.UserId == userId 
					&& e.Month == month
					&&e.Year == year);
                return explanation;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [Authorize]
		[HttpPost(nameof(PostExplanation))]
        public async Task<ActionResult<Explanation>> PostExplanation(Explanation explanation)
		{
			try
			{
				DateTime now = DateTime.Now;
                int month = now.Month;
                int year = now.Year;
                var ex = new Explanation
                {
                    Explanation1 = explanation.Explanation1,
                    UserId = explanation.UserId,
                    User = await _context.Users
                    .FirstOrDefaultAsync(u => u.Id == explanation.UserId),
                    Month = month,
                    Year = year,
                    CreatedAt = DateTime.Today
                };
                _context.Explanations.Add(ex);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetExplanation", new { id = ex.Id }, ex);
            }
			catch (Exception ex)
			{
				throw;
			}
		}


		[Authorize]
		[HttpPut("PutExplanation/{id}")]
        public async Task<IActionResult> PutExplanation(int id, Explanation explanation)
		{
			try
			{
                DateTime now = DateTime.Now;
                int month = now.Month;
                int year = now.Year;
                if (id != explanation.Id)
                {
                    return BadRequest();
                }
                var ex = await _context.Explanations
                    .Include("User").FirstOrDefaultAsync(e => e.Id == id);
                ex.Explanation1 = explanation.Explanation1;
                ex.UserId = explanation.UserId;
                ex.User = await _context.Users
					.Include("Onetype").FirstOrDefaultAsync(u => u.Id == explanation.UserId);
                ex.Month = month;
                ex.Year = year;
				ex.UpdatedAt = DateTime.Today;
				await _context.SaveChangesAsync();
			return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        

		[Authorize]
		[HttpDelete("DeleteExplanation/{id}")]
        public async Task<IActionResult> DeleteExplanation(int id)
		{
			try
			{
				var explanation = await _context.Explanations
					.Include("User").FirstOrDefaultAsync(e => e.Id == id);
				if (explanation == null)
				{
					return NotFound();
				}
				_context.Explanations.Remove(explanation);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool ExplanationExists(int id)
        {
            return (_context.Explanations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
