using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TaskManagement.Interfaces;
using TaskManagement.Model;
using TaskManagement.dto;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            var userDTOs = _mapper.Map<IEnumerable<UserDto>>(users);
            return Ok(userDTOs);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUser(id);
            if (user == null)
                return NotFound();

            var userDTO = _mapper.Map<UserDto>(user);
            return Ok(userDTO);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserDto userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userEntity = _mapper.Map<User>(userDTO);
            var createdUser = _userRepository.CreateUser(userEntity);
            if (!createdUser)
                return StatusCode(500, "An error occurred while creating the user.");

            var createdUserDTO = _mapper.Map<UserDto>(userEntity);
            return CreatedAtAction(nameof(GetUser), new { id = createdUserDTO.UserID }, createdUserDTO);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserDto userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userEntity = _mapper.Map<User>(userDTO);
            userEntity.UserID = id; // Ensure the correct ID is set for the user
            var updatedUser = _userRepository.UpdateUser(userEntity);
            if (!updatedUser)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var deleted = _userRepository.DeleteUser(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }

    }
}
