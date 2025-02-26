using Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Services;

static class RegisterServices
{
    internal static readonly string CONFIG_FILE_NAME = "tasks.json";
    internal static IServiceCollection AddServices(this IServiceCollection service)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(CONFIG_FILE_NAME)
            .Build();

        service.Configure<Dictionary<int, TasksInfo>>(builder);
        
        service.AddScoped<IConfigService, ConfigService>();
        service.AddScoped<IConsoleService, ConsoleService>();
        service.AddScoped<ITaskService, TaskService>();
        service.AddScoped<TasksInfo>();

        return service;
    }

}