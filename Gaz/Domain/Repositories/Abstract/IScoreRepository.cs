using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IScoreRepository
	{
		Task<ActionResult<IEnumerable<Score>>> GetScores();
		Task<ActionResult<Score>> GetScore(int id);
		Task<ActionResult<Score>> PostScore(Score entity);
		Task<ActionResult<Score>> PutScore(int id, Score entity);
		void DeleteScore(int id);
	}
}
