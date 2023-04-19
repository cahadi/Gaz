using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.ApiControllers.Auth.Controllers;
using Gaz.Controllers.Check;
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

        public HRController(freedb_testdbgazContext context)
        {
            _context = context;
            checkRoles = new CheckRoles(_context);
            usersController = new UsersController(_context);
            onetypesController = new OnetypesController(_context);
            registerController = new RegisterController(_context);
        }

        public async Task<IActionResult> AddUsers(int userId)
        {
            var user = checkRoles.GetUse(userId);
            var types = await _context.Onetypes.ToListAsync();
            var viewModel = new SidebarModel
            {
                Dis = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                User = user,
                Types = types
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
                viewModel.Types = await _context.Onetypes.ToListAsync();
                return View(viewModel);
            }
            viewModel.Dis = checkRoles.Discipline(user.Id);
            viewModel.Side = checkRoles.Side(user.Id);
            viewModel.User.Password = "";
            viewModel.User.TypeId = viewModel.TypeId;
            viewModel.User.Type = (await onetypesController.GetOnetype(viewModel.User.TypeId.GetValueOrDefault())).Value; 
            IActionResult us = await registerController.Register(viewModel.User);
            return View(viewModel);
        }
        
        public async Task<ActionResult<IEnumerable<User>>> ListUser(int userId)
        {
            var user = checkRoles.GetUse(userId);
            ActionResult<IEnumerable<User>> users = 
                await usersController.GetUsers();
            List<User> userList = users.Value.ToList();
            var viewModel = new SidebarModel
            {
                Dis = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                User = user,
                Users = userList
            };
            SidebarModel model = viewModel;
            return View(model);
        }
    }
}
