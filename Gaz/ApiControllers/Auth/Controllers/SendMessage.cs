using SerGaz.Controllers;
using System.Net.Mail;
using System.Net;

namespace Gaz.ApiControllers.Auth.Controllers
{
    public class SendMessage : BaseController
    {
        public static void WelcomeBack(string email, string fio)
        {
            if (email != null)
            {
                string recipientEmail = email;
                string senderEmail = "makarov0xi4g@rambler.ru";
                string smtpServer = "smtp.rambler.ru";
                int smtpPort = 587;
                using (var message = new MailMessage(senderEmail, recipientEmail))
                {
                    message.Subject = $"С возвращением, {fio}!";
                    
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
