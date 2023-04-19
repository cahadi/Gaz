using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IEditTimesRepository
	{
		Task<ActionResult<IEnumerable<EditTime>>> GetEditTimes();
		Task<ActionResult<EditTime>> GetEditTime(int id);
		Task<ActionResult<EditTime>> PostEditTime(EditTime entity);
		Task<ActionResult<EditTime>> PutEditTime(int id, EditTime entiy);
		void DeleteEditTime(int id);
	}
}
