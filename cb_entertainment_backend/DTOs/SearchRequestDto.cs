

using cb_entertainment_backend.Enums;

namespace cb_entertainment_backend.DTOs
{
    public class SearchRequestDto
    {
        public required string Token { get; set; }

        public required string Query { get; set; }

        public  required List<TypesSpotify> Types { get; set; }

    }
}
