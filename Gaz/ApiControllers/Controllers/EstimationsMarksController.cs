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
    public class EstimationsMarksController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public EstimationsMarksController(freedb_testdbgazContext context)
        {
            _context = context;
        }

        List<EstimationsMark> estiMarks;

        [Authorize]
		[HttpGet(nameof(GetEstimationsMarks))]
        public async Task<List<EstimationsMark>> GetEstimationsMarks()
		{
			estiMarks = await _context.EstimationsMarks
				.Include("Estimation")
				.Include("Mark").ToListAsync();
			return estiMarks;

        }
        [Authorize]
        [HttpGet(nameof(GetListForTable))]
        public List<EstimationsMark> GetListForTable(int id)
        {
			var em = estiMarks.Where(e => e.EstimationId == id).ToList();
            return em;
        }

        [Authorize]
		[HttpGet("GetEstimationsMark/{id}")]
        public async Task<ActionResult<EstimationsMark>> GetEstimationsMark(int id)
		{
			try
			{
				var estimationsMark = await _context.EstimationsMarks
					.Include("Estimation")
					.Include("Mark").FirstOrDefaultAsync(em=>em.Id == id);
				if (estimationsMark == null)
				{
					return NotFound();
				}
				return estimationsMark;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostEstimationsMark))]
        public async Task<ActionResult<EstimationsMark>> PostEstimationsMark(EstimationsMark estimationsMark)
        {
			try
			{
				var em = new EstimationsMark
				{
					EstimationId = estimationsMark.EstimationId,
					Estimation = await _context.Estimations.FindAsync(estimationsMark.EstimationId),
					MarkId = estimationsMark.MarkId,
					Mark = await _context.Marks.FindAsync(estimationsMark.MarkId),
					CreatedAt = DateTime.Today
				};
				_context.EstimationsMarks.Add(em);
				await _context.SaveChangesAsync(); 
				return CreatedAtAction("GetEstimationsMark", new { id = em.Id }, em);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutEstimationsMark/{id}")]
		public async Task<IActionResult> PutEstimationsMark(int id, EstimationsMark estimationsMark)
		{
			try
			{
				if (id != estimationsMark.Id)
				{
					return BadRequest();
				}
				var em = await _context.EstimationsMarks
					.Include("Estimation")
					.Include("Mark").FirstOrDefaultAsync(em => em.Id == id);
				em.EstimationId = estimationsMark.EstimationId;
				em.Estimation = await _context.Estimations.FindAsync(estimationsMark.EstimationId);
				em.MarkId = estimationsMark.MarkId;
				em.Mark = await _context.Marks.FindAsync(estimationsMark.MarkId);
				em.UpdatedAt = DateTime.Today;
				_context.EstimationsMarks.Update(em);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteEstimationsMark/{id}")]
        public async Task<IActionResult> DeleteEstimationsMark(int id)
		{
			try
			{
				var estimationsMark = await _context.EstimationsMarks
				.Include("Estimation")
				.Include("Mark").FirstOrDefaultAsync(em => em.Id == id);
				if (estimationsMark == null)
				{
					return NotFound();
				}

				_context.EstimationsMarks.Remove(estimationsMark);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool EstimationsMarkExists(int id)
        {
            return (_context.EstimationsMarks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
