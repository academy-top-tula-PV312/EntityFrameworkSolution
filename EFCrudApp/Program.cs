using EFWelcomeApp;

using (MyAppContext context = new())
{
    if(!context.Database.CanConnect())
    {
        Console.WriteLine("Inncorect Conntection");
        return;
    }

    bool isWork = true;
    while(isWork)
    {
        Console.WriteLine("1 - View Employees");
        Console.WriteLine("2 - Add Employee");
        Console.WriteLine("3 - Edit Employee");
        Console.WriteLine("4 - Delete Employee");
        Console.WriteLine("0 - Exit");

        int select = Int32.Parse(Console.ReadLine());

        switch (select)
        {
            case 1:
                ReadCrud(context);
                break;
            case 2:
                CreateCrud(context);
                break;
            case 3:
                UpdateCrud(context);
                break;
            case 4:
                DeleteCrud(context);
                break;
            case 0:
                isWork = false;
                break;
        }

        await context.SaveChangesAsync();
    }
    
}


// CRUD - Read / Select / Get
void ReadCrud(MyAppContext context)
{
    var employees = context.Employees;
    var companies = context.Companies;

    foreach (var employee in employees)
        Console.WriteLine(employee);
}

// CRUD - Create / Insert / Post
void CreateCrud(MyAppContext context)
{
    Console.WriteLine("Create new Employee:");

    Console.Write("Input name:");
    string name = Console.ReadLine();
    Console.Write("Input age:");
    int age = Int32.Parse(Console.ReadLine());

    foreach(var company in context.Companies)
    {
        Console.WriteLine($"Id: {company.Id}, Title: {company.Title}");
    }
    Console.Write("Input id company:");
    int id = Int32.Parse(Console.ReadLine());

    var companyFind = context.Companies.FirstOrDefault(c => c.Id == id);

    Employee employee = new() { Name = name, Age = age, Company = companyFind };

    context.Employees.Add(employee);
}

// CRUD - Update / Update / Put
void UpdateCrud(MyAppContext context)
{
    foreach(var e in context.Employees)
        Console.WriteLine($"Id: {e.Id}, Name: {e.Name}");
    Console.Write("Input id employee for edit: ");
    int id = Int32.Parse(Console.ReadLine());

    var employee = context.Employees.FirstOrDefault(e => e.Id == id);

    Console.Write($"Name <{employee.Name}>: ");
    string name = Console.ReadLine();
    if(string.IsNullOrEmpty(name))
        name = employee.Name;

    Console.Write($"Age <{employee.Age}>: ");
    string ageStr = Console.ReadLine();
    int? age;
    if (string.IsNullOrEmpty(ageStr))
        age = employee.Age;
    else
        age = Int32.Parse(ageStr);

    foreach (var c in context.Companies)
        Console.WriteLine($"Id: {c.Id}, Title: {c.Title}");

    Console.Write($"Id Company <{employee.Company.Id}>:");
    string idStr = Console.ReadLine();
    Company? company = null;
    if (string.IsNullOrEmpty(idStr))
        company = employee.Company;
    else
        company = context.Companies.FirstOrDefault(c => c.Id == Int32.Parse(idStr));

    employee.Name = name;
    employee.Age = age;
    employee.Company = company;

}

// CRUD - Delete / Delete / Delete
void DeleteCrud(MyAppContext context)
{
    foreach (var e in context.Employees)
        Console.WriteLine($"Id: {e.Id}, Name: {e.Name}");
    Console.Write("Input id employee for delete: ");
    int id = Int32.Parse(Console.ReadLine());

    var employee = context.Employees.FirstOrDefault(e => e.Id == id);
    context.Employees.Remove(employee);
}