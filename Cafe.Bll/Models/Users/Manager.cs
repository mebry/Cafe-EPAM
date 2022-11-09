using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.User;
using Cafe.Bll.Models.Request;

namespace Cafe.Bll.Models.Users
{
    /// <summary>
    /// A class describing the manager.
    /// </summary>
    public class Manager : IManager
    {
        private List<IPlatter> _platters;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="platters"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public Manager(List<IPlatter> platters, string name)
        {
            if (platters == null)
                throw new ArgumentNullException(nameof(platters));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            _platters = platters;
            Name = name;
        }

        public string Name { get; }

        /// <summary>
        /// Calculation of the order cost.
        /// </summary>
        /// <param name="meals"></param>
        /// <returns></returns>
        public int CalculationPrice(IMeal meals)
        {
            int price = 0;

            foreach (var meal in meals.GetAll())
            {
                foreach (var platter in _platters)
                {
                    if ((meal.Item1, meal.Item2) == (platter.TypeOfProduct, platter.Name))
                    {
                        price += platter.Price;
                    }
                }
            }

            return price;
        }

        /// <summary>
        /// Creating an order for the cook.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public IOrder CreateOrder(IClient client)
        {
            IMeal meal = client.CreateOrder();

            int price = CalculationPrice(meal);

            client.Pay(price);
            var order = new Order(client.Id, DateTime.Now, FindPlatters(meal));
            return order;
        }

        /// <summary>
        /// Getting a list of orders.
        /// </summary>
        /// <param name="meal"></param>
        /// <returns></returns>
        private List<IPlatter> FindPlatters(IMeal meal)
        {
            List<IPlatter> platters = new List<IPlatter>();

            foreach (var item in meal.GetAll())
            {
                foreach (var platter in _platters)
                {
                    if ((item.Item1, item.Item2) == (platter.TypeOfProduct, platter.Name))
                    {
                        platters.Add(platter);
                    }
                }
            }

            return platters;
        }
    }
}
