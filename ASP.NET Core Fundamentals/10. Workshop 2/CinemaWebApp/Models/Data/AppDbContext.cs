using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Models.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext()
        {
            
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<CinemaMovie> CinemasMovies { get; set; }

        public DbSet<UserMovie> UsersMovies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CinemaMovie>()
                .HasKey(cm => new { cm.CinemaId, cm.MovieId });

            modelBuilder.Entity<CinemaMovie>()
                .HasOne(cm => cm.Cinema)            
                .WithMany(c => c.CinemaMovies)
                .HasForeignKey(cm => cm.CinemaId);

            modelBuilder.Entity<CinemaMovie>()
                .HasOne(cm => cm.Movie)          
                .WithMany(m => m.CinemaMovies)   
                .HasForeignKey(cm => cm.MovieId);

            // Define the composite key for the UserMovie entity
            modelBuilder.Entity<UserMovie>()
                .HasKey(um => new { um.UserId, um.MovieId });

            //Configure the relationship between the UserMovie and IdentityUser entities
            modelBuilder.Entity<UserMovie>()
                .HasOne(um => um.User)
                .WithMany()
                .HasForeignKey(um => um.UserId);

            //Configure the relationship between the UserMovie and Movie entities
            modelBuilder.Entity<UserMovie>()
                .HasOne(um => um.Movie)
                .WithMany()
                .HasForeignKey(um => um.MovieId);
        }
    }
}
