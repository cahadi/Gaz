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
    public class EditTimesController : BaseController
    {
        private readonly freedb_testdbgazContext _context;

        public EditTimesController(freedb_testdbgazContext context)
        {
            _context = context;
        }

        [Authorize]
		[HttpGet(nameof(GetEditTimes))]
        public async Task<ActionResult<IEnumerable<EditTime>>> GetEditTimes()
		{
			try
			{
				return await _context.EditTimes.ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetEditTime/{id}")]
        public async Task<ActionResult<EditTime>> GetEditTime(int id)
		{
            try
            {
                var editTime = await _context.EditTimes.FindAsync(id);
                if (editTime == null)
				{
					return NotFound();
				}
				return editTime;
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostEditTime))]
		public async Task<ActionResult<EditTime>> PostEditTime(EditTime editTime)
		{
			try
			{
				var time = new EditTime
				{
					Date = editTime.Date,
					CreatedAt = DateTime.Today
				};
				_context.EditTimes.Add(time);
				await _context.SaveChangesAsync();
				return CreatedAtAction("GetEditTime", new { id = time.Id }, time);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutEditTime/{id}")]
        public async Task<IActionResult> PutEditTime(int id, EditTime editTime)
		{
            try
            {
                if (id != editTime.Id)
				{
					return BadRequest();
                }
                var time = await _context.EditTimes.FindAsync(id);
                time.Date = editTime.Date;
                time.UpdatedAt = DateTime.Today;
				_context.EditTimes.Update(time);
				await _context.SaveChangesAsync(); 
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}

		}

		[Authorize]
		[HttpDelete("DeleteEditTime/{id}")]
        public async Task<IActionResult> DeleteEditTime(int id)
		{
            try
            {
                var editTime = await _context.EditTimes.FindAsync(id);
                if (editTime == null)
				{
					return NotFound();
                }

                _context.EditTimes.Remove(editTime);
                await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool EditTimeExists(int id)
        {
            return (_context.EditTimes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
