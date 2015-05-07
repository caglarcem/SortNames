using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SortNames.Core;
using SortNames.Main;

namespace SortNames.Tests.Unit
{
    [TestClass]
    public class SortNamesFixture
    {
        private IFileHandler _fileSource;
        
        [TestInitialize]
        public void Setup()
        {
            _fileSource = Substitute.For<IFileHandler>();
        }

        [TestMethod]
        public void NameReader_ShouldReadNamesFromFile()
        {
            // Arrange
            _fileSource.ReadAllLines().Returns(new List<string> { "BAKER, THEODORE", "SMITH, FREDRICK" });
            var name1 = new Name("BAKER", "THEODORE");
            var name2 = new Name("SMITH", "FREDRICK");
            var nameReader = new NameReader(_fileSource);

            // Act 
            List<Name> names = nameReader.ReadItems().ToList();

            // Assert
            Assert.AreEqual(names.Count(), 2);
            Assert.AreEqual(names.First(), name1);
            Assert.AreEqual(names.Last(), name2);
        }

        [TestMethod]
        public void NameSorter_ShouldSortNames()
        {
            // Arrange
            var nameList = new List<Name> { new Name("SMITH", "FREDRICK"), new Name("BAKER", "THEODORE"), new Name("SMITH", "ANDREW") };
            var nameSorter = new NameSorter();

            // Act 
            List<Name> sortedList = nameSorter.Sort(nameList).ToList();

            // Assert
            Assert.AreEqual(sortedList[0], new Name("BAKER", "THEODORE"));
            Assert.AreEqual(sortedList[1], new Name("SMITH", "ANDREW"));
            Assert.AreEqual(sortedList[2], new Name("SMITH", "FREDRICK"));
        }

        [TestMethod]
        public void NameWriter_ShouldWriteNamesToFile()
        {
            // Arrange
            var nameList = new List<Name> { new Name("BAKER", "THEODORE"), new Name("SMITH", "FREDRICK") };
            var nameWriter = new NameWriter(_fileSource);

            // Act 
            List<string> names = nameWriter.WriteItems(nameList).ToList();

            // Assert
            Assert.AreEqual(names.First(), "BAKER, THEODORE");
            Assert.AreEqual(names.Last(), "SMITH, FREDRICK");
        }

    }
}
