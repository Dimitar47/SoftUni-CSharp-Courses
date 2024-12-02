using HotelApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HotelApp.Web.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope serviceScope = app.ApplicationServices.CreateScope();

            HotelDbContext dbContext = serviceScope.ServiceProvider.GetRequiredService<HotelDbContext>()!;
          /* 
            dbContext.Database.EnsureDeleted();

            
            dbContext.Database.EnsureCreated();
          */
            dbContext.Database.Migrate();


            return app;
        }
    }
}
