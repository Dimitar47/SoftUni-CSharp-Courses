using Infrastructure.Data.Models;
using Infrastructure.Data.Models.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Linq.Expressions;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //smodelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            var entityTypesHasSoftDeletion = modelBuilder.Model.GetEntityTypes()
                .Where(e => e.ClrType.IsAssignableTo(typeof(ISoftDeletable)));

            foreach (var entityType in entityTypesHasSoftDeletion)
            {
                var isDeletedProperty = entityType.FindProperty(nameof(ISoftDeletable.IsActive));
                var parameter = Expression.Parameter(entityType.ClrType, "p");

                if (isDeletedProperty?.PropertyInfo != null && parameter != null)
                {
                    var filter = Expression.Lambda(Expression.Property(parameter, isDeletedProperty.PropertyInfo), parameter);
                    entityType.SetQueryFilter(filter);
                }
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<ApplicationDbContext>()
                .Build();

            NpgsqlDataSourceBuilder dataSourceBuilder =
                new NpgsqlDataSourceBuilder(configuration.GetConnectionString("DefaultConnection"));

            dataSourceBuilder.UseNodaTime();

            NpgsqlDataSource dataSource = dataSourceBuilder.Build();
            optionsBuilder.UseNpgsql(
                    dataSource,
                    o =>
                    {
                        o.MigrationsAssembly("Infrastructure");
                        o.UseNodaTime();
                    })
                .UseSnakeCaseNamingConvention()
                .EnableSensitiveDataLogging();
        }

        public DbSet<Person> People { get; set; }

        public DbSet<PrimitiveCollection> PrimitiveCollections { get; set; }

        public DbSet<DefaultValue> DefaultValues { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Prescription> Prescriptions { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<MedicalPractitioner> MedicalPractitioners { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Film> films { get; set; }
    }
}
