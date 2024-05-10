using NUnit.Framework;
using NUnit.Framework.Legacy;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyNUnitTest
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumber_InputTwoInts_GetCorrectAddtion()
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            ClassicAssert.AreEqual(30, result);
        }

        [Test]
        [TestCase(11)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(a);

            //Assert
            Assert.That(result, Is.EqualTo(true));
            ClassicAssert.IsTrue(result);
        }

        [Test]
        [TestCase(58)]
        [TestCase(60)]
        public void IsOddNumber_InputEvenNumber_ReturnFalse(int a)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(a);

            //Assert
            Assert.That(result, Is.EqualTo(false));
            ClassicAssert.IsFalse(result);
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            //Arrange
            Calculator calc = new();

            //Act
            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(10.53, 16.20)] //26.73
        [TestCase(10.53, 17.20)] //27.73
        [TestCase(10.53, 18.20)] //28.73
        public void AddNumbersDouble_InputTwoDoubles_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calc = new Calculator();


            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            //Assert.That(result, Is.EqualTo(26.73));
            ClassicAssert.AreEqual(27.73, result, 2);
        }

        [Test]
        public void GetOddRange_InputMinAndMaxValue_ReturnValidOddRange()
        {
            //Arrange
            Calculator calc = new Calculator();
            List<int> expectedRange = new List<int>() {1, 3, 5, 7, 9 };

            //Act
            var actualRange = calc.GetOddRange(0, 10);

            //Assert
            //Assert.That(actualRange, Is.EquivalentTo(expectedRange));
            //ClassicAssert.Contains(7, actualRange);
            Assert.That(actualRange, Does.Contain(7));
            Assert.That(actualRange, Is.Not.Empty);
            Assert.That(actualRange.Count, Is.EqualTo(5));
            Assert.That(actualRange, Has.No.Member(6));
            Assert.That(actualRange, Is.Ordered);
            Assert.That(actualRange, Is.Unique);
        }

    }
}
