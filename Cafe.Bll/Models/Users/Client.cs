using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.User;

namespace Cafe.Bll.Models.Users
{
    /// <summary>
    /// A class describing the entity of the customer who makes the order.
    /// </summary>
    public class Client : IClient
    {
        private int _balance;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="balance"></param>
        /// <param name="id"></param>
        /// <param name="meal"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Client(int balance, int id, IMeal meal, string name)
        {
            if (balance < 0)
                throw new ArgumentOutOfRangeException(nameof(balance));

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if (meal == null)
                throw new ArgumentNullException(nameof(meal));

            if (name == null)
                throw new ArgumentNullException(nameof(name));

            _balance = balance;
            Id = id;
            Meal = meal;
            Name = name;
        }

        public int Id { get; }

        public int Balance => _balance;

        public IMeal Meal { get; }

        public string Name { get; }

        /// <summary>
        /// Place an order.
        /// </summary>
        /// <returns></returns>
        public IMeal CreateOrder()
        {
            return Meal;
        }

        /// <summary>
        /// Put money into the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void PutMoney(int amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            _balance += amount;
        }

        /// <summary>
        /// Payment for the order.
        /// </summary>
        /// <param name="price"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Pay(int price)
        {
            if (price < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price));
            }

            _balance -= price;

            if (_balance < 0)
                throw new ArgumentException("The balance is negative");
        }
    }
}
