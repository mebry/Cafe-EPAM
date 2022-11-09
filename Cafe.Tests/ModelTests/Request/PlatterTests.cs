using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe.DI.Enums;
using Cafe.Bll.Models.Request;

namespace Cafe.Tests.ModelTests.Request
{
    [TestClass]
    public class PlatterTests
    {
        ///<summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void Platter_AddNullValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new Platter(TypeOfProduct.Dish,null,1));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Platter_AddValidParameterByConstructor_IsTrue()
        {
            new Platter(TypeOfProduct.Dish, "NoN", 1);
        }

        ///<summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void Platter_AddEmptyStringByConstructor_ArgumentException()
        {
            Assert.ThrowsException<System.ArgumentException>(() =>
                new Platter(TypeOfProduct.Dish, "", 1));
        }
    }
}