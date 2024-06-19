using _02._Database_First.Data;
using System.Text;

namespace _04._Employees_with_Salary_Over_50_000
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(GetEmployeesWithSalaryOver50000(softUniContext));
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Select(x => new
            {
                x.FirstName,
                x.Salary
            })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName);

            StringBuilder stringBuilder = new StringBuilder();

            foreach (var employee in employees)
            {
                stringBuilder.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
