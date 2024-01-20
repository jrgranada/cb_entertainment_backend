namespace cb_entertainment_backend.Interfaces
{
    public interface ISpotifyAuthService
    {
        Task<string> GetAuthToken();
    }
}
