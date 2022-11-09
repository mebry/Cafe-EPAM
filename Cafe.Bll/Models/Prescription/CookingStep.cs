using Newtonsoft.Json;
using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.Recipe;

namespace Cafe.Bll.Models.Prescription
{
    /// <summary>
    /// A class describing the cooking step.
    /// </summary>
    public class CookingStep : ICookingStep
    {
        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ingredients"></param>
        /// <param name="timeSpan"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public CookingStep((ProcessingType, TimeSpan) type, 
            List<(IIngredient, int)> ingredients, TimeSpan timeSpan)
        {
            if(ingredients==null)
                throw new ArgumentNullException(nameof(ingredients));

            Type = type;
            Ingredients = ingredients;
            TimeSpan = timeSpan;
        }

        [JsonProperty(PropertyName = "Type")]
        public (ProcessingType, TimeSpan) Type { get; }

        [JsonProperty(PropertyName = "Ingredients")]
        public List<(IIngredient, int)> Ingredients { get; }

        [JsonProperty(PropertyName = "TimeSpan")]
        public TimeSpan TimeSpan { get; }
    }
}
