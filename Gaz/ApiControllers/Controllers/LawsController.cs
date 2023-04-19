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
    public class LawsController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public LawsController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetLaws))]
        public async Task<ActionResult<IEnumerable<Law>>> GetLaws()
		{
			try
			{
				return await _context.Laws.ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetLaw/{id}")]
        public async Task<ActionResult<Law>> GetLaw(int id)
		{
            try
            {
                var law = await _context.Laws.FindAsync(id);
                if (law == null)
                {
                    return NotFound();
                }
                return law;
            }
            catch (Exception ex)
            {
                throw;
            }

		}

		[Authorize]
		[HttpPost(nameof(PostLaw))]
		public async Task<ActionResult<Law>> PostLaw(Law law)
		{
			try
			{
                var la = new Law
                {
                    LawName = law.LawName,
                    CreatedAt = DateTime.Today
                };
                _context.Laws.Add(la);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetLaw", new { id = la.Id }, la);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutLaw/{id}")]
        public async Task<IActionResult> PutLaw(int id, Law law)
		{
			try
			{
				if (id != law.Id)
                {
                    return BadRequest();
                }
                var la = await _context.Laws.FindAsync(id);
                la.LawName = law.LawName;
                la.UpdatedAt = DateTime.Today;
                _context.Laws.Update(la);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteLaw/{id}")]
        public async Task<IActionResult> DeleteLaw(int id)
		{
			try
			{
				var law = await _context.Laws.FindAsync(id);
				if (law == null)
				{
					return NotFound();
				}
				_context.Laws.Remove(law);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool LawExists(int id)
        {
            return (_context.Laws?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
