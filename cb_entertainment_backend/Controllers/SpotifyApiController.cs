using cb_entertainment_backend.DTOs;
using cb_entertainment_backend.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace cb_entertainment_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpotifyApiController (
        ISpotifyApiService spotifyApiService,
        IValidator<SearchRequestDto> searchRequestValidator
    ) : ControllerBase
    {
        private readonly ISpotifyApiService _spotifyApiService = spotifyApiService;
        private readonly IValidator<SearchRequestDto> _searchRequestValidator = searchRequestValidator;

        [HttpPost("search")]
        public async Task<ActionResult<SearchSpotifyDto>> SearchForItem(SearchRequestDto searchRequestDto)
        {
            var validationResult = _searchRequestValidator.Validate(searchRequestDto);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            try
            {
                return await _spotifyApiService.SearchForItem(searchRequestDto);
            }
            catch (UnauthorizedAccessException) {
                return Unauthorized("Token no valido");
            }
        }
    }
}
