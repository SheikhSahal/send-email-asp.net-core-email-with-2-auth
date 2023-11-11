using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MailKit.Net.Smtp;

namespace Email_send_ASP_dot_Core.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Project", "s.m.sahal789@gmail.com"));
            message.To.Add(new MailboxAddress("sahal", "s.m.sahal786@outlook.com"));
            message.Subject = "test mail";
            message.Body = new TextPart("plain")
            {
                Text = "Hellow world"
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("s.m.sahal789@gmail.com", "hfom icuw wphk ingj");
                client.Send(message);
                client.Disconnect(true);
            };

            return View();
        }
    }
}