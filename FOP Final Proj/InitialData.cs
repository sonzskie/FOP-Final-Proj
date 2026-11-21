using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public static class InitialData
    {
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