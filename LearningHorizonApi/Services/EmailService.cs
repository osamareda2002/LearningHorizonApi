using MimeKit;

namespace LearningHorizonApi.Services
{
    public class EmailService : IEmailService
    {
        public void SendEmailAsync(string email, string subject, string link)
        {
            var mail = "osama.reda.abdelghany@gmail.com";
            var pw = "rzwl fkwa jlyd miuy";

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("learningHorizon", "osama.reda.abdelghany@gmail.com"));
            message.To.Add(new MailboxAddress("", email));
            message.Subject = "Reset password";
            message.Body = new TextPart("plain")
            {
                Text = $"click on this link to reset your password \n {link}"
            };

            string result = "";
            try
            {
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    client.Authenticate(mail, pw);
                    client.Send(message);
                    client.Disconnect(true);
                }
                result = "Email sent successfully.";
            }
            catch (Exception ex)
            {
                result = $"An error occurred while sending email: {ex.Message}";
            }
        }
    }
}
