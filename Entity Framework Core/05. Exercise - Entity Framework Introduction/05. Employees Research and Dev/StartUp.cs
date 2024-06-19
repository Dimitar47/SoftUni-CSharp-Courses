using _02._Database_First.Data;
using System.Text;

namespace _05._Employees_Research_and_Dev
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(GetEmployeesFromResearchAndDevelopment(softUniContext));
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.LastName,
                DepartmentName = x.Department.Name,
                x.Salary
            })
                .Where(x => x.DepartmentName == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                ;

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} {employee.LastName} from " +
                    $"{employee.DepartmentName} - ${employee.Salary:f2}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
