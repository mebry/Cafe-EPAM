using Newtonsoft.Json;
using Cafe.DI.Interfaces.Serialization;
using Cafe.DI.Interfaces.Models;
using Cafe.Data.Storage.Serialization;

namespace Cafe.Data.Storage.Json
{
    /// <summary>
    /// A class for writing and reading data from a file by serialization and deserialization.
    /// </summary>
    public class JsonData<T> : ISerializationData<T> where T : class
    {
        private List<T> _orders;
        private string _path;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="path">The path where the file will be contained.</param>
        /// <param name="orders">List of elements.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public JsonData(string path, List<T> orders)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            if (path == "")
                throw new ArgumentException(nameof(path));

            if (orders == null)
                throw new ArgumentNullException(nameof(orders));

            _orders = orders;
            _path = path;
        }

        /// <summary>
        /// The method responsible for writing the data.
        /// </summary>
        public void Write()
        {
            SerializeObject.Serialize<T>(_path, _orders);
        }

        /// <summary>
        /// The method responsible for reading the data.
        /// </summary>
        /// <param name="jsonConverter"></param>
        public void Restore(params JsonConverter[] jsonConverter)
        {
            _orders=DeserializeObject.Deserialize<T>(_path, jsonConverter).ToList();
        }

        /// <summary>
        /// A method that returns a set of elements.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> GetAll() => _orders;
    }
}
