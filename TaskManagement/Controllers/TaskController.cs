using Microsoft.AspNetCore.Mvc;
using TaskManagement.dto;
using TaskManagement.Repository;
using AutoMapper;
using TaskManagement.Model;
using System.Threading.Tasks; // Import the correct namespace for System.Threading.Tasks

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase // Change ControllerBase instead of Controller
    {
        private readonly TaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TasksController(TaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var tasks = _taskRepository.GetTasks();
            var taskDTOs = _mapper.Map<IEnumerable<TaskDto>>(tasks);
            return Ok(taskDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = _taskRepository.GetTask(id);
            if (task == null)
                return NotFound();

            var taskDTO = _mapper.Map<TaskDto>(task);
            return Ok(taskDTO);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDto taskDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskEntity = _mapper.Map<Task>(taskDTO);
            var createdTask = _taskRepository.CreateTask(taskEntity);
            var createdTaskDTO = _mapper.Map<TaskDto>(createdTask);
            return CreatedAtAction(nameof(GetTask), new { id = createdTaskDTO.TaskID }, createdTaskDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskDto taskDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var task = _mapper.Map<Task>(taskDTO);
            var updatedTask = _taskRepository.UpdateTask(task);
            if (updatedTask == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var deleted = _taskRepository.DeleteTask(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
