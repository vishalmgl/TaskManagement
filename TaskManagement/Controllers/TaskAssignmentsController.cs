using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TaskManagement.Interfaces;
using TaskManagement.Model;
using TaskManagement.dto;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskAssignmentsController : ControllerBase
    {
        private readonly ITaskAssignmentRepository _taskAssignmentRepository;
        private readonly IMapper _mapper;

        public TaskAssignmentsController(ITaskAssignmentRepository taskAssignmentRepository, IMapper mapper)
        {
            _taskAssignmentRepository = taskAssignmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTaskAssignments()
        {
            var taskAssignments = _taskAssignmentRepository.GetTaskAssignments();
            var taskAssignmentDTOs = _mapper.Map<IEnumerable<TaskAssignmentDto>>(taskAssignments);
            return Ok(taskAssignmentDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetTaskAssignment(int id)
        {
            var taskAssignment = _taskAssignmentRepository.GetTaskAssignment(id);
            if (taskAssignment == null)
                return NotFound();

            var taskAssignmentDTO = _mapper.Map<TaskAssignmentDto>(taskAssignment);
            return Ok(taskAssignmentDTO);
        }

        [HttpPost]
        public IActionResult CreateTaskAssignment([FromBody] TaskAssignmentDto taskAssignmentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskAssignmentEntity = _mapper.Map<TaskAssignment>(taskAssignmentDTO);
            var createdTaskAssignment = _taskAssignmentRepository.CreateTaskAssignment(taskAssignmentEntity);
            var createdTaskAssignmentDTO = _mapper.Map<TaskAssignmentDto>(createdTaskAssignment);
            return CreatedAtAction(nameof(GetTaskAssignment), new { id = createdTaskAssignmentDTO.TaskAssignmentID }, createdTaskAssignmentDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTaskAssignment(int id, [FromBody] TaskAssignmentDto taskAssignmentDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var taskAssignmentEntity = _mapper.Map<TaskAssignment>(taskAssignmentDTO);
            var updatedTaskAssignment = _taskAssignmentRepository.UpdateTaskAssignment(id, taskAssignmentEntity);
            if (updatedTaskAssignment == null)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTaskAssignment(int id)
        {
            var deleted = _taskAssignmentRepository.DeleteTaskAssignment(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
