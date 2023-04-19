using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract.SendMessage
{
	public interface ISendExselRepository
	{
		void Send(string name, string email);
	}
}
