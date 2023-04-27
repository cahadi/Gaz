using Gaz.Data;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SerGaz.Controllers;

namespace Gaz.Controllers.GetList
{
    public class ListUsersForTable
    {
        private readonly freedb_testdbgazContext _context;
        private readonly UsersController usersController;
        public ListUsersForTable(freedb_testdbgazContext context)
        {
            _context = context;
            usersController = new UsersController(_context);
        }

        public List<User> GetListUsersForTable(string div)
        {
            var u = _context.Users
                .Where(e => e.Division == div).ToList();
            return u;
        }

        public List<User> GetAllUsers()
        {
            var users = usersController.GetUsers().Result;
            return users;
        }
    }
}
