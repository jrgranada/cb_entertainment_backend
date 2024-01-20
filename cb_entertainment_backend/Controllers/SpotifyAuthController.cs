using cb_entertainment_backend.DTOs;
using cb_entertainment_backend.Exceptions;
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
            try
            {
                return await _spotifyAuth.GetAuthToken();
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
