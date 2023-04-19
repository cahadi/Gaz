using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IIndicatorRepository
	{
		Task<ActionResult<IEnumerable<Indicator>>> GetIndicators();
		Task<ActionResult<Indicator>> GetIndicator(int id);
		Task<ActionResult<Indicator>> PostIndicator(Indicator entity);
		Task<ActionResult<Indicator>> PutIndicator(int id, Indicator entity);
		void DeleteIndicator(int id);
	}
}
