using Newtonsoft.Json;

namespace cb_entertainment_backend.DTOs
{
    public class ImageDto
    {
        [JsonProperty("url")]
        public required string Url { get; set; }
    }
}
