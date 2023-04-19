using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Domain.Repositories.EntityFramework
{
    public class EFIndicatorRepository : IIndicatorRepository
	{
		private readonly freedb_testdbgazContext _context;
		public EFIndicatorRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<IEnumerable<Indicator>>> GetIndicators()
		{
			return await _context.Indicators.ToListAsync();
		}

		public async Task<ActionResult<Indicator>> GetIndicator(int id)
		{
			var indicator = await _context.Indicators.FindAsync(id);
			return indicator;
		}

		public async Task<ActionResult<Indicator>> PostIndicator(Indicator entity)
		{
			var indic = new Indicator
			{
				IndicatorName = entity.IndicatorName,
				CreatedAt = DateTime.Today
			};
			_context.Indicators.Add(indic);
			await _context.SaveChangesAsync();
			return indic;
		}

		public async Task<ActionResult<Indicator>> PutIndicator(int id, Indicator entity)
		{
			var indic = await _context.Indicators.FindAsync(id);
			indic.IndicatorName = entity.IndicatorName;
			indic.UpdatedAt = DateTime.Today;
			_context.Indicators.Update(indic);
			await _context.SaveChangesAsync();
			return indic;
		}

		public async void DeleteIndicator(int id)
		{
			var indicator = await _context.Indicators.FindAsync(id);
			_context.Indicators.Remove(indicator);
			await _context.SaveChangesAsync();
		}
	}
}
