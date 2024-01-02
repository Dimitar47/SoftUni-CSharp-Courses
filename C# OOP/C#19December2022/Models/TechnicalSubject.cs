using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityCompetition.Models
{
    public class TechnicalSubject : Subject
    {
        private const double techRate = 1.3;
        public TechnicalSubject(int subjectId, string subjectName) 
            : base(subjectId, subjectName, techRate)
        {
        }
    }
}
