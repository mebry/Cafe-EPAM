using Cafe.DI.Enums;

namespace Cafe.DI.Interfaces.Models
{
    /// <summary>
    /// Describes the ingredient that will be used for cooking in the future.
    /// </summary>
    public interface IIngredient
    {
        int Price { get; }
        TypeOfIngredient TypeOfIngredient { get; }
        IStorageConditions StorageConditions { get; }
    }
}
