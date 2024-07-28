using LearningHorizonApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningHorizonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;

        public SignUpController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SignUpModel model)
        {
            var users = await _userManager.FindByEmailAsync(model.Email);
            if (users!=null)
            {
                return Ok(new { message = "This Email is already registered" });
            }
            var newUser = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Country = model.UserCountry,
                University = model.UserUniversity,
                Major = model.UserMajor,
                GraduationYear = model.UserGraduationYear,
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                return Ok(new { message = "User registered successfully" });
            }

            // Handle possible errors in creating the user
            return BadRequest(result.Errors);
        }
    }
}
