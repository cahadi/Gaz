using Gaz.Domain.Entities;
using Gaz.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract.Auth
{
    public interface IAuthenticateRepository
	{
        string Login(LoginModel entity);
	}
}
