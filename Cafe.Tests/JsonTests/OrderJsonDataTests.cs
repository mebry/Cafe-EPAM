using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Cafe.Data.Storage.Json;
using Cafe.Data.Storage.Converters;
using Cafe.DI.Interfaces.Models;
using Cafe.Tests.TestData;


namespace Cafe.Tests.JsonTests
{
    [TestClass]
    public class OrderJsonDataTests
    {
        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void OrderJsonData_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IOrder>("path.json", null));
        }

        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void OrderJsonData_AddNullPathByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IOrder>(null, new List<IOrder>()));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void OrderJsonData_AddValidParameterByConstructor_IsTrue()
        {
            new JsonData<IOrder>(GetData.OrderJsonPath, new List<IOrder>());
        }

        /// <summary>
        /// Checking the method for writing to a file.
        /// </summary>
        [TestMethod]
        public void Write_SaveDataToFile_IsTrue()
        {
            var orders = new JsonData<IOrder>(GetData.OrderJsonPath, GetData.GetOrders());

            orders.Write();
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFile_NotThrowsException()
        {
            var orders = new JsonData<IOrder>(GetData.OrderJsonPath, new List<IOrder>());

            orders.Restore(new OrderConverter(), new PlatterConverter());
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFileWithoutTheConverter_ThrowsException()
        {
            var orders = new JsonData<IOrder>(GetData.OrderJsonPath, new List<IOrder>());

            try
            {
                orders.Restore();
            }
            catch
            {
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFileCheckingTheAppearanceOfData_IsTrue()
        {
            var orders = new JsonData<IOrder>(GetData.OrderJsonPath, new List<IOrder>());

            orders.Restore(new OrderConverter(), new PlatterConverter());
            int count = orders.GetAll().Count();

            Assert.IsTrue(count > 0);
        }
    }
}
