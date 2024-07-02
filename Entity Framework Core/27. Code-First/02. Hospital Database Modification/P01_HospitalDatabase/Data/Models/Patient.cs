using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        public Patient() 
        {
            Prescriptions = new List<PatientMedicament>();
            Visitations = new List<Visitation>();
            Diagnoses = new List<Diagnose>();
        }
        [Key]
        public int PatientId { get; set; }

        [Unicode]
        [MaxLength(50)]
        public string FirstName { get; set; } 

        [Unicode]
        [MaxLength(50)]
        public string LastName { get; set; }


        [Unicode]
        [MaxLength(250)]
        public string Address  { get; set; }


        [MaxLength(80)]
        public string Email  { get; set; }

        public bool HasInsurance { get; set; }

        public ICollection<PatientMedicament> Prescriptions { get; set; }
        public ICollection<Visitation> Visitations { get; set; }
        public ICollection<Diagnose> Diagnoses { get; set; }
    }
}
