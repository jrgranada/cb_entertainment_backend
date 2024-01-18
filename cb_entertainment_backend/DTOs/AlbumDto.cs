using Newtonsoft.Json;

namespace cb_entertainment_backend.DTOs
{
    public class AlbumDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonProperty("total_tracks")]
        public int? TotalTracks { get; set; }

        [JsonProperty("images")]
        public List<ImageDto>? Images { get; set; }
    }
}
