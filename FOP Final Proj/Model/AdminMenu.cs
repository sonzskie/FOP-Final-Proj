using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class AdminMenu
    {
        public static void Show(List<User> usersList, List<Product> productsList, List<Order> ordersList)
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
                var userChoice = Input.ReadNumber("Please enter a number: ", 1, 9);
                Console.WriteLine();

                switch (userChoice)
                {
                    case 1:
                        AdminManager.UpdatePassword(usersList, admin);
                        break;
                    case 2:
                        AdminManager.InactivateUser(usersList, admin);
                        break;
                    case 3:
                        AdminManager.AddUser(usersList);
                        break;
                    case 4:
                        AdminManager.DisplayUsers(usersList, "All");
                        break;
                    case 5:
                        AdminManager.DisplayUsers(usersList, "Inactive");
                        break;
                    case 6:
                        AdminManager.DisplayUsers(usersList, "Active");
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
                }
            }
        }
    }
}