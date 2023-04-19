using Gaz.Data;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Controllers.GetList
{
    public class ListForTable
    {
        private readonly freedb_testdbgazContext _context;
        public ListForTable(freedb_testdbgazContext context)
        {
            _context = context;
        }

        public List<EstimationsMark> GetListForTable(int id)
        {
            var em = _context.EstimationsMarks
                .Where(e => e.EstimationId == id)
                .Include("Mark").ToList();
            return em;
        }
    }
}
