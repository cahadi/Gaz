using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract.Auth
{
    public interface IRegisterRepository
	{
		Task<ActionResult<User>> Register(User entity);
	}
}
