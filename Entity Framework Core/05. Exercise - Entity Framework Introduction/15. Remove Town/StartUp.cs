using _02._Database_First.Data;
using System.Text;

namespace _15._Remove_Town
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(RemoveTown(softUniContext));
        }

        public static string RemoveTown(SoftUniContext context)
        {

            //  StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            var townNameToDelete = "Seattle";


            var townToDelete = context.Towns.Single(x => x.Name == townNameToDelete);

            var addresses = context.Addresses.Where(a => a.TownId == townToDelete.TownId).ToList();

            foreach (var address in addresses)
            {
                var employees = context.Employees.Where(e => e.AddressId == address.AddressId).ToList();
                foreach (var employee in employees)
                {
                    employee.AddressId = null;
                }
            }

            int countOfDeletedAddresses = addresses.Count;


            context.Addresses.RemoveRange(addresses);
            context.Towns.Remove(townToDelete);
            context.SaveChanges();




            StringBuilder sb = new StringBuilder();



            sb.AppendLine($"{countOfDeletedAddresses} addresses in {townNameToDelete} were deleted");



            return sb.ToString().TrimEnd();
        }


    }
}
