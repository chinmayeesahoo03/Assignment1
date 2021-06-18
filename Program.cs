using System;
using System.Collections.Generic;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>
            {
                new Product{UNIT="A"},new Product{UNIT="A"},new Product{UNIT="A"},
                new Product{UNIT="B"},new Product{UNIT="B"},new Product{UNIT="B"},new Product{UNIT="B"},new Product{UNIT="B"},
                new Product{UNIT="C"},new Product{UNIT="D"}
            };
            int TotoalPrice = 0;
            GetProductDetails getProductDetails = new GetProductDetails();
            TotoalPrice = getProductDetails.GetTotalPrice(products);
            Console.WriteLine(TotoalPrice);
            Console.ReadLine();
        }
    }
}
