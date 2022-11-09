using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Cafe.DI.Enums;
using Cafe.Tests.TestData;
using Cafe.DI.Interfaces.Models;
using Cafe.Bll.Models.Request;

namespace Cafe.Tests.ModelTests.Request
{
    [TestClass]
    public class OrderTests
    {
        ///<summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void Order_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new Order(1, System.DateTime.Now, null));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Order_AddValidParameterByConstructor_IsTrue()
        {
            new Order(1, System.DateTime.Now, new List<IPlatter>());
        }

        /// <summary>
        /// Checking the method for correct execution.
        /// </summary>
        [TestMethod]
        public void ReadAll_CorrectnessOfTheWorkByMethod_IsTrue()
        {
            var data = new Order(1, System.DateTime.Now, GetData.GetPlatters());

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
             var data = new Order(1, System.DateTime.Now, new List<IPlatter>());

            data.Add(new Platter(TypeOfProduct.Dish,"NoN",1));
            int count = data.GetAll().Count();

            Assert.IsTrue(count == 1);
        }

        /// <summary>
        /// Checking the method for correct execution.
        /// </summary>
        [TestMethod]
        public void Remove_CorrectnessOfTheWorkByMethod_IsTrue()
        {
            var data = new Order(1, System.DateTime.Now, new List<IPlatter>());

            data.Add(new Platter(TypeOfProduct.Dish, "NoN", 1));
            int count = data.GetAll().Count();
            data.Remove(new Platter(TypeOfProduct.Dish, "NoN", 1));
            int currentCount = data.GetAll().Count();

            Assert.IsTrue(count == currentCount+1);
        }
    }
}