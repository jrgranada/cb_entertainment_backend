using cb_entertainment_backend.DTOs;
using System.Diagnostics;

namespace cb_entertainment_backend.Builders
{
    public class SearchSpotifyDtoBuilder
    {
        private SearchSpotifyDto _searchSpotify = new ();

        public SearchSpotifyDtoBuilder AddArtists(List<ArtistDto> artists) {
            _searchSpotify.Artists = artists;
            return this;
        }

        public SearchSpotifyDtoBuilder AddAlbums(List<AlbumDto> albums)
        {
            _searchSpotify.Albums = albums;
            return this;
        }

        public SearchSpotifyDtoBuilder AddTracks(List<TrackDto> tracks)
        {
            _searchSpotify.Tracks = tracks;
            return this;
        }

        public SearchSpotifyDto Build()
        {
            return _searchSpotify;
        }
    }
}
