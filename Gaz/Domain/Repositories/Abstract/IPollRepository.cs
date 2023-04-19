using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IPollRepository
	{
		Task<ActionResult<IEnumerable<Poll>>> GetPolls();
		Task<ActionResult<Poll>> GetPoll(int id);
		Task<ActionResult<Poll>> PostPoll(Poll entity);
		Task<ActionResult<Poll>> PutPoll(int id, Poll entity);
		void DeletePoll(int id);
	}
}
