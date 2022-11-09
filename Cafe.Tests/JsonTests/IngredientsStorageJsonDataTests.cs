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
    public class IngredientsStorageJsonDataTests
    {
        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void IngredientsStorageJsonData_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() 
                => new JsonData<IIngredientsStorage>(GetData.IngredientsStorageJsonPath, null));
        }

        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void IngredientsStorageJsonData_AddNullPathByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IIngredientsStorage>(null, GetData.GetIngredientsStorages()));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void IngredientsStorageJsonData_AddValidParameterByConstructor_IsTrue()
        {
            new JsonData<IIngredientsStorage>(GetData.IngredientsStorageJsonPath, GetData.GetIngredientsStorages());
        }

        /// <summary>
        /// Checking the method for writing to a file.
        /// </summary>
        [TestMethod]
        public void Write_SaveDataToFile_IsTrue()
        {
            var ingredientsStorageJson =
                new JsonData<IIngredientsStorage>(GetData.IngredientsStorageJsonPath, GetData.GetIngredientsStorages());

            ingredientsStorageJson.Write();
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFile_NotThrowsException()
        {
            var ingredientsStorageJson =
                new JsonData<IIngredientsStorage>(GetData.IngredientsStorageJsonPath, GetData.GetIngredientsStorages());

            ingredientsStorageJson.Restore(new IngredientConverter(), new IngredientsStorageConverter());
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFileWithoutTheConverter_ThrowsException()
        {
            var ingredientsStorageJson =
                new JsonData<IIngredientsStorage>(GetData.IngredientsStorageJsonPath, GetData.GetIngredientsStorages());

            try
            {
                ingredientsStorageJson.Restore();
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
            var ingredientsStorageJson =
                new JsonData<IIngredientsStorage>(GetData.IngredientsStorageJsonPath, GetData.GetIngredientsStorages());

            ingredientsStorageJson.Restore(new IngredientConverter(), new IngredientsStorageConverter());
            int count = ingredientsStorageJson.GetAll().Count();

            Assert.IsTrue(count > 0);
        }
    }
}
