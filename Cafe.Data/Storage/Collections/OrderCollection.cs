using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Data;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.Operation.Find;

namespace Cafe.Data
{
    /// <summary>
    /// The order collection class.
    /// </summary>
    public class OrderCollection : IData<IOrder>, IFindByOrders
    {
        private readonly List<IOrder> _orders;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="ingredientsStorages"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public OrderCollection(List<IOrder> orders)
        {
            if (orders == null)
                throw new ArgumentNullException(nameof(orders));

            _orders = orders;
        }

        /// <summary>
        /// A method for adding one order.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(IOrder item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _orders.Add(item);
        }

        /// <summary>
        /// A method for searching in a range divided into types of dishes.
        /// </summary>
        /// <param name="typeOfProduct"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public IEnumerable<IOrder> FindOrdersByRange(DateTime start, DateTime end)
        {
            List<IOrder> orders = new List<IOrder>();

            foreach (var order in _orders)
            {
                if (order.Date >= start && order.Date <= end)
                {
                    orders.Add(order);
                }
            }

            return orders;
        }

        /// <summary>
        /// A method for calculating the cost of an order in a range, divided into types.
        /// </summary>
        /// <param name="typeOfProduct"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int FindPriceByRange(TypeOfProduct typeOfProduct,DateTime start, DateTime end)
        {
            int price = 0;

            foreach (var order in _orders)
            {
                if (order.Date >= start && order.Date <= end &&
                    order.GetAll().ToList().TrueForAll(i => i.TypeOfProduct.Equals(typeOfProduct)))
                {
                    price+=order.TotalPrice;
                }
            }

            return price;
        }

        /// <summary>
        /// The method of searching for the most common type.
        /// </summary>
        /// <returns></returns>
        public TypeOfProduct FindMaxUsedIngredients()
        {
            TypeOfProduct result = FindProducts().Max();

            return result;
        }

        /// <summary>
        /// The method of searching for the most frequently encountered type.
        /// </summary>
        /// <returns></returns>
        public TypeOfProduct FindMinUsedIngredients()
        {
            TypeOfProduct result = FindProducts().Min();

            return result;
        }

        /// <summary>
        /// Finding product types.
        /// </summary>
        /// <returns></returns>
        private List<TypeOfProduct> FindProducts()
        {
            var types = new List<TypeOfProduct>();

            foreach (var order in _orders)
            {
                foreach (var item in order.GetAll())
                {
                    types.Add(item.TypeOfProduct);
                }
            }

            return types;
        }

        /// <summary>
        /// The method for returning all objects.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IOrder> GetAll()
        {
            return _orders;
        }

        /// <summary>
        /// A method for removing one order.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(IOrder item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _orders.Remove(item);
        }
    }
}
