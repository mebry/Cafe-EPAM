using Newtonsoft.Json.Converters;
using Cafe.DI.Interfaces.Models;
using Cafe.Bll.Models.Warehouse;

namespace Cafe.Data.Storage.Converters
{
    /// <summary>
    /// The class responsible for the specific substitution of the object.
    /// </summary>
    public class IngredientsStorageConverter : CustomCreationConverter<IIngredientsStorage>
    {
        // <summary>
        /// Creating a class explicitly specifying through what we create.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override IIngredientsStorage Create(Type objectType)
        {
            return new IngredientsStorage(new List<(IIngredient, int)>(),1,1, new Conditions(-1, 1));
        }
    }
}
