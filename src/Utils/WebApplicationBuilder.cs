namespace CbEntertainmentBackend.src.Utils
{
    public static class WebApplicationBuilder
    {
        public static IHostBuilder ConfigureAppSettings(this IHostBuilder host)
        {
            host.ConfigureAppConfiguration((ctx, builder) =>
            {
                builder.AddJsonFile("appsettings.Development.json", false, true);
                builder.AddEnvironmentVariables();
            });

            return host;
        }
    }
}
