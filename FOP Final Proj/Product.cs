using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FOP_Final_Proj
{
    public class Product
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        public Product(string name, int quantity, bool isActive, DateTime createdDate, string createdBy)
        {
            Name = name;
            Quantity = quantity;
            IsActive = isActive;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
        }
    }
}
