using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Wordprocessing;
using Gaz.Data;
using Gaz.Domain.Entities;

namespace SerGaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstimationsController : BaseController
    {
        private readonly freedb_testdbgazContext _context;

        public EstimationsController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetEstimations))]
        public async Task<ActionResult<IEnumerable<Estimation>>> GetEstimations()
        {
            try
            {
                return await _context.Estimations.ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetEstimation/{id}")]
        public async Task<ActionResult<Estimation>> GetEstimation(int id)
		{
            try
            {
                var estimation = await _context.Estimations.FindAsync(id);
                if (estimation == null)
				{
					return NotFound();
                }
                return estimation;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostEstimation))]
		public async Task<ActionResult<Estimation>> PostEstimation(Estimation estimation)
		{
            try
            {
                var esti = new Estimation
                {
                    EstimationName = estimation.EstimationName,
                    CreatedAt = DateTime.Today
                };
                _context.Estimations.Add(esti);
                await _context.SaveChangesAsync();			
                return CreatedAtAction("GetEstimation", new { id = esti.Id }, esti);
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		[Authorize]
		[HttpPut("PutEstimation/{id}")]
        public async Task<IActionResult> PutEstimation(int id, Estimation estimation)
		{
			try
			{
                if (id != estimation.Id)
				{
					return BadRequest();
                }
                var esti = await _context.Estimations.FindAsync(id);
                esti.EstimationName = estimation.EstimationName;
                esti.UpdatedAt = DateTime.Today;
                _context.Update(esti);
                await _context.SaveChangesAsync(); 
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteEstimation/{id}")]
        public async Task<IActionResult> DeleteEstimation(int id)
        {
            try
            {
                var estimation = await _context.Estimations.FindAsync(id);
                if (estimation == null)
				{
					return NotFound();
                }

                _context.Estimations.Remove(estimation);
                await _context.SaveChangesAsync();
                return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool EstimationExists(int id)
        {
            return (_context.Estimations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
