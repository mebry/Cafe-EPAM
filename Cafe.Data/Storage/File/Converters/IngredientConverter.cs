using Newtonsoft.Json.Converters;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Enums;
using Cafe.Bll.Models.Warehouse;
using Cafe.Bll.Models.Prescription;

namespace Cafe.Data.Storage.Converters
{
    /// <summary>
    /// The class responsible for the specific substitution of the object.
    /// </summary>
    public class IngredientConverter : CustomCreationConverter<IIngredient>
    {
        // <summary>
        /// Creating a class explicitly specifying through what we create.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override IIngredient Create(Type objectType)
        {
            return new Ingredient(1,TypeOfIngredient.Water,new Conditions(-1,1));
        }
    }
}
