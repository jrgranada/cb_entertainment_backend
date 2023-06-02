namespace CbEntertainmentBackend.src.Application.Interface
{
    public interface IAuthWithSpotify
    {
        string GetUrlForAuthentication();

        Task<string> GetCallback(string code);
    }
}