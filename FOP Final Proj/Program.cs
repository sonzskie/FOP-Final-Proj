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
                            AdminRole(usersList, productsList, ordersList);
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

        public static string Login(List<string> usersList, string role)
        {
            Console.Write("Please enter your username: ");
            var username = Console.ReadLine();

            Console.Write("Please enter your password: ");
            var password = Console.ReadLine();

            foreach (var user in usersList)
            {
                var parts = user.Split('|');

                if (parts[0].ToLower() == username.Trim().ToLower() &&
                    parts[1] == password &&
                    parts[2] == role &&
                    parts[3] == "Active")
                {
                    return parts[0];
                }
            }

            Console.WriteLine("Invalid username or password.");
            return "";
        }

        public static void AdminRole(List<string> usersList, List<string> productsList, List<string> ordersList)
        {
            var admin = Login(usersList, "Admin");

            if (admin == "")
                return;

            var keepRunning = true;

            while (keepRunning)
            {
                var message = "\nPlease select an option:" +
                              "\n1. Update Password" +
                              "\n2. Inactivate User" +
                              "\n3. Add User" +
                              "\n4. Display All Users" +
                              "\n5. Display Inactive Users" +
                              "\n6. Display Active Users" +
                              "\n7. Display Products" +
                              "\n8. Display Orders" +
                              "\n9. Logout";

                Console.WriteLine(message);

                var userChoice = Convert.ToInt32(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        UpdatePassword(usersList, admin);
                        break;
                    case 2:
                        InactivateUser(usersList, admin);
                        break;
                    case 3:
                        AddUser(usersList);
                        break;
                    case 4:
                        DisplayUsers(usersList, "All");
                        break;
                    case 5:
                        DisplayUsers(usersList, "Inactive");
                        break;
                    case 6:
                        DisplayUsers(usersList, "Active");
                        break;
                    case 7:
                        //DisplayProducts
                        break;
                    case 8:
                        //DisplayOrders
                        break;
                    case 9:
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            }
        }

        public static List<string> GetActiveUsernames(List<string> usersList, string exclude)
        {
            List<string> names = new List<string>();

            foreach (var user in usersList)
            {
                var parts = user.Split('|');

                if (parts[3] == "Active" && parts[0] != exclude)
                    names.Add(parts[0]);
            }

            return names;
        }

        public static void UpdatePassword(List<string> usersList, string admin)
        {
            var activeUsers = GetActiveUsernames(usersList, admin);

            Console.WriteLine("1. My account");
            for (int i = 0; i < activeUsers.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {activeUsers[i]}");
            }

            Console.Write("Please select an account: ");
            var choice = Convert.ToInt32(Console.ReadLine());

            string target;

            if (choice == 1)
                target = admin;
            else if (choice >= 2 && choice <= activeUsers.Count + 1)
                target = activeUsers[choice - 2];
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.Write($"Please enter the new password for user {target}: ");
            var newPassword = Console.ReadLine();

            Console.Write("Please confirm the password: ");
            var confirmPassword = Console.ReadLine();

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }

            for (int i = 0; i < usersList.Count; i++)
            {
                var parts = usersList[i].Split('|');

                if (parts[0] == target)
                    usersList[i] = $"{parts[0]}|{newPassword}|{parts[2]}|{parts[3]}";
            }

            Console.WriteLine("Password has been successfully updated.");
        }

        public static void InactivateUser(List<string> usersList, string admin)
        {
            var activeUsers = GetActiveUsernames(usersList, admin);

            if (activeUsers.Count == 0)
            {
                Console.WriteLine("No other active users.");
                return;
            }

            for (int i = 0; i < activeUsers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activeUsers[i]}");
            }

            Console.Write("Please select a user to inactivate: ");
            var choice = Convert.ToInt32(Console.ReadLine());

            if (choice < 1 || choice > activeUsers.Count)
            {
                Console.WriteLine("Invalid input");
                return;
            }

            var target = activeUsers[choice - 1];

            for (int i = 0; i < usersList.Count; i++)
            {
                var parts = usersList[i].Split('|');

                if (parts[0] == target)
                    usersList[i] = $"{parts[0]}|{parts[1]}|{parts[2]}|Inactive";
            }

            Console.WriteLine($"{target} has been inactivated.");
        }

        public static void AddUser(List<string> usersList)
        {
            Console.Write("Enter role (1 Admin, 2 Warehouse, 3 User): ");
            var roleChoice = Convert.ToInt32(Console.ReadLine());

            string role;

            if (roleChoice == 1)
                role = "Admin";
            else if (roleChoice == 2)
                role = "Warehouse";
            else if (roleChoice == 3)
                role = "User";
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }

            Console.Write("Enter username: ");
            var username = Console.ReadLine().Trim();

            foreach (var user in usersList)
            {
                if (user.Split('|')[0].ToLower() == username.ToLower())
                {
                    Console.WriteLine("Username already exists.");
                    return;
                }
            }

            Console.Write("Enter password: ");
            var password = Console.ReadLine();

            usersList.Add($"{username}|{password}|{role}|Active");

            Console.WriteLine("User has been successfully created.");
        }

        public static void DisplayUsers(List<string> usersList, string filter)
        {
            var found = false;

            foreach (var user in usersList)
            {
                var parts = user.Split('|');

                if (filter == "All" || filter == parts[3])
                {
                    Console.WriteLine("Username: " + parts[0]);
                    Console.WriteLine("Role: " + parts[2]);
                    Console.WriteLine("Status: " + parts[3]);
                    Console.WriteLine();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No Record found");
        }

    }
}
