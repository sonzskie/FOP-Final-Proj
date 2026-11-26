using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class UserMenu
    {
        public static void Show(List<User> usersList, List<Product> productsList, List<Order> ordersList)
        {
            var username = Authentication.Login(usersList, "User");

            if (username == "")
                return;

            var keepRunning = true;

            while (keepRunning)
            {
                var message = "\nPlease select an option:" +
                              "\n1. Order" +
                              "\n2. Display Order" +
                              "\n3. Logout";

                Console.WriteLine(message);

                Console.WriteLine();
                Console.Write("Please enter a number: ");
                var userChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (userChoice)
                {
                    case 1:
                        OrderManager.PlaceOrder(productsList, ordersList, username);
                        break;
                    case 2:
                        OrderManager.DisplayOrders(ordersList, username);
                        break;
                    case 3:
                        Console.WriteLine("Successfully logged out.");
                        Console.Write("Press any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}