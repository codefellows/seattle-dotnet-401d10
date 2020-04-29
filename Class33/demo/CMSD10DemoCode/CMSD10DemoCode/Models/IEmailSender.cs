using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMSD10DemoCode.Models
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
