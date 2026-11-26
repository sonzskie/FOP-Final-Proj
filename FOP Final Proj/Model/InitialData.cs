using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class InitialData
    {
        public static void GetInitialValues(List<User> usersList)
        {
            usersList.Add(new User("admin", "1234", "Admin", "Active"));
            usersList.Add(new User("warehouse", "1234", "Warehouse", "Active"));
            usersList.Add(new User("jenny_warehouse", "1234", "Warehouse", "Active"));
            usersList.Add(new User("user", "1234", "User", "Active"));
            usersList.Add(new User("jenny_user", "1234", "User", "Active"));
            usersList.Add(new User("mary_user", "1234", "User", "Active"));
        }
    }
}