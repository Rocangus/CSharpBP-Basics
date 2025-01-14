﻿using System;
using Acme.Common;
using static Acme.Common.LoggingService;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Biz
{
    /// <summary>
    /// Manages products carried in inventory.
    /// </summary>
    public class Product
    {
        public Product()
        {
            Console.WriteLine("Product instance created");
            //ProductVendor = new Vendor();
        }
        public Product(int productId,
                        string productName,
                        string description) : this()
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;

            Console.WriteLine("Product instance has a name: " + ProductName);
        }
        private string productName;

        public string ProductName
        {
            get 
            {
                var formattedValue = productName?.Trim();
                return formattedValue; 
            }
            set 
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }
                else if (value.Length > 20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";
                }
                else
                {
                    productName = value;
                }
            }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        private Vendor productVendor;

        public Vendor ProductVendor
        {
            get 
            { 
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor; 
            }
            set { productVendor = value; }
        }

        public string ValidationMessage { get; private set; }

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Product", productName, "sales@abc.com");

            var result = LogAction("saying hello");
            return "Hello " + ProductName +
                " (" + ProductId + "): " +
                Description;
        }
    }
}
