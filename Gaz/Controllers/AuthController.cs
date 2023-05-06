using DocumentFormat.OpenXml.Office2010.Excel;
using Gaz.ApiControllers.Auth.Controllers;
using Gaz.Data;
using Gaz.Domain;
using Gaz.Domain.Entities;
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

        public AuthController(freedb_testdbgazContext context)
        {
            _context = context;
            authenticateController = new AuthenticateController(_context);
            usersController = new UsersController(_context);
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
            //SendMessage.WelcomeBack(useR.Email, useR.Fio);
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