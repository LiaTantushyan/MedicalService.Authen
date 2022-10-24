using MedicalService.Auth.Data;
using MedicalService.Authen.Interfaces;
using MedicalService.Authen.Service;
using MedicalService.Authen.Services;

namespace MedicalService.Authen.Extensions
{
    public static class ServicesExtensions
    {
        public static void AddEmailSender(this IServiceCollection services)
        {
            services.AddScoped<IEmailSenderService, EmailSenderService>();
        }
    }
}
