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
    public class IndicatorsController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public IndicatorsController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetIndicators))]
        public async Task<ActionResult<IEnumerable<Indicator>>> GetIndicators()
		{
			try
			{
				return await _context.Indicators.ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetIndicator/{id}")]
        public async Task<ActionResult<Indicator>> GetIndicator(int id)
		{
			try
			{
				var indicator = await _context.Indicators.FindAsync(id);
                if (indicator == null)
				{
					return NotFound();
				}
				return indicator;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostIndicator))]
		public async Task<ActionResult<Indicator>> PostIndicator(Indicator indicator)
		{
			try
			{
				var indic = new Indicator
                {
                    IndicatorName = indicator.IndicatorName,
                    CreatedAt = DateTime.Today
                };
                _context.Indicators.Add(indic);
                await _context.SaveChangesAsync(); 
                return CreatedAtAction("GetIndicator", new { id = indic.Id }, indic);
            }
            catch (Exception ex)
            {
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutIndicator/{id}")]
        public async Task<IActionResult> PutIndicator(int id, Indicator indicator)
		{
			try
			{
				if (id != indicator.Id)
				{
					return BadRequest();
				}
				var indic = await _context.Indicators.FindAsync(id);
				indic.IndicatorName = indicator.IndicatorName;
				indic.UpdatedAt = DateTime.Today;
				_context.Indicators.Update(indic);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteIndicator/{id}")]
        public async Task<IActionResult> DeleteIndicator(int id)
		{
			try
			{
				var indicator = await _context.Indicators.FindAsync(id);
            if (indicator == null)
            {
                return NotFound();
            }

            _context.Indicators.Remove(indicator);
            await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool IndicatorExists(int id)
        {
            return (_context.Indicators?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
