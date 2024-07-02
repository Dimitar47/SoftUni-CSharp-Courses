using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Visitations = new List<Visitation>();
        }
        [Key]
        public int DoctorId { get; set; }

        [Unicode]
        [MaxLength(100)]
        public string Name { get; set; }

        [Unicode]
        [MaxLength(100)]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

    }
}
