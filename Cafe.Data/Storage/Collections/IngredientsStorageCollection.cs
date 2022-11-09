using Cafe.DI.Interfaces.Data;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.Operation.Find;

namespace Cafe.Data
{
    /// <summary>
    /// The order collection class.
    /// </summary>
    public class IngredientsStorageCollection : IData<IIngredientsStorage>
    {
        private readonly List<IIngredientsStorage> _storage;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="ingredientsStorages"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public IngredientsStorageCollection(List<IIngredientsStorage> ingredientsStorages)
        {
            if (ingredientsStorages == null)
                throw new ArgumentNullException(nameof(ingredientsStorages));

            _storage = ingredientsStorages;
        }
        /// <summary>
        /// A method for adding a new ingredients storage.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(IIngredientsStorage item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _storage.Add(item);
        }

        /// <summary>
        /// The method for returning all the dishes in the order.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IIngredientsStorage> GetAll()
        {
            return _storage;
        }

        /// <summary>
        /// A method for removing a ingredients storage.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(IIngredientsStorage item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _storage.Remove(item);
        }
    }
}
