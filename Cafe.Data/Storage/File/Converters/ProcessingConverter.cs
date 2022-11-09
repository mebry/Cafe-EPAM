using Newtonsoft.Json.Converters;
using Cafe.DI.Interfaces.Operation.Processing;
using Cafe.DI.Enums;
using Cafe.Bll.Models.Prescription;

namespace Cafe.Data.Storage.Converters
{
    /// <summary>
    /// The class responsible for the specific substitution of the object.
    /// </summary>
    public class ProcessingConverter : CustomCreationConverter<IProcessing>
    {
        // <summary>
        /// Creating a class explicitly specifying through what we create.
        /// </summary>
        /// <param name="objectType"></param>
        /// <returns></returns>
        public override IProcessing Create(Type objectType)
        {
            return new Processing(1, new TimeSpan(0, 0, 1),ProcessingType.NoProcessing);
        }
    }
}
