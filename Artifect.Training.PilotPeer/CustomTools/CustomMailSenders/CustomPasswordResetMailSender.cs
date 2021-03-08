using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Arfitect.Training.PilotPeer.CustomTools.CustomMailSenders
{
    public static class CustomPasswordResetMailSender
    {
        public static void PasswordResetMailSender(string link, string email)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpClient = new SmtpClient("mail@arfitect.com");

            mail.From = new MailAddress("oguzhan.yilmaz@arfitect.com");
            mail.To.Add(email);

            mail.Subject = $"www.peerpilot.com Sifre sifirlama";
            mail.Body = "<h2>Sifrenizi yenilemek icin lutfen linke tiklayiniz. </h2><hr/>";
            mail.Body += $"<a href='{link}'>sifre yenileme linki </a>";
            mail.IsBodyHtml = true;
            smtpClient.Port = 587;
            smtpClient.Credentials = new NetworkCredential("ibrahimoguzhany@gmail.com", "199779");
            smtpClient.Send(mail);

        }
    }
}
