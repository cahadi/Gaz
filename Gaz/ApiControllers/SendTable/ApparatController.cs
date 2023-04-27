using DocumentFormat.OpenXml;
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

namespace SerGaz.SendTable
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class ApparatController : ControllerBase
	{
		private readonly freedb_testdbgazContext _context;

		public ApparatController(freedb_testdbgazContext context)
		{
			_context = context;
		}

		[HttpPost(nameof(Send))]
		public async Task<IActionResult> Send(string name, string email)
		{
			DateTime now = DateTime.Now;
			int month = now.Month;
			int year = now.Year;

			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.Type.TypeName == "Руководитель"
				&& u.Division == name);

            List<Explanation> ex = new List<Explanation>();
            List<Score> score = new List<Score>();
            if (user != null)
			{
				ex = await _context.Explanations
					.Where(e => e.UserId == user.Id 
					&& e.Year == year).ToListAsync();
				score = await _context.Scores
					.Where(s=>s.UserId == user.Id
					&& s.Year == year).ToListAsync();
			}

			CreateTable(name, user, ex, score); 

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


		public async void CreateTable(string name, User user, List<Explanation> ex, List<Score> score)
		{
			DateTime now = DateTime.Now;
			int month = now.Month;
			int year = now.Year;
			List<User> users = _context.Users
				.Where(u => u.Division == name).ToList();
			users = users.OrderBy(u => u.Fio).ToList();


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

            Score score1 = score.FirstOrDefault(e => e.Month == 1) ?? new Score();
            Score score2 = score.FirstOrDefault(e => e.Month == 2) ?? new Score();
            Score score3 = score.FirstOrDefault(e => e.Month == 3) ?? new Score();
            Score score4 = score.FirstOrDefault(e => e.Month == 4) ?? new Score();
            Score score5 = score.FirstOrDefault(e => e.Month == 5) ?? new Score();
            Score score6 = score.FirstOrDefault(e => e.Month == 6) ?? new Score();
            Score score7 = score.FirstOrDefault(e => e.Month == 7) ?? new Score();
            Score score8 = score.FirstOrDefault(e => e.Month == 8) ?? new Score();
            Score score9 = score.FirstOrDefault(e => e.Month == 9) ?? new Score();
            Score score10 = score.FirstOrDefault(e => e.Month == 10) ?? new Score();
            Score score11 = score.FirstOrDefault(e => e.Month == 11) ?? new Score();
            Score score12 = score.FirstOrDefault(e => e.Month == 12) ?? new Score();

            List<Explanation> explanations1 = _context.Explanations
				.Include("User").Where(e=>e.Month == 1 && 
				e.Year == year).ToList();
            List<Explanation> explanations2 = _context.Explanations
                .Include("User").Where(e => e.Month == 2 &&
                e.Year == year).ToList();
            List<Explanation> explanations3 = _context.Explanations
                .Include("User").Where(e => e.Month == 3 &&
                e.Year == year).ToList();
            List<Explanation> explanations4 = _context.Explanations
                .Include("User").Where(e => e.Month == 4 &&
                e.Year == year).ToList();
            List<Explanation> explanations5 = _context.Explanations
                .Include("User").Where(e => e.Month == 5 &&
                e.Year == year).ToList();
            List<Explanation> explanations6 = _context.Explanations
                .Include("User").Where(e => e.Month == 6 &&
                e.Year == year).ToList();
            List<Explanation> explanations7 = _context.Explanations
                .Include("User").Where(e => e.Month == 7 &&
                e.Year == year).ToList();
            List<Explanation> explanations8 = _context.Explanations
                .Include("User").Where(e => e.Month == 8 &&
                e.Year == year).ToList();
            List<Explanation> explanations9 = _context.Explanations
                .Include("User").Where(e => e.Month == 9 &&
                e.Year == year).ToList();
            List<Explanation> explanations10 = _context.Explanations
                .Include("User").Where(e => e.Month == 10 &&
                e.Year == year).ToList();
            List<Explanation> explanations11 = _context.Explanations
                .Include("User").Where(e => e.Month == 11 &&
                e.Year == year).ToList();
            List<Explanation> explanations12 = _context.Explanations
                .Include("User").Where(e => e.Month == 12 &&
                e.Year == year).ToList();


            List<Poll> polls1 = _context.Polls.Include("EstimationsMarks")
				.Include("EstimationsMarks.Mark").Where(p=>p.Month == 1 && 
				p.Year == year).ToList();
            List<Poll> polls2 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 2 &&
                p.Year == year).ToList();
            List<Poll> polls3 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 3 &&
                p.Year == year).ToList();
            List<Poll> polls4 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 4 &&
                p.Year == year).ToList();
            List<Poll> polls5 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 5 &&
                p.Year == year).ToList();
            List<Poll> polls6 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 6 &&
                p.Year == year).ToList();
            List<Poll> polls7 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 7 &&
                p.Year == year).ToList();
            List<Poll> polls8 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 8 &&
                p.Year == year).ToList();
            List<Poll> polls9 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 9 &&
                p.Year == year).ToList();
            List<Poll> polls10 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 10 &&
                p.Year == year).ToList();
            List<Poll> polls11 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 11 &&
                p.Year == year).ToList();
            List<Poll> polls12 = _context.Polls.Include("EstimationsMarks")
                .Include("EstimationsMarks.Mark").Where(p => p.Month == 12 &&
                p.Year == year).ToList();

			List<Score> scores1 = _context.Scores.Include("User")
				.Where(s => s.Month == 1 && s.Year == year).ToList();
            List<Score> scores2 = _context.Scores.Include("User")
                .Where(s => s.Month == 2 && s.Year == year).ToList();
            List<Score> scores3 = _context.Scores.Include("User")
                .Where(s => s.Month == 3 && s.Year == year).ToList();
            List<Score> scores4 = _context.Scores.Include("User")
                .Where(s => s.Month == 4 && s.Year == year).ToList();
            List<Score> scores5 = _context.Scores.Include("User")
                .Where(s => s.Month == 5 && s.Year == year).ToList();
            List<Score> scores6 = _context.Scores.Include("User")
                .Where(s => s.Month == 6 && s.Year == year).ToList();
            List<Score> scores7 = _context.Scores.Include("User")
                .Where(s => s.Month == 7 && s.Year == year).ToList();
            List<Score> scores8 = _context.Scores.Include("User")
                .Where(s => s.Month == 8 && s.Year == year).ToList();
            List<Score> scores9 = _context.Scores.Include("User")
                .Where(s => s.Month == 9 && s.Year == year).ToList();
            List<Score> scores10 = _context.Scores.Include("User")
                .Where(s => s.Month == 10 && s.Year == year).ToList();
            List<Score> scores11 = _context.Scores.Include("User")
                .Where(s => s.Month == 11 && s.Year == year).ToList();
            List<Score> scores12 = _context.Scores.Include("User")
                .Where(s => s.Month == 12 && s.Year == year).ToList();

            string filePath = $"Excel/{name}.xlsx";
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
				HeaderTable.CreateHeader(workbookPart, month1.Id, user, users, ex1, explanations1, polls1, score1, scores1);
				HeaderTable.CreateHeader(workbookPart, month2.Id, user, users, ex2, explanations2, polls2, score2, scores1);
				HeaderTable.CreateHeader(workbookPart, month3.Id, user, users, ex3, explanations3, polls3, score3, scores1);
				HeaderTable.CreateHeader(workbookPart, month4.Id, user, users, ex4, explanations4, polls4, score4, scores1);
				HeaderTable.CreateHeader(workbookPart, month5.Id, user, users, ex5, explanations5, polls5, score5, scores1);
				HeaderTable.CreateHeader(workbookPart, month6.Id, user, users, ex6, explanations6, polls6, score6, scores1);
				HeaderTable.CreateHeader(workbookPart, month7.Id, user, users, ex7, explanations7, polls7, score7, scores1);
				HeaderTable.CreateHeader(workbookPart, month8.Id, user, users, ex8, explanations8, polls8, score8, scores1);
				HeaderTable.CreateHeader(workbookPart, month9.Id, user, users, ex9, explanations9, polls9, score9, scores1);
				HeaderTable.CreateHeader(workbookPart, month10.Id, user, users, ex10, explanations10, polls10, score10, scores1);
				HeaderTable.CreateHeader(workbookPart, month11.Id, user, users, ex11, explanations11, polls11, score11, scores1);
				HeaderTable.CreateHeader(workbookPart, month12.Id, user, users, ex12, explanations12, polls12, score12, scores1);
				#endregion

				#region Кварталы
				QuarterHeaderTable.CreateHeader(workbookPart, quarter1.Id, user, users);
				QuarterHeaderTable.CreateHeader(workbookPart, quarter2.Id, user, users);
				QuarterHeaderTable.CreateHeader(workbookPart, quarter3.Id, user, users);
				QuarterHeaderTable.CreateHeader(workbookPart, quarter4.Id, user, users);
				QuarterHeaderTable.CreateHeader(workbookPart, yearS.Id, user, users);
				#endregion

				spreadsheetDocument.WorkbookPart.Workbook.Save(); 
				spreadsheetDocument.Close();
			}
		}
	}
}
