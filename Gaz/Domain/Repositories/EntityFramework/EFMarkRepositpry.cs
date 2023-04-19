using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFMarkRepositpry : IMarkRepositpry
	{
		private readonly freedb_testdbgazContext _context;
		public EFMarkRepositpry(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<Mark>>> GetMarks()
		{
			return await _context.Marks.ToListAsync();
		}

		public async Task<ActionResult<Mark>> GetMark(int id)
		{
			var mark = await _context.Marks.FindAsync(id);
			return mark;
		}

		public async Task<ActionResult<Mark>> PostMark(Mark entity)
		{
			var ma = new Mark
			{
				YesNo = entity.YesNo,
				LowMark = entity.LowMark,
				BigMark = entity.BigMark,
				CreatedAt = DateTime.Today
			};
			_context.Marks.Add(ma);
			await _context.SaveChangesAsync();
			return ma;
		}

		public async Task<ActionResult<Mark>> PutMark(int id, Mark entity)
		{
			var ma = await _context.Marks.FindAsync(id);
			ma.YesNo = entity.YesNo;
			ma.LowMark = entity.LowMark;
			ma.BigMark = entity.BigMark;
			ma.UpdatedAt = DateTime.Today;
			_context.Marks.Update(ma);
			await _context.SaveChangesAsync();
			return ma;
		}

		public async void DeleteMark(int id)
		{
			var mark = await _context.Marks.FindAsync(id);
			_context.Marks.Remove(mark);
			await _context.SaveChangesAsync();
		}
	}
}
