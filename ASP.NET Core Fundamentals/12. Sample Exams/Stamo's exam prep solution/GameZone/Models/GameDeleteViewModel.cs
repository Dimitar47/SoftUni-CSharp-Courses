using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class GameDeleteViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Publisher { get; set; } = null!;
    }
}
