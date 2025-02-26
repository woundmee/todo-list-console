
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Interfaces;
using Microsoft.Extensions.Options;

namespace Services;

class TaskService : ITaskService
{
    private readonly Dictionary<int, TasksInfo> _config;
    private readonly IConfigService _configService;
    private readonly TasksInfo _tasksInfo;

    public TaskService(
        IOptions<Dictionary<int, TasksInfo>> config,
        IConfigService configService,
        IOptions<TasksInfo> tasksInfo
        )
    {
        _config = config.Value;
        _configService = configService;
        _tasksInfo = tasksInfo.Value;
    }

    // вернет кол-во задач в json
    public int GetCountTasks()
        => _config.Keys.Count;

    public void ShowAll()
    {
        if (GetCountTasks() == 0)
        {
            Console.WriteLine("0 tasks: create task");
        }
        else
        {
            foreach (var item in _config)
            {
                string priorityFlag = item.Value.Priority == true ? "🚩" : "  ";
                Console.WriteLine(
                    priorityFlag +
                    $" [{item.Key}]: " +
                    $"{item.Value.Text} ({item.Value.TypeTask})"
                );
            }
        }
    }

    public void Create()
    {
        int lastTaskId = _config.Keys.Count > 0 ? _config.Keys.Max() + 1 : 1;

        while (true)
        {
            Console.Write("new task: ");
            string taskName = Console.ReadLine()!;

            if (string.IsNullOrWhiteSpace(taskName)) break;

            Console.Write("category: ");
            string taskType = Console.ReadLine()!;

            Console.Write("priority: ");
            bool taskPriority = bool.Parse(Console.ReadLine()!);

            var newTask = new TasksInfo()
            {
                Text = taskName,
                TypeTask = taskType,
                Priority = taskPriority
            };

            _configService.Write(lastTaskId, newTask);
            lastTaskId++;
        }
    }


    public void Change(int taskID)
    {
        throw new NotImplementedException();
    }


    public void Remove(int taskID)
    {
        if (GetCountTasks() == 0)
        {
            Console.WriteLine("not tasks to delete...");
        }
        else
        {
            var removeKey = _config.Keys.Where(x => x == taskID).ToList();
            foreach (var key in removeKey)
            {
                _config.Remove(key);
                _configService.RemoveNode(key);
            }

        }


    }


    // internal void TaskControl() { }
}