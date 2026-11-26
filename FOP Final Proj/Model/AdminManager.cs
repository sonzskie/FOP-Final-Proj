using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    internal class AdminManager
    {
        public static List<string> GetActiveUsernames(List<User> usersList, string exclude)
        {
            List<string> names = new List<string>();

            foreach (var user in usersList)
            {
                if (user.Status == "Active" && user.Username != exclude)
                    names.Add(user.Username);
            }

            return names;
        }

        public static void UpdatePassword(List<User> usersList, string admin)
        {
            var activeUsers = GetActiveUsernames(usersList, admin);

            Console.WriteLine("1. My account");
            for (int i = 0; i < activeUsers.Count; i++)
            {
                Console.WriteLine($"{i + 2}. {activeUsers[i]}");
            }

            int choice = Input.ReadNumber("Please select an account: ", 1, activeUsers.Count + 1);
            Console.WriteLine();

            string target;

            if (choice == 1)
                target = admin;
            else
                target = activeUsers[choice - 2];

            string newPassword;

            while (true)
            {
                Console.Write($"Please enter the new password for user {target}: ");
                newPassword = Console.ReadLine();

                if (!newPassword.Contains(" "))
                    break;

                Console.WriteLine("Invalid password. Spaces are not allowed.");
                Console.WriteLine();
            }

            Console.Write("Please confirm the password: ");
            var confirmPassword = Console.ReadLine();

            if (newPassword != confirmPassword)
            {
                Console.WriteLine("Passwords do not match.");
                return;
            }

            foreach (var user in usersList)
            {
                if (user.Username == target)
                    user.Password = newPassword;
            }

            Console.WriteLine("Password has been successfully updated.");
        }

        public static void InactivateUser(List<User> usersList, string admin)
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

            int choice = Input.ReadNumber("Please select a user to inactivate: ", 1, activeUsers.Count);
            Console.WriteLine();

            var target = activeUsers[choice - 1];

            foreach (var user in usersList)
            {
                if (user.Username == target)
                    user.Status = "Inactive";
            }

            Console.WriteLine($"{target} has been inactivated.");
        }

        public static void AddUser(List<User> usersList)
        {
            int roleChoice = Input.ReadNumber("Enter role (1 Admin, 2 Warehouse, 3 User): ", 1, 3);
            Console.WriteLine();

            string role;

            if (roleChoice == 1)
                role = "Admin";
            else if (roleChoice == 2)
                role = "Warehouse";
            else
                role = "User";

            Console.Write("Enter username: ");
            var username = Console.ReadLine().Trim();
            Console.WriteLine();


            foreach (var user in usersList)
            {
                if (user.Username.ToLower() == username.ToLower())
                {
                    Console.WriteLine("Username already exists.");
                    return;
                }
            }

            Console.Write("Enter password: ");
            var password = Console.ReadLine();
            Console.WriteLine();

            usersList.Add(new User(username, password, role, "Active"));

            Console.WriteLine("User has been successfully created.");
        }

        public static void DisplayUsers(List<User> usersList, string filter)
        {
            var found = false;

            foreach (var user in usersList)
            {
                if (filter == "All" || filter == user.Status)
                {
                    Console.WriteLine($"Username: {user.Username}");
                    Console.WriteLine($"Role: {user.Role}");

                    if (filter == "All")
                        Console.WriteLine($"Status: {user.Status}");

                    Console.WriteLine();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("No Record found");
        }
    }
}