using _02._Database_First.Data;
using System.Text;

namespace _10._Departments_with_More_Than_5_Employees
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(GetDepartmentsWithMoreThan5Employees(softUniContext));
        }
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments.Where(x => x.Employees.Count() > 5)
                .Select(x => new
                {
                    DepartmentName = x.Name,
                    ManagerFirstName = x.Manager.FirstName,
                    ManagerLastName = x.Manager.LastName,
                    Employees = x.Employees.Select(x => new
                    {
                        x.FirstName,
                        x.LastName,
                        x.JobTitle
                    }).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList()

                })
                .OrderBy(x => x.Employees.Count())
                .ThenBy(x => x.DepartmentName)
                .ToList();



            StringBuilder sb = new StringBuilder();


            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} – {department.ManagerFirstName} {department.ManagerLastName}");
                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }

            }

            return sb.ToString().TrimEnd();
        }


    }
}
