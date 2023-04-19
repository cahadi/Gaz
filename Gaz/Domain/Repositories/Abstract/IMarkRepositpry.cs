using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IMarkRepositpry
	{
		Task<ActionResult<IEnumerable<Mark>>> GetMarks();
		Task<ActionResult<Mark>> GetMark(int id);
		Task<ActionResult<Mark>> PostMark(Mark entity);
		Task<ActionResult<Mark>> PutMark(int id, Mark entity);
		void DeleteMark(int id);
	}
}
