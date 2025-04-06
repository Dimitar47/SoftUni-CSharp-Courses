using EF8Demo.Models;
using Infrastructure.Data;
using Infrastructure.Data.Common;
using Infrastructure.Data.Models;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Npgsql;

#region Settings

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddUserSecrets<Program>()
    .Build();

NpgsqlDataSourceBuilder dataSourceBuilder = 
    new NpgsqlDataSourceBuilder(configuration.GetConnectionString("DefaultConnection"));
   
dataSourceBuilder.UseNodaTime();

NpgsqlDataSource dataSource = dataSourceBuilder.Build();

IServiceProvider serviceProvider = new ServiceCollection()
    .AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(
                    dataSource,
                    o =>
                    {
                        o.MigrationsAssembly("Infrastructure");
                        o.UseNodaTime();
                    })
                .UseSnakeCaseNamingConvention()
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .EnableSensitiveDataLogging())
    .AddScoped<IRepository, Repository>()
    .BuildServiceProvider();

# endregion

IRepository repo;

using (var scope = serviceProvider.CreateScope())
{
    repo = scope.ServiceProvider.GetRequiredService<IRepository>();

    // ComplexType demo
    // await AddPersonAsync();

    // PrimitiveCollections demo
    // await FilterByCollectionValue();

    // Json Columns demo
    //await AddEmployeesWithJsonColumnAsync();
     //await GetEmployeesFromOffice1Async();

    // Stored Procedures demo (SQLQuery)
    //await GetEmployeesByOfficeAsync("Офис 1");
    //await TestSQLQuery();

    // Default values demo
    //await AddDefaultValuesAsync();

    // ExecuteDelete and ExecuteUpdate demo
    //await DeleteBooksOldWayAsync();
    //await UpdateAndDeleteBooksAsync();

    // DeleteAsNoTracking demo
    //await DeleteFilmsAsync();
    //await DeleteBooksAsync();
    //await GetAllFilms();
    //await GetAllFilmsWithDeleted();
}



async Task AddPersonAsync()
{
    var address = new Address()
    {
        Line1 = "123 Витоша",
        Line2 = null,
        City = "София",
        Country = "България",
        PostCode = "1000"
    };

    var person = new Person()
    {
        Name = "Иван Иванов",
        PermanentAddress = address,
        CurrentAddress = address
    };

    await repo.AddAsync(person);
    await repo.SaveChangesAsync();
}

async Task FilterByCollectionValue()
{
    int number = 1;
    string text = "one";

    var coll = await repo.AllReadonly<PrimitiveCollection>()
        .Where(pc => pc.Ints.Contains(number))
        .Where(pc => pc.Strings.Any(s => s == text))
        .ToListAsync();

    // The same as above but with literals
    var coll1 = await repo.AllReadonly<PrimitiveCollection>()
        .Where(pc => pc.Ints.Contains(1))
        .Where(pc => pc.Strings.Any(s => s == "one"))
        .ToListAsync();

    await Console.Out.WriteLineAsync(coll.ToJson());
}

async Task AddEmployeesWithJsonColumnAsync()
{
    var employees = new List<Employee>()
    {
        new Employee()
        {
            Name = "Иван Иванов",
            Email = "i.ivanov@comapny.com",
            Workplace = new Workplace()
            {
                Office = "Офис 1",
                Address = "Адрес 1",
                City = "София",
                Floor =7,
                RoomNumber = 709,
                Phones = new[] { "0888 888 887", "0888 888 889" }
            }
        },
        new Employee()
        {
            Name = "Петър Петров",
            Email = "p.petrov@comapny.com",
            Workplace = new Workplace()
            {
                Office = "Офис 2",
                Address = "Адрес 1",
                City = "София",
                Floor = 2,
                RoomNumber = 250,
                Phones = new[] { "0888 888 886", "0888 888 885" }
            }
        }
    };

    await repo.AddRangeAsync(employees);
    await repo.SaveChangesAsync();
}

async Task GetEmployeesFromOffice1Async()
{
    string office = "Офис 1";
    string phone = "0888 888 887";

    var employees = await repo.AllReadonly<Employee>()
        .Where(e => e.Workplace.Office == office)
        .TagWith("Filter only on property")
        .ToListAsync();

    employees = await repo.AllReadonly<Employee>()
        .Where(e => e.Workplace.Office == office)
        .Where(e => e.Workplace.Phones.Contains(phone))
        .TagWith("Filter on property and collection")
        .ToListAsync();

    await Console.Out.WriteLineAsync(employees.ToJson());
}

async Task GetEmployeesByOfficeAsync(string officeName)
{
    var employees = await repo
        .ExecuteProc<EmployeeModel>(ProcedureType.GetEmployeesByOffice, officeName);

    await Console.Out.WriteLineAsync(employees.ToJson());
}

async Task TestSQLQuery()
{
    string officeName = "Офис 1";

    FormattableString query = $"""
        SELECT
        	e."name",
        	e.email,
        	(e.workplace->'RoomNumber')::int4 as room_number
        FROM
        	employees AS e 
        WHERE
        	e.workplace->>'Office' = {officeName};
        """;

    officeName = "'' OR 1=1 --";

    FormattableString queryInjection = $"""
        SELECT
        	e."name",
        	e.email,
        	(e.workplace->'RoomNumber')::int4 as room_number
        FROM
        	employees AS e 
        WHERE
        	e.workplace->>'Office' = {officeName};
        """;

    string strQuery = $"""
        SELECT
        	e."name",
        	e.email,
        	(e.workplace->'RoomNumber')::int4 as room_number
        FROM
        	employees AS e 
        WHERE
        	e.workplace->>'Office' = {officeName};
        """;

    var employees = await repo.
        ExecuteSQL<EmployeeModel>(query)
        .TagWith("SQLQuery - no injection")
        .ToListAsync();

    await Console.Out.WriteLineAsync($"-- SQLQuery - no injection result \n{employees.ToJson()}");

    var employeesInjection = await repo.
        ExecuteSQL<EmployeeModel>(queryInjection)
        .TagWith("SQLQuery - with injection")
        .ToListAsync();

    await Console.Out.WriteLineAsync($"-- SQLQuery - with injection result \n{employeesInjection.ToJson()}");

    var employeesRaw = await repo.
        ExecuteRawSQL<EmployeeModel>(strQuery)
        .TagWith("Raw SQLQuery - with injection")
        .ToListAsync();
    
    await Console.Out.WriteLineAsync($"-- SQLQueryRaw - with injection result \n{employeesRaw.ToJson()}");
}

async Task AddDefaultValuesAsync()
{
    List<DefaultValue> defaultValues = new List<DefaultValue>()
    {
        new DefaultValue()
        {
            CreditsWithoutSentinel = 5,
            CreditsWithSentinel = 5,
            IsActiveDefaultFalse = false,
            IsActiveDefaultTrue = false
        },
        new DefaultValue()
        {
            CreditsWithoutSentinel = 0,
            CreditsWithSentinel = 0,
            IsActiveDefaultFalse = true,
            IsActiveDefaultTrue = true
        },
        new DefaultValue()
        {
            CreditsWithoutSentinel = -1,
            CreditsWithSentinel = -1,
            IsActiveDefaultFalse = false,
            IsActiveDefaultTrue = true
        },
        new DefaultValue()
    };

    await repo.AddRangeAsync(defaultValues);
    await repo.SaveChangesAsync();
}

async Task SeedBooks()
{
    List<Book> books = new List<Book>();

    for (int i = 0; i < 100; i++)
    {
        books.Add(new Book()
        {
            Title = $"Book {i}",
            Author = $"Author {i}",
            YearPublished = 2000 + i
        });
    }

    await repo.AddRangeAsync(books);
    await repo.SaveChangesAsync();
}

async Task DeleteBooksOldWayAsync()
{
    await SeedBooks();

    var books = await repo.All<Book>()
        .Where(b => b.YearPublished > 2020)
        .ToListAsync();

    foreach (var book in books)
    {
        await repo.DeleteAsync<Book>(book.Id);
    }

    await repo.SaveChangesAsync();
}

async Task UpdateAndDeleteBooksAsync()
{
    await SeedBooks();

    await repo.AllReadonly<Book>()
        .Where(b => b.YearPublished < 2020)
        .ExecuteUpdateAsync(s => s.SetProperty(b => b.YearPublished, o => o.YearPublished + 20));

    await repo.AllReadonly<Book>()
        .Where(b => b.YearPublished >= 2020)
        .ExecuteDeleteAsync();
}

async Task DeleteFilmsAsync()
{
    await repo.DeleteAsNoTrackingAsync<Film>(f => f.Year < 2000);
}

async Task DeleteBooksAsync()
{
    await SeedBooks();
    await repo.DeleteAsNoTrackingAsync<Book>(b => b.YearPublished > 2000);
}

async Task GetAllFilms()
{
    var films = await repo.AllReadonly<Film>().ToListAsync();
    await Console.Out.WriteLineAsync(films.ToJson());
}

async Task GetAllFilmsWithDeleted()
{
    var films = await repo.All<Film>()
        .IgnoreQueryFilters()
        .ToListAsync();
    
    await Console.Out.WriteLineAsync(films.ToJson());
}