using Gaz.Data;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gaz.Controllers.GetList
{
    public class ListUsersForTable
    {
        private readonly freedb_testdbgazContext _context;
        public ListUsersForTable(freedb_testdbgazContext context)
        {
            _context = context;
        }

        public List<User> GetListUsersForTable(string div)
        {
            var u = _context.Users
                .Where(e => e.Division == div).ToList();
            return u;
        }
    }
}
