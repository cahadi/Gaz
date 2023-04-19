using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFEditTimesRepository : IEditTimesRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFEditTimesRepository(freedb_testdbgazContext context) =>
			_context = context;

		public async Task<ActionResult<IEnumerable<EditTime>>> GetEditTimes()
		{
			return await _context.EditTimes.ToListAsync();
		}

		public async Task<ActionResult<EditTime>> GetEditTime(int id)
		{
			var editTime = await _context.EditTimes.FindAsync(id);
			return editTime;
		}

		public async Task<ActionResult<EditTime>> PostEditTime(EditTime entity)
		{
			var time = new EditTime
			{
				Date = entity.Date,
				CreatedAt = DateTime.Today
			};
			_context.EditTimes.Add(time);
			await _context.SaveChangesAsync();
			return time;
		}

		public async Task<ActionResult<EditTime>> PutEditTime(int id, EditTime entiy)
		{
			var time = await _context.EditTimes.FindAsync(id);
			time.Date = entiy.Date;
			time.UpdatedAt = DateTime.Today;
			_context.EditTimes.Update(time);
			await _context.SaveChangesAsync();
			return time;
		}

		public async void DeleteEditTime(int id)
		{
			var editTime = await _context.EditTimes.FindAsync(id);
			_context.EditTimes.Remove(editTime);
			await _context.SaveChangesAsync();
		}
	}
}
