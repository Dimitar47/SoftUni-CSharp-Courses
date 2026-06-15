using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class University : IUniversity
    {
        private int id;
        private string name;
        private string category;
        private int capacity;
        private ICollection<int> requiredSubjects;
        public University(int universityId, string universityName, string category,
            int capacity, ICollection<int> requiredSubjects)
        {
            Name = universityName;
            Category = category;
            Capacity = capacity;
            this.requiredSubjects = requiredSubjects;
            Id = universityId;
        }
        public int Id
        {
            get => id;
            private set => id = value;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Category
        {
            get => category;
            private set
            {
                if (value !="Technical" && value !="Economical" && value !="Humanity")
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CategoryNotAllowed,value));
                }
                category = value;

            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityNegative);
                }
                capacity = value;
            }
        }

        public IReadOnlyCollection<int> RequiredSubjects 
            => requiredSubjects.ToList().AsReadOnly();
    }
}
