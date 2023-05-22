using Gaz.Data;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SerGaz.Controllers;

namespace Gaz.HelpFolder.GetList
{
    public class ListForTable
    {
        private readonly freedb_testdbgazContext _context;
        public ListForTable(freedb_testdbgazContext context)
        {
            _context = context;
        }

        public List<Indicator> GetDivisions()
        {
            var divisions = _context.Indicators
                .Where(i => i.Id > 9 && i.Id < 22).ToList();
            return divisions;
        }
    }
}
