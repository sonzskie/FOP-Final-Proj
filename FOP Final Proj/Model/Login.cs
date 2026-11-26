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

        public static string Login(List<User> usersList, string role)
        {
            Console.WriteLine("(Enter 0 to go back)");

            for (int attempt = 1; attempt <= MAX_ATTEMPTS; attempt++)
            {
                Console.Write("Please enter your username: ");
                var username = Console.ReadLine();

                if (username == "0")
                    return "";

                Console.Write("Please enter your password: ");
                var password = Console.ReadLine();

                if (password == "0")
                    return "";

                if (int.TryParse(password, out int message))
                {
                    if (message < 0)
                    {
                        Console.WriteLine("Please enter a valid option.");

                        var attemptsLeft = MAX_ATTEMPTS - attempt;

                        if (attemptsLeft > 0)
                            Console.WriteLine($"Attempts left: {attemptsLeft}");

                        Console.WriteLine();
                        continue;
                    }
                }


                foreach (var user in usersList)
                {
                    if (user.Username.ToLower() == username.ToLower() &&
                        user.Password == password &&
                        user.Role == role &&
                        user.Status == "Active")
                    {
                        Console.Clear();
                        return user.Username;
                    }
                }

                Console.WriteLine();

                var remainingAttempts = MAX_ATTEMPTS - attempt;

                if (remainingAttempts > 0)
                    Console.WriteLine($"Invalid username or password. Attempts left: {remainingAttempts}");
                else
                    Console.WriteLine("Invalid username or password.");

                Console.WriteLine();
            }

            Console.WriteLine("Too many failed attempts. Returning to the role menu.");
            return "";
        }
    }
}