using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {

        public Student()
        {
            StudentsCourses = new HashSet<StudentCourse>();
            Homeworks = new HashSet<Homework>();
        }

      
        public int StudentId { get; set; }

       
        public string Name { get; set; } 

        
        public string PhoneNumber { get; set; } 

        public DateTime RegisteredOn { get; set; } 

        public DateTime? Birthday { get; set; }

        public virtual ICollection<StudentCourse> StudentsCourses { get; set; } 
        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
