using Newtonsoft.Json;

namespace Cafe.Data.Storage.Serialization
{
    /// <summary>
    /// The class responsible for deserialization.
    /// </summary>
    public class DeserializeObject 
    {
        /// <summary>
        /// The method responsible for deserialization.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonConverter"></param>
        /// <returns></returns>
        public static IEnumerable<T> Deserialize<T>(string path, params JsonConverter[] jsonConverters)
        {
            JsonSerializer serializer = new JsonSerializer();
            IEnumerable<T> data;
            using (StreamReader reader = new StreamReader(path))
            {
                string str = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<IEnumerable<T>>(str, jsonConverters);
            }
            return data;
        }
    }
}
