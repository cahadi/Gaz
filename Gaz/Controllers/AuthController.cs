using DocumentFormat.OpenXml.Office2010.Excel;
using Gaz.ApiControllers.Auth.Controllers;
using Gaz.Data;
using Gaz.Domain;
using Gaz.Domain.Entities;
using Gaz.HelpFolder.Check;
using Gaz.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SerGaz.Controllers;

namespace Gaz.Controllers
{
    public class AuthController : Controller
    {
        private readonly freedb_testdbgazContext _context;
        private readonly AuthenticateController authenticateController;
        private readonly UsersController usersController;
        private readonly CheckRoles checkRoles;

        public AuthController(freedb_testdbgazContext context)
        {
            _context = context;
            authenticateController = new AuthenticateController(_context);
            usersController = new UsersController(_context);
            checkRoles = new CheckRoles(_context);
        }

        public IActionResult Login()
        {
            return View(new LoginModel()); 
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await usersController.GetUserEmail(model.Email);
            if (user == null)
            {
                return NotFound();
            }
            var viewModel = new LoginModel
            {
                User = user
            };
            User useR = viewModel.User;
            authenticateController.Login(model).ToString();
            bool dirct = checkRoles.Direct(useR.Id);
            switch (dirct)
            {
                case true:
                    return RedirectToAction("ListUser", "HRController", new { userId = viewModel.User.Id });
            }
            switch (string.IsNullOrWhiteSpace(useR.Division))
            {
                case false:
                    return RedirectToAction("Apparat", "EvaluationTable", new { userId = viewModel.User.Id, param = useR.Division });
                
                default: 
                    return RedirectToAction("Start", "Home", useR);
            }
        }
    }
}