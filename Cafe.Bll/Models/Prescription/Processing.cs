using Newtonsoft.Json;
using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Operation.Processing;

namespace Cafe.Bll.Models.Prescription
{
    /// <summary>
    /// The class responsible for the processing of ingredients.
    /// </summary>
    public class Processing : IProcessing
    {
        [JsonIgnore]
        private static Semaphore s_semaphore=new Semaphore(3, 3);
        [JsonIgnore]
        private Thread _thread;

        /// <summary>
        /// Constructor for filling in data.
        /// </summary>
        /// <param name="price"></param>
        /// <param name="timeSpan"></param>
        /// <param name="operation"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Processing(int price, TimeSpan timeSpan, ProcessingType operation)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price));

            Price = price;
            TimeSpan = timeSpan;
            Operation = operation;

            _thread = new Thread(Execute);
            _thread.Start();
        }

        [JsonProperty(PropertyName = "Price")]
        public int Price { get; }

        [JsonProperty(PropertyName = "TimeSpan")]
        public TimeSpan TimeSpan { get; }

        [JsonProperty(PropertyName = "Operation")]
        public ProcessingType Operation { get; }

        /// <summary>
        /// The method that starts the execution of parallel processing.
        /// </summary>
        public void Execute()
        {
            s_semaphore.WaitOne();

            Process();

            s_semaphore.Release();
        }

        /// <summary>
        /// A method of simulating the processing process.
        /// </summary>
        private void Process()
        {
            Thread.Sleep(TimeSpan);
        }
    }
}
