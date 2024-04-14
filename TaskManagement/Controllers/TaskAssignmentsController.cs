
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interfaces;
using TaskManagement.Model;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly ITaskAssignmentRepository _taskAssignmentRepository;

        public TaskAssignmentController(ITaskAssignmentRepository taskAssignmentRepository)
        {
            _taskAssignmentRepository = taskAssignmentRepository;
        }

        [HttpPost("{taskId}/assign/{userId}")]
        public IActionResult AssignTaskToUser(int taskId, int userId)
        {
            var assigned = _taskAssignmentRepository.AssignTaskToUser(taskId, userId);
            if (!assigned)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{taskId}/unassign/{userId}")]
        public IActionResult UnassignTaskFromUser(int taskId, int userId)
        {
            var unassigned = _taskAssignmentRepository.UnassignTaskFromUser(taskId, userId);
            if (!unassigned)
                return BadRequest();

            return NoContent();
        }
    }
}
