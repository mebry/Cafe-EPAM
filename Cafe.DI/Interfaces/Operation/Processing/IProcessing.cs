using Cafe.DI.Enums;

namespace Cafe.DI.Interfaces.Operation.Processing
{
    /// <summary>
    /// Interface describing the type of processing.
    /// </summary>
    public interface IProcessing
    {
        int Price { get; }
        TimeSpan TimeSpan { get; }
        ProcessingType Operation { get; }

        void Execute();
    }
}
