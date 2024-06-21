using CallCenter;

IManager manager = new Manager();

for (int i = 0; i < 50; i++)
{       
    manager.AddEmployee();
}

Console.WriteLine($"Count of All Employee: {manager.CountOfAllEmployee()}");

Console.WriteLine($"Count of Free Employee: {manager.CountOfFreeEmployee()}");

manager.KillEmployee(1);

Console.WriteLine($"Count of All Employee: {manager.CountOfAllEmployee()}");

manager.AddEmployee();

for (int i = 0; i < 500000; i++)
{
    manager.AddTask($"Task {i}");
}

Thread.Sleep(1000);
Console.WriteLine($"Count of Free Employee after Tasks: {manager.CountOfFreeEmployee()}");

manager.KillEmployee();