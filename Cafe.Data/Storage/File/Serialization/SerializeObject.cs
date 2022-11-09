using Newtonsoft.Json;

namespace Cafe.Data.Storage.Serialization
{
    /// <summary>
    /// The class responsible for serialization.
    /// </summary>
    public class SerializeObject 
    {
        /// <summary>
        /// The method responsible for serialization.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        public static void Serialize<T>(string path, IEnumerable<T> data)
        {
            JsonSerializer serializer = new JsonSerializer();

            string str = JsonConvert.SerializeObject(data);

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                writer.WriteLine(str);
            }
        }
    }
}
