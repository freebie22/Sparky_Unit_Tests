using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class CustomerXUnitTests
    {
        private Customer customer;

        public CustomerXUnitTests()
        {
            customer = new Customer();
        }

        [Theory]
        [InlineData("Artem", "Boikov")]
        public void GreetAndCombineNames_InputFirstAndLastName_ReturnFullName(string firstName, string lastName)
        {
            //Arrange
            //customer = new Customer();

            //Act
            customer.GreetAndCombineNames(firstName, lastName);

            //Assert
 
            Assert.Equal("Hello, Artem Boikov", customer.GreetMessage);
            Assert.Contains("artem Boikov".ToLower(), customer.GreetMessage.ToLower());
            Assert.StartsWith("Hello,", customer.GreetMessage);
            Assert.EndsWith("Boikov", customer.GreetMessage);
            Assert.Matches("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", customer.GreetMessage);
            //ClassicAssert.AreEqual("Hello, Artem Boikov", fullName);
        }

        [Fact]
        public void GreetAndCombineNames_NotGreeted_ReturnNull()
        {
            //Arrange
            //customer = new Customer();

            //Act
            //customer.GreetAndCombineNames("Artem", "Boikov");

            //Assert
            //ClassicAssert.IsNull(customer.GreetMessage);
            Assert.Null(customer.GreetMessage);
        }

        [Fact]
        public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
        {
            //Arrange
            //Customer customer = new Customer();

            //Act
            //customer.GreetAndCombineNames("Artem", "Boikov");

            //Assert
            Assert.InRange(customer.Discount, 10, 25);
        }

        [Fact]
        public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
        {
            //Act
            customer.GreetAndCombineNames("Artem", "");

            //Assert
            Assert.NotNull(customer.GreetMessage);
            Assert.False(string.IsNullOrWhiteSpace(customer.GreetMessage));
        }

        [Fact]
        public void GreetChecker_EmptyFirstName_ThrowsException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Boikov"));
            Assert.Equal("FirstName is empty", exceptionDetails.Message);


            Assert.Throws<ArgumentException>(() => customer.GreetAndCombineNames("", "Boikov"));
        }

        [Fact]
        public void CustomerType_CreateCustomerLessThat100OrderTotal_ReturnTypeBasicCustomer()
        {
            //Act
            customer.OrderTotal = 10;

            var result = customer.GetCustomerDetails();

            //Assert
            Assert.IsType<BasicCustomer>(result);
        }

        [Fact]
        public void CustomerType_CreateCustomerMoreThat100OrderTotal_ReturnTypePlatinumCustomer()
        {
            //Act
            customer.OrderTotal = 250;

            var result = customer.GetCustomerDetails();

            //Assert
            Assert.IsType<PlatinumCustomer>(result);
        }
    }
}
