using Newtonsoft.Json;
using Cafe.Bll.Service.Converter;
using Cafe.Bll.Models.Warehouse;
using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;

namespace Cafe.Bll
{
    /// <summary>
    /// The class responsible for storing ingredients.
    /// </summary>
    public class IngredientsStorage : IIngredientsStorage
    {
        [JsonProperty(PropertyName = "_ingredients")]
        private List<(IIngredient, int)> _ingredients;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="ingredients"></param>
        /// <param name="numberOfPlaces"></param>
        /// <param name="maxGrammingForOneIngredients"></param>
        /// <param name="storageConditions"></param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public IngredientsStorage(List<(IIngredient, int)> ingredients, int numberOfPlaces,
            int maxGrammingForOneIngredients, IStorageConditions storageConditions)
        {
            if (ingredients == null)
                throw new ArgumentNullException(nameof(ingredients));

            if (numberOfPlaces <= 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfPlaces));

            if (maxGrammingForOneIngredients <= 0)
                throw new ArgumentOutOfRangeException(nameof(numberOfPlaces));

            if (storageConditions == null)
                throw new ArgumentNullException(nameof(storageConditions));

            _ingredients = ingredients;
            NumberOfPlaces = numberOfPlaces;
            MaxGrammingForOneIngredients = maxGrammingForOneIngredients;
            StorageConditions = storageConditions;
        }

        [JsonProperty(PropertyName = "NumberOfPlaces")]
        public int NumberOfPlaces { get; }

        [JsonProperty(PropertyName = "MaxGrammingForOneIngredients")]
        public int MaxGrammingForOneIngredients { get; }

        [JsonProperty(PropertyName = "StorageConditions")]
        [JsonConverter(typeof(ConcreteTypeConverter<Conditions>))]
        public IStorageConditions StorageConditions { get; }

        /// <summary>
        /// The method of adding a new ingredient to the storage.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Add((IIngredient, int) item)
        {
            if(NumberOfPlaces<_ingredients.Count()) 
                throw new ArgumentOutOfRangeException(nameof(item), 
                    "The maximum storage capacity has been reached.");

            if (item.Item1 == null)
                throw new ArgumentNullException(nameof(item));

            if (item.Item2 <= 0)
                throw new ArgumentOutOfRangeException(nameof(item));

            if (item.Item2 > MaxGrammingForOneIngredients)
                throw new ArgumentOutOfRangeException(nameof(item));

            _ingredients.Add(item);
        }

        /// <summary>
        /// Method for getting a list of ingredients stored in the storage.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(IIngredient, int)> GetAll()
        {
            return _ingredients;
        }

        /// <summary>
        /// The method of obtaining the ingredient from the storage.
        /// </summary>
        /// <param name="typeOfIngredient"></param>
        /// <param name="numberOfGrams"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public (IIngredient, int) GetIngredients(TypeOfIngredient typeOfIngredient, int numberOfGrams)
        {
            foreach (var ingredient in _ingredients)
            {
                if (ingredient.Item1.TypeOfIngredient == typeOfIngredient &&
                    ingredient.Item2 >= numberOfGrams)
                {
                    _ingredients.Remove(ingredient);
                    return ingredient;
                }
            }

            throw new ArgumentException(nameof(typeOfIngredient));
        }

        /// <summary>
        /// The method of removing the ingredient in the storage.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Remove((IIngredient, int) item)
        {
            if (item.Item1 == null)
                throw new ArgumentNullException(nameof(item));

            if (item.Item2 <= 0)
                throw new ArgumentOutOfRangeException(nameof(item));

            _ingredients.Remove(item);
        }
    }
}
