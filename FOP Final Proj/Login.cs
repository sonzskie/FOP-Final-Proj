using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class Authentication
    {
        const int MAX_ATTEMPTS = 3;

        public static string Login(List<string> usersList, string role)
        {
            Console.WriteLine("(Enter 0 to go back)");

            for (int attempt = 1; attempt <= MAX_ATTEMPTS; attempt++)
            {
                Console.Write("Please enter your username: ");
                var username = Console.ReadLine();

                if (username.Trim() == "0")
                    return "";

                Console.Write("Please enter your password: ");
                var password = Console.ReadLine();

                if (password.Trim() == "0")
                    return "";

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

                Console.WriteLine();
                var attemptsLeft = MAX_ATTEMPTS - attempt;

                if (attemptsLeft > 0)
                    Console.WriteLine($"Invalid username or password. Attempts left: {attemptsLeft}");
                else
                    Console.WriteLine("Invalid username or password.");
                Console.WriteLine();
            }

            Console.WriteLine("Too many failed attempts. Returning to the role menu.");
            return "";
        }
    }
}
