using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Google_Calendar_API.Models;

namespace Google_Calendar_API.Service
{
    public class EmailService : IEmailService
    {
        private SmtpClient _smtpClient;
        public EmailService()
        {
            _smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("mail", "pass"),
                EnableSsl = true,
            };
        }
        public void SendEmail(string mail,EventDTO eventDTO)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress("eng.ahmed9466@gmail.com"),
                Subject = "New Event is Created",
                Body = $"<div>" +
                $"<h1>Event Creaated</h1>" +
                $"<label>Event</label><h3>{eventDTO.Title}</h3>" +
                $"</div>",
                IsBodyHtml = true,
            };
            mailMessage.To.Add(mail);

            _smtpClient.Send(mailMessage);
            
        }
    }
}
