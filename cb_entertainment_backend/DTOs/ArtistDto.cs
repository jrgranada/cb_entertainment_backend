using Newtonsoft.Json;

namespace cb_entertainment_backend.DTOs
{
    public class ArtistDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("popularity")]
        public string? Popularity { get; set; }

        [JsonProperty("images")]
        public List<ImageDto>? Images { get; set; }
    }
}
