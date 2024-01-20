namespace cb_entertainment_backend.Interfaces
{
    public interface ISpotifyAuth
    {
        Task<string> GetAuthToken();
    }
}
