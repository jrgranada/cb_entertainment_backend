using cb_entertainment_backend.Builders;

namespace cb_entertainment_backend.DTOs
{
    public class SearchSpotifyDto
    {
        public List<ArtistDto>? Artists { get; set; }
        public List<AlbumDto>? Albums { get; set; }
        public List<TrackDto>? Tracks { get; set; }

        public static implicit operator SearchSpotifyDto(SearchSpotifyDtoBuilder v)
        {
            throw new NotImplementedException();
        }
    }
}
