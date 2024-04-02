using TaskManagement.Interfaces;

namespace TaskManagement.Repository
{
    public class TaskRepository : ITaskRepository
    {
        public bool CreateTask(Task task)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTask(Task task)
        {
            throw new NotImplementedException();
        }

        public Task GetTask(int TaskID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Task> GetTasks()
        {
            throw new NotImplementedException();
        }

        public bool save()
        {
            throw new NotImplementedException();
        }

        public bool taskExists(int TaskID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(Task task)
        {
            throw new NotImplementedException();
        }
    }
}
