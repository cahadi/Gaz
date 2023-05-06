using Gaz.Data;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gaz.HelpFolder.GetElement
{
    public class GetEl
    {
        private readonly freedb_testdbgazContext _context;
        public GetEl(freedb_testdbgazContext context)
        {
            _context = context;
        }

        public EstimationsMark GetEM(int emId)
        {
            EstimationsMark em = _context.EstimationsMarks
                .Include("Mark").Include("Estimation")
                .FirstOrDefault(p => p.Id ==
                emId);
            return em;
        }
    }
}
