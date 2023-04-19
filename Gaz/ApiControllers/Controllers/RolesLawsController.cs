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
    public class RolesLawsController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public RolesLawsController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetRolesLaws))]
        public async Task<ActionResult<IEnumerable<RolesLaw>>> GetRolesLaws()
		{
			try
			{
                return await _context.RolesLaws
                    .Include("Law")
                    .Include("Role").ToListAsync();
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetRolesLaw/{id}")]
        public async Task<ActionResult<RolesLaw>> GetRolesLaw(int id)
		{
			try
			{
                var rolesLaw = await _context.RolesLaws
                    .Include("Law")
                    .Include("Role").FirstOrDefaultAsync(rl=>rl.Id==id);
                if (rolesLaw == null)
                {
                    return NotFound();
                }
                return rolesLaw;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostRolesLaw))]
		public async Task<ActionResult<RolesLaw>> PostRolesLaw(RolesLaw rolesLaw)
		{
			try
			{
                var rl = new RolesLaw
                {
                    RoleId = rolesLaw.RoleId,
                    Role = await _context.Roles
                    .Include("Indicator")
                    .Include("EditTime").FirstOrDefaultAsync(r=>r.Id == rolesLaw.RoleId),
                    LawId = rolesLaw.LawId,
                    Law = await _context.Laws.FindAsync(rolesLaw.LawId),
                    CreatedAt = DateTime.Today
                };
                _context.RolesLaws.Add(rl);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetRolesLaw", new { id = rl.Id }, rl);
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutRolesLaw/{id}")]
        public async Task<IActionResult> PutRolesLaw(int id, RolesLaw rolesLaw)
		{
			try
			{
				if (id != rolesLaw.Id)
                {
                    return BadRequest();
                }
                var rl = await _context.RolesLaws
                    .Include("Law")
                    .Include("Role").FirstOrDefaultAsync(rL=>rL.Id == id);
                rl.RoleId = rolesLaw.RoleId;
                rl.Role = await _context.Roles
                    .Include("Indicator")
                    .Include("EditTime")
                    .FirstOrDefaultAsync(r => r.Id == rolesLaw.RoleId);
                rl.LawId = rolesLaw.LawId;
                rl.Law = await _context.Laws.FindAsync(rolesLaw.LawId);
                rl.UpdatedAt = DateTime.Today;
                _context.RolesLaws.Update(rl);
                await _context.SaveChangesAsync();
                return NoContent();
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteRolesLaw/{id}")]
        public async Task<IActionResult> DeleteRolesLaw(int id)
		{
			try
			{
                var rolesLaw = await _context.RolesLaws
                    .Include("Law")
                    .Include("Role").FirstOrDefaultAsync(rl=>rl.Id == id);
                if (rolesLaw == null)
                {
                    return NotFound();
                }
                _context.RolesLaws.Remove(rolesLaw);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
			{
				throw;
			}
		}

        private bool RolesLawExists(int id)
        {
            return (_context.RolesLaws?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
