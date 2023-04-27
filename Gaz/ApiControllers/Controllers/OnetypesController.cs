using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using Gaz.Data;
using Gaz.Domain.Entities;

namespace SerGaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnetypesController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public OnetypesController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetOnetypes))]
        public async Task<List<Onetype>> GetOnetypes()
		{
			try
			{
                return await _context.Onetypes.ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetOnetype/{id}")]
        public async Task<Onetype> GetOnetype(int? id)
		{
			try
			{
                var onetype = await _context.Onetypes.FindAsync(id);
                return onetype;
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostOnetype))]
		public async Task<ActionResult<Onetype>> PostOnetype(Onetype onetype)
		{
			try
			{
				var ot = new Onetype
                {
                    TypeName = onetype.TypeName,
                    CreatedAt = DateTime.Today
                };
                _context.Onetypes.Add(ot);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetOnetype", new { id = ot.Id }, ot);
            }
            catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutOnetype/{id}")]
        public async Task<IActionResult> PutOnetype(int id, Onetype onetype)
		{
			try
			{
				if (id != onetype.Id)
				{
					return BadRequest();
				}
				var ot = await _context.Onetypes.FindAsync(id);
				ot.TypeName = onetype.TypeName;
				ot.UpdatedAt = DateTime.Today;
				_context.Onetypes.Update(ot);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteOnetype/{id}")]
        public async Task<IActionResult> DeleteOnetype(int id)
		{
			try
			{
				var onetype = await _context.Onetypes.FindAsync(id);
				if (onetype == null)
				{
					return NotFound();
				}
				_context.Onetypes.Remove(onetype);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool OnetypeExists(int id)
        {
            return (_context.Onetypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
