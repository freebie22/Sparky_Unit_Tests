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
    public class GradingCalculatorNUnitTests
    {
        private GradingCalculator gradingCalculator;

        [SetUp]
        public void Setup()
        {
            gradingCalculator = new GradingCalculator();
        }

        [Test]
        [TestCase(95,90)]
        public void GetGrade_ScoreIs95AndAttendanceIs90_ReturnGradeA(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("A"));
        }

        [Test]
        [TestCase(85, 90)]
        public void GetGrade_ScoreIs85AndAttendanceIs90_ReturnGradeB(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(65, 90)]
        public void GetGrade_ScoreIs65AndAttendanceIs90_ReturnGradeC(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("C"));
        }

        [Test]
        [TestCase(85, 90)]
        public void GetGrade_ScoreIs95AndAttendanceIs65_ReturnGradeB(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("B"));
        }

        [Test]
        [TestCase(95, 55)]
        [TestCase(65, 55)]
        [TestCase(50, 90)]

        public void GetGrade_ScoreOrAttendanceIsLessThan65_ReturnGradeF(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            string result = gradingCalculator.GetGrade();

            //Assert
            Assert.That(result, Is.EqualTo("F"));
        }

        [Test]
        [TestCase(95, 95, ExpectedResult = "A")]
        [TestCase(85, 75, ExpectedResult = "B")]
        [TestCase(65, 75, ExpectedResult = "C")]
        [TestCase(55, 55, ExpectedResult = "F")]

        public string GetGrade_InputScoreAndAttendance_ReturnGrade(int score, int attendancePercentage)
        {
            //Arrange
            gradingCalculator.Score = score;
            gradingCalculator.AttendancePercentage = attendancePercentage;

            //Act
            return gradingCalculator.GetGrade();
        }
    }
}
