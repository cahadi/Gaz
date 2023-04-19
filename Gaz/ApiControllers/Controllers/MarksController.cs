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
    public class MarksController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public MarksController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetMarks))]
        public async Task<ActionResult<IEnumerable<Mark>>> GetMarks()
		{
			try
			{
                return await _context.Marks.ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetMark/{id}")]
        public async Task<ActionResult<Mark>> GetMark(int id)
		{
			try
			{
				var mark = await _context.Marks.FindAsync(id);
                if (mark == null)
                {
                    return NotFound();
                }
                return mark;
            }
            catch (Exception ex)
            {
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostMark))]
		public async Task<ActionResult<Mark>> PostMark(Mark mark)
		{
			try
			{
                var ma = new Mark
                {
                    YesNo = mark.YesNo,
                    LowMark = mark.LowMark,
                    BigMark = mark.BigMark,
                    CreatedAt = DateTime.Today
                };
                _context.Marks.Add(ma); 
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetMark", new { id = ma.Id }, ma);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutMark/{id}")]
        public async Task<IActionResult> PutMark(int id, Mark mark)
		{
			try
			{
				if (id != mark.Id)
                {
                    return BadRequest();
                }
                var ma = await _context.Marks.FindAsync(id);
                ma.YesNo = mark.YesNo;
                ma.LowMark = mark.LowMark;
                ma.BigMark = mark.BigMark;
                ma.UpdatedAt = DateTime.Today;
                _context.Marks.Update(ma);
                await _context.SaveChangesAsync();
                return NoContent();
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteMark/{id}")]
        public async Task<IActionResult> DeleteMark(int id)
		{
			try
			{
				var mark = await _context.Marks.FindAsync(id);
				if (mark == null)
				{
					return NotFound();
				}
				_context.Marks.Remove(mark);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool MarkExists(int id)
        {
            return (_context.Marks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
