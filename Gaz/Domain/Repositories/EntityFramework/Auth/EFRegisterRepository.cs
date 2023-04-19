using Gaz.Domain.Entities;
using Gaz.Domain.Repositories.Abstract.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Gaz.Data;

namespace Gaz.Domain.Repositories.EntityFramework.Auth
{
    public class EFRegisterRepository : IRegisterRepository
	{
		private readonly freedb_testdbgazContext _context;

		public EFRegisterRepository(freedb_testdbgazContext context)
			=> _context = context;

		public async Task<ActionResult<User>> Register(User entity)
		{
			string password = GeneratePassword();
			entity.Password = password;
			SendEmail(entity.Email, entity.Password);
			entity.Password = EncryptPassword(entity.Password);
			var user = new User
			{
				Fio = entity.Fio,
				ServiceNumber = entity.ServiceNumber,
				Division = entity.Division,
				Position = entity.Position,
				TypeId = entity.TypeId,
				Type = await _context.Onetypes.FirstOrDefaultAsync(t => t.Id == entity.TypeId),
				Email = entity.Email,
				Password = entity.Password,
				CreatedAt = DateTime.Today
			};
			_context.Add(user);
			_context.SaveChanges();
			return user;
		}

		public static string GeneratePassword()
		{
			int length = 13;
			const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+-=[]{}|;:,.<>?";

			var random = new Random();

			var bytes = new byte[length];
			using (var rng = new RNGCryptoServiceProvider())
			{
				rng.GetBytes(bytes);
			}

			var result = new char[length];
			for (int i = 0; i < length; i++)
			{
				result[i] = validChars[bytes[i] % validChars.Length];
			}

			return new string(result);
		}

		public static string EncryptPassword(string password)
		{
			byte[] data = Encoding.UTF8.GetBytes(password);
			data = new SHA256Managed().ComputeHash(data);
			return Encoding.ASCII.GetString(data);
		}

		public static void SendEmail(string email, string password)
		{
			if (email != null)
			{
				string recipientEmail = email;
				string senderEmail = "makarov0xi4g@rambler.ru";
				string smtpServer = "smtp.rambler.ru";
				int smtpPort = 587;
				using (var message = new MailMessage(senderEmail, recipientEmail))
				{
					message.Subject = "Добро пожаловать!";
					message.Body = "Электронный адрес для Вашей учетной записи: "
						+ email
						+ ". Ваш пароль: "
						+ password
						+ " . Пароль сгенерирован авторатически! " +
						"В целях безопасности Вашей учетной записи, пожалуйста, не раскрывайте ее никому и смените пароль!";

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
