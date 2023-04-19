using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IUserRepository
	{
		Task<ActionResult<IEnumerable<User>>> GetUsers();
		Task<ActionResult<User>> GetUser(int id);
		Task<ActionResult<User>> GetUserEmail(string email);
		Task<ActionResult<User>> PutUser(int id, User entity);
		void DeleteUser(int id);
	}
}
