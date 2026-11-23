using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class AdminMenu
    {
        public static void Show(List<string> usersList, List<string> productsList, List<string> ordersList)
        {
            var admin = Authentication.Login(usersList, "Admin");

            if (admin == "")
                return;

            var keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("\nPlease select an option:" +
                              "\n1. Update Password" +
                              "\n2. Inactivate User" +
                              "\n3. Add User" +
                              "\n4. Display All Users" +
                              "\n5. Display Inactive Users" +
                              "\n6. Display Active Users" +
                              "\n7. Display Products" +
                              "\n8. Display Orders" +
                              "\n9. Logout");

                Console.WriteLine();
                Console.Write("Please enter a number: ");
                var userChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (userChoice)
                {
                    case 1:
                        UserManager.UpdatePassword(usersList, admin);
                        break;
                    case 2:
                        UserManager.InactivateUser(usersList, admin);
                        break;
                    case 3:
                        UserManager.AddUser(usersList);
                        break;
                    case 4:
                        UserManager.DisplayUsers(usersList, "All");
                        break;
                    case 5:
                        UserManager.DisplayUsers(usersList, "Inactive");
                        break;
                    case 6:
                        UserManager.DisplayUsers(usersList, "Active");
                        break;
                    case 7:
                        ProductManager.DisplayProducts(productsList);
                        break;
                    case 8:
                        OrderManager.DisplayOrders(ordersList, "");
                        break;
                    case 9:
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