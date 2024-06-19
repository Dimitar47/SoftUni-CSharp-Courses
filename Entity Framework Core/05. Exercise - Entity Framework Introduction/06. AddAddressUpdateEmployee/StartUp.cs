using _02._Database_First.Data;
using _02._Database_First.Models;
using System.Text;

namespace _06._AddAddressUpdateEmployee
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(AddNewAddressToEmployee(softUniContext));
        }
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
   
            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

        
            context.Addresses.Add(newAddress);
            context.SaveChanges();

           
            var employee = context.Employees.FirstOrDefault(e => e.LastName == "Nakov");

            if (employee != null)
            {
          
                employee.AddressId = newAddress.AddressId;
                context.SaveChanges();
            }

          
            var employees = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

         
            return string.Join(Environment.NewLine, employees);
        }
    }
}
