
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeS
{
    //Long Parameter List
    public class ProductInfo
    {
        public string ProductName
        {
            get;
            set;
        }

        public string Category
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public int Stock
        {
            get;
            set;
        }

        public string SupplierName
        {
            get;
            set;
        }

        public string SupplierContact
        {
            get;
            set;
        }
    }

    public class ProductManager
    {
        public void RegisterProduct(ProductInfo productInfo)
        {
            Console.WriteLine(
                $"Product: {productInfo.ProductName}, Category: {productInfo.Category}, Price: {productInfo.Price:C}, Stock: {productInfo.Stock}, Supplier: {productInfo.SupplierName}, Contact: {productInfo.SupplierContact}");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            var product = new ProductInfo
            {
                ProductName = "Laptop",
                Category = "Electronics",
                Price = 1200.99m,
                Stock = 10,
                SupplierName = "TechSupplier Inc.",
                SupplierContact = "contact@techsupplier.com"
            };

            var manager = new ProductManager();
            manager.RegisterProduct(product);



        }
    }
}