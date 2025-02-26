using Services;

namespace Interfaces;

interface IConfigService
{
    void Read();
    void Write(int lastTaskId, TasksInfo tasksInfo);
    void RemoveNode(int removeKey);
}