using Microsoft.EntityFrameworkCore;
using TaskManagement.Interfaces;
using TaskManagement.Model;

namespace TaskManagement.Repository
{
    public class TaskAssignmentRepository : ITaskAssignmentRepository
    {
        private readonly DbContext _context;

        public TaskAssignmentRepository(DbContext context)
        {
            _context = context;
        }
        public bool CreateTaskAssignment(TaskAssignment TaskAssignment)
        {
            _context.TaskAssignment.Add(TaskAssignment);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteTaskAssignment(int TaskAssignmentId)
        {
            var taskAssignment = _context.TaskAssignments.Find(TaskAssignmentId);
            if (taskAssignment == null)
                return false;
            _context.TaskAssignments.Remove(taskAssignment);
            _context.SaveChanges();
            return true;
        }

        public TaskAssignment GetTaskAssignment(int TaskAssignmentId)
        {
            return _context.TaskAssignments.Find(TaskAssignmentId);
        }

        public IEnumerable<TaskAssignment> GetTaskAssignments()
        {
            return _context.TaskAssignments;
        }
    }
}
