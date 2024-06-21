using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {

        public StudentSystemContext()
        {

        }
        public StudentSystemContext(DbContextOptions<StudentSystemContext> options) 
            : base(options) 
        {
        
        }


        public virtual DbSet<Student> Students { get; set; } = null!; 
        public virtual DbSet<StudentCourse> StudentsCourses { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Homework> Homeworks { get; set; } = null!;
        public virtual DbSet<Resource> Resources { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {

            string connectionString = "Server=DESKTOP-H4T3O5Q;Database=StudentSystem;" +
                "Integrated security=true;TrustServerCertificate=true;";

            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.StudentId);

                entity.Property(s => s.Name).HasMaxLength(100).IsUnicode(true) ;
                entity.Property(s => s.PhoneNumber).IsRequired(false).HasMaxLength(10).IsUnicode(false);
                entity.Property(s => s.Birthday).IsRequired(false);

                
            }) ;

            modelBuilder.Entity<Course>(entity =>
            {

                entity.HasKey(c => c.CourseId);
                entity.Property(c => c.Name).HasMaxLength(80).IsUnicode(true);
                entity.Property(c => c.Description).IsUnicode(true).IsRequired(false);
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasKey(r => r.ResourceId);
                entity.Property(r => r.Name).HasMaxLength(50).IsUnicode(true);
                entity.Property(r => r.Url).IsUnicode(false);

                entity.HasOne(r => r.Course).WithMany(r => r.Resources).HasForeignKey(r => r.CourseId);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.HasKey(h => h.HomeworkId);
                entity.Property(h=> h.Content).IsUnicode(false);

                entity.HasOne(h => h.Course).WithMany(h => h.Homeworks).HasForeignKey(h => h.CourseId);

                entity.HasOne(h => h.Student).WithMany(h => h.Homeworks).HasForeignKey(h => h.StudentId);

            });

            modelBuilder.Entity<StudentCourse>(entity =>
            {
                entity.HasKey(sc => new {sc.StudentId, sc.CourseId});
             entity.HasOne(sc => sc.Student).WithMany(sc => sc.StudentsCourses)
                .HasForeignKey(sc => sc.StudentId);
                entity.HasOne(sc => sc.Course).WithMany(sc => sc.StudentsCourses)
                   .HasForeignKey(sc => sc.CourseId);


            });
        }
    }
}
