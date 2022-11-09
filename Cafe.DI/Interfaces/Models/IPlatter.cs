using Cafe.DI.Enums;

namespace Cafe.DI.Interfaces.Models
{
    /// <summary>
    /// The type of dish and its cost.
    /// </summary>
    public interface IPlatter
    {
        TypeOfProduct TypeOfProduct { get; }
        string Name { get; }
        int Price { get; }
    }
}
