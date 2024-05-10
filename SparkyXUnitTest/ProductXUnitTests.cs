using Moq;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SparkyXUnitTest
{
    public class ProductXUnitTests
    {
        [Fact]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            //Arrange
            Product product = new Product() { Price = 50 };

            //Act
            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            //Assert
            Assert.Equal(40, result);
        }

        [Fact]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            //Arrange
            Product product = new Product() { Price = 50 };
            var customerMock = new Mock<ICustomer>();

            customerMock.Setup(u => u.IsPlatinum).Returns(true);

            //Act
            var result = product.GetPrice(customerMock.Object);

            //Assert
            Assert.Equal(40, result);
        }
    }
}
