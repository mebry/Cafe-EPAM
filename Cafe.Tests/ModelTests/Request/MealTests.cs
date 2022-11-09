using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Cafe.DI.Enums;
using Cafe.Tests.TestData;
using Cafe.Bll.Models.Request;

namespace Cafe.Tests.ModelTests.Request
{
    [TestClass]
    public class MealTests
    {
        ///<summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void Meal_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new Meal(null));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Meal_AddValidParameterByConstructor_IsTrue()
        {
            new Meal(new List<(TypeOfProduct, string)> { });
        }

        /// <summary>
        /// Checking the method for correct execution.
        /// </summary>
        [TestMethod]
        public void ReadAll_CorrectnessOfTheWorkByMethod_IsTrue()
        {
            var data = new Meal(GetData.GetDataForMeal());

            int count = data.GetAll().Count();

            Assert.IsTrue(count > 0);
        }

        /// <summary>
        /// Checking the method for correct execution.
        /// </summary>
        [TestMethod]
        public void ReadAll_CorrectnessOfTheWorkByMethod_IsFalse()
        {
            var data = new Meal(GetData.GetDataForMeal());

            int count = data.GetAll().Count();

            Assert.IsFalse(count == 0);
        }

        /// <summary>
        /// Checking the method for correct execution.
        /// </summary>
        [TestMethod]
        public void Add_CorrectnessOfTheWorkByMethod_IsTrue()
        {
            var data = new Meal(new List<(TypeOfProduct, string)> { });

            data.Add((TypeOfProduct.Dish, " "));
            int count = data.GetAll().Count();

            Assert.IsTrue(count == 1);
        }

        /// <summary>
        /// Checking the method for correct execution.
        /// </summary>
        [TestMethod]
        public void Add_CorrectnessOfTheWorkByMethod_IsFalse()
        {
            var data = new Meal(new List<(TypeOfProduct, string)> { });

            data.Add((TypeOfProduct.Dish, " "));
            int count = data.GetAll().Count();

            Assert.IsFalse(count == 0);
        }

        /// <summary>
        /// Checking the method for correct execution.
        /// </summary>
        [TestMethod]
        public void Remove_CorrectnessOfTheWorkByMethod_IsTrue()
        {
            var data = new Meal(new List<(TypeOfProduct, string)> { });

            data.Add((TypeOfProduct.Dish, " "));
            data.Add((TypeOfProduct.Dish, " "));
            int count = data.GetAll().Count();

            data.Remove((TypeOfProduct.Dish, " "));
            int currentCount = data.GetAll().Count();

            Assert.IsTrue(count == currentCount + 1);
        }

        /// <summary>
        /// Checking the method for correct execution.
        /// </summary>
        [TestMethod]
        public void Remove_CorrectnessOfTheWorkByMethod_IsFalse()
        {
            var data = new Meal(new List<(TypeOfProduct, string)> { });

            data.Add((TypeOfProduct.Dish, " "));
            data.Add((TypeOfProduct.Dish, " "));
            int count = data.GetAll().Count();

            data.Remove((TypeOfProduct.Dish, " "));
            int currentCount = data.GetAll().Count();

            Assert.IsFalse(count == currentCount);
        }
    }
}