using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract.SendMessage;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;
using System.Net;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Gaz.Domain.Repositories.EntityFramework.SendMessage.Headers;
using Gaz.Data;

namespace Gaz.Domain.Repositories.EntityFramework.SendMessage
{
    public class EFSendExselRepository : ISendExselRepository
	{
		private readonly freedb_testdbgazContext _context;

		public EFSendExselRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async void Send(string name, string email)
		{
			DateTime now = DateTime.Now;
			int month = now.Month;

			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.Type.TypeName == "Руководитель"
				&& u.Division == name);

			Explanation ex = null;
			if (user != null)
			{
				ex = await _context.Explanations
					.FirstOrDefaultAsync(e => e.UserId == user.Id
					&& e.Month == month);
			}

			CreateTable(name, user, ex);

			string recipientEmail = email;
			string senderEmail = "makarov0xi4g@rambler.ru";
			string smtpServer = "smtp.rambler.ru";
			int smtpPort = 587;
			string filePath = Environment
				.GetFolderPath(Environment.SpecialFolder.Desktop)
				+ @$"\{name}.xlsx";
			var message = new MailMessage(senderEmail, recipientEmail);
			Attachment attachment = new Attachment(filePath);
			message.Attachments.Add(attachment);
			using (var client = new SmtpClient(smtpServer, smtpPort))
			{
				client.Credentials = new NetworkCredential(senderEmail, "K8sUUTBK325fGm");
				client.EnableSsl = true;
				client.Send(message);
			}
		}
		public async void CreateTable(string name, User user, Explanation ex)
		{
			DateTime now = DateTime.Now;
			int month = now.Month;

			List<User> users = _context.Users
				.Where(u => u.Division == name).ToList();
			users = users.OrderBy(u => u.Fio).ToList();

			List<Explanation> explanations = _context.Explanations.ToList();
			List<Poll> polls = _context.Polls.ToList();

			string filePath = $@"C:\Users\{Environment.UserName}\Desktop\{name}.xlsx";
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
				Sheet year = new Sheet()
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
				sheets.Append(year);

				#endregion

				#region Месяцы
				HeaderTable.CreateHeader(workbookPart, month1.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month2.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month3.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month4.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month5.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month6.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month7.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month8.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month9.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month10.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month11.Id, user, users, ex, explanations, polls);
				HeaderTable.CreateHeader(workbookPart, month12.Id, user, users, ex, explanations, polls);
				#endregion

				#region Кварталы
				QuarterHeaderTable.CreateHeader(workbookPart, quarter1.Id, user, users);
				QuarterHeaderTable.CreateHeader(workbookPart, quarter2.Id, user, users);
				QuarterHeaderTable.CreateHeader(workbookPart, quarter3.Id, user, users);
				QuarterHeaderTable.CreateHeader(workbookPart, quarter4.Id, user, users);
				QuarterHeaderTable.CreateHeader(workbookPart, year.Id, user, users);
				#endregion

				spreadsheetDocument.WorkbookPart.Workbook.Save();
				spreadsheetDocument.Close();
			}
		}
	}
}
