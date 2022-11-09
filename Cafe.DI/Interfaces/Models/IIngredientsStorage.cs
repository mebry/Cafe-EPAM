using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Data;

namespace Cafe.DI.Interfaces.Models
{
    /// <summary>
    /// Storage of ingredients with different temperatures.
    /// </summary>
    public interface IIngredientsStorage : IData<(IIngredient, int)>
    {
        int NumberOfPlaces { get; }
        int MaxGrammingForOneIngredients { get; }
        IStorageConditions StorageConditions { get; }

        (IIngredient, int) GetIngredients(TypeOfIngredient typeOfIngredient, int numberOfGrams);
    }
}