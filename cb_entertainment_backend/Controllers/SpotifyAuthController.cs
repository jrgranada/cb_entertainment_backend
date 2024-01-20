using cb_entertainment_backend.DTOs;
using cb_entertainment_backend.Exceptions;
using cb_entertainment_backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cb_entertainment_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyAuthController(ISpotifyAuthService spotifyAuthService) : ControllerBase
    {
        private readonly ISpotifyAuthService _spotifyAuthService = spotifyAuthService;

        [HttpGet("token")]
        public async Task<ActionResult<string>> GetAuthToken()
        {
            try
            {
                return await _spotifyAuthService.GetAuthToken();
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized("No autorizado para solicitar un token");
            }
            catch (BadHttpRequestException)
            {
                return BadRequest("No se pudo obtener el token, parámetros no válidos");
            }
            catch (TokenNotFoundException)
            {
                return BadRequest("Error al obtener el token");
            }
        }
    }
}
