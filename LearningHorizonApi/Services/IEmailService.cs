namespace LearningHorizonApi.Services
{
    public interface IEmailService
    {
        void SendEmailAsync(string email, string subject, string link);
    }
}
