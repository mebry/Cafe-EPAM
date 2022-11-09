using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Enums;
using Cafe.Bll.Models.Prescription;

namespace Cafe.Tests.ModelTests.Prescription
{
    [TestClass]
    public class CookingStepTests
    {

        // <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void CookingStep_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new CookingStep((ProcessingType.NoProcessing, System.TimeSpan.Zero),
                null, System.TimeSpan.Zero));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void CookingStep_AddValidParameterByConstructor_IsTrue()
        {
            new CookingStep((ProcessingType.NoProcessing, System.TimeSpan.Zero),
                new List<(IIngredient, int)>(), System.TimeSpan.Zero);
        }
    }
}