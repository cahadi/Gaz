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
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SerGaz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersRolesController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public UsersRolesController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetUsersRoles))]
        public async Task<ActionResult<IEnumerable<UsersRole>>> GetUsersRoles()
		{
			try
			{
                return await _context.UsersRoles
                    .Include("User")
                    .Include("Role").ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        [HttpGet]
        public async Task<List<UsersRole>> GetRolesByUser(int id)
        {
            try
            {
                return await _context.UsersRoles
                    .Include("Role")
                    .Include("User")
                    .Where(z => z.UserId == id).ToListAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

		[Authorize]
		[HttpGet("GetUsersRole/{id}")]
        public async Task<ActionResult<UsersRole>> GetUsersRole(int id)
		{
			try
			{
                var usersRole = await _context.UsersRoles
                    .Include("User")
                    .Include("Role").FirstOrDefaultAsync(ur=>ur.Id==id);
                if (usersRole == null)
                {
                    return NotFound();
                }
                return usersRole;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        [HttpGet]
        public async Task<UsersRole> GetUR(int userId, int roleId)
        {
            try
            {
                var ur = await _context.UsersRoles
                    .Include("Role")
                    .Include("User")
                    .FirstOrDefaultAsync(z => z.UserId == userId && z.RoleId == roleId);
                return ur;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

		[Authorize]
		[HttpPost(nameof(PostUsersRole))]
		public async Task<ActionResult<UsersRole>> PostUsersRole(UsersRole usersRole)
		{
			try
			{
                var ur = new UsersRole
                {
                    UserId = usersRole.UserId,
                    User = await _context.Users
                    .Include("Type")
                    .FirstOrDefaultAsync(u=>u.Id==usersRole.UserId),
                    RoleId = usersRole.RoleId,
                    Role = await _context.Roles
                    .Include("Indicator")
                    .Include("Time")
                    .FirstOrDefaultAsync(r=>r.Id==usersRole.RoleId),
                    CreatedAt = DateTime.Today
                };
                _context.UsersRoles.Add(ur);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsersRole", new { id = ur.Id }, ur); 
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutUsersRole/{id}")]
        public async Task<IActionResult> PutUsersRole(int id, UsersRole usersRole)
		{
            try
            {
                if (id != usersRole.Id)
                {
                    return BadRequest();
                }
                var ur = await _context.UsersRoles
                    .Include("User")
                    .Include("Role").FirstOrDefaultAsync(uR=>uR.Id==id);
                ur.UserId = usersRole.UserId;
                ur.User = await _context.Users
                    .Include("Type")
                    .FirstOrDefaultAsync(u=>u.Id==usersRole.UserId);
                ur.RoleId = usersRole.RoleId;
                ur.Role = await _context.Roles
                    .Include("Indicator")
                    .Include("Time").FirstOrDefaultAsync(r=>r.Id==usersRole.RoleId);
                ur.UpdatedAt = DateTime.Today;
                _context.UsersRoles.Update(ur);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

		[Authorize]
		[HttpDelete("DeleteUsersRole/{id}")]
        public async Task<IActionResult> DeleteUsersRole(int id)
		{
			try
			{
                var usersRole = await _context.UsersRoles
                    .Include("User")
                    .Include("Role").FirstOrDefaultAsync(uR => uR.Id == id);
                if (usersRole == null)
                {
                    return NotFound();
                }
                _context.UsersRoles.Remove(usersRole);
                await _context.SaveChangesAsync();
                return NoContent();
            }
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool UsersRoleExists(int id)
        {
            return (_context.UsersRoles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
