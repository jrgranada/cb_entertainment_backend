using CbEntertainmentBackend.src.Domain;

namespace CbEntertainmentBackend.src.Application.Interface
{
    public interface ISpotifyRequest
    {
        Task<SearchSpotify> SearchByQuery(string accessToken, string query);
    }
}