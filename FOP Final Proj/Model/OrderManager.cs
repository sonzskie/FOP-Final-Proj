using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class OrderManager
    {
        public static void PlaceOrder(List<Product> productsList, List<Order> ordersList, string username)
        {
            Console.WriteLine("0. Back");

            for (int i = 0; i < productsList.Count; i++)
            {
                Product item = productsList[i];

                if (item.IsActive)
                {
                    Console.WriteLine($"{i + 1}. Product Name: {item.Name}");
                    Console.WriteLine($"Quantity: {item.Quantity}");
                    Console.WriteLine();
                }
            }

            int productChoice = Input.ReadNumber("\nPlease enter the number of the product you want to order: ", 0, productsList.Count);
            Console.WriteLine();

            if (productChoice == 0)
                return;

            Product product = productsList[productChoice - 1];

            if (!product.IsActive)
            {
                Console.WriteLine("Product is not available.");
                return;
            }

            int quantity = Input.ReadNumber("Please enter the quantity of the product you want to order: ", 1);
            Console.WriteLine();

            int availableQuantity = product.Quantity;

            if (quantity > availableQuantity)
            {
                Console.WriteLine("Insufficient product quantity.");
                return;
            }

            product.Quantity = availableQuantity - quantity;

            ordersList.Add(new Order(username, product.Name, quantity, DateTime.Now));

            Console.WriteLine("\nOrder has been successfully created.");

            Console.WriteLine("\nOrder Details:");
            Console.WriteLine($"Product Name: {product.Name}");
            Console.WriteLine($"Quantity: {quantity}");
        }

        public static void DisplayOrders(List<Order> ordersList, string username)
        {
            bool found = false;

            foreach (var order in ordersList)
            {
                if (username == "" || order.Username == username)
                {
                    Console.WriteLine($"Product Name: {order.ProductName}");
                    Console.WriteLine($"Quantity: {order.Quantity}");
                    Console.WriteLine($"Order Date: {order.OrderDate:M/d/yyyy}");

                    if (username == "")
                        Console.WriteLine($"Ordered By: {order.Username}");

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