using _02._Database_First.Data;
using System.Text;

namespace _12._Increase_Salaries
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(IncreaseSalaries(softUniContext));
        }
        public static string IncreaseSalaries(SoftUniContext context)
        {

            //  StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
            var employeesInDepartments = context.Employees
                .Where(x => x.Department.Name == "Engineering"
                       || x.Department.Name == "Tool Design"
                       || x.Department.Name == "Marketing"
                       || x.Department.Name == "Information Services")
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Salary = x.Salary + x.Salary * (decimal)0.12

                })
                .OrderBy(x => x.FirstName)
                .ThenBy(x => x.LastName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            foreach (var employee in employeesInDepartments)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }




            return sb.ToString().TrimEnd();
        }


    }
}
