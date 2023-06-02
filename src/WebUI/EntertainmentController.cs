using CbEntertainmentBackend.src.Application.Interface;
using CbEntertainmentBackend.src.Domain;
using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Web;

namespace CbEntertainmentBackend.src.WebUI
{

    [ApiController]
    [Route("api/spotify")]
    public class EntertainmentController : ControllerBase
    {
        private readonly ISpotifyRequest _spotifyRequest;

        public EntertainmentController(ISpotifyRequest spotifyRequest)
        {
            _spotifyRequest = spotifyRequest;
        }

        [HttpGet("search-by-query")]
        public async Task<SearchSpotify> SearchByQuery(string accessToken, String query)
        {
            return await _spotifyRequest.SearchByQuery(accessToken, query);
            //return "[{\"image\":\"https://i.scdn.co/image/ab67616d0000b273560445d98df282b4462635d2\",\"name\":\"Jose\",\"release_date\":\"2023\",\"total_trakc\":20}, {\"image\":\"https://i.scdn.co/image/ab67616d0000b273560445d98df282b4462635d2\",\"name\":\"Juan\",\"release_date\":\"2023\",\"total_track\":20},{\"image\":\"https://i.scdn.co/image/ab67616d0000b273560445d98df282b4462635d2\",\"name\":\"Jose\",\"release_date\":\"2023\",\"total_trakc\":20}, {\"image\":\"https://i.scdn.co/image/ab67616d0000b273560445d98df282b4462635d2\",\"name\":\"Juan\",\"release_date\":\"2023\",\"total_track\":20}]";

        }
    }
}
