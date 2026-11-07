using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static void Main(string[] args)
            {
                List<string> usersList = new List<string>();
                List<string> productsList = new List<string>();
                List<string> ordersList = new List<string>();

                GetInitialValues(usersList);


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
                            //AdminRole(usersList, productsList, ordersList);
                            break;
                        case 2:
                            //WarehouseRole(usersList, productsList);
                            break;
                        case 3:
                            //UserRole(usersList, productsList, ordersList);
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                }
            }

            public static void GetInitialValues(List<string> usersList)
            {
                usersList.Add("yourname_admin|yourname_password|Admin|Active");
                usersList.Add("jayson_warehouse|1234|Warehouse|Active");
                usersList.Add("jenny_warehouse|1234|Warehouse|Active");
                usersList.Add("jayson_user|1234|User|Active");
                usersList.Add("jenny_user|1234|User|Active");
                usersList.Add("mary_user|1234|User|Active");
            }
        }
    }
}
