using LearningHorizonApi.Models;
using Microsoft.AspNetCore.Identity;

namespace LearningHorizonApi.Services
{
    public class LoginService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<(bool isSuccess, string errorMessage)> ValidateLoginAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return (false, "Email not found");
            }

            var storedHash = user.PasswordHash;
            var isPasswordCorrect = _userManager.PasswordHasher.VerifyHashedPassword(user, storedHash, password);

            if (isPasswordCorrect == PasswordVerificationResult.Failed)
            {
                return (false, "Wrong Password");
            }

            return (true, "Login successful");
        }
    }
}
