using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace cb_entertainment_backend.Utils
{
    public class MapperRespSpotifyToClass
    {
        public static List<T> Mapper<T>(JObject jObject, string key1, string key2)
        {
            List<T> objs = [];

            JArray? jArray = (JArray?)jObject[key1]?[key2];

            if (jArray == null) { 
                return objs;
            }

            foreach (JObject element in jArray.Cast<JObject>())
            {
                T? obj = JsonConvert.DeserializeObject<T>(element.ToString());

                if (obj != null) {
                    objs.Add(obj);
                }
            }

            return objs;
        }
    }
}
