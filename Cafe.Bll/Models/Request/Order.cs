using Newtonsoft.Json;
using Cafe.DI.Interfaces.Models;

namespace Cafe.Bll.Models.Request
{
    /// <summary>
    /// A class for registering orders.
    /// </summary>
    public class Order : IOrder
    {
        [JsonProperty(PropertyName = "_platers")]
        private List<IPlatter> _platers;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="totalPrice"></param>
        /// <param name="date"></param>
        /// <param name="platters"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public Order(int id, DateTime date, List<IPlatter> platters)
        {
            if(id<=0)
                throw new ArgumentOutOfRangeException(nameof(id));

            if(date<=DateTime.MinValue)
                throw new ArgumentOutOfRangeException(nameof(date));

            if(date>=DateTime.MaxValue)
                throw new ArgumentOutOfRangeException(nameof(date));

            if(platters==null)
                throw new ArgumentNullException(nameof(platters));

            Id = id;
            Date = date;
            _platers=platters;
        }

        [JsonProperty(PropertyName = "Id")]
        public int Id { get; }

        [JsonIgnore]
        public int TotalPrice => _platers.Sum(i => i.Price);

        [JsonProperty(PropertyName = "Date")]
        public DateTime Date { get; }

        /// <summary>
        /// A method for adding a new dish.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(IPlatter item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            _platers.Add(item);
        }

        /// <summary>
        /// The method for returning all the dishes in the order.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<IPlatter> GetAll()
        {
            return _platers;
        }

        /// <summary>
        /// A method for removing a given dish.
        /// </summary>
        /// <param name="item"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(IPlatter item)
        {
            if(item==null)
                throw new ArgumentNullException(nameof(item));

            _platers.Remove(item);
        }
    }
}
