using Newtonsoft.Json.Converters;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Enums;
using Cafe.Bll.Models.Request;

namespace Cafe.Data.Storage.Converters
{
    /// <summary>
    /// The class responsible for the specific substitution of the object.
    /// </summary>
    public class PlatterConverter : CustomCreationConverter<IPlatter>
    {
        // <summary>
        /// Creating a class explicitly specifying through what we create.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override IPlatter Create(Type objectType)
        {
            return new Platter(TypeOfProduct.Dish, "NoN", 10);
        }
    }
}
