

using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CinemaApp.Data
{
    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext()
        {
            
        }

        public CinemaDbContext(DbContextOptions options)   : base(options) { }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
