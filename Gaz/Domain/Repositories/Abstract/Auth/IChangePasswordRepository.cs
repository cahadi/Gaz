using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract.Auth
{
    public interface IChangePasswordRepository
	{
		Task<ActionResult<User>> Change(string oldpass, string newpass);
	}
}
