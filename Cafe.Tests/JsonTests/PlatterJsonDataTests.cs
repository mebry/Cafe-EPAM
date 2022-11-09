using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Cafe.Bll.Models.Request;
using Cafe.Data.Storage.Json;
using Cafe.Data.Storage.Converters;
using Cafe.DI.Interfaces.Models;
using Cafe.Tests.TestData;


namespace Cafe.Tests.JsonTests
{
    [TestClass]
    public class PlatterJsonDataTests
    {
        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void PlatterJsonData_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IPlatter>("path.json", null));
        }


        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void PlatterJsonData_AddNullPathByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IPlatter>(null, new List<IPlatter>()));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void PlatterJsonData_AddValidParameterByConstructor_IsTrue()
        {
            new JsonData<IPlatter>(GetData.PlatterJsonDataPath, new List<IPlatter>());
        }

        /// <summary>
        /// Checking the method for writing to a file.
        /// </summary>
        [TestMethod]
        public void Write_SaveDataToFile_IsTrue()
        {
            var platters = new JsonData<IPlatter>(GetData.PlatterJsonDataPath, GetData.GetPlatters());

            platters.Write();
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFile_NotThrowsException()
        {
            var platters = new JsonData<IPlatter>(GetData.PlatterJsonDataPath, new List<IPlatter>());

            platters.Restore(new PlatterConverter());
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFileWithoutTheConverter_ThrowsException()
        {
            var platters = new JsonData<IPlatter>(GetData.PlatterJsonDataPath, new List<IPlatter>());


            try
            {
                platters.Restore();
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
            var platters = new JsonData<IPlatter>(GetData.PlatterJsonDataPath, new List<IPlatter>());

            platters.Restore(new PlatterConverter());

            int count = platters.GetAll().Count();

            Assert.IsTrue(count > 0);
        }
    }
}
