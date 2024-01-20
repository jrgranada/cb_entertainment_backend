using cb_entertainment_backend.DTOs;
using cb_entertainment_backend.Interfaces;
using cb_entertainment_backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cb_entertainment_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyAuthController(ISpotifyAuth spotifyAuth) : ControllerBase
    {
        private readonly ISpotifyAuth _spotifyAuth = spotifyAuth;

        [HttpGet("token")]
        public async Task<ActionResult<string>> GetAuthToken()
        {
            return await _spotifyAuth.GetAuthToken();
        }
    }
}
