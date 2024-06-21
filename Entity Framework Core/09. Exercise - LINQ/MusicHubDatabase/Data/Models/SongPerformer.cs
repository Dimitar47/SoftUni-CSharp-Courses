using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {


        [Required]
        public int SongId { get; set; }

        public Song Song { get; set; }


        [Required]
        public int PerformerId { get; set; }

        public Performer Performer { get; set; }


    }
}
