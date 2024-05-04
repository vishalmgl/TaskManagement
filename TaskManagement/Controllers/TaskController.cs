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
    public class TaskController : Controller
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskController(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model.Task>))]
        public IActionResult GetTasks()
        {
            var tasks = _mapper.Map<List<TaskDto>>(_taskRepository.GetTasks());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(tasks);
        }
        [HttpGet("{TaskID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Model.Task>))]
        [ProducesResponseType(400)]
        public IActionResult GetTask(int TaskID)
        {
            if (_taskRepository.TaskExists(TaskID))
                return NotFound();
            var task = _taskRepository.GetTask(TaskID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(task);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateTask([FromBody] TaskDto TaskCreate)
        {
            if (TaskCreate == null)
                return BadRequest(ModelState);
            var tasks = _taskRepository.GetTasks().Where(c => c.Title.Trim().ToUpper() == TaskCreate.Title.TrimEnd().ToUpper()).FirstOrDefault();
            if (tasks != null)
            {
                ModelState.AddModelError("", "Task Already exists");
                return StatusCode(422, ModelState);

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var TaskMaps = _mapper.Map<Model.Task>(TaskCreate);
            if (!_taskRepository.CreateTask(TaskMaps))
            {
                ModelState.AddModelError("", "somthing went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("successfully created");

        }
        [HttpPut("{TaskID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateTask(int TaskID, [FromBody] TaskDto UpdateTask)
        {
            if (UpdateTask == null)
                return BadRequest(ModelState);
            if (TaskID != UpdateTask.TaskID)
                return BadRequest(ModelState);
            if (!_taskRepository.TaskExists(TaskID))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var UpdateMap = _mapper.Map<Model.Task>(UpdateTask);
            if (!_taskRepository.UpdateTask(UpdateMap))
            {
                ModelState.AddModelError("", "somthing went wrong updating task");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{TaskID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteTask(int TaskID)
        {
            if (!_taskRepository.TaskExists(TaskID))
            {
                return NotFound();

            }
            var TaskDelete = _taskRepository.GetTask(TaskID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_taskRepository.DeleteTask(TaskDelete))
            {
                ModelState.AddModelError("", "something went wrong deleAting category");

            }
            return NoContent();

        }
    }
}