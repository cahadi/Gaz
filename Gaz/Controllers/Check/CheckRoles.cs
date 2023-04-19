using DocumentFormat.OpenXml.Office2010.Excel;
using Gaz.Data;
using Gaz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using SerGaz.Controllers;

namespace Gaz.Controllers.Check
{
    public class CheckRoles
    {
        private readonly freedb_testdbgazContext _context;

        public CheckRoles(freedb_testdbgazContext context)
        {
            _context = context;
        }

        public User GetUse(int id)
        {
            User user = _context.Users.FirstOrDefault(u => u.Id == id);
            return user;
        }

        public List<Role> GetRoles()
        {
            List<Role> roles = _context.Roles.ToList();
            return roles;
        }

        public List<UsersRole> GetRolesList(int id)
        {
            var user = GetUse(id);
            List<UsersRole> userRole = _context.UsersRoles.Where(z => z.UserId == user.Id)
                .Include(u => u.Role)
                .Include(u => u.User)
                .ToList();
            return userRole;
        }
        public bool Admin(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3))
            {
                return true;
            }
            return false;
        }

        public bool Discipline(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3))
            {
                return true;
            }
            return false;
        }

        public bool Side(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 4))
            {
                return true;
            }
            return false;
        }

        public bool Dis(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Stop(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 5 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Rac(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 6 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Ber(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 7 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Ruk(int userId, int? indicId = null)
        {
            var user = GetUse(userId);
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
            z.RoleId == 2 ||
            z.RoleId == 3)  ||
            (user.TypeId == 1 &&
             userRole.Any(z => z.Role.IndicatorId == indicId)))
            {
                return true;
            }
            return false;
        }

        public bool Pol(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 8 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Nast(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 9 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Prof(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 10 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Ecolog(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 11 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Sport(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 12 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Kult(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 13 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }

        public bool Blag(int userId)
        {
            var userRole = GetRolesList(userId);
            if (userRole.Any(z => z.RoleId == 1 ||
                z.RoleId == 2 ||
                z.RoleId == 3 ||
                z.RoleId == 14 ||
                z.UserId == userId))
            {
                return true;
            }
            return false;
        }
    }
}
