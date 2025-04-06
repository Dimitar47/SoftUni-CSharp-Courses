using GameZone.Common;
using GameZone.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; }

        public string PublisherId { get; set; } = string.Empty!;

        public string Publisher { get; set; } = string.Empty;

        public string ReleasedOn { get; set; } = string.Empty;

        public string Genre { get; set; } = string.Empty;
    }
}