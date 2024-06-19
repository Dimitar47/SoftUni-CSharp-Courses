using _02._Database_First.Data;
using System.Text;

namespace _08._AddressesTown
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(GetAddressesByTown(softUniContext));
        }
        public static string GetAddressesByTown(SoftUniContext context)
        {

            var addresses = context.Addresses
                .OrderByDescending(x => x.Employees.Count())
                .ThenBy(x => x.Town.Name)
                .ThenBy(x => x.AddressText)
                .Select(x => new
                {
                    AddressText = x.AddressText,
                    TownName = x.Town.Name,
                    EmployeeCount = x.Employees.Count()
                })
                .Take(10)
                .ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }



            return sb.ToString().TrimEnd();
        }


    }
}
