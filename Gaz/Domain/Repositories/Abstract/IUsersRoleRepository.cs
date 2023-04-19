using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IUsersRoleRepository
	{
		Task<ActionResult<IEnumerable<UsersRole>>> GetUsersRoles();
		Task<ActionResult<UsersRole>> GetUsersRole(int id);
		Task<ActionResult<UsersRole>> PostUsersRole(UsersRole entity);
		Task<ActionResult<UsersRole>> PutUsersRole(int id, UsersRole entity);
		void DeleteUsersRole(int id);
	}
}
