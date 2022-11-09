using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Cafe.Data.Storage.Json;
using Cafe.Data.Storage.Converters;
using Cafe.DI.Interfaces.Recipe;
using Cafe.Tests.TestData;


namespace Cafe.Tests.JsonTests
{
    [TestClass]
    public class RecipeJsonDataTests
    {
        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void RecipeJsonData_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IRecipe>("path.json", null));
        }


        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void RecipeJsonData_AddNullPathByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IRecipe>(null, new List<IRecipe>()));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void RecipeJsonData_AddValidParameterByConstructor_IsTrue()
        {
            new JsonData<IRecipe>("path.json", new List<IRecipe>());
        }

        /// <summary>
        /// Checking the method for writing to a file.
        /// </summary>
        [TestMethod]
        public void Write_SaveDataToFile_IsTrue()
        {
            var recipes = new JsonData<IRecipe>(GetData.RecipeJsonDataPath, GetData.GetRecipes());

            recipes.Write();
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFile_NotThrowsException()
        {
            var recipes = new JsonData<IRecipe>(GetData.RecipeJsonDataPath, new List<IRecipe>());

            recipes.Restore(new CookingStepConverter(), new IngredientConverter(),new RecipeConverter());
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFileWithoutTheConverter_ThrowsException()
        {
            var recipes = new JsonData<IRecipe>(GetData.RecipeJsonDataPath, new List<IRecipe>());

            try
            {
                recipes.Restore(new CookingStepConverter(), new RecipeConverter());
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
            var recipes = new JsonData<IRecipe>(GetData.RecipeJsonDataPath, new List<IRecipe>());

            recipes.Restore(new CookingStepConverter(), new IngredientConverter(), new RecipeConverter());
            int count = recipes.GetAll().Count();

            Assert.IsTrue(count > 0);
        }
    }
}
