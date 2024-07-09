using System;
using System.Collections.Generic;

namespace AcademicRecordsApp.Data.Models
{
    public partial class Grade
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int ExamId { get; set; }
        public int StudentId { get; set; }

        public virtual Exam Exam { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}
