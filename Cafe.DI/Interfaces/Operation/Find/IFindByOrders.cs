using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;

namespace Cafe.DI.Interfaces.Operation.Find
{
    /// <summary>
    /// Interface describing the main types of search.
    /// </summary>
    public interface IFindByOrders 
    {
        IEnumerable<IOrder> FindOrdersByRange(DateTime start, DateTime end);
        int FindPriceByRange(TypeOfProduct typeOfProduct, DateTime start, DateTime end);
        TypeOfProduct FindMinUsedIngredients();
        TypeOfProduct FindMaxUsedIngredients();
    }
}
