using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using SerGaz.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Office2010.Excel;
using Gaz.Data;
using Gaz.Domain.Entities;
using System.Net.Mail;
using System.Net;

namespace Gaz.ApiControllers.Auth.Controllers
{
    [ApiController]
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class ChangePassword : BaseController
	{
		private readonly freedb_testdbgazContext _dbContext;
		public ChangePassword
			(freedb_testdbgazContext dbContext) =>
			_dbContext = dbContext;

		public static string EncryptPassword(string password)
		{
			byte[] data = Encoding.UTF8.GetBytes(password);
			data = new SHA256Managed().ComputeHash(data);
			return Encoding.ASCII.GetString(data);
		}

		[HttpPut(nameof(Change)), Authorize]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		public async Task<IActionResult> Change(string email, string oldpass, string newpass)
		{
			oldpass = EncryptPassword(oldpass);
			newpass = EncryptPassword(newpass);
			User user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == oldpass);
			user.Password = newpass;
			user.UpdatedAt = DateTime.Today;
			try
			{
				_dbContext.Users.Update(user);
				await _dbContext.SaveChangesAsync();
				SendEmail(user.Email);

            }
			catch (DbUpdateConcurrencyException)
			{
				throw;
			}
			return NoContent();
		}

        public static void SendEmail(string email)
        {
            if (email != null)
            {
                string recipientEmail = email;
                string senderEmail = "makarov0xi4g@rambler.ru";
                string smtpServer = "smtp.rambler.ru";
                int smtpPort = 587;
                using (var message = new MailMessage(senderEmail, recipientEmail))
                {
                    message.Subject = "Вы успешно сменили пароль!";
                   
                    using (var client = new SmtpClient(smtpServer, smtpPort))
                    {
                        client.Credentials = new NetworkCredential(senderEmail, "K8sUUTBK325fGm");
                        client.EnableSsl = true;
                        client.Send(message);
                    }
                }
            }
        }

    }
}
