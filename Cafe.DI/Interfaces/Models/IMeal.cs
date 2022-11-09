using Cafe.DI.Interfaces.Data;
using Cafe.DI.Enums;

namespace Cafe.DI.Interfaces.Models
{
    /// <summary>
    /// Interface describing the user's order.
    /// </summary>
    public interface IMeal:IData<(TypeOfProduct,string)>
    {
        void Reset();
    }
}
