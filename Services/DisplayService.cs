using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Services
{
    class DisplayService
    {
        private string userName;
        private string password;

        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public DisplayService() 
        {
            getCredentials();
        }


        private void getCredentials()
        {
            Console.Write("Enter Username :");
            userName = Console.ReadLine();
            Console.Write("Enter Password :");
            password = Console.ReadLine();
        }


        //displays menu products and return selected Id and quantity
        public (int, int) printMenu(List<Product> products, List<CartProduct> CartProducts)
        {
            Console.WriteLine("Id\tBrand\tName\t\tPrice\tQuantity Available");
            Console.WriteLine("-------------------------------------------------------");
            foreach (Product product in products)
            {
                CartProduct productInCart = CartProducts.SingleOrDefault(CartProduct => CartProduct.Id == product.PId);
                int QunatityAlreadyInCart = productInCart == null ? 0 : productInCart.Quantity;

                Console.WriteLine($"{product.PId}\t{product.Brand}\t{product.Name}\t{product.Price}\t\t{product.Quantity_Available - QunatityAlreadyInCart}");
            }
            Console.WriteLine("Enter -1 for checkout.\n");

            Console.Write("\nEnter Product Id, -1 for checkout :");
            int SelectId = Convert.ToInt32(Console.ReadLine());
            //-1 for checkout
            if (SelectId == -1) return (SelectId, 0);
        
            Console.Write("Enter Quantity :");
            int SelectQuantity = Convert.ToInt32(Console.ReadLine());

            return (SelectId, SelectQuantity);
        }
        public int printCartProducts(List<CartProduct> CartProducts)
        {
            Console.WriteLine("Id\tBrand\tName\t\tPrice\tQuantity");
            Console.WriteLine("--------------------------------------------");
            int sum = 0;
            foreach (CartProduct cartProduct in CartProducts)
            {
                Console.WriteLine($"{cartProduct.Id}\t{cartProduct.Brand}\t{cartProduct.Name}\t{cartProduct.Price}\t{cartProduct.Quantity}");
                sum += cartProduct.Price * cartProduct.Quantity;
            }
            Console.WriteLine("----------------------------------------------");

            return sum;

        }

    }
}
