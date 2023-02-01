using Microsoft.Extensions.Options;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Threading.Tasks;
using System;

namespace IdentityUdemyCourse.Services
{
    public class EmailSender
    {
        private readonly TwoFactorOptions twoFactorOptions;
        private readonly TwoFactorService twoFactorService;

        public EmailSender(IOptions<TwoFactorOptions> twoFactorOptions, TwoFactorService twoFactorService)
        {
            this.twoFactorOptions = twoFactorOptions.Value;
            this.twoFactorService = twoFactorService;
        }
        public string Send(string email)
        {
            string code = twoFactorService.GetCodeVerification().ToString();
            Execute(email, code).Wait();
            return code;
        }
        private async Task Execute(string email, string code)
        {

            var client = new SendGridClient(twoFactorOptions.SendGrid_ApiKey);
            var from = new EmailAddress("emir_han886@outlook.com", "Honoso");
            var subject = "İki adımlı kimlik doğrulama kodu";
            var to = new EmailAddress(email);
            var htmlContent = $"<h2>Siteye giriş yapabilmek için  doğrulama kodunuz aşağıdadır.</h2><h3>Kodunuz:{code}</h3>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
