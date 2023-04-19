using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IRoleRepository
	{
		Task<ActionResult<IEnumerable<Role>>> GetRoles();
		Task<ActionResult<Role>> GetRole(int id);
		Task<ActionResult<Role>> PostRole(Role entity);
		Task<ActionResult<Role>> PutRole(int id, Role entity);
		void DeleteRole(int id);
	}
}
