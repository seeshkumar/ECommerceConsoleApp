using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ECommerceApp.Models;
using System.Xml;

namespace ECommerceApp.Services
{
    class FileService
    {
        public static dynamic ReadJsonFile(string filename)
        {
            filename = "./assets/"+filename;

            string Json = File.ReadAllText(filename);
            if (filename == "./assets/"+"Users.json")
                return JsonConvert.DeserializeObject<List<User>>(Json);
            else
                return JsonConvert.DeserializeObject<List<Product>>(Json);

        }
        public static void SaveJson(string filename, dynamic objs)
        {
            filename = "./assets/" + filename;
            File.WriteAllText(filename, JsonConvert.SerializeObject(objs, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
