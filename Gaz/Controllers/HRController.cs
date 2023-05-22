using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.ApiControllers.Auth.Controllers;
using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.HelpFolder.Check;
using Gaz.HelpFolder.GetList;
using Gaz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerGaz.Controllers;

namespace Gaz.Controllers
{
    public class HRController : Controller
    {
        private readonly freedb_testdbgazContext _context;
        private readonly CheckRoles checkRoles;
        private readonly UsersController usersController;
        private readonly OnetypesController onetypesController;
        private readonly RegisterController registerController;
        private readonly ListUsersForTable listUsersForTable;
        private readonly UsersRolesController usersRolesController;
        private readonly ExplanationsController explanationsController;
        private readonly PollsController pollsController;
        private readonly ScoresController scoresController;
        private readonly ListForTable listForTable;
        private readonly IndicatorsController indicatorsController;

        public HRController(freedb_testdbgazContext context)
        {
            _context = context;
            checkRoles = new CheckRoles(_context);
            usersController = new UsersController(_context);
            onetypesController = new OnetypesController(_context);
            registerController = new RegisterController(_context);
            listUsersForTable = new ListUsersForTable(_context);
            usersRolesController = new UsersRolesController(_context);
            explanationsController = new ExplanationsController(_context);
            pollsController = new PollsController(_context);
            scoresController = new ScoresController(_context);
            listForTable = new ListForTable(_context);
            indicatorsController = new IndicatorsController(_context);
        }

        public async Task<IActionResult> AddUsers(int userId)
        {
            var user = checkRoles.GetUse(userId);
            var types = await _context.Onetypes.ToListAsync();
            var roles = new List<Role>();
            if (user.UsersRoles.Any(u => u.Role.RoleName != "Главный администратор"))
            {
                roles = checkRoles.GetOtherRoles();
            }
            else if (user.UsersRoles.Any(u => u.Role.RoleName == "Главный администратор"))
                roles = checkRoles.GetRoles();

            checkRoles.GetRolesList(user.Id);
            var viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(),
                Dis = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                User = user,
                Types = types,
                Roles = roles,
                Divisions = listForTable.GetDivisions()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddUsers(SidebarModel viewModel)
        {
            var id = viewModel.User.Id;
            var user = checkRoles.GetUse(id);
            if (user != null)
            {
                viewModel.Types = await onetypesController.GetOnetypes();
            }
            List<Role> roles = Request.Form["Roles"].Select(x => new Role { Id = int.Parse(x) }).ToList();

            var roless = new List<Role>();
            if (user.UsersRoles.Any(u => u.Role.RoleName != "Главный администратор"))
            {
                roless = checkRoles.GetOtherRoles();
            }
            else if (user.UsersRoles.Any(u => u.Role.RoleName == "Главный администратор"))
                roless = checkRoles.GetRoles(); 
            viewModel.Divisions = Request.Form["Divisions"].Select(x => new Indicator { Id = int.Parse(x) }).ToList();
            viewModel.Division = viewModel.Divisions.FirstOrDefault();
            viewModel.Division = indicatorsController.GetIndicator(viewModel.Division.Id);
            viewModel.User.Password = "";
            viewModel.User.TypeId = viewModel.TypeId;
            viewModel.User.Type = await onetypesController.GetOnetype(viewModel.User.TypeId);
            viewModel.User.Division = viewModel.Division.IndicatorName;
            var us = registerController.Register(viewModel.User).Result;

            checkRoles.GetRolesList(user.Id);
            foreach (var role in roles)
            {
                UsersRole ur = new UsersRole();
                ur.UserId = us.Id;
                ur.RoleId = role.Id;
                await usersRolesController.PostUsersRole(ur);
            }

            return RedirectToAction("AddUsers", "HR", new { userId = id });
        }


        public async Task<IActionResult> EditUser(int userId)
        {
            var user = checkRoles.GetUse(userId);
            var types = await _context.Onetypes.ToListAsync();
            var roles = new List<Role>();
            if (user.UsersRoles.Any(u => u.Role.RoleName != "Главный администратор"))
            {
                roles = checkRoles.GetOtherRoles();
            }
            else if (user.UsersRoles.Any(u => u.Role.RoleName == "Главный администратор"))
                roles = checkRoles.GetRoles();

            checkRoles.GetRolesList(user.Id);
            var viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(),
                Dis = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                User = user,
                Types = types,
                Roles = roles,
                AllUsers = listUsersForTable.GetUsers(),
                Divisions = listForTable.GetDivisions()
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(SidebarModel viewModel)
        {
            var id = viewModel.User.Id;
            var user = checkRoles.GetUse(id);
            var roles = new List<Role>();
            if (user.UsersRoles.Any(u => u.Role.RoleName != "Главный администратор"))
            {
                roles = checkRoles.GetOtherRoles();
            }
            else if (user.UsersRoles.Any(u => u.Role.RoleName == "Главный администратор"))
                roles = checkRoles.GetRoles();

            checkRoles.GetRolesList(user.Id);
            viewModel.EditUser = checkRoles.GetUse(viewModel.EditUserId);
            viewModel.TypeId = viewModel.EditUser.TypeId;
            viewModel.Type = await onetypesController.GetOnetype(viewModel.TypeId);
            viewModel.Fio = viewModel.EditUser.Fio;
            viewModel.ServiceNumber = viewModel.EditUser.ServiceNumber;
            viewModel.DivisionName = viewModel.EditUser.Division;
            viewModel.Position = viewModel.EditUser.Position;
            viewModel.Divisions = listForTable.GetDivisions();
            viewModel.Types = await onetypesController.GetOnetypes();
            viewModel.AllUsers = listUsersForTable.GetUsers();
            viewModel.Roles = roles;
            viewModel.MainAdmin = checkRoles.MainAdmin();
            viewModel.Dis = checkRoles.Discipline();
            viewModel.Side = checkRoles.Side();
            viewModel.User = user;
            viewModel.UserId = id;
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SaveEditUser(SidebarModel viewModel)
        {
            var id = viewModel.User.Id;
            var user = checkRoles.GetUse(id);
            var edId = viewModel.EditUser.Id;

            List<Onetype> types = await onetypesController.GetOnetypes();

            var fio = viewModel.Fio;
            var serNum = viewModel.ServiceNumber;
            var pos = viewModel.Position;

            List<Role> roles = Request.Form["Roles"].Select(x => new Role { Id = int.Parse(x) }).ToList();
            List<UsersRole> ur = usersRolesController.GetRolesByUser(edId);

            viewModel.EditUserId = edId;
            viewModel.EditUser = checkRoles.GetUse(edId);
            viewModel.TypeId = viewModel.EditUser.TypeId;
            viewModel.Type = await onetypesController.GetOnetype(viewModel.TypeId);
            viewModel.DivisionName = viewModel.EditUser.Division;
            viewModel.Division = await _context.Indicators
                .FirstOrDefaultAsync(i => i.IndicatorName == 
                viewModel.DivisionName);
            viewModel.EditUser.TypeId = viewModel.TypeId;
            viewModel.EditUser.Type = viewModel.Type;
            viewModel.EditUser.Fio = fio;
            viewModel.EditUser.ServiceNumber = serNum;
            viewModel.EditUser.Division = viewModel.Division.IndicatorName;
            viewModel.EditUser.Position = pos;
            foreach (var role in roles)
            {
                UsersRole urs = new UsersRole();
                if (ur.Any(z => z.RoleId == role.Id))
                {
                    urs = await usersRolesController.GetUR(viewModel.EditUserId, role.Id);
                    await usersRolesController.DeleteUsersRole(urs.Id);
                }
                urs.UserId = viewModel.EditUserId;
                urs.RoleId = role.Id;
                await usersRolesController.PostUsersRole(urs);
            }
            await usersController.PutUser(viewModel.EditUser.Id, viewModel.EditUser);
            var roless = new List<Role>();
            if (user.UsersRoles.Any(u => u.Role.RoleName != "Главный администратор"))
            {
                roless = checkRoles.GetOtherRoles();
            }
            else if (user.UsersRoles.Any(u => u.Role.RoleName == "Главный администратор"))
                roless = checkRoles.GetRoles();
            viewModel.Roles = roless;
            viewModel.Divisions = listForTable.GetDivisions();
            return RedirectToAction("EditUser", "HR", new { userId = id });
        }


        public async Task<ActionResult<IEnumerable<User>>> ListUser(int userId)
        {
            var user = checkRoles.GetUse(userId);
            List<User> userList = listUsersForTable.GetUsers();

            checkRoles.GetRolesList(user.Id);
            var viewModel = new SidebarModel
            { 
                MainAdmin = checkRoles.MainAdmin(),
                Dis = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                User = user,
                Users = userList
            };
            SidebarModel model = viewModel;
            return View(model);
        }


        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = checkRoles.GetUse(userId);
            var types = await _context.Onetypes.ToListAsync();
            checkRoles.GetRolesList(user.Id);
            var viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(),
                Dis = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                User = user,
                Types = types,
                Roles = checkRoles.GetRoles(),
                AllUsers = listUsersForTable.GetUsers()
            };
            SidebarModel model = viewModel;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(SidebarModel viewModel)
        {
            var id = viewModel.User.Id;
            var user = checkRoles.GetUse(id);
            var roless = new List<Role>();
            if (user.UsersRoles.Any(u => u.Role.RoleName != "Главный администратор"))
            {
                roless = checkRoles.GetOtherRoles();
            }
            else
                roless = checkRoles.GetRoles();
            var edId = viewModel.EditUserId;
            checkRoles.GetRolesList(user.Id);
            viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(),
                Dis = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                User = user,
                UserId = id,
                EditUserId = viewModel.EditUserId,
                EditUser = checkRoles.GetUse(viewModel.EditUserId),
                Roles = roless,
                AllUsers = listUsersForTable.GetUsers()
            };
            List<UsersRole> ur = usersRolesController.GetRolesByUser(edId);
            foreach (var role in ur)
            {
                UsersRole urs = new UsersRole();
                urs = await usersRolesController.GetUR(viewModel.EditUserId, role.RoleId);
                await usersRolesController.DeleteUsersRole(urs.Id);
            }
            List<Explanation> ex = await explanationsController.GetExByUser(edId); 
            foreach (var explanation in ex)
            {
                await explanationsController.DeleteExplanation(explanation.Id);
            }
            List<Poll> polls = await pollsController.GetPollsByUser(edId);
            foreach (var poll in polls)
            {
                await explanationsController.DeleteExplanation(poll.Id);
            }
            List<Score> scores = await scoresController.GetScoresByUser(edId);
            foreach (var sc in scores)
            {
                await explanationsController.DeleteExplanation(sc.Id);
            }
            await usersController.DeleteUser(viewModel.EditUserId);
            SidebarModel model = viewModel;
            return View(model);
        }
    }
}
