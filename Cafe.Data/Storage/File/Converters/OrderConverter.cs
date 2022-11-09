using Newtonsoft.Json.Converters;
using Cafe.DI.Interfaces.Models;
using Cafe.Bll.Models.Request;

namespace Cafe.Data.Storage.Converters
{
    /// <summary>
    /// The class responsible for the specific substitution of the object.
    /// </summary>
    public class OrderConverter : CustomCreationConverter<IOrder>
    {
        // <summary>
        /// Creating a class explicitly specifying through what we create.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override IOrder Create(Type objectType)
        {
            return new Order(1,DateTime.Now, new List<IPlatter>());
        }
    }
}
