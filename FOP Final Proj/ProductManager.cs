using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class ProductManager
    {
        public static void AddProducts(List<string> productsList, string warehouse)
        {
            int numProduct = 0;
            var isValid = false;

            Console.WriteLine("(Enter 0 to go back)");

            while (!isValid)
            {
                try
                {
                    Console.Write("Please enter the number of products you want to add: ");
                    numProduct = Convert.ToInt32(Console.ReadLine());

                    switch (numProduct)
                    {
                        case 0:
                            return;  
                        default:
                            if (numProduct < 0)
                                Console.WriteLine("Please enter a number greater than zero.");
                            else
                                isValid = true;
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("That number is too big.");
                }
            }

            for (int i = 1; i <= numProduct; i++)
            {
                
                string name;

                do
                {
                    Console.Write($"{i}. Please enter the name of the product : ");
                    name = Console.ReadLine().Trim();

                    if (name == "" || name.Contains("|"))
                        Console.WriteLine("The name cannot be empty or contain the | character.");
                }
                while (name == "" || name.Contains("|"));

                int quantity = 0;
                var isQuantityValid = false;

                while (!isQuantityValid)
                {
                    try
                    {
                        Console.Write($"{i}. Please enter the quantity of the product : ");
                        quantity = Convert.ToInt32(Console.ReadLine());

                        if (quantity <= 0)
                            Console.WriteLine("Quantity must be greater than zero.");
                        else
                            isQuantityValid = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                    catch (OverflowException)
                    {
                        Console.WriteLine("That number is too big.");
                    }
                }

                var date = DateTime.Now.ToString("M/d/yyyy h:mm tt");

                productsList.Add($"{name}|{quantity}|True|{date}|{warehouse}");
            }

            Console.WriteLine("All products have been successfully created.");
        }

        public static void DisplayProducts(List<string> productsList)
        {
            if (productsList.Count == 0)
            {
                Console.WriteLine("No Record found");
                return;
            }

            foreach (var product in productsList)
            {
                var parts = product.Split('|');

                Console.WriteLine($"Product Name: {parts[0]}");
                Console.WriteLine($"Quantity: {parts[1]}");
                Console.WriteLine("Active : " + (parts[2] == "True" ? "Yes" : "No"));
                Console.WriteLine($"Created Date: {parts[3]}");
                Console.WriteLine($"Created By: {parts[4]}");
                Console.WriteLine();
            }
        }
    }
}
