using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameZone.Data.Models
{
    public class GamerGame
    {
        public string GamerId { get; set; } = string.Empty;

        [ForeignKey(nameof(GamerId))]
        public virtual IdentityUser Gamer { get; set; } = null!;

        public int GameId { get; set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; } = null!;
    }
}
