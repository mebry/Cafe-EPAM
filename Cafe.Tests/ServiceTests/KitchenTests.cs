using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Cafe.DI.Enums;
using Cafe.DI.Interfaces.Models;
using Cafe.DI.Interfaces.Recipe;
using Cafe.DI.Interfaces.Operation.Processing;
using Cafe.Bll.Models.Prescription;
using Cafe.Bll.Models.Request;
using Cafe.Bll.Service.Operation;
using Cafe.Tests.TestData;

namespace Cafe.Tests.ModelTests.ServiceTests
{
    [TestClass]
    public class KitchenTests
    {
        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void Kitchen_AddValidParameterByConstructor_IsTrue()
        {
            new Kitchen(new List<IIngredientsStorage>(), new List<IProcessing>(),
                new List<IOrder>(), new List<IRecipe>());
        }

        // <summary>
        /// Checking for a null value.
        /// </summary>
        [TestMethod]
        public void Kitchen_AddNullValueByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new Kitchen(new List<IIngredientsStorage>(), new List<IProcessing>(),
                new List<IOrder>(), null));
        }

        // <summary>
        /// Checking the method for operability.
        /// </summary>
        [TestMethod]
        public void CreateRecipe_CreateTheNewRecipe_IsTrue()
        {
            new Kitchen(new List<IIngredientsStorage>(), new List<IProcessing>(),
                new List<IOrder>(), new List<IRecipe>());

            int count = Kitchen.Recipes.Count();
            Kitchen.Chief.CreateRecipe(new Recipe(100, "Something",
                TypeOfProduct.Dish, new List<ICookingStep>(), new List<(IIngredient, int)>()));
            int currentCount = Kitchen.Recipes.Count();

            Assert.IsTrue(count == currentCount - 1);
        }

        // <summary>
        /// Checking the method for operability.
        /// </summary>
        [TestMethod]
        public void CreateRecipe_CreateTheNewRecipe_IsFalse()
        {
            new Kitchen(new List<IIngredientsStorage>(), new List<IProcessing>(),
                new List<IOrder>(), new List<IRecipe>());

            int count = Kitchen.Recipes.Count();
            Kitchen.Chief.CreateRecipe(new Recipe(100, "Something",
                TypeOfProduct.Dish, new List<ICookingStep>(), new List<(IIngredient, int)>()));
            int currentCount = Kitchen.Recipes.Count();

            Assert.IsFalse(count == currentCount);
        }

        // <summary>
        /// Checking the method for operability.
        /// </summary>
        [TestMethod]
        public void ExecuteOrder_CreateTheNewRecipe_IsTrue()
        {
            new Kitchen(new List<IIngredientsStorage>(), new List<IProcessing>(),
                new List<IOrder>(), new List<IRecipe>());

            Kitchen.Chief.ExecuteOrder(new Order(1, System.DateTime.Now, GetData.GetPlatters()));
        }

        // <summary>
        /// Checking the method for operability.
        /// </summary>
        [TestMethod]
        public void ExecuteOrder_CreateTheNewRecipe_ThrowsException()
        {
            new Kitchen(new List<IIngredientsStorage>(), new List<IProcessing>(),
                new List<IOrder>(), new List<IRecipe>());

            Assert.ThrowsException<System.ArgumentNullException>(() =>
                Kitchen.Chief.ExecuteOrder(null));
        }
    }
}