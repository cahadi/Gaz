using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.Data;
using Gaz.Domain.Entities;
using Gaz.HelpFolder.Check;
using Gaz.HelpFolder.CheckMonth;
using Gaz.HelpFolder.GetElement;
using Gaz.HelpFolder.GetList;
using Gaz.HelpFolder.Sum;
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
        private readonly GetMonth getMonth;
        private readonly EstimationsMarksController estimationsMarksController;

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
            getMonth = new GetMonth();
            estimationsMarksController = new EstimationsMarksController(_context);
        }

		public async Task<IActionResult> Apparat(int userId, string param)
		{
			DateTime now = DateTime.Now;
            int day = now.Day;
			int month = now.Month;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable(param);
            var ex = await _context.Explanations
				.Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            await estimationsMarksController.GetEstimationsMarks();
            var em1 = estimationsMarksController.GetListForTable(1);
            var em2 = estimationsMarksController.GetListForTable(2);
            var em3 = estimationsMarksController.GetListForTable(3);
            var em4 = estimationsMarksController.GetListForTable(4);
            var em5 = estimationsMarksController.GetListForTable(5);
            var em6 = estimationsMarksController.GetListForTable(6);
            var em7 = estimationsMarksController.GetListForTable(7);
            var em8 = estimationsMarksController.GetListForTable(8);
            var em9 = estimationsMarksController.GetListForTable(9);
            var em10 = estimationsMarksController.GetListForTable(10);
            var em11 = estimationsMarksController.GetListForTable(11);
            var em12 = estimationsMarksController.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            int preMonth = month - 1;
            int prePreMonth = month - 2;
            string monthName = getMonth.GetMonths(month);
            string preMonthName = getMonth.GetMonths(preMonth);
            string prePreMonthName = getMonth.GetMonths(prePreMonth);

            checkRoles.GetRolesList(user.Id);
            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(),
                Admin = checkRoles.Admin(),
                Discipline = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                Dis = checkRoles.Dis(),
                Stop = checkRoles.Stop(),
                Rac = checkRoles.Rac(),
                Ber = checkRoles.Ber(),
                Ruk = checkRoles.Ruk(userId),
                Pol = checkRoles.Pol(),
                Nast = checkRoles.Nast(),
                Prof = checkRoles.Prof(),
                Ecolog = checkRoles.Ecolog(),
                Sport = checkRoles.Sport(),
                Kult = checkRoles.Kult(),
                Blag = checkRoles.Blag(),

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

                Name = param,
                CurrentMonth = monthName,
                PreviousMonth = preMonthName,
                PM = preMonth,
                TwoMonthsAgo = prePreMonthName,
                TMA = prePreMonth
            };
			return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ApparatSend(SidebarModel viewModel)
        {
            string name = viewModel.Name;
            viewModel.AllUsers = listUsersForTable.GetAllUsers();
            string email = string.IsNullOrEmpty(viewModel.Email) ? Request.Form["Email"] : viewModel.Email;
            await apparatController.Send(name, email);

            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;

            int useId = viewModel.User.Id;
            var users = listUsersForTable.GetListUsersForTable(name);

            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = viewModel.Scores;

            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            return RedirectToAction("Apparat", "EvaluationTable", new { userId = useId, param = name });
        }


        public async Task<IActionResult> PreviousMonths(int userId, string param,
            int month)
        {
            DateTime now = DateTime.Now;
            int year = now.Year;

            var user = checkRoles.GetUse(userId);
            var users = listUsersForTable.GetListUsersForTable(param);
            var ex = await _context.Explanations
                .Where(e => e.Month == month && e.Year == year).ToListAsync();

            var sc = await _context.Scores
                .Where(s => s.Month == month && s.Year == year).ToListAsync();

            await estimationsMarksController.GetEstimationsMarks();
            var em1 = estimationsMarksController.GetListForTable(1);
            var em2 = estimationsMarksController.GetListForTable(2);
            var em3 = estimationsMarksController.GetListForTable(3);
            var em4 = estimationsMarksController.GetListForTable(4);
            var em5 = estimationsMarksController.GetListForTable(5);
            var em6 = estimationsMarksController.GetListForTable(6);
            var em7 = estimationsMarksController.GetListForTable(7);
            var em8 = estimationsMarksController.GetListForTable(8);
            var em9 = estimationsMarksController.GetListForTable(9);
            var em10 = estimationsMarksController.GetListForTable(10);
            var em11 = estimationsMarksController.GetListForTable(11);
            var em12 = estimationsMarksController.GetListForTable(12);
            var polls = await _context.Polls
                .Where(p => p.Month == month && p.Year == year).ToListAsync();

            int preMonth = month;
            int prePreMonth = month - 1;
            string monthName = getMonth.GetMonths(month + 1);
            string preMonthName = getMonth.GetMonths(preMonth);
            string prePreMonthName = getMonth.GetMonths(prePreMonth);

            var viewModel = new SidebarModel
            {
                User = user,
                Users = users,
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(),
                Admin = checkRoles.Admin(),
                Discipline = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                Dis = checkRoles.Dis(),
                Stop = checkRoles.Stop(),
                Rac = checkRoles.Rac(),
                Ber = checkRoles.Ber(),
                Ruk = checkRoles.Ruk(userId),
                Pol = checkRoles.Pol(),
                Nast = checkRoles.Nast(),
                Prof = checkRoles.Prof(),
                Ecolog = checkRoles.Ecolog(),
                Sport = checkRoles.Sport(),
                Kult = checkRoles.Kult(),
                Blag = checkRoles.Blag(),

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

                Name = param,
                CurrentMonth = monthName,
                PreviousMonth = preMonthName,
                PM = preMonth,
                TwoMonthsAgo = prePreMonthName,
                TMA = prePreMonth
            };
            return View(viewModel);
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
            await estimationsMarksController.GetEstimationsMarks();
            viewModel = new SidebarModel
            {
                UserId = userId,
                User = checkRoles.GetUse(userId),
                Users = listUsersForTable.GetListUsersForTable(user.Division),
                AllUsers = listUsersForTable.GetAllUsers(),
                MainAdmin = checkRoles.MainAdmin(),
                Admin = checkRoles.Admin(),
                Discipline = checkRoles.Discipline(),
                Side = checkRoles.Side(),
                Dis = checkRoles.Dis(),
                Stop = checkRoles.Stop(),
                Rac = checkRoles.Rac(),
                Ber = checkRoles.Ber(),
                Ruk = checkRoles.Ruk(userId),
                Pol = checkRoles.Pol(),
                Nast = checkRoles.Nast(),
                Prof = checkRoles.Prof(),
                Ecolog = checkRoles.Ecolog(),
                Sport = checkRoles.Sport(),
                Kult = checkRoles.Kult(),
                Blag = checkRoles.Blag(),

                Explanations = exs,
                Scores = scores,
                EstimationsMarks1 = estimationsMarksController.GetListForTable(1),
                EstimationsMarks2 = estimationsMarksController.GetListForTable(2),
                EstimationsMarks3 = estimationsMarksController.GetListForTable(3),
                EstimationsMarks4 = estimationsMarksController.GetListForTable(4),
                EstimationsMarks5 = estimationsMarksController.GetListForTable(5),
                EstimationsMarks6 = estimationsMarksController.GetListForTable(6),
                EstimationsMarks7 = estimationsMarksController.GetListForTable(7),
                EstimationsMarks8 = estimationsMarksController.GetListForTable(8),
                EstimationsMarks9 = estimationsMarksController.GetListForTable(9),
                EstimationsMarks10 = estimationsMarksController.GetListForTable(10),
                EstimationsMarks11 = estimationsMarksController.GetListForTable(11),
                EstimationsMarks12 = estimationsMarksController.GetListForTable(12),
                Polls = polls,

                Name = name
            };
            switch (string.IsNullOrWhiteSpace(name))
            {
                case false:
                    return RedirectToAction("Apparat", "EvaluationTable", new { userId = viewModel.User.Id, param = name });
                default:
                    return NotFound();
            }
        }
    }
}
