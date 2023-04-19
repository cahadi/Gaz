using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFEstimationsMarkRepository : IEstimationsMarkRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFEstimationsMarkRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<EstimationsMark>>> GetEstimationsMarks()
		{
			return await _context.EstimationsMarks
			.Include("Estimation")
			.Include("Mark").ToListAsync();
		}

		public async Task<ActionResult<EstimationsMark>> GetEstimationsMark(int id)
		{
			var estimationsMark = await _context.EstimationsMarks
					.Include("Estimation")
					.Include("Mark").FirstOrDefaultAsync(em => em.Id == id);
			return estimationsMark;
		}

		public async Task<ActionResult<EstimationsMark>> PostEstimationsMark(EstimationsMark entity)
		{
			var em = new EstimationsMark
			{
				EstimationId = entity.EstimationId,
				Estimation = await _context.Estimations.FindAsync(entity.EstimationId),
				MarkId = entity.MarkId,
				Mark = await _context.Marks.FindAsync(entity.MarkId),
				CreatedAt = DateTime.Today
			};
			_context.EstimationsMarks.Add(em);
			await _context.SaveChangesAsync();
			return em;
		}

		public async Task<ActionResult<EstimationsMark>> PutEstimationsMark(int id, EstimationsMark entity)
		{
			var em = await _context.EstimationsMarks
					.Include("Estimation")
					.Include("Mark").FirstOrDefaultAsync(em => em.Id == id);
			em.EstimationId = entity.EstimationId;
			em.Estimation = await _context.Estimations.FindAsync(entity.EstimationId);
			em.MarkId = entity.MarkId;
			em.Mark = await _context.Marks.FindAsync(entity.MarkId);
			em.UpdatedAt = DateTime.Today;
			_context.EstimationsMarks.Update(em);
			await _context.SaveChangesAsync();
			return em;
		}

		public async void DeleteEstimationsMark(int id)
		{
			var estimationsMark = await _context.EstimationsMarks
				.Include("Estimation")
				.Include("Mark").FirstOrDefaultAsync(em => em.Id == id);
			_context.EstimationsMarks.Remove(estimationsMark);
			await _context.SaveChangesAsync();
		}
	}
}
