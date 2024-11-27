using EFWelcomeApp;

using (MyAppContext context = new())
{
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();

    var companies = new List<Company>()
    {
        new(){ Title = "Yandex" },
        new(){ Title = "Mail" },
        new(){ Title = "Ozon" },
    };

    var employees = new List<Employee>()
    {
        new(){ Name = "Bobby", Age = 32, Company = companies[0] },
        new(){ Name = "Sammy", Age = 21, Company = companies[1] },
        new(){ Name = "Jimmy", Age = 29, Company = companies[1] },
        new(){ Name = "Tommy", Age = 37, Company = companies[0] },
        new(){ Name = "Rikky", Age = 41, Company = companies[2] },
        new(){ Name = "Lenny", Age = 19, Company = companies[2] },
    };

    context.Employees.AddRange(employees);
    context.Companies.AddRange(companies);

    context.SaveChanges();
}