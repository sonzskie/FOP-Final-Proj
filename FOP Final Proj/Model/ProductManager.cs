using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FOP_Final_Proj
{
    public static class ProductManager
    {
        public static void AddProducts(List<Product> productsList, string warehouse)
        {
            Console.WriteLine("(Enter 0 to go back)");

            int numProduct = Input.ReadNumber("Please enter the number of products you want to add: ", 0);
            Console.WriteLine();

            if (numProduct == 0)
                return;

            for (int i = 1; i <= numProduct; i++)
            {
                string name = "";
                var isNameValid = false;

                while (!isNameValid)
                {
                    Console.Write($"{i}. Please enter the name of the product : ");
                    name = Console.ReadLine().Trim();

                    if (name == "" || name.Contains("|"))
                        Console.WriteLine("The name cannot be empty or contain the | character.");
                    else if (ProductExists(productsList, name))
                        Console.WriteLine("Invalid product. Product already exists.");
                    else
                        isNameValid = true;
                }

                int quantity = Input.ReadNumber($"{i}. Please enter the quantity of the product : ", 0);
                Console.WriteLine();

                productsList.Add(new Product(name, quantity, true, DateTime.Now, warehouse));
            }

            Console.WriteLine("All products have been successfully created.");
        }

        public static bool ProductExists(List<Product> productsList, string name)
        {
            foreach (var product in productsList)
            {
                if (product.Name.ToLower() == name.ToLower())
                    return true;
            }

            return false;
        }

        public static void DisplayProducts(List<Product> productsList)
        {
            if (productsList.Count == 0)
            {
                Console.WriteLine("No Record found");
                return;
            }

            foreach (var product in productsList)
            {
                Console.WriteLine($"Product Name: {product.Name}");
                Console.WriteLine($"Quantity: {product.Quantity}");
                Console.WriteLine("Active : " + (product.IsActive ? "Yes" : "No"));
                Console.WriteLine($"Created Date: {product.CreatedDate.ToString("M/d/yyyy h:mm tt")}");
                Console.WriteLine($"Created By: {product.CreatedBy}");
                Console.WriteLine();
            }
        }
    }
}