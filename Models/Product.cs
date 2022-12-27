using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    class Product
    {
        public int PId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity_Available { get; set; }
        public string Brand { get; set; }
    }
}
