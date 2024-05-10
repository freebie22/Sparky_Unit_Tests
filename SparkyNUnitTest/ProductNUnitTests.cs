using Moq;
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
    public class ProductNUnitTests
    {
        [Test]
        public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            //Arrange
            Product product = new Product() {Price = 50 };

            //Act
            var result = product.GetPrice(new Customer() { IsPlatinum = true });

            //Assert
            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
        {
            //Arrange
            Product product = new Product() { Price = 50 };
            var customerMock = new Mock<ICustomer>();

            customerMock.Setup(u => u.IsPlatinum).Returns(true);

            //Act
            var result = product.GetPrice(customerMock.Object);

            //Assert
            Assert.That(result, Is.EqualTo(40));
        }
    }
}
