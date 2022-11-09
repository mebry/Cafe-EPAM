using Cafe.DI.Interfaces.Data;

namespace Cafe.DI.Interfaces.Models
{
    /// <summary>
    /// The interface responsible for ordering dishes.
    /// </summary>
    public interface IOrder:IData<IPlatter>
    {
        int Id { get; }
        int TotalPrice { get; }
        DateTime Date { get; }
    }
}
