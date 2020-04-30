using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace CMSD10DemoCode.Models.Services
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// Sends an email through SendGrid to required locations
        /// </summary>
        /// <param name="email">Who are we sending the email too</param>
        /// <param name="subject">Title of the Email</param>
        /// <param name="htmlMessage">HTML message contents of the email</param>
        /// <returns></returns>
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["SendGridKey"]);
            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("admin@busmall.com", "Site Admin");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);
        }
    }
}
