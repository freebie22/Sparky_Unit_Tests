using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class FiboSeriesXUnitTests
    {
        private Fibo fibo;

        public FiboSeriesXUnitTests()
        {
            fibo = new Fibo();
        }

        [Fact]
        public void GetFiboSeries_InputRangeOf1_ReceiveListWith1Element()
        {
            //Arrange
            fibo.Range = 1;
            List<int> expectedList = new List<int>() { 0 };

            //Act
            var result = fibo.GetFiboSeries();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(result.OrderBy(u => u), result);
            Assert.Equivalent(expectedList, result);
            Assert.True(result.SequenceEqual(expectedList));
        }

        [Fact]
        public void GetFiboSeries_InputRangeOf6_ReceiveListWith6Elements()
        {
            //Arrange
            fibo.Range = 6;
            List<int> expectedList = new List<int>() { 0, 1, 1, 2, 3, 5 };

            //Act
            var result = fibo.GetFiboSeries();

            //Assert
            Assert.Contains(3, expectedList);
            Assert.Equal(6, expectedList.Count);
            Assert.DoesNotContain(4, result);
            Assert.Equivalent(expectedList, result);
        }
    }
}
