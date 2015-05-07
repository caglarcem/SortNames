using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using SortNames.Core;
using SortNames.Main;

namespace SortNames.Tests.Integration
{
    [TestClass]
    public class NameSortManagerFixture
    {
        private IFileHandler _fileSource;
        private NameSortManager _nameSortManager;

        [TestInitialize]
        public void Setup()
        {
            _fileSource = Substitute.For<IFileHandler>();
            _nameSortManager = new NameSortManager(new NameReader(_fileSource), new NameWriter(_fileSource), new NameSorter());
        }

        [TestMethod]
        public void NameSortManager_ShouldReadNamesAndWriteSortedList()
        {
            // Arrange
            _fileSource.ReadAllLines().Returns(new List<string> { "KENT, MADISON", "SMITH, FREDRICK", "SMITH, ANDREW", "BAKER, THEODORE" });

            // Act 
            var names = _nameSortManager.ReadItems();
            var sortedNames = _nameSortManager.Sort(names);
            var writtenNames = _nameSortManager.WriteItems(sortedNames).ToList();

            // Assert
            Assert.AreEqual(writtenNames.Count(), 4);
            Assert.AreEqual(writtenNames[0], "BAKER, THEODORE");
            Assert.AreEqual(writtenNames[1], "KENT, MADISON");
            Assert.AreEqual(writtenNames[2], "SMITH, ANDREW");
            Assert.AreEqual(writtenNames[3], "SMITH, FREDRICK");
        }
    }
}
