using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFEstimationRepository : IEstimationRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFEstimationRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<Estimation>>> GetEstimations()
		{
			return await _context.Estimations.ToListAsync();
		}

		public async Task<ActionResult<Estimation>> GetEstimation(int id)
		{
			var estimation = await _context.Estimations.FindAsync(id);
			return estimation;
		}

		public async Task<ActionResult<Estimation>> PostEstimation(Estimation entity)
		{
			var esti = new Estimation
			{
				EstimationName = entity.EstimationName,
				CreatedAt = DateTime.Today
			};
			_context.Estimations.Add(esti);
			await _context.SaveChangesAsync();
			return esti;
		}

		public async Task<ActionResult<Estimation>> PutEstimation(int id, Estimation entity)
		{
			var esti = await _context.Estimations.FindAsync(id);
			esti.EstimationName = entity.EstimationName;
			esti.UpdatedAt = DateTime.Today;
			_context.Update(esti);
			await _context.SaveChangesAsync();
			return esti;
		}

		public async void DeleteEstimation(int id)
		{
			var estimation = await _context.Estimations.FindAsync(id);
			_context.Estimations.Remove(estimation);
			await _context.SaveChangesAsync();
		}
	}
}
