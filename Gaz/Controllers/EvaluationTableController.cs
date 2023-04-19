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
    public class EvaluationTableController : Controller
	{
		private readonly freedb_testdbgazContext _context;
        private readonly UsersController usersController;
        private readonly ListForTable listForTable;
        private readonly CheckRoles checkRoles;
        private readonly ListUsersForTable listUsersForTable;

        public EvaluationTableController(freedb_testdbgazContext context)
		{
			_context = context;
            usersController = new UsersController(_context);
            listForTable = new ListForTable(_context);
            checkRoles = new CheckRoles(_context);
            listUsersForTable = new ListUsersForTable(_context);
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
                Polls = polls
            };
			return View(viewModel);
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
                Admin = checkRoles.Admin(userId),
                Discipline = checkRoles.Discipline(userId),
                Side = checkRoles.Side(userId),
                Dis = checkRoles.Dis(userId),
                Stop = checkRoles.Stop(userId),
                Rac = checkRoles.Rac(userId),
                Ber = checkRoles.Ber(userId),
                Ruk = checkRoles.Ruk(userId, 10),
                Pol = checkRoles.Pol(userId),
                Nast = checkRoles.Nast(userId),
                Prof = checkRoles.Prof(userId),
                Ecolog = checkRoles.Ecolog(userId),
                Sport = checkRoles.Sport(userId),
                Kult = checkRoles.Kult(userId),
                Blag = checkRoles.Blag(userId),

                Explanations = ex,
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
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
                Polls = polls
            };
            return View(viewModel);
        }


        public async Task<IActionResult> EXZ(int userId)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable("ЭВЗ");
            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

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
                Polls = polls
            };
            return View(viewModel);
        }

    }
}
