using _02._Database_First.Data;
using System.Text;

namespace _14._Delete_Project_by_Id
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(DeleteProjectById(softUniContext));
        }

        public static string DeleteProjectById(SoftUniContext context)
        {

            //  StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)



            var employeeProjectWithId2 = context.EmployeesProjects.Where(x => x.Project.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(employeeProjectWithId2);



            var projectWithId2 = context.Projects.Find(2);
            context.Projects.Remove(projectWithId2!);

            context.SaveChanges();
            StringBuilder sb = new StringBuilder();


            foreach (var project in context.Projects.Select(p => p.Name).Take(10))
            {
                sb.AppendLine(project);
            }


            return sb.ToString().TrimEnd();
        }


    }
}
