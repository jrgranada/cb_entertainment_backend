using CbEntertainmentBackend.src.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CbEntertainmentBackend.WebUI
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthWithSpotify _authWithSpotify;

        public AuthController(IAuthWithSpotify authWithSpotify)
        {
            _authWithSpotify = authWithSpotify;
        }

        [HttpGet("signin")]
        public ActionResult<string> SignIn()
        {
            return Redirect(_authWithSpotify.GetUrlForAuthentication());
        }

        [HttpGet("callback")]
        public async Task<string> GetCallback(string code)
        {
           string token = await _authWithSpotify.GetCallback(code);
           return token;
        }
    }
}
