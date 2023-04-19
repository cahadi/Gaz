using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFOnetypeRepository : IOnetypeRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFOnetypeRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<Onetype>>> GetOnetypes()
		{
			return await _context.Onetypes.ToListAsync();
		}

		public async Task<ActionResult<Onetype>> GetOnetype(int id)
		{
			var onetype = await _context.Onetypes.FindAsync(id);
			return onetype;
		}

		public async Task<ActionResult<Onetype>> PostOnetype(Onetype entity)
		{
			var ot = new Onetype
			{
				TypeName = entity.TypeName,
				CreatedAt = DateTime.Today
			};
			_context.Onetypes.Add(ot);
			await _context.SaveChangesAsync();
			return ot;
		}

		public async Task<ActionResult<Onetype>> PutOnetype(int id, Onetype entity)
		{
			var ot = await _context.Onetypes.FindAsync(id);
			ot.TypeName = entity.TypeName;
			ot.UpdatedAt = DateTime.Today;
			_context.Onetypes.Update(ot);
			await _context.SaveChangesAsync();
			return ot;
		}

		public async void DeleteOnetype(int id)
		{
			var onetype = await _context.Onetypes.FindAsync(id);
			_context.Onetypes.Remove(onetype);
			await _context.SaveChangesAsync();
		}
	}
}
