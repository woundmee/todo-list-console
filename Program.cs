
using Microsoft.Extensions.DependencyInjection;

using Interfaces;
using Services;

Console.Clear();

var services = new ServiceCollection().AddServices();
var serviceProvider = services.BuildServiceProvider();

var config = serviceProvider.GetRequiredService<IConfigService>();
var tasks = serviceProvider.GetRequiredService<ITaskService>();
var myConsole = serviceProvider.GetRequiredService<IConsoleService>();

// config.ReadFromConfig();
// config.WriteConfig();
// tasks.Create();
// tasks.ShowAll();
// tasks.RemoveTask(1);


Console.WriteLine();


// Console.WriteLine(logo);
myConsole.Menu();

while (true)
{
    // Console.Write("choise: ");
    myConsole.SetColor(ConsoleColor.Yellow, "choise: ");

    int userSetMenu = int.Parse(Console.ReadLine()!);

    switch (userSetMenu)
    {
        case 1:
            tasks.Create();
            break;
        case 2:
            int removeTaskNumber = 0;
            if (tasks.GetCountTasks() != 0)
            {
                Console.Write("Номер задачи для удаления: ");
                removeTaskNumber = int.Parse(Console.ReadLine()!);
            }
            tasks.Remove(removeTaskNumber);
            break;
        case 3:
            tasks.ShowAll();
            break;
        case 4:
            tasks.Change(1);
            Console.WriteLine("Недоступно...");
            break;
        default:
            Console.WriteLine("choose from the available menu ↑");
            break;
    }
}

