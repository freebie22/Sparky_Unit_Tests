using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class CalculatorXUnitTests
    {
        [Fact]
        public void AddNumber_InputTwoInts_GetCorrectAddtion()
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.Equal(30, result);
        }

        [Theory]
        [InlineData(11)]
        [InlineData(13)]
        public void IsOddNumber_InputOddNumber_ReturnTrue(int a)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(a);

            //Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(12)]
        public void IsOddNumber_InputEvenNumber_ReturnFalse(int a)
        {
            //Arrange
            Calculator calc = new Calculator();

            //Act
            bool result = calc.IsOddNumber(a);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(11, true)]
        public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
        {
            //Arrange
            Calculator calc = new();

            //Act
            bool result = calc.IsOddNumber(a);

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(10.53, 16.20)] //26.73
        [InlineData(10.53, 17.20)] //27.73
        [InlineData(10.53, 18.20)] //28.73
        public void AddNumbersDouble_InputTwoDoubles_GetCorrectAddition(double a, double b)
        {
            //Arrange
            Calculator calc = new Calculator();


            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            //Assert.That(result, Is.EqualTo(26.73));
            Assert.Equal(27.73, result, 2);
        }

        [Fact]
        public void GetOddRange_InputMinAndMaxValue_ReturnValidOddRange()
        {
            //Arrange
            Calculator calc = new Calculator();
            List<int> expectedRange = new List<int>() { 1, 3, 5, 7, 9 };

            //Act
            var actualRange = calc.GetOddRange(0, 10);

            //Assert
            //Assert.That(actualRange, Is.EquivalentTo(expectedRange));
            //ClassicAssert.Contains(7, actualRange);
            Assert.Equal(expectedRange, actualRange);
            Assert.Contains(7, actualRange);
            Assert.NotEmpty(actualRange);
            Assert.Equal(5, actualRange.Count);
            Assert.DoesNotContain(6, actualRange);
            Assert.Equal(expectedRange.OrderBy(u => u), actualRange);
        }

    }
}
