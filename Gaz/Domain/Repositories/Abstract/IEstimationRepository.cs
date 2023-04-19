using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IEstimationRepository
	{
		Task<ActionResult<IEnumerable<Estimation>>> GetEstimations();
		Task<ActionResult<Estimation>> GetEstimation(int id);
		Task<ActionResult<Estimation>> PostEstimation(Estimation entity);
		Task<ActionResult<Estimation>> PutEstimation(int id, Estimation entity);
		void DeleteEstimation(int id);
	}
}
