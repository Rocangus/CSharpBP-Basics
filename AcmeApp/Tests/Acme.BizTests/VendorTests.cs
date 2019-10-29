using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class VendorTests
    {
        [TestMethod()]
        public void SendWelcomeEmail_ValidCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "ABC Corp";
            var expected = "Message sent: Hello ABC Corp";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_EmptyCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = "";
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SendWelcomeEmail_NullCompany_Success()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message sent: Hello";

            // Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToStringTest()
        {
            // Arrange
            var vendor = new Vendor();
            vendor.VendorId = 1;
            vendor.CompanyName = "ABC Corp";
            var expected = "Vendor: ABC Corp";

            // Act
            var actual = vendor.ToString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void PrepareDirectionsTest()
        {
            // Arrange
            var vendor = new Vendor();
            var expected = @"Insert \r\n to define a new line";

            // Act
            var actual = vendor.PrepareDirections();
            Console.WriteLine(actual);

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProductName_TooShort()
        {
            // Arrange 
            var currentProduct = new Product();
            currentProduct.ProductName = "aw";

            string expected = null;
            string expectedMessage = "Product Name must be at least 3 characters";

            // Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage); 
        }
        [TestMethod]
        public void ProductName_TooLong()
        {
            // Arrange 
            var currentProduct = new Product();
            currentProduct.ProductName = "Steel Böaded Hand Saw";

            string expected = null;
            string expectedMessage = "Product Name cannot be more than 20 characters";

            // Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void ProductName_JustRight()
        {
            // Arrange 
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";

            string expected = "Saw";
            string expectedMessage = null;

            // Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
    }
}