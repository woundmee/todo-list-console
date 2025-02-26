namespace Interfaces;

interface ITaskService
{
    void Create();
    void Remove(int taskID);
    void Change(int taskID);
    void ShowAll();
    int GetCountTasks();
}
