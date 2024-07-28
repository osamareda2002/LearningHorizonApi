using LearningHorizonApi.Models;
using LearningHorizonApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningHorizonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _loginService.ValidateLoginAsync(model.Email, model.Password);

            if (result.isSuccess)
            {
                return new JsonResult(new { success = true });
            }
            else
            {
                return new JsonResult(new { success = false, message = result.errorMessage });
            }
        }
    }
}
