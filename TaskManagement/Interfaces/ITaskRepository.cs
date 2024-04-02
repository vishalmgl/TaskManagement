using System.Diagnostics.Eventing.Reader;

namespace TaskManagement.Interfaces
{
    public interface ITaskRepository
    {
        ICollection<Task> GetTasks();
        Task GetTask(int TaskID);
        bool taskExists(int TaskID);
        bool CreateTask(Task task);
        bool UpdateTask(Task task);
        bool DeleteTask(Task task);
        bool save();

        


    }
}
