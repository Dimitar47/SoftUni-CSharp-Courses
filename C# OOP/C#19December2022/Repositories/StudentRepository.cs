using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students;
        public StudentRepository() 
        {
            students = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => students;

        public void AddModel(IStudent model)
        {
            students.Add(model);
        }

        public IStudent FindById(int id)
        {
           return students.FirstOrDefault(x=>x.Id== id);
        }

        public IStudent FindByName(string name)
        {

            return students.FirstOrDefault(x => 
            (x.FirstName + " " + x.LastName) == name);
        }
    }
}
