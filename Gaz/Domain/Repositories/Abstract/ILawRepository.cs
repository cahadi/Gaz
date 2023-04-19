using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface ILawRepository
	{
		Task<ActionResult<IEnumerable<Law>>> GetLaws();
		Task<ActionResult<Law>> GetLaw(int id);
		Task<ActionResult<Law>> PostLaw(Law entity);
		Task<ActionResult<Law>> PutLaw(int id, Law entity);
		void DeleteLaw(int id);
	}
}
