using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;
using Cafe.Bll.Service.Converter;
using Cafe.Bll.Models.Warehouse;
using Newtonsoft.Json;

namespace Cafe.Bll.Models.Prescription
{
    /// <summary>
    /// The class responsible for the description of the ingredient.
    /// </summary>
    public class Ingredient : IIngredient
    {
        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="typeOfIngredient"></param>
        /// <param name="storageConditions"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Ingredient(int price, TypeOfIngredient typeOfIngredient, IStorageConditions storageConditions)
        {
            if (price <= 0 || price > 100000)
                throw new ArgumentOutOfRangeException(nameof(price));

            if (storageConditions == null)
                throw new ArgumentNullException(nameof(storageConditions));

            Price = price;
            TypeOfIngredient = typeOfIngredient;
            StorageConditions = storageConditions;

        }

        [JsonProperty(PropertyName = "Price")]
        public int Price { get; }

        [JsonProperty(PropertyName = "TypeOfIngredient")]
        public TypeOfIngredient TypeOfIngredient { get; }

        [JsonProperty(PropertyName = "StorageConditions")]
        [JsonConverter(typeof(ConcreteTypeConverter<Conditions>))]
        public IStorageConditions StorageConditions { get; }
    }
}