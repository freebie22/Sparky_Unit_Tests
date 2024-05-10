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
    public class CustomerNUnitTests
    {
        private Customer customer;

        [SetUp]
        public void Setup()
        {
            customer = new Customer();
        }

        [Test]
        [TestCase("Artem", "Boikov")]
        public void GreetAndCombineNames_InputFirstAndLastName_ReturnFullName(string firstName, string lastName)
        {
            //Arrange
            //customer = new Customer();

            //Act
            customer.GreetAndCombineNames(firstName, lastName);

            //Assert
            Assert.Multiple(() =>
            {
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Artem Boikov"));
                Assert.That(customer.GreetMessage, Does.Contain("artem Boikov").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(customer.GreetMessage, Does.EndWith("Boikov"));
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
            //ClassicAssert.AreEqual("Hello, Artem Boikov", fullName);
        }

        [Test]
        public void GreetAndCombineNames_NotGreeted_ReturnNull()
        {
            //Arrange
            //customer = new Customer();

            //Act
            //customer.GreetAndCombineNames("Artem", "Boikov");

            //Assert
            //ClassicAssert.IsNull(customer.GreetMessage);
            Assert.That(customer.GreetMessage, Is.Null);
        }

        [Test]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            //Arrange
            //Customer customer = new Customer();

            //Act
            //customer.GreetAndCombineNames("Artem", "Boikov");

            //Assert
            Assert.That(customer.Discount, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            //Act
            customer.GreetAndCombineNames("Artem", "");

            //Assert
            Assert.That(customer.GreetMessage, Is.Not.Null);
            ClassicAssert.IsFalse(string.IsNullOrWhiteSpace(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Boikov"));
            ClassicAssert.AreEqual("FirstName is empty", exceptionDetails.Message);
            Assert.That(
                () => customer.GreetAndCombineNames("", "Boikov"),
                Throws.ArgumentException.With.Message.EqualTo("FirstName is empty"));

            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Boikov"));
            Assert.That(
                () => customer.GreetAndCombineNames("", "Boikov"),
                Throws.ArgumentException);
        }

        [Test]
        public void CustomerType_CreateCustomerLessThat100OrderTotal_ReturnTypeBasicCustomer()
        {
            //Act
            customer.OrderTotal = 10;

            var result = customer.GetCustomerDetails();

            //Assert
            Assert.That(result, Is.InstanceOf(typeof(BasicCustomer)));
            ClassicAssert.IsInstanceOf(typeof(BasicCustomer), result);

            Assert.That(result, Is.TypeOf(typeof(BasicCustomer)));

        }

        [Test]
        public void CustomerType_CreateCustomerMoreThat100OrderTotal_ReturnTypePlatinumCustomer()
        {
            //Act
            customer.OrderTotal = 250;

            var result = customer.GetCustomerDetails();

            //Assert
            Assert.That(result, Is.InstanceOf(typeof(PlatinumCustomer)));
            ClassicAssert.IsInstanceOf(typeof(PlatinumCustomer), result);

            Assert.That(result, Is.TypeOf(typeof(PlatinumCustomer)));

        }
    }
}
