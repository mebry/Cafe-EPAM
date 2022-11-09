namespace Cafe.DI.Interfaces.Models
{
    /// <summary>
    /// Storage conditions.
    /// </summary>
    public interface IStorageConditions
    {
        int MinTemperature { get; }
        int MaxTemperature { get; }
    }
}
