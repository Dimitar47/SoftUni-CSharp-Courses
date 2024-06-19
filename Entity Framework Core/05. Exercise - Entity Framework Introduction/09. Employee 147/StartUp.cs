using _02._Database_First.Data;
using System.Text;

namespace _09._Employee_147
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(GetEmployee147(softUniContext));
        }
        public static string GetEmployee147(SoftUniContext context)
        {
            var employeeWithId147 = context.Employees.Select(
                x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.LastName,
                    x.JobTitle,
                    Projects = x.EmployeesProjects.Select(x => x.Project.Name).OrderBy(x => x).ToList()
                })
                .Single(x => x.EmployeeId == 147);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{employeeWithId147.FirstName} {employeeWithId147.LastName} - {employeeWithId147.JobTitle}");
            foreach (var project in employeeWithId147.Projects)
            {
                sb.AppendLine($"{project}");
            }


            return sb.ToString().TrimEnd();
        }


    }
}
