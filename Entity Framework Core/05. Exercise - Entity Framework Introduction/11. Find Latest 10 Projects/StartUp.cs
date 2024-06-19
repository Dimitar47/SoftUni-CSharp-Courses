using _02._Database_First.Data;
using System.Globalization;
using System.Text;

namespace _11._Find_Latest_10_Projects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext softUniContext = new SoftUniContext();

            Console.WriteLine(GetLatestProjects(softUniContext));
        }
        public static string GetLatestProjects(SoftUniContext context)
        {

            //  StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)

            var projects = context.Projects
                         .Select(x => new
                         {
                             x.Name,
                             x.Description,
                             x.StartDate
                         })
                         .OrderByDescending(x => x.StartDate)
                         .Take(10)
                         .ToList();
            StringBuilder sb = new StringBuilder();
            foreach (var project in projects.OrderBy(x => x.Name))
            {
                sb.AppendLine($"{project.Name}{Environment.NewLine}" +
                              $"{project.Description}{Environment.NewLine}" +
                              $"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }




            return sb.ToString().TrimEnd();
        }


    }
}
