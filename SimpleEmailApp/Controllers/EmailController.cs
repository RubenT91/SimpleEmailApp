using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace SimpleEmailApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(string Body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("Ruben@adatumtapia.onmicrosoft.com"));
            email.To.Add(MailboxAddress.Parse("Ruben@adatumtapia.onmicrosoft.com"));
            email.Subject = "Test Email Subject";
            email.Body = new TextPart(TextFormat.Html) { Text = Body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.office365.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("ruben@adatumtapia.onmicrosoft.com", "Chuter91$");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok(smtp);
        }
    }
}