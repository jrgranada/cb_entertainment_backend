using Newtonsoft.Json;

namespace cb_entertainment_backend.DTOs
{
    public class TrackDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("album")]
        public AlbumDto? Album { get; set; }

        [JsonProperty("artists")]
        public List<ArtistDto>? Artists { get; set; }
    }
}
