﻿using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SerGaz.Controllers;
using System.Net.Mail;
using System.Net;
using DocumentFormat.OpenXml.Drawing.Charts;
using NuGet.DependencyResolver;
using DocumentFormat.OpenXml.Office2010.Excel;
using System.Web.Helpers;
using SerGaz.SendTable.Header;
using Gaz.Data;
using Gaz.Domain.Entities;
using DocumentFormat.OpenXml.Bibliography;
using Gaz.ApiControllers.SendTable.CreateQuarter;
using DocumentFormat.OpenXml.Wordprocessing;

namespace SerGaz.SendTable
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class ApparatController : ControllerBase
	{
		private readonly freedb_testdbgazContext _context;
		private readonly ExplanationsController explanationsController;
		private readonly PollsController pollsController;
		private readonly ScoresController scoresController;
		private readonly QuarterHeaderTable quarterHeaderTable;

        public ApparatController(freedb_testdbgazContext context)
		{
			_context = context;
			explanationsController = new ExplanationsController(_context);
			pollsController = new PollsController(_context);
			scoresController = new ScoresController(_context);
			quarterHeaderTable = new QuarterHeaderTable(_context);
        }
        [HttpPost(nameof(Send))]
        public async Task<IActionResult> Send(string name, string email)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UsersRoles.Any(z => z.Role.RoleName == $"Руководитель {name}") && u.Division == name);
            List<Explanation> ex = new List<Explanation>();
            List<Score> score = new List<Score>();
            if (user != null)
            {
                ex = await _context.Explanations.Where(e => e.UserId == user.Id && e.Year == year).ToListAsync();
                score = await _context.Scores.Where(s => s.UserId == user.Id && s.Year == year).ToListAsync();
            }
            List<Poll> polls = await pollsController.GetPolls();
            List<Score> scores = await scoresController.GetScores();
            List<User> users = _context.Users.Where(u => u.Division == name && u.UsersRoles.Any(z => z.Role.RoleName != $"Руководитель {name}")).ToList();
            users = users.OrderBy(u => u.Fio).ToList();
            List<Explanation> explanations = await explanationsController.GetExplanations();
            CreateTable(name, user, ex, score, polls, scores, users, explanations);
            //CreateQuarter();

            string recipientEmail = email;
            string senderEmail = "makarov0xi4g@rambler.ru";
            string smtpServer = "smtp.rambler.ru";
            int smtpPort = 587;
            string filePath = $"Excel/{name}.xlsx";
            var message = new MailMessage(senderEmail, recipientEmail);
            Attachment attachment = new Attachment(filePath);
            message.Attachments.Add(attachment);
            using (var client = new SmtpClient(smtpServer, smtpPort))
            {
                client.Credentials = new NetworkCredential(senderEmail, "K8sUUTBK325fGm");
                client.EnableSsl = true;
                client.Send(message);
            }
            return Ok();
        }


        public async Task CreateTable(string name, User user, List<Explanation> ex, List<Score> score, List<Poll> polls, List<Score> scores, List<User> users, List<Explanation> explanations)
        {
            DateTime now = DateTime.Now;
            int month = now.Month;
            int year = now.Year;
            string filePath = $"Excel/{name}.xlsx";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            // проблема с созданием файла
            using (SpreadsheetDocument spreadsheetDocument
				= SpreadsheetDocument.Create
				(filePath, SpreadsheetDocumentType.Workbook))
            {
                #region Explanations
                Explanation ex1 = ex.FirstOrDefault(e => e.Month == 1) ?? new Explanation();
                Explanation ex2 = ex.FirstOrDefault(e => e.Month == 2) ?? new Explanation();
                Explanation ex3 = ex.FirstOrDefault(e => e.Month == 3) ?? new Explanation();
                Explanation ex4 = ex.FirstOrDefault(e => e.Month == 4) ?? new Explanation();
                Explanation ex5 = ex.FirstOrDefault(e => e.Month == 5) ?? new Explanation();
                Explanation ex6 = ex.FirstOrDefault(e => e.Month == 6) ?? new Explanation();
                Explanation ex7 = ex.FirstOrDefault(e => e.Month == 7) ?? new Explanation();
                Explanation ex8 = ex.FirstOrDefault(e => e.Month == 8) ?? new Explanation();
                Explanation ex9 = ex.FirstOrDefault(e => e.Month == 9) ?? new Explanation();
                Explanation ex10 = ex.FirstOrDefault(e => e.Month == 10) ?? new Explanation();
                Explanation ex11 = ex.FirstOrDefault(e => e.Month == 11) ?? new Explanation();
                Explanation ex12 = ex.FirstOrDefault(e => e.Month == 12) ?? new Explanation();
                #endregion
                #region Scores
                Score score1 = new Score();
                Score score2 = new Score();
                Score score3 = new Score();
                Score score4 = new Score();
                Score score5 = new Score();
                Score score6 = new Score();
                Score score7 = new Score();
                Score score8 = new Score();
                Score score9 = new Score();
                Score score10 = new Score();
                Score score11 = new Score();
                Score score12 = new Score();
                if (score.Count != 0)
                {
                    score1 = score.FirstOrDefault(e => e.Month == 1) ?? new Score();
                    score2 = score.FirstOrDefault(e => e.Month == 2) ?? new Score();
                    score3 = score.FirstOrDefault(e => e.Month == 3) ?? new Score();
                    score4 = score.FirstOrDefault(e => e.Month == 4) ?? new Score();
                    score5 = score.FirstOrDefault(e => e.Month == 5) ?? new Score();
                    score6 = score.FirstOrDefault(e => e.Month == 6) ?? new Score();
                    score7 = score.FirstOrDefault(e => e.Month == 7) ?? new Score();
                    score8 = score.FirstOrDefault(e => e.Month == 8) ?? new Score();
                    score9 = score.FirstOrDefault(e => e.Month == 9) ?? new Score();
                    score10 = score.FirstOrDefault(e => e.Month == 10) ?? new Score();
                    score11 = score.FirstOrDefault(e => e.Month == 11) ?? new Score();
                    score12 = score.FirstOrDefault(e => e.Month == 12) ?? new Score();
                }
                #endregion
                #region List<Explanation>
                List<Explanation> explanations1 = new List<Explanation>();
                List<Explanation> explanations2 = new List<Explanation>();
                List<Explanation> explanations3 = new List<Explanation>();
                List<Explanation> explanations4 = new List<Explanation>();
                List<Explanation> explanations5 = new List<Explanation>();
                List<Explanation> explanations6 = new List<Explanation>();
                List<Explanation> explanations7 = new List<Explanation>();
                List<Explanation> explanations8 = new List<Explanation>();
                List<Explanation> explanations9 = new List<Explanation>();
                List<Explanation> explanations10 = new List<Explanation>();
                List<Explanation> explanations11 = new List<Explanation>();
                List<Explanation> explanations12 = new List<Explanation>();
                if (explanations.Count != 0)
                {
                    explanations1 = await explanationsController.GetExplanationsByMY(1, year);
                    explanations2 = await explanationsController.GetExplanationsByMY(2, year);
                    explanations3 = await explanationsController.GetExplanationsByMY(3, year);
                    explanations4 = await explanationsController.GetExplanationsByMY(4, year);
                    explanations5 = await explanationsController.GetExplanationsByMY(5, year);
                    explanations6 = await explanationsController.GetExplanationsByMY(6, year);
                    explanations7 = await explanationsController.GetExplanationsByMY(7, year);
                    explanations8 = await explanationsController.GetExplanationsByMY(8, year);
                    explanations9 = await explanationsController.GetExplanationsByMY(9, year);
                    explanations10 = await explanationsController.GetExplanationsByMY(10, year);
                    explanations11 = await explanationsController.GetExplanationsByMY(11, year);
                    explanations12 = await explanationsController.GetExplanationsByMY(12, year);
                }
                #endregion
                #region List<Poll>
                List<Poll> polls1 = new List<Poll>();
                List<Poll> polls2 = new List<Poll>();
                List<Poll> polls3 = new List<Poll>();
                List<Poll> polls4 = new List<Poll>();
                List<Poll> polls5 = new List<Poll>();
                List<Poll> polls6 = new List<Poll>();
                List<Poll> polls7 = new List<Poll>();
                List<Poll> polls8 = new List<Poll>();
                List<Poll> polls9 = new List<Poll>();
                List<Poll> polls10 = new List<Poll>();
                List<Poll> polls11 = new List<Poll>();
                List<Poll> polls12 = new List<Poll>();
                if (polls.Count != 0)
                {
                    polls1 = await pollsController.GetPollsByMY(1, year);
                    polls2 = await pollsController.GetPollsByMY(2, year);
                    polls3 = await pollsController.GetPollsByMY(3, year);
                    polls4 = await pollsController.GetPollsByMY(4, year);
                    polls5 = await pollsController.GetPollsByMY(5, year);
                    polls6 = await pollsController.GetPollsByMY(6, year);
                    polls7 = await pollsController.GetPollsByMY(7, year);
                    polls8 = await pollsController.GetPollsByMY(8, year);
                    polls9 = await pollsController.GetPollsByMY(9, year);
                    polls10 = await pollsController.GetPollsByMY(10, year);
                    polls11 = await pollsController.GetPollsByMY(11, year);
                    polls12 = await pollsController.GetPollsByMY(12, year);
                }
                #endregion
                #region List<Score>
                List<Score> scores1 = new List<Score>();
                List<Score> scores2 = new List<Score>();
                List<Score> scores3 = new List<Score>();
                List<Score> scores4 = new List<Score>();
                List<Score> scores5 = new List<Score>();
                List<Score> scores6 = new List<Score>();
                List<Score> scores7 = new List<Score>();
                List<Score> scores8 = new List<Score>();
                List<Score> scores9 = new List<Score>();
                List<Score> scores10 = new List<Score>();
                List<Score> scores11 = new List<Score>();
                List<Score> scores12 = new List<Score>();
                if(scores.Count != 0)
                {
                    scores1 = await scoresController.GetScoreByMY(1, year);
                    scores2 = await scoresController.GetScoreByMY(2, year);
                    scores3 = await scoresController.GetScoreByMY(3, year);
                    scores4 = await scoresController.GetScoreByMY(4, year);
                    scores5 = await scoresController.GetScoreByMY(5, year);
                    scores6 = await scoresController.GetScoreByMY(6, year);
                    scores7 = await scoresController.GetScoreByMY(7, year);
                    scores8 = await scoresController.GetScoreByMY(8, year);
                    scores9 = await scoresController.GetScoreByMY(9, year);
                    scores10 = await scoresController.GetScoreByMY(10, year);
                    scores11 = await scoresController.GetScoreByMY(11, year);
                    scores12 = await scoresController.GetScoreByMY(12, year);
                }
                #endregion

                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
				workbookPart.Workbook = new Workbook();
				
				#region Создание страниц
				Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
				#region Страницы
				Sheet month1 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 1,
					Name = "Январь"
				};
				Sheet month2 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 2,
					Name = "Ферваль"
				};
				Sheet month3 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 3,
					Name = "Март"
				};
				Sheet month4 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 4,
					Name = "Апрель"
				};
				Sheet month5 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 5,
					Name = "Май"
				};
				Sheet month6 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 6,
					Name = "Июнь"
				};
				Sheet month7 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 7,
					Name = "Июль"
				};
				Sheet month8 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 8,
					Name = "Август"
				};
				Sheet month9 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 9,
					Name = "Сентябрь"
				};
				Sheet month10 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 10,
					Name = "Октябрь"
				};
				Sheet month11 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 11,
					Name = "Ноябрь"
				};
				Sheet month12 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 12,
					Name = "Декабрь"
				};
				Sheet quarter1 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 13,
					Name = "1 квартал"
				};
				Sheet quarter2 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 14,
					Name = "2 квартал"
				};
				Sheet quarter3 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 15,
					Name = "3 квартал"
				};
				Sheet quarter4 = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 16,
					Name = "4 квартал"
				};
				Sheet yearS = new Sheet()
				{
					Id = workbookPart
					.GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
					SheetId = 17,
					Name = "Год"
				};
				#endregion

				sheets.Append(month1);
				sheets.Append(month2);
				sheets.Append(month3);
				sheets.Append(month4);
				sheets.Append(month5);
				sheets.Append(month6);
				sheets.Append(month7);
				sheets.Append(month8);
				sheets.Append(month9);
				sheets.Append(month10);
				sheets.Append(month11);
				sheets.Append(month12);
				sheets.Append(quarter1);
				sheets.Append(quarter2);
				sheets.Append(quarter3);
				sheets.Append(quarter4);
				sheets.Append(yearS);

				#endregion

				#region Месяцы
				HeaderTable.CreateHeader(workbookPart, month1.Id, user, users, ex1, explanations1, polls1, score1, scores1, 1, year);
				HeaderTable.CreateHeader(workbookPart, month2.Id, user, users, ex2, explanations2, polls2, score2, scores2, 2, year);
				HeaderTable.CreateHeader(workbookPart, month3.Id, user, users, ex3, explanations3, polls3, score3, scores3, 3, year);
				HeaderTable.CreateHeader(workbookPart, month4.Id, user, users, ex4, explanations4, polls4, score4, scores4, 4, year);
				HeaderTable.CreateHeader(workbookPart, month5.Id, user, users, ex5, explanations5, polls5, score5, scores5, 5, year);
				HeaderTable.CreateHeader(workbookPart, month6.Id, user, users, ex6, explanations6, polls6, score6, scores6, 6, year);
				HeaderTable.CreateHeader(workbookPart, month7.Id, user, users, ex7, explanations7, polls7, score7, scores7, 7, year);
				HeaderTable.CreateHeader(workbookPart, month8.Id, user, users, ex8, explanations8, polls8, score8, scores8, 8, year);
				HeaderTable.CreateHeader(workbookPart, month9.Id, user, users, ex9, explanations9, polls9, score9, scores9, 9, year);
				HeaderTable.CreateHeader(workbookPart, month10.Id, user, users, ex10, explanations10, polls10, score10, scores10, 10, year);
				HeaderTable.CreateHeader(workbookPart, month11.Id, user, users, ex11, explanations11, polls11, score11, scores11, 11, year);
				HeaderTable.CreateHeader(workbookPart, month12.Id, user, users, ex12, explanations12, polls12, score12, scores12, 12, year);
                #endregion

                #region Кварталы
                quarterHeaderTable.CreateHeader(workbookPart, quarter1.Id, user, users, 13);
                quarterHeaderTable.CreateHeader(workbookPart, quarter2.Id, user, users, 14);
                quarterHeaderTable.CreateHeader(workbookPart, quarter3.Id, user, users, 15);
                quarterHeaderTable.CreateHeader(workbookPart, quarter4.Id, user, users, 16);
                quarterHeaderTable.CreateHeader(workbookPart, yearS.Id, user, users, 17);
				#endregion

				spreadsheetDocument.WorkbookPart.Workbook.Save(); 
				spreadsheetDocument.Close();
			}
		}


        public async void CreateQuarter()
        {
            string filePath = "Excel/Квартал.xlsx";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
            using (SpreadsheetDocument spreadsheetDocument
                = SpreadsheetDocument.Create
                (filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();
                #region Создание страниц
                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                #region Страницы
                Sheet all = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 1,
                    Name = "All"

                };
                Sheet firstQuarterITR = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 2,
                    Name = "1 квартал ИТР"

                };
                Sheet firstQuarterWorker = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 3,
                    Name = "1 квартал рабочие"

                };
                Sheet secondQuarterITR = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 4,
                    Name = "2 квартал ИТР"

                };
                Sheet secondQuarterWorker = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 5,
                    Name = "2 квартал рабочие"

                };
                Sheet thirdQuarterITR = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 6,
                    Name = "3 квартал ИТР"

                };
                Sheet thirdQuarterWorker = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 7,
                    Name = "3 квартал рабочие"

                };
                Sheet fourthQuarterITR = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 8,
                    Name = "4 квартал ИТР"

                };
                Sheet fourthQuarterWorker = new Sheet()
                {
                    Id = workbookPart
                    .GetIdOfPart(workbookPart.AddNewPart<WorksheetPart>()),
                    SheetId = 9,
                    Name = "4 квартал рабочие"

                };
                #endregion
                sheets.Append(all); 
				sheets.Append(firstQuarterITR);
                sheets.Append(firstQuarterWorker);
                sheets.Append(secondQuarterITR);
                sheets.Append(secondQuarterWorker);
                sheets.Append(thirdQuarterITR);
                sheets.Append(thirdQuarterWorker);
                sheets.Append(fourthQuarterITR);
                sheets.Append(fourthQuarterWorker);
                #endregion

                List<User> users = _context.Users
                    .Where(u => u.Division != null || u.Division != "").ToList();
                CreateAll.CreateSheet(workbookPart, all.Id, users);

            }
        }
    }
}
