using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManagement.Interfaces;
using TaskManagement.Model;
using TaskManagement.dto;
using AutoMapper;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository, IMapper mapper)
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

            var taskEntity = _mapper.Map<Task>(taskDTO);
            taskEntity.TaskID = id; // Ensure the correct ID is set for the task
            var updatedTask = _taskRepository.UpdateTask(taskEntity);
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
