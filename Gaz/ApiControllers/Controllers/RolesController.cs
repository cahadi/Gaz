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
    public class RolesController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public RolesController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetRoles))]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
		{
			try
			{
                return await _context.Roles
                    .Include("Indicator")
                    .Include("Time").ToListAsync();
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetRole/{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
		{
			try
			{
                var role = await _context.Roles
                    .Include("Indicator")
                    .Include("Time").FirstOrDefaultAsync(r=>r.Id==id);
                if (role == null)
                {
                    return NotFound();
                }
                return role;
            }
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPost(nameof(PostRole))]
		public async Task<ActionResult<Role>> PostRole(Role role)
		{
			try
			{
                var ro = new Role
                {
                    RoleName = role.RoleName,
                    TimeId = role.TimeId,
                    Time = await _context.EditTimes.FindAsync(role.TimeId),
                    IndicatorId = role.IndicatorId,
                    Indicator = await _context.Indicators.FindAsync(role.IndicatorId),
                    CreatedAt = DateTime.Today
                };
                _context.Roles.Add(ro); 
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetRole", new { id = ro.Id }, ro);
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutRole/{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
		{
			try
			{
                if (id != role.Id)
                {
                    return BadRequest();
                }
                var ro = await _context.Roles
                    .Include("Indicator")
                    .Include("Time").FirstOrDefaultAsync(r=>r.Id==id);
                ro.RoleName = role.RoleName;
                ro.TimeId = role.TimeId;
                ro.Time = await _context.EditTimes.FindAsync(role.TimeId);
                ro.IndicatorId = role.IndicatorId;
                ro.Indicator = await _context.Indicators.FindAsync(role.IndicatorId);
                ro.UpdatedAt = DateTime.Today;
                _context.Roles.Update(ro);
                await _context.SaveChangesAsync();
                return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
		{
			try
			{
                var role = await _context.Roles
                    .Include("Indicator")
                    .Include("Time").FirstOrDefaultAsync(r=>r.Id==id);
                if (role == null)
                {
                    return NotFound();
                }
                _context.Roles.Remove(role);
                await _context.SaveChangesAsync();
                return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
