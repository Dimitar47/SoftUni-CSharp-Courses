using Microsoft.AspNetCore.Identity;

namespace CinemaWebApp.Models
{
    public class UserMovie
    {
        public string UserId { get; set; } = null!;  // Links to the user who added the movie
        public IdentityUser User { get; set; } = null!;

        public int MovieId { get; set; }  // Links to the movie the user wants to watch
        public Movie Movie { get; set; } = null!;
    }
}
