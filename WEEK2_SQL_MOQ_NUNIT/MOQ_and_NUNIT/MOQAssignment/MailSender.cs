using System.Net;
using System.Net.Mail;

namespace MoqAssignment
{
    public class MailSender : IMailSender
    {
        public bool SendMail(string toAddress, string message)
        {
            try
            {
                using (var mail = new MailMessage())
                using (var smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    mail.From = new MailAddress("your_email@gmail.com");
                    mail.To.Add(toAddress);
                    mail.Subject = "Test Mail";
                    mail.Body = message;

                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential("username", "password");
                    smtpClient.EnableSsl = true;

                    smtpClient.Send(mail);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
