using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerceApp.Models;

namespace ECommerceApp.Services
{
    class ShopService
    {


        public List<Product> products ;
        public List<CartProduct> CartProducts;


        public List<CartProduct> Shop(DisplayService displayService)
        {
               CartProducts = new List<CartProduct>();

            AddProducts:
                products = FileService.ReadJsonFile("Products.json");


                int SelectId = 0;
                int SelectQuantity;

                while (SelectId != -1)
                {
                    

                    
                    (SelectId, SelectQuantity) = displayService.printMenu(products, CartProducts);
                    if (SelectId == -1) break;


                    Product SelectedProduct = products.SingleOrDefault(product => product.PId == SelectId);
                    //check if product exists in menu
                    if (SelectedProduct == null)
                    {
                        Console.WriteLine("Unable to add product\n\n");
                        continue;
                    }
                    //check if selected product exists in cart
                    CartProduct productInCart = CartProducts.SingleOrDefault(CartProduct => CartProduct.Id == SelectId);
                    int QunatityAlreadyInCart = productInCart == null ? 0 : productInCart.Quantity;
                    
                    //check if selected quantity is available
                    if (SelectQuantity > SelectedProduct.Quantity_Available - QunatityAlreadyInCart)
                    {
                        Console.WriteLine($"Selected quantity({SelectQuantity}) exceeds available quantity({SelectedProduct.Quantity_Available - QunatityAlreadyInCart})\n\n");
                        continue;
                    }
                    Console.Write("\n");
                    //add product to cart
                    //check if product already in cart
                    if (productInCart == null)
                    {
                        CartProducts.Add(new CartProduct(SelectedProduct, SelectQuantity));
                        Console.WriteLine($"Added {SelectQuantity} units of {SelectedProduct.Name} to cart");
                    }
                    else
                    {
                        productInCart.Quantity += SelectQuantity;
                        Console.WriteLine($"{productInCart.Quantity} units of {SelectedProduct.Name} in cart");
                    }
                    Console.WriteLine("\n");
                }
            Checkout:
                Console.WriteLine("\n");
                int Total = displayService.printCartProducts(CartProducts);
                Console.WriteLine($"Total : {Total}\n");
                Console.WriteLine("1.Add products, 2.Delete products, 3.exit");
                int op = Convert.ToInt32(Console.ReadLine());
                switch (op)
                {
                    case 1:
                        goto AddProducts;
                        break;
                case 2:
                        CartProducts = deleteProducts(CartProducts, displayService);
                        Console.Write("\n");
                        goto Checkout;
                        break;
                    case 3:
                        return CartProducts;
                        //SaveData(products, CartProducts, UserName);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        goto Checkout;
                }


        }


        
        static List<CartProduct> deleteProducts(List<CartProduct> CartProducts, DisplayService displayService)
        {
            int DeleteId = 0;
            while (DeleteId != -1)
            {
                Console.WriteLine("\n\nProducts in cart :");
                displayService.printCartProducts(CartProducts);
                Console.Write("Select Id to delete,-1 to checkout :");
                DeleteId = Convert.ToInt32(Console.ReadLine());
                if (DeleteId == -1) break;

                //check if Id exitst in cart
                CartProduct DeleteProduct = CartProducts.SingleOrDefault(cartProduct => cartProduct.Id == DeleteId);
                if (DeleteProduct == null)
                {
                    Console.WriteLine("Invalid Input");
                    continue;
                }
                Console.WriteLine("How many units to delete:");
                int DeleteQuantity = Convert.ToInt32(Console.ReadLine());
                if (DeleteQuantity < 0) { Console.WriteLine("Invalid input"); }//negative qunatity is invalid
                if (DeleteQuantity > DeleteProduct.Quantity)
                {
                    Console.WriteLine($"Quantity to delete({DeleteQuantity}) is greater than quantity in cart({DeleteProduct.Quantity})");
                    continue;
                }
                DeleteProduct.Quantity -= DeleteQuantity;
                if (DeleteProduct.Quantity == 0)
                {
                    CartProducts.Remove(DeleteProduct);
                }

            }

            return CartProducts;
        }
        


    }
}
