using Gaz.ApiControllers.Auth.Controllers;
using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using SerGaz.Controllers;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Office2010.Excel;
using Gaz.HelpFolder.Check;

namespace Gaz.Controllers
{
    public class HomeController : Controller
    {
        private readonly freedb_testdbgazContext _context;
        private readonly ChangePassword changePassword;
        private readonly UsersController usersController;
        private readonly CheckRoles checkRoles;

        public HomeController(freedb_testdbgazContext context)
        {
            _context = context;
            changePassword = new ChangePassword(_context);
            usersController = new UsersController(_context);
            checkRoles = new CheckRoles(_context);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Start(User user)
        {
            checkRoles.GetRolesList(user.Id);
            var viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(),
                Dis = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                User = user
            };
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Change(int userId)
        {
            var user = checkRoles.GetUse(userId);
            if (user == null)
            {
                return NotFound();
            }
            var viewModel = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(),
                Dis = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                User = user
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Change(SidebarModel viewModel)
        {
            var email = viewModel.User.Email;
            var user = await usersController.GetUserEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            string pass = EncryptPassword(viewModel.OldPass);
            if (user.Password == pass)
            {
                await changePassword.Change(viewModel.User.Email, viewModel.OldPass, viewModel.NewPass);
            }
            var viewM = new SidebarModel
            {
                MainAdmin = checkRoles.MainAdmin(),
                Dis = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                User = user
            };
            SidebarModel model = viewM;
            return View(model);
        }


        public static string EncryptPassword(string password)
        {
            byte[] data = Encoding.UTF8.GetBytes(password);
            data = new SHA256Managed().ComputeHash(data);
            return Encoding.ASCII.GetString(data);
        }
    }
}