using Gaz.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Gaz.Domain.Repositories.Abstract
{
    public interface IRolesLawRepository
	{
		Task<ActionResult<IEnumerable<RolesLaw>>> GetRolesLaws();
		Task<ActionResult<RolesLaw>> GetRolesLaw(int id);
		Task<ActionResult<RolesLaw>> PostRolesLaw(RolesLaw entity);
		Task<ActionResult<RolesLaw>> PutRolesLaw(int id, RolesLaw entity);
		void DeleteRolesLaw(int id);
	}
}
