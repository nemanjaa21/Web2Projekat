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
        public SlanjeEmailaService(IConfiguration config)
        {
            this.config = config;
        }
        public async Task EmailObavestenje(string verifikovan, string email)
        {
            try
            {
                string text = $"Vasa verifikacija je {verifikovan}";
                var mail = new MimeMessage
                {
                    Subject = "Verifikacija",
                    Body = new TextPart(MimeKit.Text.TextFormat.Plain) { Text = text }
                };


                mail.From.Add(new MailboxAddress(config.GetValue<string>("MailSettings:DisplayName"), config.GetValue<string>("MailSettings:From")));
                mail.To.Add(MailboxAddress.Parse(email));

                SmtpClient smtp = new SmtpClient();
                await smtp.ConnectAsync(config["MailSettings:Host"], int.Parse(config["MailSettings:Port"]!), SecureSocketOptions.Auto);
                string s = config["MailSettings:From"] + " " + config["MailSettings:Password"];
                await smtp.AuthenticateAsync(config["MailSettings:From"], config["MailSettings:Password"]);
                await smtp.SendAsync(mail);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Exception during email sending: " + ex.Message);
                // You can also log the full exception details and stack trace for further debugging
            }

        }
    }
}
