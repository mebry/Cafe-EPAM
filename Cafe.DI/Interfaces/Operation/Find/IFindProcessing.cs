using Cafe.DI.Interfaces.Operation.Processing;

namespace Cafe.DI.Interfaces.Operation.Find
{
    /// <summary>
    /// Interface describing the main types of search.
    /// </summary>
    public interface IFindProcessing
    {
        IProcessing FindMaxCostlyProcessing();
    }
}
