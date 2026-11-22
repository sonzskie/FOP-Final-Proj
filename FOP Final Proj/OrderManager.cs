using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class OrderManager
    {
        public static void PlaceOrder(List<string> productsList, List<string> ordersList, string username)
        {
            Console.WriteLine("0. Back");

            for (int i = 0; i < productsList.Count; i++)
            {
                string[] details = productsList[i].Split('|');

                if (details[2] == "True")
                {
                    Console.WriteLine($"{i + 1}. Product Name: {details[0]}");
                    Console.WriteLine($"Quantity: {details[1]}");
                    Console.WriteLine();
                }
            }

            Console.Write("\nPlease enter the number of the product you want to order: ");
            int productChoice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            switch (productChoice)
            {
                case 0:
                    return;  // back to the user menu
                default:
                    if (productChoice < 1 || productChoice > productsList.Count)
                    {
                        Console.WriteLine("Invalid product number.");
                        return;
                    }
                    break;
            }

            string[] product = productsList[productChoice - 1].Split('|');

            if (product[2] != "True")
            {
                Console.WriteLine("Product is not available.");
                return;
            }

            Console.Write("Please enter the quantity of the product you want to order: ");
            int quantity = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

            int availableQuantity = Convert.ToInt32(product[1]);

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than zero.");
                return;
            }

            if (quantity > availableQuantity)
            {
                Console.WriteLine("Insufficient product quantity.");
                return;
            }

            int remainingQuantity = availableQuantity - quantity;

            productsList[productChoice - 1] =
                $"{product[0]}|{remainingQuantity}|{product[2]}|{product[3]}|{product[4]}";

            ordersList.Add(
                $"{username}|{product[0]}|{quantity}|{DateTime.Now:M/d/yyyy}");

            Console.WriteLine("\nOrder has been successfully created.");

            Console.WriteLine("\nOrder Details:");
            Console.WriteLine($"Product Name: {product[0]}");
            Console.WriteLine($"Quantity: {quantity}");
        }

        public static void DisplayOrders(List<string> ordersList, string username)
        {
            bool found = false;

            foreach (var order in ordersList)
            {
                string[] details = order.Split('|');

                if (username == "" || details[0] == username)
                {
                    Console.WriteLine($"Product Name: {details[1]}");
                    Console.WriteLine($"Quantity: {details[2]}");
                    Console.WriteLine($"Order Date: {details[3]}");

                    if (username == "")
                        Console.WriteLine($"Ordered By: {details[0]}");

                    Console.WriteLine();
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No Record found.");
            }
        }
    }
}
