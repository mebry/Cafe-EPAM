using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Recipe;
using Cafe.Bll.Models.Prescription;

namespace Cafe.Tests.ModelTests.Prescription
{
    [TestClass]
    public class RecipeTests
    {
        ///<summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void Recipe_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new Recipe(1, "NoN", TypeOfProduct.Dish, null, null));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Recipe_AddValidParameterByConstructor_IsTrue()
        {
            new Recipe(1, "NoN", TypeOfProduct.Dish, new List<ICookingStep>(),
                new List<(DI.Interfaces.Models.IIngredient, int)>());
        }

        // <summary>
        /// Checking for a negative value.
        /// </summary>
        [TestMethod]
        public void Recipe_AddNegativeValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                 new Recipe(-1, "NoN", TypeOfProduct.Dish, new List<ICookingStep>(),
                new List<(DI.Interfaces.Models.IIngredient, int)>()));
        }

        // <summary>
        /// Checking for a zero value.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddZeroValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() =>
                 new Recipe(0, "NoN", TypeOfProduct.Dish, new List<ICookingStep>(),
                new List<(DI.Interfaces.Models.IIngredient, int)>()));
        }

        // <summary>
        /// Checking for a null value.
        /// </summary>
        [TestMethod]
        public void Ingredient_AddNullStringValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                 new Recipe(1, null, TypeOfProduct.Dish, new List<ICookingStep>(),
                new List<(DI.Interfaces.Models.IIngredient, int)>()));
        }
    }
}