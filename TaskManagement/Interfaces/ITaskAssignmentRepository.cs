using TaskManagement.Model;

namespace TaskManagement.Interfaces
{
    public interface ITaskAssignmentRepository
    {
        TaskAssignment GetTaskAssignment(int TaskAssignmentId);
        bool AssignTaskToUser(int taskId, int userId);
        bool UnassignTaskFromUser(int taskId, int userId);
        IEnumerable<TaskAssignment> GetTaskAssignments();
        bool CreateTaskAssignment(TaskAssignment TaskAssignment);
        bool DeleteTaskAssignment(int TaskAssignmentId);
    }
}
