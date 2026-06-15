using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Repositories.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private IRepository<IStudent> students;
        private IRepository<ISubject> subjects;
        private IRepository<IUniversity> universities;
        public Controller() 
        {
            students = new StudentRepository();
            subjects = new SubjectRepository();
            universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            string result = "";

            if (this.students.FindByName($"{firstName} {lastName}") != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            else
            {
                IStudent student = new Student(this.students.Models.Count + 1, firstName, lastName);
                this.students.AddModel(student);
                result = string
                    .Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
            }

            return result.TrimEnd();
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            string result = "";

            if (subjectType != nameof(TechnicalSubject) &&
                subjectType != nameof(EconomicalSubject) &&
                subjectType != nameof(HumanitySubject))
            {
                result = string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else if (subjects.FindByName(subjectName) != null)
            {
                result = String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            else
            {
                ISubject subject;
                int subjectId = subjects.Models.Count + 1;

                if (subjectType == nameof(TechnicalSubject))
                {
                    subject = new TechnicalSubject(subjectId, subjectName);
                }
                else if (subjectType == nameof(EconomicalSubject))
                {
                    subject = new EconomicalSubject(subjectId, subjectName);
                }
                else
                {
                    subject = new HumanitySubject(subjectId, subjectName);
                }

                this.subjects.AddModel(subject);
                result = string
                    .Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
            }

            return result.TrimEnd();
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            string result = "";

            if (this.universities.FindByName(universityName) != null)
            {
                result = string.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            else
            {
                List<int> rs = new List<int>();
                foreach (var subName in requiredSubjects)
                {
                    rs.Add(this.subjects.FindByName(subName).Id);
                }
                IUniversity university =
                    new University(this.universities.Models.Count + 1, universityName, category, capacity, rs);
                this.universities.AddModel(university);

                result = string
                    .Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
            }

            return result.TrimEnd();
        }



        public string ApplyToUniversity(string studentName, string universityName)
        {
            string firstName = studentName.Split(" ")[0];
            string lastName = studentName.Split(" ")[1];

            var student = this.students.FindByName(studentName);
            var university = this.universities.FindByName(universityName);


            if (student == null)
            {
                return string.Format(OutputMessages.StudentNotRegitered,
                    firstName,
                    lastName);
            }
          
            if (university == null)
            {
                return string.Format(OutputMessages.UniversityNotRegitered,
                    universityName);
            }
            if (!university.RequiredSubjects.All(exam => student.CoveredExams.Contains(exam)))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams
                    , studentName,
                    universityName);

            }

            if (student.University != null)
            {


                if (student.University.Name == university.Name)
                {
                    return string.Format(OutputMessages.StudentAlreadyJoined
                        , firstName,
                        lastName
                        , universityName);
                }
            }

            student.JoinUniversity(university);
            return string.Format(OutputMessages.StudentSuccessfullyJoined,
                firstName,
                lastName,
                universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            string result = "";

            if (this.students.FindById(studentId) == null)
            {
                result = string.Format(OutputMessages.InvalidStudentId);
            }
            else if (this.subjects.FindById(subjectId) == null)
            {
                result = string.Format(OutputMessages.InvalidSubjectId);
            }
            else if (students.FindById(studentId).CoveredExams.Any(e => e == subjectId))
            {
                result = string
                    .Format(OutputMessages
                    .StudentAlreadyCoveredThatExam,
                    students.FindById(studentId).FirstName,
                    students.FindById(studentId).LastName,
                    subjects.FindById(subjectId).Name);
            }
            else
            {
                var student = this.students.FindById(studentId);
                var subject = this.subjects.FindById(subjectId);

                student.CoverExam(subject);
                result = string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
            }

            return result.TrimEnd();


        }




        public string UniversityReport(int universityId)
        {
            StringBuilder sb = new StringBuilder();
            IUniversity university = universities.FindById(universityId);
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            List<IStudent> admitted = students.Models
                .Where(x=>x.University ==university).ToList();
            sb.AppendLine($"Students admitted: {admitted.Count}");
            sb.AppendLine($"University vacancy: {university.Capacity - admitted.Count}");
            return sb.ToString().TrimEnd();
        }
    }
}
