using Microsoft.Extensions.Configuration;

namespace MailingService
{
    public class Mailing
    {
        private static string mailAccount = "";
        private static string mailPassword = "";
        private static string mailTitle = "";
        private static string pop3Host = "";
        private static int pop3Port;

        public Mailing(IConfiguration configuration)
        {
            mailAccount = configuration["MailInfo:Account"];
            mailPassword = configuration["MailInfo:Password"];
            mailTitle = configuration["MailInfo:Title"];
            pop3Host = configuration["MailInfo:Pop3Host"];
            pop3Port = int.Parse(configuration["MailInfo:Pop3Port"]);
        }


        public static bool Send(string mailAddresses, string mailContent)
        {
            try
            {
                System.Net.NetworkCredential cred = new System.Net.NetworkCredential(mailAccount, mailPassword);

                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                mail.From = new System.Net.Mail.MailAddress(mailAccount, mailTitle);
                mail.To.Add(mailAddresses);
                mail.Subject = "";
                mail.IsBodyHtml = true;
                mail.Body = mailContent;
                mail.Attachments.Clear();


                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(pop3Host, pop3Port);
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = true;
                smtp.Credentials = cred;
                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
