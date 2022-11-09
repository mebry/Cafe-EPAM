using Newtonsoft.Json;
using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;

namespace Cafe.Bll.Models.Request
{
    /// <summary>
    /// The class responsible for the type of dish and its name.
    /// </summary>
    public class Platter : IPlatter
    {
        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="typeOfProduct"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Platter(TypeOfProduct typeOfProduct, string name,int price)
        {
            if(name == null)
                throw new ArgumentNullException(nameof(name));

            if(name.Length == 0)
                throw new ArgumentException(nameof(name));

            if (price <= 0 || price > 100000)
                throw new ArgumentOutOfRangeException(nameof(price));

            TypeOfProduct = typeOfProduct;
            Name = name;
            Price = price;
        }

        [JsonProperty(PropertyName = "TypeOfProduct")]
        public TypeOfProduct TypeOfProduct { get; }

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; }

        [JsonProperty(PropertyName = "Price")]
        public int Price { get; }

        /// <summary>
        /// Redefined method.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>Boolean value.</returns>
        public override bool Equals(object? obj)
        {
            return obj is Platter platter &&
                   TypeOfProduct == platter.TypeOfProduct &&
                   Name == platter.Name &&
                   Price == platter.Price;
        }

        /// <summary>
        /// Redefined method.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(TypeOfProduct, Name, Price);
        }
    }
}
