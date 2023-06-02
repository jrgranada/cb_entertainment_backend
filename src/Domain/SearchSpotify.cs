using SpotifyAPI.Web;

namespace CbEntertainmentBackend.src.Domain
{
    public class SearchSpotify
    {
        public List<SimpleAlbum>? Albumes { get; set; }
        public List<FullArtist>? Artists { get; set; }
        public List<FullTrack>? Tracks { get; set; }
    }
}
