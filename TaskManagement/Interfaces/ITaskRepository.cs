using System.Diagnostics.Eventing.Reader;

namespace TaskManagement.Interfaces
{
    public interface ITaskRepository
    {
        ICollection<Model.Task> GetTasks();
        Model.Task GetTask(int TaskID);
        bool CreateTask(Task task);
        bool UpdateTask(Task task);
        bool DeleteTask(Task task);
        bool Save();

        


    }
}
