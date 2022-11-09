using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;

namespace Cafe.Bll.Models.Request
{
    /// <summary>
    /// A class describing the essence of the food that is being ordered.
    /// </summary>
    public class Meal : IMeal
    {
        private List<(TypeOfProduct, string)> _meals;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="meals"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Meal(List<(TypeOfProduct, string)> meals)
        {
            if(meals == null)
                throw new ArgumentNullException(nameof(meals));

            _meals=meals;
        }

        /// <summary>
        /// The method of adding a new meal.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add((TypeOfProduct, string) item)
        {
            if (item.Item2 == null)
                throw new ArgumentNullException(nameof(item));

            _meals.Add(item);
        }

        /// <summary>
        /// Method for getting a list of meals.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<(TypeOfProduct, string)> GetAll()
        {
            return _meals;
        }

        /// <summary>
        /// The method of removing the meal.
        /// </summary>
        /// <param name="item"></param>
        public void Remove((TypeOfProduct, string) item)
        {
            _meals.Remove(item);
        }

        /// <summary>
        /// The method of zeroing the order.
        /// </summary>
        public void Reset()
        {
            _meals = new List<(TypeOfProduct, string)>();
        }
    }
}
