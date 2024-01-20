using cb_entertainment_backend.Builders;
using cb_entertainment_backend.DTOs;
using cb_entertainment_backend.Interfaces;
using cb_entertainment_backend.Utils;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http.Headers;

namespace cb_entertainment_backend.Services
{
    public class SpotifyApiService(
        HttpClient httpClient,
        IConfiguration configuration,
        ILogger<SpotifyApiService> logger
    ) : ISpotifyApiService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _configuration = configuration;
        private readonly ILogger<SpotifyApiService> _logger = logger;
        public async Task<SearchSpotifyDto> SearchForItem(SearchRequestDto searchRequestDto)
        {

            if (_httpClient.BaseAddress == null)
            {
                throw new InvalidOperationException("La propiedad BaseAddress no se ha establecido.");
            }

            string baseUrl = _httpClient.BaseAddress.ToString();

            string endpoint = _configuration["SpotifySettings:SearchUrl"] ??
                throw new InvalidOperationException("La propiedad SearchUrl no se ha establecido.");

            string apiUrl = $"{baseUrl}/{endpoint}";

            string types = string.Join(",", searchRequestDto.Types);

            var uriBuilder = new UriBuilder(apiUrl)
            {
                Query = $"query={searchRequestDto.Query}&type={types}"
            };

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", searchRequestDto.Token);

            try
            {
                var result = await _httpClient.GetAsync(uriBuilder.Uri.ToString());

                if (result.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new UnauthorizedAccessException();
                }

                var bodyResponse = await result.Content.ReadAsStringAsync();

                JObject jObject = JObject.Parse(bodyResponse);

                List<AlbumDto> albums = MapperRespSpotifyToClass.Mapper<AlbumDto>(jObject, "albums", "items");

                List<ArtistDto> artists = MapperRespSpotifyToClass.Mapper<ArtistDto>(jObject, "artists", "items");

                List<TrackDto> tracks = MapperRespSpotifyToClass.Mapper<TrackDto>(jObject, "tracks", "items");

                SearchSpotifyDto searchSpotify = new SearchSpotifyDtoBuilder()
                                                        .AddArtists(artists)
                                                        .AddAlbums(albums)
                                                        .AddTracks(tracks)
                                                        .Build();

                return searchSpotify;

            }
            catch (Exception ex) when (ex is not UnauthorizedAccessException)
            {
                _logger.LogError(ex, $"Ocurrió la siguiente excepción al procesar la solicitud de busqueda: {ex}");
                throw new Exception("Se presentaron fallas, por favor contacte al administrador");
            }
        }
    }
}