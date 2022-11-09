namespace Cafe.DI.Interfaces.Serialization
{
    /// <summary>
    /// An interface describing a contract that implements data serialization and deserialization.
    /// </summary>
    /// <typeparam name="T">General type.</typeparam>
    public interface ISerializationData<T> : ISerialize, IDeserialize
    {
        IEnumerable<T> GetAll();
    }
}
