using CbEntertainmentBackend.src.Application.Interface;
using CbEntertainmentBackend.src.Domain;
using SpotifyAPI.Web;

namespace CbEntertainmentBackend.src.Application
{
    public class SpotifyRequest: ISpotifyRequest
    {
        public async Task<SearchSpotify> SearchByQuery(string accessToken, String query)
        {
            try
            {
                var spotify = new SpotifyClient(accessToken);

                SearchRequest searchRequest = 
                    new SearchRequest(SearchRequest.Types.Album | SearchRequest.Types.Artist |  SearchRequest.Types.Track, query);

                var search = await spotify.Search.Item(searchRequest);

                SearchSpotify searchSpotify = new SearchSpotify();
                searchSpotify.Albumes = search.Albums.Items;
                searchSpotify.Artists = search.Artists.Items;
                searchSpotify.Tracks = search.Tracks.Items;

                return searchSpotify;
               
            }
            catch (APIUnauthorizedException) {
                return new SearchSpotify();
            }
            catch(APIException) {
                return new SearchSpotify();
            }
                      
        }
    }
}
