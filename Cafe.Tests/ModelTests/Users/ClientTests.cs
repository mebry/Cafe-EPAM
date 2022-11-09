using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cafe.DI.Enums;
using Cafe.Tests.TestData;
using Cafe.Bll.Models.Users;
using Cafe.Bll.Models.Request;

namespace Cafe.Tests.ModelTests.Users
{
    [TestClass]
    public class ClientTests
    {
        ///<summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void Client_AddNullValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new Client(1, 1, new Meal(new List<(TypeOfProduct, string)>()), null));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Client_AddValidParameterByConstructor_IsTrue()
        {
            new Client(1, 1, new Meal(new List<(TypeOfProduct, string)>()), " ");
        }

        ///<summary>
        /// Check for adding a negative value.
        /// </summary>
        [TestMethod]
        public void Client_AddNegativeValueByConstructor_ArgumentOutOfRangeException()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                new Client(-1, 1, new Meal(new List<(TypeOfProduct, string)>()), " "));
        }

        ///<summary>
        /// Check for adding a zero value.
        /// </summary>
        [TestMethod]
        public void Client_AddZeroValueByConstructor_IsTrue()
        {
            new Client(0, 1, new Meal(new List<(TypeOfProduct, string)>()), " ");
        }

        /// <summary>
        /// Checking for correctness of execution.
        /// </summary>
        [TestMethod]
        public void CreateOrder_CorrectMethodСall_IsTrue()
        {
            var client = new Client(0, 1, new Meal(GetData.GetDataForMeal()), " ");

            var data = client.CreateOrder();

            Assert.IsTrue(data != null);
        }

        /// <summary>
        /// Checking for correctness of execution.
        /// </summary>
        [TestMethod]
        public void PutMoney_CorrectMethodСall_IsTrue()
        {
            var client = new Client(0, 1, new Meal(GetData.GetDataForMeal()), " ");

            client.PutMoney(10);

            Assert.IsTrue(client.Balance == 10);
        }

        /// <summary>
        /// Checking for correctness of execution.
        /// </summary>
        [TestMethod]
        public void PutMoney_CorrectMethodСall_ArgumentOutOfRangeException()
        {
            var client = new Client(0, 1, new Meal(GetData.GetDataForMeal()), " ");

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                client.PutMoney(-10));
        }

        /// <summary>
        /// Checking for correctness of execution.
        /// </summary>
        [TestMethod]
        public void Pay_CorrectMethodСall_IsTrue()
        {
            var client = new Client(0, 1, new Meal(GetData.GetDataForMeal()), " ");

            client.PutMoney(10);
            client.Pay(10);

            Assert.IsTrue(client.Balance == 0);
        }

        /// <summary>
        /// Checking for correctness of execution.
        /// </summary>
        [TestMethod]
        public void Pay_CorrectMethodСall_ArgumentOutOfRangeException()
        {
            var client = new Client(0, 1, new Meal(GetData.GetDataForMeal()), " ");

            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                client.Pay(-10));
        }
    }
}