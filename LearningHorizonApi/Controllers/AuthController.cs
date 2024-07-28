using Google.Apis.Auth;
using LearningHorizonApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningHorizonApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin([FromBody] TokenModel tokenModel)
        {
            try
            {
                var payload = await GoogleJsonWebSignature.ValidateAsync(tokenModel.Token);
                return Ok(new { message = "Google authentication successful", user = payload });
            }
            catch (InvalidJwtException)
            {
                return BadRequest("Invalid Google token.");
            }
        }
    }
}
