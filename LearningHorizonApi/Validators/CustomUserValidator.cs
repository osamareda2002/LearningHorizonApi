using Microsoft.AspNetCore.Identity;

namespace LearningHorizonApi.Validators
{
    public class CustomUserValidator<TUser> : IUserValidator<TUser> where TUser : IdentityUser
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
        {
            // Skipping the unique username validation
            var errors = new List<IdentityError>();
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                errors.Add(new IdentityError { Code = "UserNameEmpty", Description = "Username cannot be empty." });
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                errors.Add(new IdentityError { Code = "EmailEmpty", Description = "Email cannot be empty." });
            }

            return errors.Count == 0 ? IdentityResult.Success : IdentityResult.Failed(errors.ToArray());
        }
    }
}
