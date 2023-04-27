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
            string token = authenticateController.Login(model).ToString();
            switch (useR.Division)
            {
                case "Аппарат":
                    return RedirectToAction("Apparat", "EvaluationTable", new { userId = viewModel.User.Id });
                case "ГИТ":
                    return RedirectToAction("GIT", "EvaluationTable", new { userId = viewModel.User.Id });
                case "ГРС":
                    return RedirectToAction("GRS", "EvaluationTable", new { userId = viewModel.User.Id });
                case "ДС":
                    return RedirectToAction("DS", "EvaluationTable", new { userId = viewModel.User.Id });
                case "КИПиА":
                    return RedirectToAction("KIPiA", "EvaluationTable", new { userId = viewModel.User.Id });
                case "ЛЭС":
                    return RedirectToAction("LES", "EvaluationTable", new { userId = viewModel.User.Id });
                case "МТС":
                    return RedirectToAction("MTS", "EvaluationTable", new { userId = viewModel.User.Id });
                case "РСГЭХУ":
                    return RedirectToAction("RSGEXY", "EvaluationTable", new { userId = viewModel.User.Id });
                case "СТС":
                    return RedirectToAction("STS", "EvaluationTable", new { userId = viewModel.User.Id });
                case "ТЦ":
                    return RedirectToAction("TC", "EvaluationTable", new { userId = viewModel.User.Id });
                case "ЭВС":
                    return RedirectToAction("EVS", "EvaluationTable", new { userId = viewModel.User.Id });
                case "ЭХЗ":
                    return RedirectToAction("EXZ", "EvaluationTable", new { userId = viewModel.User.Id });
                default: 
                    return RedirectToAction("Start", "Home", useR);
            }
        }
    }
}