using TaskManagement.Model;

namespace TaskManagement.Interfaces
{
    public interface ITaskAssignmentRepository
    {
        TaskAssignment GetTaskAssignment(int TaskAssignmentId);
        IEnumerable<TaskAssignment> GetTaskAssignments();
        bool CreateTaskAssignment(TaskAssignment TaskAssignment);
        bool DeleteTaskAssignment(int TaskAssignmentId);
    }
}
