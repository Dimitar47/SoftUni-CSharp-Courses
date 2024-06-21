using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
namespace MusicHub.Data
{

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }
        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Performer> Performers { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<SongPerformer> SongsPerformers { get; set; } = null!;
        public virtual DbSet<Writer> Writers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(e => new { e.PerformerId, e.SongId });

                entity.HasOne(sp => sp.Song)
                        .WithMany(sp => sp.SongPerformers)
                        .HasForeignKey(sp => sp.SongId);

                entity.HasOne(sp => sp.Performer)
                        .WithMany(sp => sp.PerformerSongs)
                        .HasForeignKey(sp => sp.PerformerId);
            });

        }
    }
}
