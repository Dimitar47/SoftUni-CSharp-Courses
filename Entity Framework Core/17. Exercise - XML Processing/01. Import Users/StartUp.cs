using _01._Import_Users.DTOs.Import;
using ProductShop.Data;
using ProductShop.Models;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            using ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            string inputXml =
                File.ReadAllText(@"D:\Users\admin\Desktop\C# DB_SoftUni\Entity Framework Core - June 2024\" +
               @"17. Exercise - XML Processing\01. Import Users\Datasets\users.xml");

            string result = ImportUsers(context, inputXml);
            Console.WriteLine(result);
        }
        private static T Deserialize<T>(string inputXml,string rootName)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootName);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            using StringReader reader = new StringReader(inputXml);

            T dtos = (T)serializer.Deserialize(reader);
            return dtos;
        }




        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var userDtos = Deserialize<ImportUserDto[]>(inputXml, "Users");

            User[] users = userDtos
                .Select(s => new User()
                {
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Age = s.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count()}";
        }
    }
}