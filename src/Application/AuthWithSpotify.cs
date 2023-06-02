using CbEntertainmentBackend.src.Application.Interface;
using SpotifyAPI.Web;

namespace CbEntertainmentBackend.src.Application
{
    public class AuthWithSpotify : IAuthWithSpotify
    {
        private readonly IConfiguration _configuration;
        public AuthWithSpotify(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetUrlForAuthentication()
        {
            var clientId = _configuration["SpotifySettings:ClientId"] ?? "";
            var redirectUri = _configuration["SpotifySettings:RedirectUri"] ?? "";

            var loginRequest = new LoginRequest(
              new Uri(redirectUri),
              clientId,
              LoginRequest.ResponseType.Code
            )
            {
                Scope = new[] { Scopes.PlaylistReadPrivate, Scopes.PlaylistReadCollaborative }
            };


            return loginRequest.ToUri().ToString();

        }

        public async Task<string> GetCallback(string code)
        {
            var clientId = _configuration["SpotifySettings:ClientId"] ?? "";
            var clientSecret = _configuration["SpotifySettings:clientSecret"] ?? "";
            var redirectUri = _configuration["SpotifySettings:RedirectUri"] ?? "";

            var response = await new OAuthClient().RequestToken(
              new AuthorizationCodeTokenRequest(clientId, clientSecret, code, new Uri(redirectUri))
            );

            return response.AccessToken;
        }
    }
}
