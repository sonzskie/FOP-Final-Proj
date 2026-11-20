using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class Authentication
    {
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
    }
}
