using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cafe.DI.Enums;
using Cafe.Bll.Models.Prescription;
using Cafe.Bll.Models.Warehouse;

namespace Cafe.Tests.ModelTests.Prescription
{
    [TestClass]
    public class IngredientTests
    {

        // <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new Ingredient(1,TypeOfIngredient.Tomatoes,null));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddValidParameterByConstructor_IsTrue()
        {
            new Ingredient(1, TypeOfIngredient.Tomatoes, new Conditions(-1,1));
        }

        // <summary>
        /// Checking for a negative value.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddNegativeValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                new Ingredient(-1, TypeOfIngredient.Tomatoes, new Conditions(-1, 1)));
        }

        // <summary>
        /// Checking for a zero value.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddZeroValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                new Ingredient(0, TypeOfIngredient.Tomatoes, new Conditions(-1, 1)));
        }
    }
}