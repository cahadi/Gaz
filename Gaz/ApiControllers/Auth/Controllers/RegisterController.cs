using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SerGaz.Controllers;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Gaz.Data;
using Gaz.Domain.Entities;
using static System.Net.WebRequestMethods;

namespace Gaz.ApiControllers.Auth.Controllers
{
    //ВСЁ РАБОТАЕТ ПО ЗАДУМКЕ!!! 
    //НИЧЕГО НЕ МЕНЯЙ
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RegisterController : BaseController
    {
        private readonly freedb_testdbgazContext _dbContext;
        public RegisterController
            (freedb_testdbgazContext dbContext) =>
            _dbContext = dbContext;

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

        [HttpPost(nameof(Register)), Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<User> Register(User model)
        {
            string password = GeneratePassword();
            model.Password = password;
            SendEmail(model.Email, model.Password);
            model.Password = EncryptPassword(model.Password);

            var user = new User
            {
                Fio = model.Fio,
                ServiceNumber = model.ServiceNumber,
                Division = model.Division,
                Position = model.Position,
                TypeId = model.TypeId,
                Type = await _dbContext.Onetypes.FirstOrDefaultAsync(t => t.Id == model.TypeId),
                Email = model.Email,
                Password = model.Password,
                CreatedAt = DateTime.Today
            };
            _dbContext.Add(user);
            _dbContext.SaveChanges();

            var result = user;
            return user;
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
                        "В целях безопасности Вашей учетной записи, пожалуйста, не раскрывайте ее никому и смените пароль! " + 
                        $"http://nameee-001-site1.itempurl.com/AUTH/LOGIN";

                    using (var client = new SmtpClient(smtpServer, smtpPort))
                    {
                        client.Credentials = new NetworkCredential(senderEmail, "K8sUUTBK325fGm");
                        client.EnableSsl = true;
                        client.Send(message);
                    }
                }
            }
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
