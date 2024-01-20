using cb_entertainment_backend.Interfaces;
using System.Net;
using Newtonsoft.Json.Linq;
using cb_entertainment_backend.Exceptions;

namespace cb_entertainment_backend.Services
{
    public class SpotifyAuth(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<SpotifyApiService> logger
    ) : ISpotifyAuth
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _configuration = configuration;
        private readonly ILogger<SpotifyApiService> _logger = logger;
        public async Task<string> GetAuthToken()
        {
            string apiUrl = _configuration["SpotifySettings:GetTokenUrl"] ??
                throw new InvalidOperationException("La propiedad GetTokenUrl no se ha establecido.");

            string clientId = _configuration["SpotifySettings:ClientId"] ??
                throw new InvalidOperationException("La propiedad ClientId no se ha establecido.");

            string clientSecret = _configuration["SpotifySettings:ClientSecret"] ??
                throw new InvalidOperationException("La propiedad ClientSecret no se ha establecido.");

            string authGrantType = _configuration["SpotifySettings:AuthGrantType"] ??
                throw new InvalidOperationException("La propiedad AuthGrantType no se ha establecido.");

            var body = new Dictionary<string, string>
            {
                { "grant_type", authGrantType },
                { "client_id", clientId },
                { "client_secret", clientSecret }
            };

            var content = new FormUrlEncodedContent(body);

            try
            {
                var result = await _httpClient.PostAsync(apiUrl, content);

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }

                if (result.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new BadHttpRequestException("clientId o clientSecret no validos");
                }

                var bodyResponse = await result.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(bodyResponse);

                string token = jObject["access_token"]?.ToString()
                    ?? throw new TokenNotFoundException("Token no encontrado en la respuesta del servidor");

                return token;
            }
            catch (Exception ex) when (ex is not UnauthorizedAccessException || ex is not BadHttpRequestException)
            {
                _logger.LogError(ex, $"Ocurrió la siguiente excepción al procesar la solicitud de busqueda: {ex}");
                throw new Exception("Se presentaron fallas, por favor contacte al administrador");
            }
        }
    }
}
