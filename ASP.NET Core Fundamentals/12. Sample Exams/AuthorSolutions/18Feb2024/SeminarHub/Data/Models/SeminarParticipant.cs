using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeminarHub.Data.Models
{
    public class SeminarParticipant
    {
        public int SeminarId { get; set; }

        [ForeignKey(nameof(SeminarId))]
        public virtual Seminar Seminar { get; set; } = null!;

        public string ParticipantId { get; set; } = null!;

        [ForeignKey(nameof(ParticipantId))]
        public virtual IdentityUser Participant { get; set; } = null!;        
    }
}
