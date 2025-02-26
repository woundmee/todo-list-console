namespace Interfaces;

interface IConsoleService
{
    void Menu();
    // void TableFormatFromTasks(string column1, string column2);
    void SetColor(ConsoleColor color, string text);
}