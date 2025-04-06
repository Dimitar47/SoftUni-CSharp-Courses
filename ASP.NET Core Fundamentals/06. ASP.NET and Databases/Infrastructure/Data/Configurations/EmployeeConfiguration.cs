using Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.OwnsOne(e => e.Workplace, wp =>
            {
                wp.ToJson("workplace");
            });

            // HasData is not supported for entities mapped to JSON.
            //builder.HasData(
            //    new Employee()
            //    {
            //        Id = 1,
            //        Name = "John Doe",
            //        Email = "j.doe@company.com",
            //        Workplace = new Workplace()
            //        { 
            //            Office = "Central Office", 
            //            Address = "Panajot Volov 2", 
            //            City = "Sofia", 
            //            Floor = 7, 
            //            RoomNumber = 709 
            //        }
            //    });
        }
    }
}
