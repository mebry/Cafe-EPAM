using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;

namespace Cafe.DI.Interfaces.Recipe
{
    /// <summary>
    /// Interface describing the cooking step of the dish.
    /// </summary>
    public interface ICookingStep
    {
        (ProcessingType, TimeSpan) Type { get; }
        List<(IIngredient, int)> Ingredients { get; }
        TimeSpan TimeSpan { get; }
    }
}
        