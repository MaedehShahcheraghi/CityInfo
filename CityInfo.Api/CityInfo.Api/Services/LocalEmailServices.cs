using System.Net;
using System.Net.Mail;

namespace CityInfo.Api.Services
{
    public class LocalEmailServices : IMailService
    {
        private readonly string _mailto = string.Empty;
        private readonly string _mailfrom = string.Empty;
        public LocalEmailServices(IConfiguration configuration)
        {
            _mailfrom = configuration["MailSetting:mailfromaddress"];
            _mailto = configuration["MailSetting:mailtoaddress"];
        }
        public void send(string subject, string message)
        {
            Console.WriteLine($"Mail  From {_mailfrom}  To {_mailto}  , "
                  + $"with {nameof(LocalEmailServices)}  ,  ");
            Console.WriteLine($" subject : {subject}");
            Console.WriteLine($"message : {message}");
        }

        public void Email(string subject, string htmlString
          , string to)
        {
            try
            {
                string _mailFrom = "maedeh.sh2005@gmail.com";
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(_mailFrom);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("maedeh.sh2005@gmail.com", "0110713486m");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception) { }
        }

    }
}
