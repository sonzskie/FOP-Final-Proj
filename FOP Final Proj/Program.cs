using System;
using System.Collections.Generic;

namespace FOP_Final_Proj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> usersList = new List<string>();
            List<string> productsList = new List<string>();
            List<string> ordersList = new List<string>();

            InitialData.GetInitialValues(usersList);

            while (true)
            {
                var message = "\nPlease select a user role to login:" +
                              "\n1 Admin" +
                              "\n2 Warehouse" +
                              "\n3 User";

                Console.WriteLine(message);

                var userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        AdminMenu.Show(usersList, productsList, ordersList);
                        break;
                    case 2:
                        //WarehouseMenu.Show(usersList, productsList);
                        break;
                    case 3:
                        //UserMenu.Show(usersList, productsList, ordersList);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }
    }
}
