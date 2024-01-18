using cb_entertainment_backend.DTOs;

namespace cb_entertainment_backend.Interfaces
{
    public interface ISpotifyApiService
    {
        Task<SearchSpotifyDto> SearchForItem(SearchRequestDto searchRequestDto);
    }
}
