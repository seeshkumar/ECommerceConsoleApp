using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Services;
using ECommerceApp.Models;

namespace ECommerceApp.Contollers
{
    class ECommerceAppController
    {

        private DisplayService displayService;
        private ShopService ShopService;

        public ECommerceAppController()
        {
            displayService = new DisplayService();

            List<User> users = FileService.ReadJsonFile("Users.json");

            bool loginSucess = UserService.ValidDetails(users, displayService.UserName, displayService.Password);

            if (!loginSucess) return;



            ShopService = new ShopService();
            List<CartProduct> cartProducts = ShopService.Shop(displayService);

            SaveData(ShopService.products,ShopService.CartProducts,displayService.UserName);

        }
        static void SaveData(List<Product> products, List<CartProduct> cartProducts, string UserName)
        {
            foreach (var cartProduct in cartProducts)
            {
                products.Find(product => product.PId == cartProduct.Id).Quantity_Available -= cartProduct.Quantity;
            }

            FileService.SaveJson("products.json", products);
        }


    }
}
