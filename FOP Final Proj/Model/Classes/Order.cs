using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public class Order
    {
        public string Username { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }

        public Order(string username, string productName, int quantity, DateTime orderDate)
        {
            Username = username;
            ProductName = productName;
            Quantity = quantity;
            OrderDate = orderDate;
        }
    }
}
