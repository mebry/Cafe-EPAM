namespace Cafe.DI.Interfaces.Data
{
    /// <summary>
    /// The interface responsible for working with a collection of elements.
    /// </summary>
    /// <typeparam name="T">Generalized type.</typeparam>
    public interface IData<T>
    {
        void Add(T item);
        void Remove(T item);
        IEnumerable<T> GetAll();
    }
}
