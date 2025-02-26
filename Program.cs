
using Microsoft.Extensions.DependencyInjection;

using Interfaces;
using Services;
using Microsoft.VisualBasic;

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
        case 0:
            Console.Clear();
            myConsole.Menu();
            break;
        case 1:
            Console.Clear();
            tasks.Create();
            break;
        case 2:
            Console.Clear();
            tasks.ShowAll();
            Console.WriteLine();
            int removeTaskNumber = 0;
            if (tasks.GetCountTasks() != 0)
            {
                Console.Write("Номер задачи для удаления: ");
                removeTaskNumber = int.Parse(Console.ReadLine()!);
            }
            tasks.Remove(removeTaskNumber);
            break;
        case 3:
            Console.Clear();
            tasks.ShowAll();
            break;
        case 4:
            Console.Clear();
            tasks.Change(1);
            Console.WriteLine("Недоступно...");
            break;
        default:
            Console.WriteLine("choose from the available menu ↑");
            break;
    }
}

