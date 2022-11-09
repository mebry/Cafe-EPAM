using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe.DI.Enums;
using Cafe.Bll.Models.Prescription;
using Cafe.Bll.Models.Warehouse;

namespace Cafe.Tests.ModelTests.Prescription
{
    [TestClass]
    public class ProcessingTests
    {
        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddValidParameterByConstructor_IsTrue()
        {
            new Processing(1, System.TimeSpan.Zero, ProcessingType.NoProcessing);
        }

        // <summary>
        /// Checking for a negative value.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddNegativeValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                new Processing(-10, System.TimeSpan.Zero, ProcessingType.NoProcessing));
        }

        // <summary>
        /// Checking for a zero value.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddZeroValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                new Processing(0, System.TimeSpan.Zero, ProcessingType.NoProcessing));
        }
    }
}