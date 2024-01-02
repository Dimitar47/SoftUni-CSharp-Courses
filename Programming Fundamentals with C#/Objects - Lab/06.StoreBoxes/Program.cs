using System;
using System.Collections.Generic;
using System.Linq;
namespace _06.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Box> listOfBoxes = new List<Box>();
           
            while ((command = Console.ReadLine()) != "end")
            {
                string[] commandArray = command.Split();
                string serialNumber = commandArray[0];
                string name = commandArray[1];
                int quantity = int.Parse(commandArray[2]);
                decimal price = decimal.Parse(commandArray[3]);
                decimal priceOfOneBox = quantity * price;

                Box box = new Box
                {
                    Item = new Item(),
                    SerialNumber = serialNumber,
                    Quantity = quantity,
                    PriceBox = price
                };
                box.Item.Name = name;
                box.Item.Price = priceOfOneBox;
                listOfBoxes.Add(box);
                
            }

            List<Box> sortedBox = listOfBoxes.OrderByDescending(num => num.Item.Price).ToList();

            foreach (Box box in sortedBox)
            {
                
                Console.WriteLine(box.SerialNumber);
                Console.WriteLine($"-- {box.Item.Name} - ${box.PriceBox:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.Item.Price:f2}");
            }
            

        }
    }

    class Item
    {
        
        public string Name
        {
            get;set;
        }

        public decimal Price
        {
            get;set;
        }
    }

    class Box
    {
      
        public string SerialNumber
        {
            get;set;
        }

        public Item Item
        {
            get;set;
        }

        public int Quantity
        {
            get;set;
        }

        public decimal PriceBox
        {
            get;set;
        }
        
    }
}
