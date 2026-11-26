using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }

        public User(string username, string password, string role, string status)
        {
            Username = username;
            Password = password;
            Role = role;
            Status = status;
        }
    }
}
