using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.User;
using Cafe.Tests.TestData;
using Cafe.Bll.Models.Users;
using Cafe.Bll.Models.Request;

namespace Cafe.Tests.ModelTests.Users
{
    [TestClass]
    public class ManagerTests
    {
        ///<summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void Manager_AddNullValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new Manager(null, "NoN"));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Manager_AddValidParameterByConstructor_IsTrue()
        {
            new Manager(GetData.GetPlatters(), "NoN");
        }

        ///<summary>
        /// Checking for correctness of execution.
        /// </summary>
        [TestMethod]
        public void CreateOrder_AddZeroValueByConstructor_IsTrue()
        {
            var manager = new Manager(GetData.GetPlatters(), "NoN");

            IOrder order = manager.CreateOrder(new Client(10000, 1, new Meal(GetData.GetDataForMeal()), " "));

            Assert.IsTrue(order != null);
        }
    }
}