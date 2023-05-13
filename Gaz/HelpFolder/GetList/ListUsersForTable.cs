using Gaz.Data;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SerGaz.Controllers;

namespace Gaz.HelpFolder.GetList
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

        public List<User> GetUsers()
        {
            var users = _context.Users
                .Where(u => u.UsersRoles.Any(r => r.Role.RoleName
                != "Главный администратор"))
                .Include("Type")
                .Include("Explanations")
                .Include("Polls")
                .Include("Scores")
                .Include("UsersRoles")
                .Include("UsersRoles.Role")
                .ToList();
            return users;
        }
    }
}
