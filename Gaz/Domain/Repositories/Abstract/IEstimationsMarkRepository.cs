using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IEstimationsMarkRepository
	{
		Task<ActionResult<IEnumerable<EstimationsMark>>> GetEstimationsMarks();
		Task<ActionResult<EstimationsMark>> GetEstimationsMark(int id);
		Task<ActionResult<EstimationsMark>> PostEstimationsMark(EstimationsMark entity);
		Task<ActionResult<EstimationsMark>> PutEstimationsMark(int id, EstimationsMark entity);
		void DeleteEstimationsMark(int id);
	}
}
