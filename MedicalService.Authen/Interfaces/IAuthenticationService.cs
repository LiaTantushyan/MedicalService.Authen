using MedicalService.Auth.Data;
using MedicalService.Authen.Common;
using MedicalService.Authen.Models;

namespace MedicalService.Authen.Interfaces
{
    public interface IAuthService
    {
        Task<ApplicationUser> RegisterUserAsync(UserModel user);

        Task<ApplicationUser> GetUserByUserIdAsync(Guid userId);

        Task<Result> ConfirmUserEmailAsync(Guid userId);
            
    }
}
