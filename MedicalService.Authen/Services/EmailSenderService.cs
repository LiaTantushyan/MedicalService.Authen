using MedicalService.Authen.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using System.Net.Mail;
using System.Net;
using MedicalService.Authen.Common;

namespace MedicalService.Authen.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public async Task SendVerificationEmailAsync(string emailTo, string link)
        {
            //TODO: separate credentials sending and authorizing for email sending to private method and use this method for only link-based message constructing
            //TODO: set credentials from appsettings.json (hint: search for IOptions<T> and make your own class for EmailOptions)
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("onlinereservationservice@gmail.com");
                message.To.Add(emailTo);
                message.Subject = "Confirm your email";
                message.IsBodyHtml = true;
                message.Body = $"To confirm your email click this link {Environment.NewLine} <a href={link}>Confirm Registration</a>";
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("onlinereservationservice@gmail.com", "rratohzwgaqpjciy");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
