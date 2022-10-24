using MedicalService.Auth.Data;
using MedicalService.Authen.Common;
using MedicalService.Authen.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MedicalService.Authen.Service
{
    public class UserManagerService : UserManager<ApplicationUser>
    {
        public UserManagerService(
            IUserStore<ApplicationUser> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<ApplicationUser> passwordHasher,
            IEnumerable<IUserValidator<ApplicationUser>> userValidators,
            IEnumerable<IPasswordValidator<ApplicationUser>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors,
            IServiceProvider services,
            DbContextOptions<MedicalServiceIdentityDbContext> dbContext,
            ILogger<UserManager<ApplicationUser>> logger)
            : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
        {
        }

        public async Task<Result> ConfirmUserEmailAsync(Guid userId)
        {
            var result = new Result();
            var user = await GetUserByUserIdAsync(userId);
            if (user == null)
            {
                result.Message = "User does not exist";
                return result;
            }

            user.EmailConfirmed = true;
            await UpdateUserAsync(user);
            result.Succeeded = true;

            return result;
        }

        public async Task<ApplicationUser> GetUserByUserIdAsync(Guid userId)
        {
            return await FindByIdAsync(userId.ToString());
        }

        public async Task<ApplicationUser> RegisterUserAsync(UserModel user)
        {
            var identityUser = new ApplicationUser
            {
                Email = user.Email,
                UserName = "LLia",
                PasswordHash = user.Password,
            };

            var createResult = await CreateAsync(identityUser, user.Password);
            if (!createResult.Succeeded)
            {
                return null;
            }

            return identityUser;
        }
    }
}
