using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Cafe.Data.Storage.Json;
using Cafe.Data.Storage.Converters;
using Cafe.DI.Interfaces.Recipe;
using Cafe.DI.Interfaces.Operation.Processing;
using Cafe.Tests.TestData;


namespace Cafe.Tests.JsonTests
{
    [TestClass]
    public class ProcessingJsonDataTests
    {
        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void ProcessingJsonData_AddNullListByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IProcessing>("path.json", null));
        }


        /// <summary>
        /// Checking the constructor when passing a null parameter.
        /// </summary>
        [TestMethod]
        public void ProcessingJsonData_AddNullPathByConstructor_ThrowsException()
        {
            Assert.ThrowsException<System.ArgumentNullException>(() =>
                new JsonData<IProcessing>(null, new List<IProcessing>()));
        }

        /// <summary>
        /// Checking the constructor when passing the correct parameter.
        /// </summary>
        [TestMethod]
        public void ProcessingJsonData_AddValidParameterByConstructor_IsTrue()
        {
            new JsonData<IProcessing>("path.json", new List<IProcessing>());
        }

        /// <summary>
        /// Checking the method for writing to a file.
        /// </summary>
        [TestMethod]
        public void Write_SaveDataToFile_IsTrue()
        {
            var processing = new JsonData<IProcessing>(GetData.ProcessingJsonDataPath, GetData.GetProcessing());

            processing.Write();
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFile_NotThrowsException()
        {
            var processing = new JsonData<IProcessing>(GetData.ProcessingJsonDataPath, new List<IProcessing>());

            processing.Restore(new ProcessingConverter());
        }

        /// <summary>
        /// Checking the method for reading from a file.
        /// </summary>
        [TestMethod]
        public void Restore_ReadDataFromFileWithoutTheConverter_ThrowsException()
        {
            var processing = new JsonData<IProcessing>(GetData.ProcessingJsonDataPath, new List<IProcessing>());

            try
            {
                processing.Restore();
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
            var processing = new JsonData<IProcessing>(GetData.ProcessingJsonDataPath, new List<IProcessing>());

            processing.Restore(new ProcessingConverter());
            int count = processing.GetAll().Count();

            Assert.IsTrue(count > 0);
        }
    }
}
