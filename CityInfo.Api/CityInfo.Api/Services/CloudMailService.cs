namespace CityInfo.Api.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailto = string.Empty;
        private readonly string _mailfrom = string.Empty;
        public CloudMailService(IConfiguration configuration)
        {
            _mailfrom = configuration["MailSetting:mailfromaddress"];
            _mailto = configuration["MailSetting:mailtoaddress"];
        }
        public void send(string subject, string message)
        {
            Console.WriteLine($"Mail  From {_mailfrom}  To {_mailto}  , "
                  + $"with {nameof(CloudMailService)}  ,  ");
            Console.WriteLine($" subject : {subject}");
            Console.WriteLine($"message : {message}");
        }
    }
}
