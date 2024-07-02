using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {

        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }

        public int MedicamentId { get;set; }
        [ForeignKey(nameof(MedicamentId))]
        public Medicament Medicament { get; set; }
    }
}
