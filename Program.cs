using MiniORM.app.Entities;

var connectionString = "Server=DESKTOP-P55A8PQ\\SQLEXPRESS;Database=MiniORM;Integrated Security = True;Encrypt=False;";

var softUniContext = new SoftUniDbContext(connectionString);

var employees = softUniContext.Employees.FirstOrDefault();

Console.WriteLine(employees.FirstName);