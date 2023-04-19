using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IExplanationRepository
	{
		Task<ActionResult<IEnumerable<Explanation>>> GetExplanations();
		Task<ActionResult<Explanation>> GetExplanation(int id);
		Task<ActionResult<Explanation>> PostExplanation(Explanation entity);
		Task<ActionResult<Explanation>> PutExplanation(int id, Explanation entity);
		void DeleteExplanation(int id);
	}
}
