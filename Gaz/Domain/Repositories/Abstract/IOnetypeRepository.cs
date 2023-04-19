using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IOnetypeRepository
	{
		Task<ActionResult<IEnumerable<Onetype>>> GetOnetypes();
		Task<ActionResult<Onetype>> GetOnetype(int id);
		Task<ActionResult<Onetype>> PostOnetype(Onetype entity);
		Task<ActionResult<Onetype>> PutOnetype(int id, Onetype entity);
		void DeleteOnetype(int id);
	}
}
