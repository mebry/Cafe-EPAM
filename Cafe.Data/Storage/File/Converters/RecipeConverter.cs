using Newtonsoft.Json.Converters;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.Recipe;
using Cafe.DI.Enums;
using Cafe.Bll.Models.Prescription;

namespace Cafe.Data.Storage.Converters
{
    /// <summary>
    /// The class responsible for the specific substitution of the object.
    /// </summary>
    public class RecipeConverter : CustomCreationConverter<IRecipe>
    {
        /// <summary>
        /// Creating a class explicitly specifying through what we create.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override IRecipe Create(Type objectType)
        {
            return new Recipe(1, "NoN", TypeOfProduct.Dish,
                new List<ICookingStep>(), new List<(IIngredient, int)>());
        }
    }
}
