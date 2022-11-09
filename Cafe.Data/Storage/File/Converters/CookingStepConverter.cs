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
    public class CookingStepConverter : CustomCreationConverter<ICookingStep>
    {
        public override ICookingStep Create(Type objectType)
        {
            // <summary>
            /// Creating a class explicitly specifying through what we create.
            /// </summary>
            /// <param name="objectType"></param>
            /// <returns></returns>
            return new CookingStep((ProcessingType.NoProcessing, TimeSpan.Zero), 
                new List<(IIngredient, int)>(), TimeSpan.Zero);
        }
    }
}
