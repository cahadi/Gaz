using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.ApiControllers.Auth.Controllers;
using Gaz.Controllers.Check;
using Gaz.Controllers.GetList;
using Gaz.Data;
using Gaz.Domain.Entities;
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
        }

        public async Task<IActionResult> AddUsers(int userId)
        {
            var user = checkRoles.GetUse(userId);
            var types = await _context.Onetypes.ToListAsync();
            var viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(userId),
                Dis = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                User = user,
                Types = types,
                Roles = checkRoles.GetRoles()
            };
            SidebarModel model = viewModel;
            return View(model);
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

            viewModel.MainAdmin = checkRoles.MainAdmin(id);
            viewModel.Dis = checkRoles.Discipline(user.Id);
            viewModel.Side = checkRoles.Side(user.Id);
            viewModel.User.Password = "";
            viewModel.User.TypeId = viewModel.TypeId;
            viewModel.User.Type = await onetypesController.GetOnetype(viewModel.User.TypeId);
            var us = registerController.Register(viewModel.User).Result; 
            foreach (var role in roles)
            {
                UsersRole ur = new UsersRole();
                ur.UserId = us.Id;
                ur.RoleId = role.Id;
                await usersRolesController.PostUsersRole(ur);
            }
            return View(viewModel);
        }


        public async Task<IActionResult> EditUser(int userId)
        {
            var user = checkRoles.GetUse(userId);
            var types = await _context.Onetypes.ToListAsync();
            var viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(userId),
                Dis = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                User = user,
                Types = types,
                Roles = checkRoles.GetRoles(),
                AllUsers = listUsersForTable.GetAllUsers()
            };
            SidebarModel model = viewModel;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(SidebarModel viewModel)
        {
            var id = viewModel.User.Id;
            var user = checkRoles.GetUse(id);
            var types = await _context.Onetypes.ToListAsync();
            viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(id),
                Dis = checkRoles.Discipline(id),
                Side = checkRoles.Side(id),
                User = user,
                UserId = id,
                EditUserId = viewModel.EditUserId,
                EditUser = checkRoles.GetUse(viewModel.EditUserId),
                Types = types,
                Roles = checkRoles.GetRoles(),
                AllUsers = listUsersForTable.GetAllUsers()
            };
            viewModel.TypeId = viewModel.EditUser.TypeId;
            viewModel.Type = await onetypesController.GetOnetype(viewModel.TypeId);
            viewModel.Fio = viewModel.EditUser.Fio;
            viewModel.ServiceNumber = viewModel.EditUser.ServiceNumber;
            viewModel.Division = viewModel.EditUser.Division;
            viewModel.Position = viewModel.EditUser.Position;
            SidebarModel model = viewModel;
            return View(model);
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
            var div = viewModel.Division;
            var pos = viewModel.Position;

            List<Role> roles = Request.Form["Roles"].Select(x => new Role { Id = int.Parse(x) }).ToList();
            List<UsersRole> ur = await usersRolesController.GetRolesByUser(edId);
            viewModel.MainAdmin = checkRoles.MainAdmin(id);
            viewModel.Dis = checkRoles.Discipline(id);
            viewModel.Side = checkRoles.Side(id);
            viewModel.User = user;
            viewModel.UserId = id;
            viewModel.EditUserId = edId;
            viewModel.EditUser = checkRoles.GetUse(edId);
            viewModel.Types = types;
            viewModel.Roles = checkRoles.GetRoles();
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            viewModel.TypeId = viewModel.EditUser.TypeId;
            viewModel.Type = await onetypesController.GetOnetype(viewModel.TypeId);
            viewModel.EditUser.TypeId = viewModel.TypeId;
            viewModel.EditUser.Type = viewModel.Type;
            viewModel.EditUser.Fio = fio;
            viewModel.EditUser.ServiceNumber = serNum;
            viewModel.EditUser.Division = div;
            viewModel.EditUser.Position = pos;
            foreach(var role in ur)
            {
                await usersRolesController.DeleteUsersRole(role.Id);
            }
            foreach (var role in roles)
            {
                UsersRole urs = new UsersRole();
                urs.UserId = viewModel.EditUserId;
                urs.RoleId = role.Id;
                if (ur.Any(z=>z.RoleId == urs.RoleId))
                {
                    urs = await usersRolesController.GetUR(urs.UserId, urs.RoleId);
                    await usersRolesController.DeleteUsersRole(urs.Id);
                }
                await usersRolesController.PostUsersRole(urs);
            }
            await usersController.PutUser(viewModel.EditUser.Id, viewModel.EditUser);
            return RedirectToAction("EditUser", "HR", viewModel);
        }


        public async Task<ActionResult<IEnumerable<User>>> ListUser(int userId)
        {
            var user = checkRoles.GetUse(userId);
            List<User> userList = await usersController.GetUsers();
            var viewModel = new SidebarModel
            { 
                MainAdmin = checkRoles.MainAdmin(userId),
                Dis = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
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
            var viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(userId),
                Dis = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                User = user,
                Types = types,
                Roles = checkRoles.GetRoles(),
                AllUsers = listUsersForTable.GetAllUsers()
            };
            SidebarModel model = viewModel;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(SidebarModel viewModel)
        {
            var id = viewModel.User.Id;
            var user = checkRoles.GetUse(id);
            var edId = viewModel.EditUserId;
            viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(id),
                Dis = checkRoles.Discipline(id),
                Side = checkRoles.Side(id),
                User = user,
                UserId = id,
                EditUserId = viewModel.EditUserId,
                EditUser = checkRoles.GetUse(viewModel.EditUserId),
                Roles = checkRoles.GetRoles(),
                AllUsers = listUsersForTable.GetAllUsers()
            };
            List<UsersRole> ur = await usersRolesController.GetRolesByUser(edId);
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
