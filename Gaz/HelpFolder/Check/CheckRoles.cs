using DocumentFormat.OpenXml.Office2010.Excel;
using Gaz.Data;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SerGaz.Controllers;

namespace Gaz.HelpFolder.Check
{
    public class CheckRoles
    {
        private readonly freedb_testdbgazContext _context;
        private readonly UsersController usersController;

        public CheckRoles(freedb_testdbgazContext context)
        {
            _context = context;
            usersController = new UsersController(_context);
        }

        public bool Direct(int id)
        {
            User user = _context.Users
                    .Include("Type")
                    .Include("UsersRoles")
                    .Include("UsersRoles.Role")
                    .FirstOrDefault(u => u.Id == id);
            if (user.UsersRoles.Any(z => z.Role.RoleName == "Директор"))
                return true;

            return false;
        }

        public User GetUse(int id)
        {
            User user = _context.Users
                    .Include("Type")
                    .Include("UsersRoles")
                    .Include("UsersRoles.Role")
                    .FirstOrDefault(u => u.Id == id);
            return user;
        }

        public List<Role> GetRoles()
        {
            List<Role> roles = _context.Roles.ToList();
            return roles;
        }

        public List<Role> GetOtherRoles()
        {
            List<Role> roles = _context.Roles.Where(r => r.RoleName != "Главный админисратор"
            && r.RoleName != "Текущий администратор").ToList();
            return roles;
        }


        List<UsersRole> roles;
        public void GetRolesList(int id)
        {
            var user = GetUse(id);
            roles = _context.UsersRoles.Where(z => z.UserId == user.Id)
                .Include(u => u.Role)
                .Include(u => u.User)
                .ToList();
        }
        //доступ к sidebar
        public bool MainAdmin()
        {
            if (roles.Any(z => z.RoleId == 1))
            {
                return true;
            }
            return false;
        }
        public bool Dis()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3))
            {
                return true;
            }
            return false;
        }
        public bool Side()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 4))
            {
                return true;
            }
            return false;
        }
        //


        public bool Admin()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3))
            {
                return true;
            }
            return false;
        }
        public bool Discipline()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3))
            {
                return true;
            }
            return false;
        }
        public bool Stop()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 5))
            {
                return true;
            }
            return false;
        }
        public bool Rac()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 6))
            {
                return true;
            }
            return false;
        }
        public bool Ber()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 7))
            {
                return true;
            }
            return false;
        }
        public bool Ruk(int userId, int? indicId = null)
        {
            var user = GetUse(userId);
            if (roles.Any(z => z.RoleId == 1 ||
            z.RoleId == 2 ||
            z.RoleId == 3) ||
            user.TypeId == 1 &&
             roles.Any(z => z.Role.IndicatorId == indicId))
            {
                return true;
            }
            return false;
        }
        public bool Pol()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 8))
            {
                return true;
            }
            return false;
        }
        public bool Nast()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 9))
            {
                return true;
            }
            return false;
        }
        public bool Prof()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 10))
            {
                return true;
            }
            return false;
        }
        public bool Ecolog()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 11))
            {
                return true;
            }
            return false;
        }
        public bool Sport()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 12))
            {
                return true;
            }
            return false;
        }
        public bool Kult()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 13))
            {
                return true;
            }
            return false;
        }
        public bool Blag()
        {
            if (roles.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 14))
            {
                return true;
            }
            return false;
        }
    }
}
