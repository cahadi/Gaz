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
    public class UsersController : ControllerBase
    {
        private readonly freedb_testdbgazContext _context;

        public UsersController(freedb_testdbgazContext context)
        {
            _context = context;
        }

		[Authorize]
		[HttpGet(nameof(GetUsers))]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
		{
			try
			{
				return await _context.Users
					.Include("Type").ToListAsync();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpGet("GetUser/{id}")]
        public async Task<User> GetUser(int id)
		{
			try
			{
                var user = await _context.Users
                    .Include("Type").FirstOrDefaultAsync(u=>u.Id==id);
                return user;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[HttpGet("GetUserEmail/{email}")]
		public async Task<User> GetUserEmail(string email)
		{
			try
			{
				var user = await _context.Users
					.Include("Type").FirstOrDefaultAsync(u => u.Email == email);
				return user;
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpPut("PutUser/{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
		{
			try
			{
                var us = await _context.Users
                    .Include("Type").FirstOrDefaultAsync(u=>u.Id==id);
                us.Fio = user.Fio;
                us.ServiceNumber = user.ServiceNumber;
                us.Division = user.Division;
                us.Position = user.Position;
                us.TypeId = user.TypeId;
                us.Type = await _context.Onetypes.FindAsync(user.TypeId);
                us.Email = user.Email;
                us.UpdatedAt = DateTime.Today;
                _context.Users.Update(us);
                await _context.SaveChangesAsync();
                return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

		[Authorize]
		[HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
		{
			try
			{
				var user = await _context.Users
					.Include("Type").FirstOrDefaultAsync(u=>u.Id==id);
				if (user == null)
				{
					return NotFound();
				}
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
				return NoContent();
			}
			catch (Exception ex)
			{
				throw;
			}
		}

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
