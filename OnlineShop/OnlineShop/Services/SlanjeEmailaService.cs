using MailKit.Security;
using MailKit.Net.Smtp;
using MimeKit;
using OnlineShop.Common;
using System.Runtime;
using Org.BouncyCastle.Asn1.Pkcs;


namespace OnlineShop.Services
{
    public class SlanjeEmailaService : ISlanjeEmailaService
    {
        private readonly IConfiguration config;
        public SlanjeEmailaService(IConfiguration configg)
        {
            this.config = configg;
        }
        public async Task EmailObavestenje(string verifikovan, string email)
        {
            string html = "<h1>" + "Vasa verifikacija je " + verifikovan + "</h1>";

            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress(config.GetValue<string>("MailSettings:DisplayName"), config.GetValue<string>("MailSettings:From")));
            mail.To.Add(MailboxAddress.Parse(email));

            mail.Subject = "Verifikacija";

            var builder = new BodyBuilder();
            builder.HtmlBody = html;
            mail.Body = builder.ToMessageBody();

            SmtpClient smtp = new SmtpClient();
            await smtp.ConnectAsync(config.GetValue<string>("MailSettings:Host"), int.Parse(config.GetValue<string>("MailSettings:Port")!), SecureSocketOptions.Auto);
            await smtp.AuthenticateAsync(config.GetValue<string>("MailSettings:From"), config.GetValue<string>("MailSettings:Password"));
            await smtp.SendAsync(mail);
            await smtp.DisconnectAsync(true);

        }
    }
}
