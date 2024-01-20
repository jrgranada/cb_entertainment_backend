using cb_entertainment_backend.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NUnit.Framework.Internal;

namespace cb_entertainment_backend.test.Services
{
    [TestFixture]
    public class SpotifyAuthServiceTest
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;
        private SpotifyAuthService _spotifyAuthService;
        private Logger<SpotifyAuthService> _logger;

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

            _logger = new Logger<SpotifyAuthService>(new LoggerFactory());

            _spotifyAuthService = new SpotifyAuthService(_httpClient, _configuration, _logger);

        }

        /**
         * Prueba unitaria que intenta obtener un token
         */
        [Test]
        public async Task GetAuthTokenWithCorrectValues()
        {
            var result = await _spotifyAuthService.GetAuthToken();
            Assert.That(result, Is.TypeOf<string>());
        }
    }
}
