using cb_entertainment_backend.DTOs;
using cb_entertainment_backend.Enums;
using cb_entertainment_backend.Interfaces;
using cb_entertainment_backend.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;


namespace cb_entertainment_backend.test.Services
{

    [TestFixture]
    public class SpotifyApiServiceTest
    {

        private HttpClient _httpClient;
        private IConfiguration _configuration;
        private SpotifyApiService _spotifyApiService;
        private Logger<SpotifyApiService> _logger;
        private SearchRequestDto _searchRequestDto;
        private string _baseUrl;

        [SetUp]
        public void Setup()
        {
            string projectPath = Path.GetFullPath(Path.Combine(
                TestContext.CurrentContext.TestDirectory,
                "../../../../cb_entertainment_backend"));

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(projectPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = configurationBuilder.Build();

            _httpClient = new HttpClient();

            _baseUrl = _configuration["SpotifySettings:BaseUrl"] ?? "";

            _httpClient.BaseAddress = new Uri(_baseUrl);

            _logger = new Logger<SpotifyApiService>(new LoggerFactory());

            _searchRequestDto = new()
            {
                Token = "123456",
                Query = "Guns And Roses",
                Types = [TypesSpotify.album, TypesSpotify.artist, TypesSpotify.track]
            };

            _spotifyApiService = new SpotifyApiService(_httpClient, _configuration, _logger);
        }

        /**
         * Prueba unitaria que realiza una búsqueda con un token no válido
         */
        [Test]
        public void SearchForItemCorrectValues()
        {
            Assert.Throws<UnauthorizedAccessException>(async () => await _spotifyApiService.SearchForItem(_searchRequestDto));
        }
    }
}
