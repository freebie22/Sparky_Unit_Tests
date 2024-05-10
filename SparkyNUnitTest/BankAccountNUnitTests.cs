using Moq;
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
    public class BankAccountNUnitTests
    {
        private BankAccount _account;

        [SetUp]
        public void Setup()
        {
            
        }

        //[Test]
        //public void BankDepositWithFakeLogger_Add100_ReturnTrue()
        //{
        //    //Arrange
        //    BankAccount bankAccount = new BankAccount(new FakeLogBook());

        //    //Act
        //    bool result = bankAccount.Deposit(100);

        //    //Assert
        //    ClassicAssert.IsTrue(result);
        //    Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        //}

        [Test]
        public void BankDeposit_Add100_ReturnTrue()
        {
            //Arrange
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new BankAccount(logMock.Object);

            logMock.Setup(x => x.Message(""));

            //Act
            bool result = bankAccount.Deposit(100);

            //Assert
            ClassicAssert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 50)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            //Arrange
            var logMock = new Mock<ILogBook>(); 
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);

            //Act
            bankAccount.Deposit(balance);

            //Assert
            var result = bankAccount.Withdraw(withdraw);
            Assert.That(result, Is.True);
        }

        [Test]
        public void BankWithdraw_Withdraw300With200Balance_ReturnsFalse()
        {
            //Arrange
            var logMock = new Mock<ILogBook>();
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.Is<int>(x => x > 0))).Returns(true);
            logMock.Setup(u => u.LogBalanceAfterWithdrawal(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive))).Returns(false);

            BankAccount bankAccount = new(logMock.Object);

            //Act
            bankAccount.Deposit(200);

            //Assert
            var result = bankAccount.Withdraw(300);
            Assert.That(result, Is.False);
        }

        [Test]
        public void BankLogDummy_LogMockString_ReturnsTrue()
        {
            //Arrange
            var logBook = new Mock<ILogBook>();
            string desiredOutput = "hello";

            //Act
            logBook.Setup(u => u.MessageWithReturnStr(It.IsAny<string>())).Returns((string str) => str.ToLower());

            //Assert
            Assert.That(logBook.Object.MessageWithReturnStr("HELLo"), Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogMockStringOutputStr_ReturnsTrue()
        {
            //Arrange
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            //Act
            logMock.Setup(u => u.LogWithOutputStr(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";

            //Assert
            Assert.That(logMock.Object.LogWithOutputStr("Ben", out result), Is.True);
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnsTrue()
        {
            //Arrange
            var logMock = new Mock<ILogBook>();
            Customer customer = new Customer();
            Customer customerNotUsed = new Customer();

            //Act
            logMock.Setup(u => u.LogWithRefObj(ref customer)).Returns(true);

            //Assert
            Assert.That(logMock.Object.LogWithRefObj(ref customer), Is.True);
            Assert.That(logMock.Object.LogWithRefObj(ref customerNotUsed), Is.False);
        }

        [Test]
        public void BankLogDummy_SetAndGetLogTypeAndSeverityMockTest()
        {
            //Arrange
            var logMock = new Mock<ILogBook>();

            logMock.Setup(u => u.LogSeverity).Returns(10);
            logMock.SetupAllProperties();
            logMock.Setup(u => u.LogType).Returns("Warning");


            logMock.Object.LogSeverity = 100;

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(100));
            Assert.That(logMock.Object.LogType, Is.EqualTo("Warning"));

            //Callbacks
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp += str);

            logMock.Object.LogToDb("Artem");
            Assert.That(logTemp, Is.EqualTo("Hello, Artem"));

            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => counter++);

            logMock.Object.LogToDb("Artem");
            Assert.That(counter, Is.EqualTo(6));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new BankAccount(logMock.Object);
            bankAccount.Deposit(100);
            Assert.That(bankAccount.GetBalance(), Is.EqualTo(100));

            //verification
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.AtLeastOnce());
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);
            logMock.VerifyGet(u => u.LogSeverity, Times.Once);

        }
    }
}
