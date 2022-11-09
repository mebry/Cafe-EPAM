using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;

namespace Cafe.DI.Interfaces.Recipe
{
    /// <summary>
    /// Interface describing the finished recipe.
    /// </summary>
    public interface IRecipe
    {
        int TotalPrice { get; }
        string Name { get; }
        TypeOfProduct TypeOfProduct { get; }
        List<ICookingStep> CookingSteps { get; }
        List<(IIngredient, int)> Ingredients { get; }  
    }
}



