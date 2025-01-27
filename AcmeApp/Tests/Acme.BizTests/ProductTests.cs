﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "Saw";
            currentProduct.ProductId = 1;
            currentProduct.Description = "15-inch steel blade hand saw";
            currentProduct.ProductVendor.CompanyName = "ABC Corp";
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            // Act
            var actual = currentProduct.SayHello();
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void SayHelloParameterizedConstructor()
        {
            // Arrange
            var currentProduct = new Product(1, "Saw", "15-inch steel blade hand saw");
            var expected = "Hello Saw (1): 15-inch steel blade hand saw";

            // Act
            var actual = currentProduct.SayHello();
            // Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void ProductName_Format()
        {
            // Arrange
            var currentProduct = new Product();
            currentProduct.ProductName = "  Steel Hammer   ";

            var expected = "Steel Hammer";

            // Act
            var actual = currentProduct.ProductName;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}