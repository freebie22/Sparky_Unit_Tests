using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class GradingCalculatorXUnitTests
    {
        private GradingCalculator gradingCalculator;

        public GradingCalculatorXUnitTests()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Theory]
        [InlineData(95, 90)]
        public void GetGrade_ScoreIs95AndAttendanceIs90_ReturnGradeA(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("A", result);
        }

        [Theory]
        [InlineData(85, 90)]
        public void GetGrade_ScoreIs85AndAttendanceIs90_ReturnGradeB(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(65, 90)]
        public void GetGrade_ScoreIs65AndAttendanceIs90_ReturnGradeC(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("C", result);
        }

        [Theory]
        [InlineData(85, 90)]
        public void GetGrade_ScoreIs95AndAttendanceIs65_ReturnGradeB(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("B", result);
        }

        [Theory]
        [InlineData(95, 55)]
        [InlineData(65, 55)]
        [InlineData(50, 90)]

        public void GetGrade_ScoreOrAttendanceIsLessThan65_ReturnGradeF(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal("F", result);
        }

        [Theory]
        [InlineData(95, 95, "A")]
        [InlineData(85, 75, "B")]
        [InlineData(65, 75, "C")]
        [InlineData(55, 55, "F")]

        public void GetGrade_InputScoreAndAttendance_ReturnGrade(int score, int attendancePercentage, string expectedResult)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
