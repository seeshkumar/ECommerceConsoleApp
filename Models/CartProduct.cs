using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Models
{
    class CartProduct
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }

        public CartProduct(Product product, int Quantity)
        {
            Id = product.PId;
            Brand = product.Brand;
            Name = product.Name;
            Price = product.Price;
            this.Quantity = Quantity;
        }
    }
}
