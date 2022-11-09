using Cafe.DI.Interfaces.Models;

namespace Cafe.DI.Interfaces.User
{
    /// <summary>
    /// Interface describing the behavior of the manager.
    /// </summary>
    public interface IManager:IPerson
    {
        int CalculationPrice(IMeal meals);
        IOrder CreateOrder(IClient client);
    }
}
