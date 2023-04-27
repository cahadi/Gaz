using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.Controllers.Check;
using Gaz.Controllers.GetElement;
using Gaz.Controllers.GetList;
using Gaz.Controllers.Sum;
using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerGaz.Controllers;
using SerGaz.SendTable;

namespace Gaz.Controllers
{
    public class EvaluationTableController : Controller
	{
		private readonly freedb_testdbgazContext _context;
        private readonly UsersController usersController;
        private readonly ListForTable listForTable;
        private readonly CheckRoles checkRoles;
        private readonly ListUsersForTable listUsersForTable;
        private readonly ApparatController apparatController;
        private readonly ExplanationsController explanationsController;
        private readonly PollsController pollsController;
        private readonly SumScore sumScore;
        private readonly GetEl getEl;
        private readonly ScoresController scoresController;

        public EvaluationTableController(freedb_testdbgazContext context)
		{
			_context = context;
            usersController = new UsersController(_context);
            listForTable = new ListForTable(_context);
            checkRoles = new CheckRoles(_context);
            listUsersForTable = new ListUsersForTable(_context);
            apparatController = new ApparatController(_context);
            explanationsController = new ExplanationsController(_context);
            pollsController = new PollsController(_context);
            sumScore = new SumScore(_context);
            getEl = new GetEl(_context);
            scoresController = new ScoresController(_context);
        }

		public async Task<IActionResult> Apparat(int userId)
		{
			DateTime now = DateTime.Now;
			int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("Аппарат");
            var ex = await _context.Explanations
				.Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
				EstimationsMarks1 = em1,
				EstimationsMarks2 = em2,
				EstimationsMarks3 = em3,
				EstimationsMarks4 = em4,
				EstimationsMarks5 = em5,
				EstimationsMarks6 = em6,
				EstimationsMarks7 = em7,
				EstimationsMarks8 = em8,
				EstimationsMarks9 = em9,
				EstimationsMarks10 = em10,
				EstimationsMarks11 = em11,
				EstimationsMarks12 = em12,
                Polls = polls,

                Name = "Аппарат"
            };
			return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ApparatSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("Аппарат", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("Аппарат");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,

                Name = "Аппарат"
            };

            return RedirectToAction("Apparat", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> GIT(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("ГИТ");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "ГИТ"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GITSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("ГИТ", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("ГИТ");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,


                Name = "ГИТ"
            };

            return RedirectToAction("GIT", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> GRS(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("ГРС");
            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 11),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "ГРС"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> GRSSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("ГРС", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("ГРС");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,


                Name = "ГРС"
            };

            return RedirectToAction("GRS", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> DS(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("ДС");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 12),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "ДС"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DSSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("ДС", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("ДС");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,


                Name = "ДС"
            };

            return RedirectToAction("DS", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> KIPiA(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("КИПиА");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 13),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "КИПиА"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> KIPiASend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("КИПиА", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("КИПиА");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,

                Name = "КИПиА"
            };

            return RedirectToAction("KIPiA", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> LES(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("ЛЭС");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 14),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "ЛЭС"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LESSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("ЛЭС", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("ЛЭС");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,

                Name = "ЛЭС"
            };

            return RedirectToAction("LES", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> MTS(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("МТС");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 15),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "МТС"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> MTSSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("МТС", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("МТС");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,


                Name = "МТС"
            };

            return RedirectToAction("MTS", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> RSGEXY(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("РСГЭХУ");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 16),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "РСГЭХУ"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> RSGEXYSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("РСГЭХУ", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("РСГЭХУ");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,


                Name = "РСГЭХУ"
            };

            return RedirectToAction("RSGEXY", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> STS(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("СТС");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 17),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "СТС"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> STSSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("СТС", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("СТС");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,


                Name = "СТС"
            };

            return RedirectToAction("STS", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> TC(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("ТЦ");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 18),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "ТЦ"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> TCSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("ТЦ", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("ТЦ");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,


                Name = "ТЦ"
            };

            return RedirectToAction("TC", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> EVS(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("ЭВС");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 19),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "ЭВС"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EVSSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("ЭВС", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("ЭВС");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,

                Name = "ЭВС"
            };

            return RedirectToAction("EVS", "EvaluationTable", new { userId = useId });
        }


        public async Task<IActionResult> EXZ(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("ЭХЗ");
            var ex = await _context.Explanations
               .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            var em1 = listForTable.GetListForTable(1);
            var em2 = listForTable.GetListForTable(2);
            var em3 = listForTable.GetListForTable(3);
            var em4 = listForTable.GetListForTable(4);
            var em5 = listForTable.GetListForTable(5);
            var em6 = listForTable.GetListForTable(6);
            var em7 = listForTable.GetListForTable(7);
            var em8 = listForTable.GetListForTable(8);
            var em9 = listForTable.GetListForTable(9);
            var em10 = listForTable.GetListForTable(10);
            var em11 = listForTable.GetListForTable(11);
            var em12 = listForTable.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 20),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = em1,
                EstimationsMarks2 = em2,
                EstimationsMarks3 = em3,
                EstimationsMarks4 = em4,
                EstimationsMarks5 = em5,
                EstimationsMarks6 = em6,
                EstimationsMarks7 = em7,
                EstimationsMarks8 = em8,
                EstimationsMarks9 = em9,
                EstimationsMarks10 = em10,
                EstimationsMarks11 = em11,
                EstimationsMarks12 = em12,
                Polls = polls,

                Name = "ЭХЗ"
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EXZSend(SidebarModel viewModel)
        {
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send("ЭХЗ", email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable("ЭХЗ");

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            viewModel = new SidebarModel
            {
                User = checkRoles.GetUse(useId),
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(useId),
                Admin = checkRoles.Admin(useId),
                Discipline = checkRoles.Discipline(useId),
                Side = checkRoles.Side(useId),
                Dis = checkRoles.Dis(useId),
                Stop = checkRoles.Stop(useId),
                Rac = checkRoles.Rac(useId),
                Ber = checkRoles.Ber(useId),
                Ruk = checkRoles.Ruk(useId),
                Pol = checkRoles.Pol(useId),
                Nast = checkRoles.Nast(useId),
                Prof = checkRoles.Prof(useId),
                Ecolog = checkRoles.Ecolog(useId),
                Sport = checkRoles.Sport(useId),
                Kult = checkRoles.Kult(useId),
                Blag = checkRoles.Blag(useId),

                Explanations = ex,
                Scores = sc,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,

                Name = "ЭХЗ"
            };

            return RedirectToAction("EXZ", "EvaluationTable", new { userId = useId });
        }




        [HttpPost]
        public async Task<IActionResult> Save(SidebarModel viewModel)
        {
            var name = viewModel.Name;
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            Explanation ex = new Explanation();
            ex.Explanation1 = viewModel.Explanation;
            ex.UserId = viewModel.EditUserId;
            ex.User = await usersController.GetUser(viewModel.EditUserId);

            Explanation exp = await explanationsController.GetExByDetail(ex.UserId, month, year);
            if (exp != null)
            {
                await explanationsController.DeleteExplanation(exp.Id);
            }
            await explanationsController.PostExplanation(ex);

            Poll poll = new Poll();
            poll.UserId = viewModel.EditUserId;
            poll.User = await usersController.GetUser(poll.UserId);
            var user = checkRoles.GetUse(poll.UserId);

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId1);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId2);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId3);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId4);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId5);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId6);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId7);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId8);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId9);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId10);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId11);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            poll.EstimationsMarks = getEl.GetEM(viewModel.MarkId12);
            if (poll.EstimationsMarks != null)
            {
                poll.EstimationsMarksId = poll.EstimationsMarks.Id;
                Poll po = await pollsController.GetPollByOtherDetail(poll.UserId, month, year, poll.EstimationsMarksId);
                if (po == null)
                    await pollsController.PostPoll(poll);
                else
                    await pollsController.PutPoll(po.Id, poll);
            }

            Score score =  await sumScore.Score(viewModel.EditUserId,
                month, year);

            int userId = viewModel.UserId;
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();
            var exs = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();
            var scores =viewModel.Scores;
            viewModel = new SidebarModel
            {
                UserId = userId,
                User = checkRoles.GetUse(userId),
                Users = listUsersForTable.GetListUsersForTable(user.Division),
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(userId),
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = exs,
                Scores = scores,
                EstimationsMarks1 = listForTable.GetListForTable(1),
                EstimationsMarks2 = listForTable.GetListForTable(2),
                EstimationsMarks3 = listForTable.GetListForTable(3),
                EstimationsMarks4 = listForTable.GetListForTable(4),
                EstimationsMarks5 = listForTable.GetListForTable(5),
                EstimationsMarks6 = listForTable.GetListForTable(6),
                EstimationsMarks7 = listForTable.GetListForTable(7),
                EstimationsMarks8 = listForTable.GetListForTable(8),
                EstimationsMarks9 = listForTable.GetListForTable(9),
                EstimationsMarks10 = listForTable.GetListForTable(10),
                EstimationsMarks11 = listForTable.GetListForTable(11),
                EstimationsMarks12 = listForTable.GetListForTable(12),
                Polls = polls,

                Name = name
            };
            switch (name)
            {
                case "Аппарат":
                    return RedirectToAction("Apparat", "EvaluationTable", new { userId = viewModel.UserId });
                case "ГИТ":
                    return RedirectToAction("GIT", "EvaluationTable", new { userId = viewModel.UserId });
                case "ГРС":
                    return RedirectToAction("GRS", "EvaluationTable", new { userId = viewModel.UserId });
                case "ДС":
                    return RedirectToAction("DS", "EvaluationTable", new { userId = viewModel.UserId });
                case "КИПиА":
                    return RedirectToAction("KIPiA", "EvaluationTable", new { userId = viewModel.UserId });
                case "ЛЭС":
                    return RedirectToAction("LES", "EvaluationTable", new { userId = viewModel.UserId });
                case "МТС":
                    return RedirectToAction("MTS", "EvaluationTable", new { userId = viewModel.UserId });
                case "РСГЭХУ":
                    return RedirectToAction("RSGEXY", "EvaluationTable", new { userId = viewModel.UserId });
                case "СТС":
                    return RedirectToAction("STS", "EvaluationTable", new { userId = viewModel.UserId });
                case "ТЦ":
                    return RedirectToAction("TC", "EvaluationTable", new { userId = viewModel.UserId });
                case "ЭВС":
                    return RedirectToAction("EVS", "EvaluationTable", new { userId = viewModel.UserId });
                case "ЭХЗ":
                    return RedirectToAction("EXZ", "EvaluationTable", new { userId = viewModel.UserId });
                default:
                    return NotFound();
            }
        }
    }
}
