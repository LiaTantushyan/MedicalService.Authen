using MedicalService.Auth.Data;
using MedicalService.Authen.Common;
using MedicalService.Authen.Extensions;
using MedicalService.Authen.Helpers;
using MedicalService.Authen.Interfaces;
using MedicalService.Authen.Models;
using MedicalService.Authen.Service;
using Microsoft.AspNetCore.Mvc;

namespace MedicalService.Authen.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserManagerController : Controller
    {
        private readonly UserManagerService _auth;
        private readonly IEmailSenderService _emailSender;
        private readonly IConfiguration _configuration; 
        
        public UserManagerController(
            UserManagerService auth,
            IEmailSenderService emailSender,
            IConfiguration configuration)
        {
            _auth = auth;
            _emailSender = emailSender;
            _configuration = configuration; 
        }

        [HttpGet]
        public async Task<IActionResult> RequestEmailConfirmation(string email)
        {
            var result = new Result();
            if (string.IsNullOrEmpty(email)
                || email.StartsWith(" ")
                || email.EndsWith(" ")
                || !email.IsValidEmail())
            {
                result.Message = "Invalid incoming parameter";
                return Json(result);
            }

            var user = await _auth.RegisterUserAsync(new UserModel
            {
                Email = email,
                UserName = TextGenerator.GenerateRandomText(10),
                Password = "123456Aa?"
            });

            if (user == null)
            {
                result.Message = $"Error while saving user {email}";
                return Json(result);
            }

            string requestHost = _configuration["MedicalServiceIdentityHost"];
            string linkConfirm = $"{requestHost}{RouteData.Values["controller"].ToString()}/VerifyUser?userId={user.Id}";
            await _emailSender.SendVerificationEmailAsync(email, linkConfirm);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> VerifyUser(Guid userId)
        {
            var result = new Result();

            var user = await _auth.GetUserByUserIdAsync(userId);
            if (user == null)
            {
                result.Message = $"User {userId} does not exist";
                return Json(result);
            }

            result = await _auth.ConfirmUserEmailAsync(userId);
            return Json(result);
        }
    }
}