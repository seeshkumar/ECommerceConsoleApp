using ECommerceApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Services
{
    class UserService
    {
        public static bool ValidDetails(List<User> Users, string UserName, string Password)
        {
            if (Users.Find(user => user.Username == UserName && user.Password == Password) == null)
            {
                Console.WriteLine("Unable to login");
                return false;
            }
            Console.WriteLine($"Logged in as {UserName}");
            return true;
        }
    }
}
