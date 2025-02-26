using Interfaces;

namespace Services;


class ConsoleService : IConsoleService
{
    const string logo = """
  _____ ___  ___   ___      _    ___ ___ _____ 
 |_   _/ _ \|   \ / _ \ ___| |  |_ _/ __|_   _|
   | || (_) | |) | (_) |___| |__ | |\__ \ | |  
   |_| \___/|___/ \___/    |____|___|___/ |_|  
                                               
""";

    public void Menu()
    {
        Console.WriteLine(logo);

        Console.WriteLine(
            "1 - new task\n" +
            "2 - remove task\n" +
            "3 - show all tasks\n" +
            "4 - change tasks\n"
        );
    }

    public void SetColor(ConsoleColor color, string text)
    {
        ConsoleColor defaultColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ForegroundColor = defaultColor;  // return default color
    }
}