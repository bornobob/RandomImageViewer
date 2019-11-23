using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomImageViewer.Exceptions;
using RandomImageViewer.Interfaces;
using Moq;

namespace RandomImageViewer.Tests
{
    [TestClass]
    public class WeightedRandomTests
    {
        private Mock<IRandomGenerator> _generatorMock;
        private WeightedRandom _randomService;

        [TestInitialize]
        public void WeightedRandomTestsInitialize()
        {
            _generatorMock = new Mock<IRandomGenerator>();
            _randomService = new WeightedRandom(_generatorMock.Object);
        }

        [TestMethod]
        public void RandomTestEmpty()
        {
            Assert.ThrowsException<InputArrayIsEmptyException>(() => _randomService.Random(new object[] { }, new int[] { }));
        }

        [TestMethod]
        public void RandomTestDifferingSizes()
        {
            Assert.ThrowsException<InputArraySizesDifferException>(() => _randomService.Random(new object[] { 1 }, new int[] { }));
        }

        [TestMethod]
        public void RandomTestNegativeWeight()
        {
            Assert.ThrowsException<NegativeWeightException>(() => _randomService.Random(new object[] { 1, 2 }, new int[] { -1, 0 }));
        }

        [TestMethod]
        public void RandomTestNormal1()
        {
            _generatorMock.Setup(g => g.Next(10)).Returns(8); //this can be anything from 6 to 9
            Assert.AreEqual(3, _randomService.Random(new object[] { 1, 2, 3 }, new int[] { 1, 5, 4 }));
        }

        [TestMethod]
        public void RandomTestNormal2()
        {
            _generatorMock.Setup(g => g.Next(1)).Returns(0);
            Assert.AreEqual(2, _randomService.Random(new object[] { 1, 2, 3 }, new int[] { 0, 1, 0 }));
        }
    }
}