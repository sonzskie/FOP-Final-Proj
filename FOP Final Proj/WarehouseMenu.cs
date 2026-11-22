using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class WarehouseMenu
    {
        public static void Show(List<string> usersList, List<string> productsList)
        {
            var warehouse = Authentication.Login(usersList, "Warehouse");

            if (warehouse == "")
                return;

            var keepRunning = true;

            while (keepRunning)
            {
                var message = "\nPlease select an option:" +
                              "\n1. Add Products" +
                              "\n2. Display Products" +
                              "\n3. Logout";

                Console.WriteLine(message);

                Console.WriteLine();
                Console.Write("Please enter a number: ");
                var userChoice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();

                switch (userChoice)
                {
                    case 1:
                        ProductManager.AddProducts(productsList, warehouse);
                        break;
                    case 2:
                        ProductManager.DisplayProducts(productsList);
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