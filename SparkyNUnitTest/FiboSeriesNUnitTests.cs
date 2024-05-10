using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class FiboSeriesNUnitTests
    {
        private Fibo fibo;

        [SetUp]
        public void Setup()
        {
            fibo = new Fibo();
        }

        [Test]
        public void GetFiboSeries_InputRangeOf1_ReceiveListWith1Element()
        {
            //Arrange
            fibo.Range = 1;
            List<int> expectedList = new List<int>() { 0 };

            //Act
            var result = fibo.GetFiboSeries();

            //Assert
            Assert.That(result, Is.Not.Empty);
            Assert.That(result, Is.Ordered);
            Assert.That(result, Is.EquivalentTo(expectedList));
        }

        [Test]
        public void GetFiboSeries_InputRangeOf6_ReceiveListWith6Elements()
        {
            //Arrange
            fibo.Range = 6;
            List<int> expectedList = new List<int>() { 0, 1, 1, 2, 3, 5 };

            //Act
            var result = fibo.GetFiboSeries();

            //Assert
            Assert.That(result, Does.Contain(3));
            Assert.That(result.Count, Is.EqualTo(6));   
            Assert.That(result, Has.No.Member(4));
            Assert.That(result, Is.EquivalentTo(expectedList));
        }
    }
}
