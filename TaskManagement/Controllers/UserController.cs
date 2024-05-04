using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interfaces;
using TaskManagement.Model;
using TaskManagement.dto;
using AutoMapper;
using TaskManagement.Repository;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        public IActionResult GetUsers()
        {
            var Users = _mapper.Map<List<TaskDto>>(_userRepository.GetUsers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(Users);
        }
        [HttpGet("{UserID}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<User>))]
        [ProducesResponseType(400)]
        public IActionResult GetUser(int UserID)
        {
            if (_userRepository.UsersExist(UserID))
                return NotFound();
            var User = _userRepository.GetUser(UserID);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            return Ok(User);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UserDto UserCreate)
        {
            if (UserCreate == null)
                return BadRequest(ModelState);
            var Users = _userRepository.GetUsers().Where(c => c.UserName.Trim().ToUpper() == UserCreate.Username.TrimEnd().ToUpper()).FirstOrDefault();
            if (Users != null)
            {
                ModelState.AddModelError("", "Task Already exists");
                return StatusCode(422, ModelState);

            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var UserMaps = _mapper.Map<User>(UserCreate);
            if (!_userRepository.CreateUser(UserMaps))
            {
                ModelState.AddModelError("", "somthing went wrong while saving");
                return StatusCode(500, ModelState);
            }
            return Ok("successfully created");

        }
        [HttpPut("{UserID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser(int UserID, [FromBody] UserDto UpdateUser)
        {
            if (UpdateUser == null)
                return BadRequest(ModelState);
            if (UserID != UpdateUser.UserID)
                return BadRequest(ModelState);
            if (!_userRepository.UsersExist(UserID))
                return NotFound();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var UpdateMap = _mapper.Map<User>(UpdateUser);
            if (!_userRepository.UpdateUser(UpdateMap))
            {
                ModelState.AddModelError("", "somthing went wrong updating task");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
        [HttpDelete("{UserID}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUser(int UserID)
        {
            if (!_userRepository.UsersExist(UserID))
            {
                return NotFound();

            }
            var UserDelete = _userRepository.GetUser(UserID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            if (!_userRepository.DeleteUser(UserDelete))
            {
                ModelState.AddModelError("", "something went wrong deleAting category");

            }
            return NoContent();
        }





    }
}