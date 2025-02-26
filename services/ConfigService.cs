using Interfaces;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace Services;

class ConfigService : IConfigService
{
    private readonly Dictionary<int, TasksInfo> _config;
    // public static readonly string CONFIGNAME = @"tasks.json";


    public ConfigService(IOptions<Dictionary<int, TasksInfo>> config)
        => _config = config.Value;


    public void Read()
    {
        foreach (var item in _config)
        {
            Console.WriteLine(item.Value.Text);
        }
    }


    // Запись в JSON
    // public void WriteToConfig(int lastTaskId, string taskName, string taskType, bool taskPriority)
    public void Write(int lastTaskId, TasksInfo tasksInfo)
    {
        _config[lastTaskId] = tasksInfo;
        JsonWriter();

    }


    // Удаление объекта из конфига
    public void RemoveNode(int removeKey)
    {
        _config.Remove(removeKey);
        JsonWriter();
    }

    public void JsonWriter()
    {
        var jsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        var json = JsonSerializer.Serialize(_config, jsonOptions);
        File.WriteAllText(RegisterServices.CONFIG_FILE_NAME, json);
    }

}


public class TasksInfo
{
    public string Text { get; set; } = "";
    public bool Priority { get; set; }
    public string TypeTask { get; set; } = "";
}