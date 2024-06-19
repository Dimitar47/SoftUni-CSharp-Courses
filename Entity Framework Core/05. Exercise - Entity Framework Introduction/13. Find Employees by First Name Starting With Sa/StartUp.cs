using _02._Database_First.Data;
using System.Text;

namespace _13._Find_Employees_by_First_Name_Starting_With_Sa
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(softUniContext));
        }
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {

            //  StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            var employees = context.Employees.Where(x => x.FirstName.ToLower().StartsWith("sa"))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Salary = $"{x.Salary:f2}"
                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();


            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - " +
                              $"{employee.JobTitle} - (${employee.Salary})");
            }

            return sb.ToString().TrimEnd();
        }


    }
}
