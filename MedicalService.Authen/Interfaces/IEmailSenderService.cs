namespace MedicalService.Authen.Interfaces
{
    public interface IEmailSenderService
    {
        Task SendVerificationEmailAsync(string emailTo, string content);
    }
}
