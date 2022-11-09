using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.Recipe;
using Newtonsoft.Json;

namespace Cafe.Bll.Models.Prescription
{
    /// <summary>
    /// A class describing a cooking recipe.
    /// </summary>
    public class Recipe : IRecipe
    {
        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="totalPrice"></param>
        /// <param name="name"></param>
        /// <param name="typeOfProduct"></param>
        /// <param name="cookingSteps"></param>
        /// <param name="ingredients"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Recipe(int totalPrice, string name, TypeOfProduct typeOfProduct, 
            List<ICookingStep> cookingSteps, List<(IIngredient, int)> ingredients)
        {
            if (totalPrice <= 0)
                throw new ArgumentOutOfRangeException(nameof(totalPrice));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (name.Length == 0)
                throw new ArgumentException(nameof(name));

            if (cookingSteps == null)
                throw new ArgumentNullException(nameof(cookingSteps));

            if (ingredients == null)
                throw new ArgumentNullException(nameof(ingredients));

            TotalPrice = totalPrice;
            Name = name;
            TypeOfProduct = typeOfProduct;
            CookingSteps = cookingSteps;
            Ingredients = ingredients;
        }

        [JsonProperty(PropertyName = "TotalPrice")]
        public int TotalPrice {get;}

        [JsonProperty(PropertyName = "Name")]
        public string Name { get; }

        [JsonProperty(PropertyName = "TypeOfProduct")]
        public TypeOfProduct TypeOfProduct { get; }

        [JsonProperty(PropertyName = "CookingSteps")]
        public List<ICookingStep> CookingSteps { get; }

        [JsonProperty(PropertyName = "Ingredients")]
        public List<(IIngredient, int)> Ingredients { get; }
    }
}
