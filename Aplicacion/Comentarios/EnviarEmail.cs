
using Microsoft.Data.SqlClient.DataClassification;
using System.Net;
using System.Net.Mail;


namespace Aplicacion.Comentarios
{
    public class EnviarEmail
    {
        public void SendEmail(string FromEmail, string FromName, string body)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("yairsienra@gmail.com");
            mail.From = new MailAddress(FromEmail);
            mail.Subject = FromName;
            mail.Body = body+" "+FromEmail;
            mail.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; 
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("yairsienra@gmail.com", "sadsksszpsjnbhdn");
            smtp.Send(mail);

        }
    }
}
        
    

