using TaskManagement.Data;
using TaskManagement.Interfaces;


namespace TaskManagement.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }

        public bool AssignTaskToUser(int TaskID, int UserID)
        {
            var task = _context.Tasks.Find(TaskID);
            var user = _context.Tasks.Find(UserID);
            if (task == null || user == null)
                return false;
            var TaskAssignment=new Model.TaskAssignment ();
            TaskAssignment.TaskID = TaskID;
            TaskAssignment.UserID = UserID;
            task.AssignedUsers.Add(TaskAssignment);
            _context.SaveChanges();
            return true;
        }

        public bool CreateTask(Task task)
        {
            _context.Add(task);
            _context.SaveChanges();
            return Save();

        }

        public bool DeleteTask(Task task)
        {
            _context.Remove(task);
            return Save();
        }

        public Model.Task GetTask(int TaskID)
        {
            return _context.Tasks.Where(e=>e.TaskID==TaskID).FirstOrDefault();
        }

        public ICollection<Model.Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public bool Save()
        {
            var Saved=_context.SaveChanges();
            return Saved >0 ? true : false;
        }

        public bool UnassignTaskFromUser(int TaskID, int UserID)
        {
            throw new NotImplementedException();
        }

        public bool UpdateTask(Task task)
        {
            _context.Update(task);
            return Save();
        }
    }
}
