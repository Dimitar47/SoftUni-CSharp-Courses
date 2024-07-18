using CinemaApp.Contracts;
using CinemaApp.Data;
using CinemaApp.Data.Common;
using CinemaApp.Models;
using CinemaApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", true)
    .AddUserSecrets(typeof(Program).Assembly)
    .Build();

var serviceProvider = new ServiceCollection()
    .AddLogging()
    .AddDbContext<CinemaDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("CinemaConnection")))
    .AddScoped<IRepository, Repository>()
    .AddScoped<ICinemaService, CinemaService>()
    .BuildServiceProvider();

using var scope = serviceProvider.CreateScope();
ICinemaService? service = scope.ServiceProvider.GetService<ICinemaService>();

//if (service != null)
//{
//    var cinema = new CinemaModel("Capitol", "Sofia, Car Boris III");

//    await service.AddCinemaAsync(cinema);
//}